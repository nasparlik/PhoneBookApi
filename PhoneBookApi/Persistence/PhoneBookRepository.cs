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

        public void Add(Record phoneBook)
        {
            throw new NotImplementedException();
        }

       

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Record phoneBook)
        {
            throw new NotImplementedException();
        }
    }
}
