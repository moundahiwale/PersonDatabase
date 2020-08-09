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

        public async Task<SavePersonResponse> SaveAsync(Person person)
        {
            try
            {
                await _personRepository.AddAsync(person);
                await _unitOfWork.CompleteAsync();

                return new SavePersonResponse(person);
            }
            catch (Exception ex)
            {
                // Can also log this to a provider of choice, e.g. Azure Application Insights
                return new SavePersonResponse($"An error occurred when saving the person: {ex.Message}");
            }
        }
    }
}