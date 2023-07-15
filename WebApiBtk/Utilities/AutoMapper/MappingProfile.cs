using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace WebApiBtk.Utilities.AutoMapper
{
    public class MappingProfile:Profile//mapleme için
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate,Book>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookDtoForInsertion>().ReverseMap();
        }
    }
}
