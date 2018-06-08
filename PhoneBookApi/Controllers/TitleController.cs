using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Controllers.Resources;
using PhoneBookApi.Core;
using PhoneBookApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Controllers
{
    [Route("api/titles")]
    public class TitleController : Controller
    {
        private readonly IPhoneBookRepository repository;
        private readonly IMapper mapper;

        public TitleController(IPhoneBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<TitleResource>> Get()
        {
            var titles = await repository.GetTitlesAsync();

            return mapper.Map<IEnumerable<Title>, IEnumerable<TitleResource>>(titles);
        }

    }
}
