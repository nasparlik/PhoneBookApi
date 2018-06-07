using System.Threading.Tasks;

namespace PhoneBookApi.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}