using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDatabase.API.DTOs;
using PersonDatabase.API.Services;
using PersonDatabase.API.Extensions;
using PersonDatabase.API.Models;
using System;

namespace PersonDatabase.API.Controllers
{
    [Route("/api/persons/{personId}/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressesController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AddressToReturnDTO>> ListAsync(int personId)
        {
            var addresses = await _addressService.ListAsync(personId);
            var addressesToReturn = _mapper.Map<IEnumerable<AddressToReturnDTO>>(addresses);

            return addressesToReturn;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var address = await _addressService.GetAsync(id);
            var addressToReturn = _mapper.Map<AddressToReturnDTO>(address);

            return Ok(addressToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] IEnumerable<AddressForCreationDTO> addressesForCreationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var addresses = _mapper.Map<IEnumerable<Address>>(addressesForCreationDTO);
            var personId = Convert.ToInt32(RouteData.Values["personId"]);
            var result = await _addressService.SaveAsync(personId, addresses);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressesToReturn = _mapper.Map<IEnumerable<AddressToReturnDTO>>(result.Addresses);

            return Ok(addressesToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AddressForCreationDTO addressToUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var address = _mapper.Map<Address>(addressToUpdateDTO);
            var result = await _addressService.UpdateAsync(id, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressToReturn = _mapper.Map<AddressToReturnDTO>(result.Address);

            return Ok(addressToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _addressService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressToReturn = _mapper.Map<AddressToReturnDTO>(result.Address);

            return Ok(addressToReturn);
        }
    }
}