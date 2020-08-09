using AutoMapper;
using PersonDatabase.API.DTOs;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Mapping
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile() => CreateMap<PersonForCreationDTO, Person>();
    }
}