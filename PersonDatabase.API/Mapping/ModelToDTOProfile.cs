using AutoMapper;
using PersonDatabase.API.Dtos;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Mapping
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile() => CreateMap<Person, PersonToReturnDTO>();
    }
}