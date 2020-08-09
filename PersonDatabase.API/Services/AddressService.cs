using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Data.Repositories;
using PersonDatabase.API.Models;
using PersonDatabase.API.Repositories;
using PersonDatabase.API.Services.Communication;

namespace PersonDatabase.API.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IAddressRepository addressRepository, IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _addressRepository = addressRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Address>> ListAsync(int personId)
        {
            return await _addressRepository.ListAsync(personId);
        }
        public async Task<Address> GetAsync(int id)
        {
            return await _addressRepository.GetAsync(id);
        }
        public async Task<AddressResponse> SaveAsync(int personId, IEnumerable<Address> addresses)
        {
            var person = await _personRepository.GetAsync(personId);

            if (person == null)
                return new AddressResponse("Person not found.");

            try
            {
                await _addressRepository.AddAsync(person, addresses);
                await _unitOfWork.CompleteAsync();

                return new AddressResponse(addresses);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"An error occurred when saving the address: {ex.Message}");
            }
        }

        public async Task<AddressResponse> UpdateAsync(int id, Address address)
        {
            var existingAddress = await _addressRepository.GetAsync(id);

            if (existingAddress == null)
                return new AddressResponse("Address not found.");

            existingAddress.Street = address.Street;
            existingAddress.City = address.City;
            existingAddress.State = address.State;
            existingAddress.PostalCode = address.PostalCode;

            try
            {
                _addressRepository.Update(existingAddress);
                await _unitOfWork.CompleteAsync();

                return new AddressResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"An error occurred when updating the address: {ex.Message}");
            }
        }

        public async Task<AddressResponse> DeleteAsync(int id)
        {
            var existingAddress = await _addressRepository.FindByIdAsync(id);

            if (existingAddress == null)
                return new AddressResponse("Address not found.");

            try
            {
                _addressRepository.Remove(existingAddress);
                await _unitOfWork.CompleteAsync();

                return new AddressResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"An error occurred when deleting the address: {ex.Message}");
            }
        }
    }
}