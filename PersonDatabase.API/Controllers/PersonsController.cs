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
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonsController(IPersonService personService, IMapper mapper)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var person = await _personService.GetAsync(id);
            var personToReturn = _mapper.Map<PersonToReturnWithAddressDTO>(person);

            return Ok(personToReturn);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] PersonForCreationDTO personToUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var person = _mapper.Map<Person>(personToUpdateDTO);
            var result = await _personService.UpdateAsync(id, person);

            if (!result.Success)
                return BadRequest(result.Message);

            var personToReturn = _mapper.Map<PersonToReturnDTO>(result.Person);

            return Ok(personToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _personService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personToReturn = _mapper.Map<PersonToReturnDTO>(result.Person);

            return Ok(personToReturn);
        }
    }
}