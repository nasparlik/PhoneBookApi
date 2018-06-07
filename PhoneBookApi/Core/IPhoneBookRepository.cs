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

        void Add(Record phoneBook);

        void Update(Record phoneBook);

        void Remove(int id);
    }
}
