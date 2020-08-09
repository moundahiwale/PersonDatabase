using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonDatabase.API.Data.Contexts;
using PersonDatabase.API.Data.Repositories;
using PersonDatabase.API.Models;
using PersonDatabase.API.Repositories;

namespace PersonDatabase.API.Data.Repositories
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        private readonly IPersonRepository _personRepository;
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Address>> ListAsync(int personId)
        {
            return await _context.Addresses.Where(a => a.PersonId == personId).Include(a => a.Person).ToListAsync();
        }
        public async Task<Address> GetAsync(int id)
        {
            return await _context.Addresses.Include(p => p.Person).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAsync(Person person, IEnumerable<Address> addresses)
        {
            foreach (var address in addresses)
            {
                address.Person = person;
            }
            await _context.Addresses.AddRangeAsync(addresses);
        }

        public async Task<Address> FindByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public void Update(Address address)
        {
            _context.Addresses.Update(address);
        }

        public void Remove(Address address)
        {
            _context.Addresses.Remove(address);
        }
    }
}