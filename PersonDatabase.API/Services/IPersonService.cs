using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;
using PersonDatabase.API.Services.Communication;

namespace PersonDatabase.API.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> ListAsync();
        Task<Person> GetAsync(int id);
        Task<PersonResponse> SaveAsync(Person person);
        Task<PersonResponse> UpdateAsync(int id, Person person);
        Task<PersonResponse> DeleteAsync(int id);
    }
}