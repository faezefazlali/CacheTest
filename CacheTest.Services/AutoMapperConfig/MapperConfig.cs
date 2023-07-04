using AutoMapper;
using CacheTest.Common.DTOs.Common;
using CacheTest.Domain.Common;


namespace CacheTest.Services.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<BookDTO, Book>().ReverseMap();

        }
    }
}
