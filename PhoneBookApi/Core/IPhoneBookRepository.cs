using PhoneBookApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Core
{
    public interface IPhoneBookRepository
    {
        Task<IEnumerable<Record>> GetPhoneBookRecordsAsync();

        void Add(Record record);

        void Update(Record record);

        void Remove(int id);
    }
}
