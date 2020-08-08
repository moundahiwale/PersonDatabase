using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonDatabase.API.Data.Contexts;
using PersonDatabase.API.Data.Repositories;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _context.Persons.Include(p => p.Addresses).ToListAsync();
        }
    }
}