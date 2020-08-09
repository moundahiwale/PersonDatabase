using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Data.Repositories;
using PersonDatabase.API.Models;
using PersonDatabase.API.Repositories;
using PersonDatabase.API.Services.Communication;

namespace PersonDatabase.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _personRepository.ListAsync();
        }

        public async Task<Person> GetAsync(int id)
        {
            return await _personRepository.GetAsync(id);
        }

        public async Task<PersonResponse> SaveAsync(Person person)
        {
            try
            {
                await _personRepository.AddAsync(person);
                await _unitOfWork.CompleteAsync();

                return new PersonResponse(person);
            }
            catch (Exception ex)
            {
                // Can also log this to a provider of choice, e.g. Azure Application Insights
                return new PersonResponse($"An error occurred when saving the person: {ex.Message}");
            }
        }

        public async Task<PersonResponse> UpdateAsync(int id, Person person)
        {
            var existingPerson = await _personRepository.FindByIdAsync(id);

            if (existingPerson == null)
                return new PersonResponse("Person not found.");

            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;

            try
            {
                _personRepository.Update(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PersonResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PersonResponse($"An error occurred when updating the person: {ex.Message}");
            }
        }

        public async Task<PersonResponse> DeleteAsync(int id)
        {
            var existingPerson = await _personRepository.FindByIdAsync(id);

            if (existingPerson == null)
                return new PersonResponse("Person not found.");

            try
            {
                _personRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PersonResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PersonResponse($"An error occurred when deleting the person: {ex.Message}");
            }
        }
    }
}