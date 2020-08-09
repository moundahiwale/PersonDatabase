using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDatabase.API.Dtos;
using PersonDatabase.API.Services;

namespace PersonDatabase.API.Controllers
{
    [Route("/api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonToReturnDTO>> GetAllAsync()
        {
            var persons = await _personService.ListAsync();
            var personsToReturn = _mapper.Map<IEnumerable<PersonToReturnDTO>>(persons);

            return personsToReturn;
        }
    }
}