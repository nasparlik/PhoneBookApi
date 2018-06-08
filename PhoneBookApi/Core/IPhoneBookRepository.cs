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

        Task<Record> GetRecord(int id);

        void Add(Record record);

        void Remove(Record record);

        Task<IEnumerable<Title>> GetTitlesAsync();
    }
}
