using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> ListAsync(int personId);
    }
}