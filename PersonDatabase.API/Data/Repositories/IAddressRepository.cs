using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Data.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> ListAsync(int personId);
        Task<Address> GetAsync(int id);
        Task AddAsync(Person person, IEnumerable<Address> address);
        Task<Address> FindByIdAsync(int id);
        void Update(Address address);
        void Remove(Address address);
    }
}