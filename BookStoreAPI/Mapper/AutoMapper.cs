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

            CreateMap<Authors, CreateAuthorDTO>().ReverseMap();

            CreateMap<Authors, UpdateAuthorDTO>().ReverseMap();

            
            CreateMap<Books, BooksDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Authors != null ? src.Authors.Name : null));

            CreateMap<Books, CreateBooksDTO>().ReverseMap();

            CreateMap<Books, UpdateBooksDTO>().ReverseMap();
        }
    }
}
