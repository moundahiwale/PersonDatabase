using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> ListAsync();
        Task AddAsync(Person person);
        Task<Person> FindByIdAsync(int id);
        void Update(Person category);
    }
}