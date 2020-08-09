using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;
using PersonDatabase.API.Services.Communication;

namespace PersonDatabase.API.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> ListAsync();
        Task<SavePersonResponse> SaveAsync(Person person);
    }
}