using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> ListAsync();
    }
}