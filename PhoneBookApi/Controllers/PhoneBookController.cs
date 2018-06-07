using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Controllers.Resources;
using PhoneBookApi.Core;
using PhoneBookApi.Core.Models;

namespace PhoneBookApi.Controllers
{
    [Route("api/phonebook")]
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookRepository repository;
        private readonly IMapper mapper;

        public PhoneBookController(IPhoneBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<RecordResource>> Get()
        {
            var records = await repository.GetPhoneBookRecordsAsync();

            return mapper.Map<IEnumerable<Record>, IEnumerable<RecordResource>>(records);
        }

      
    }
}
