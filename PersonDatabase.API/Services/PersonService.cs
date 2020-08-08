using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;
using PersonDatabase.API.Repositories;

namespace PersonDatabase.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        
        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _personRepository.ListAsync();
        }
    }
}