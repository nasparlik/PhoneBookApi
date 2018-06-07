using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Core;
using PhoneBookApi.Core.Models;

namespace PhoneBookApi.Controllers
{
    [Route("api/phonebook")]
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookRepository repository;

        public PhoneBookController(IPhoneBookRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Record>> Get()
        {
            return await repository.GetPhoneBookRecordsAsync();
        }

      
    }
}
