﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Controllers.Resources
{
    public class SaveRecordResource
    {
        public int Id { get; set; }

        public int TitleId { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
