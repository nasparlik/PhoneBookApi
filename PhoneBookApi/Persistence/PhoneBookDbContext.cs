using Microsoft.EntityFrameworkCore;
using PhoneBookApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Persistence
{
    public class PhoneBookDbContext : DbContext
    {
        public DbSet<Record> Record { get; set; }

        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options) { }

    }
}
