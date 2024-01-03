using Application.DTO;
using AutoMapper;
using Domain.Models;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<string, IEnumerable<UserDto>>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserRolle, UserRolleDto>().ReverseMap();
        CreateMap<Rolle, RollesDto>().ReverseMap();
    }
}
