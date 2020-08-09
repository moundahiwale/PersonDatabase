using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDatabase.API.DTOs;
using PersonDatabase.API.Services;

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
    }
}