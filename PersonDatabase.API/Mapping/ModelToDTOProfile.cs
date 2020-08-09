using AutoMapper;
using PersonDatabase.API.DTOs;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Mapping
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Person, PersonToReturnDTO>();
            CreateMap<Address, AddressToReturnDTO>();
        }
    }
}