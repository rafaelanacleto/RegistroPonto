using System.Linq;
using AutoMapper;
using PontoEletronico.API.Dtos;
using PontoEletronico.Domain;
using PontoEletronico.Domain.Identity;

namespace PontoEletronico.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PontoRegistro, PontoRegistroDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            
        }                

    }
}