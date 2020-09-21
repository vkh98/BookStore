using AutoMapper;
using BookStore.Core.DTOs;
using BookStore.Core.Entities;

namespace BookStore.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BooksDto>();
            CreateMap<Category, CategoryDto>();

        }
    }
}
