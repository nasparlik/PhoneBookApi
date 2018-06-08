using Microsoft.EntityFrameworkCore;
using PhoneBookApi.Core;
using PhoneBookApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Persistence
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookDbContext context;

        public PhoneBookRepository(PhoneBookDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Record>> GetPhoneBookRecordsAsync()
        {
           return await context.Record
                .Include(t => t.Title).ToListAsync();
        }

        public async Task<Record> GetRecord(int id)
        {
            return await context.Record
                            .Include(t => t.Title)
                      .SingleOrDefaultAsync(re => re.Id == id);
        }

        public void Add(Record record)
        {
            context.Record.Add(record);
        }

        public void Remove(Record record)
        {
            context.Remove(record);
        }
       
    }
}
