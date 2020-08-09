using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Data.Repositories;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> ListAsync(int personId)
        {
            return await _addressRepository.ListAsync(personId);
        }
    }
}