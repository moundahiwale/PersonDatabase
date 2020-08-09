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
            return await _context.Persons.ToListAsync();
        }
        public async Task<Person> GetAsync(int id)
        {
            return await _context.Persons.Include(p => p.Addresses).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
        }

        public async Task<Person> FindByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
        }

        public void Remove(Person person)
        {
            _context.Persons.Remove(person);
        }
    }
}