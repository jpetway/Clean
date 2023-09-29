using AutoMapper;
using Clean.Application.DTOs;
using Clean.Domain.Entities;

namespace Clean.API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonEntity, PersonDto>();
        CreateMap<PersonDto, PersonEntity>();
    }
}
