using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonDatabase.API.Data.Contexts;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Data.Repositories
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Address>> ListAsync(int personId)
        {
            return await _context.Addresses.Where(a => a.PersonId == personId).Include(a => a.Person).ToListAsync();
        }
    }
}