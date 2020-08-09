using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDatabase.API.DTOs;
using PersonDatabase.API.Extensions;
using PersonDatabase.API.Models;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonForCreationDTO personForCreationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var person = _mapper.Map<Person>(personForCreationDTO);
            var result = await _personService.SaveAsync(person);

            if (!result.Success)
                return BadRequest(result.Message);

            var personToReturn = _mapper.Map<PersonToReturnDTO>(result.Person);

            return Ok(personToReturn);
        }
    }
}