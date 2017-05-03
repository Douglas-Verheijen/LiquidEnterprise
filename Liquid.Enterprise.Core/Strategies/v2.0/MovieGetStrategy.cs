using AutoMapper;
using Liquid.Enterprise.DTO;
using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("GET")]
    [ApiVersion("v2.0")]
    [ApiCommand("movie")]
    public class MovieGetStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var id = context.Resolve<Guid>();
            using (var dbContext = new LibraryEntities())
            {
                if (id != Guid.Empty)
                {
                    var entity = dbContext.Movies.FirstOrDefault(x => x.Id == id);
                    context.Response = Mapper.Map<MovieDto>(entity);
                }
                else
                {
                    context.Response = dbContext.Movies
                        .AsEnumerable()
                        .Select(x => Mapper.Map<MovieDto>(x))
                        .ToList();
                }
            }
        }
    }
}