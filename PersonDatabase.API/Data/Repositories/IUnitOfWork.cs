using System.Threading.Tasks;

namespace PersonDatabase.API.Data.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}