using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhoneBookDbContext context;

        public UnitOfWork(PhoneBookDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
