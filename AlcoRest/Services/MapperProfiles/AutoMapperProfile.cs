using AlcoRest.Data.Models;
using AlcoRest.Services.Dtos;
using AutoMapper;

namespace AlcoRest.Services.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
