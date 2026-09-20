using AutoMapper;
using BookStoreAPI.Models.Domains;
using BookStoreAPI.Models.DTO;

namespace BookStoreAPI.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Authors, AuthorsDTO>().ReverseMap();
        }
    }
}
