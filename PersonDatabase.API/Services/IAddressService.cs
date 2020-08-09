using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;
using PersonDatabase.API.Services.Communication;

namespace PersonDatabase.API.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> ListAsync(int personId);
        Task<Address> GetAsync(int id);
        Task<AddressResponse> SaveAsync(int personId, IEnumerable<Address> addresses);
        Task<AddressResponse> UpdateAsync(int id, Address address);
        Task<AddressResponse> DeleteAsync(int id);
    }
}