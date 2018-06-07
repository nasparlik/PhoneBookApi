﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public async Task<IActionResult> CreateRecord([FromBody] SaveRecordResource recordResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var record = mapper.Map<SaveRecordResource, Record>(recordResource);
            record.LastUpdate = DateTime.Now;

            repository.Add(record);

            await unitOfWork.CompleteAsync();
            
            return Ok();
        }
    }
}
