using AutoMapper;
using Liquid.Enterprise.DTO;
using Liquid.Library.DAL;

namespace Liquid.Enterprise.Core
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            // Entity to DTO
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<Movie, MovieDto>();

            // DTO to Entity
            Mapper.CreateMap<BookDto, Book>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}
