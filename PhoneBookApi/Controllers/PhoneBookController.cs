using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Controllers.Resources;
using PhoneBookApi.Core;
using PhoneBookApi.Core.Models;
using PhoneBookApi.Persistence;

namespace PhoneBookApi.Controllers
{
    [Route("api/phonebook")]
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PhoneBookController(IPhoneBookRepository repository, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<RecordResource>> Get()
        {
            var records = await repository.GetPhoneBookRecordsAsync();

            return mapper.Map<IEnumerable<Record>, IEnumerable<RecordResource>>(records);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRecord([FromBody] SaveRecordResource saveRecordResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var record = mapper.Map<SaveRecordResource, Record>(saveRecordResource);
            record.LastUpdate = DateTime.Now;

            repository.Add(record);

            await unitOfWork.CompleteAsync();
            
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRecord(int id, [FromBody] SaveRecordResource saveRecordResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var record = await repository.GetRecord(id);

            if (record == null)
                return NotFound();

             mapper.Map<SaveRecordResource, Record>(saveRecordResource, record);
            record.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            record = await repository.GetRecord(record.Id);
            var result = mapper.Map<Record, RecordResource>(record);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var record = await repository.GetRecord(id);

            if (record == null)
                return NotFound();

            repository.Remove(record);

            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecord(int id)
        {
            var record = await repository.GetRecord(id);

            if (record == null)
                return NotFound();

            var recordResource = mapper.Map<Record, RecordResource>(record);

            return Ok(recordResource);
        }
    }
}
