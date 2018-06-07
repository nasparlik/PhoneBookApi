using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Core.Models
{

    [Table("Records")]
    public class Record
    {
        public int Id { get; set; }

        [Required]
        public Title Title { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime LastUpdate { get; set; }

    }
}
