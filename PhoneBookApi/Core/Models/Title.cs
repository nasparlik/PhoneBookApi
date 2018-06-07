using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Core.Models
{
    [Table("Records")]
    public class Title
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
