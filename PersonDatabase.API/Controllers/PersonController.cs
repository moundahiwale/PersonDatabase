using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonDatabase.API.Models;
using PersonDatabase.API.Services;

namespace PersonDatabase.API.Controllers
{
    [Route("/api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var persons = await _personService.ListAsync();
            return persons;
        }
    }
}