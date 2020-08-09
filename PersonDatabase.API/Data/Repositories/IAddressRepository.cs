using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Data.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> ListAsync(int personId);
    }
}