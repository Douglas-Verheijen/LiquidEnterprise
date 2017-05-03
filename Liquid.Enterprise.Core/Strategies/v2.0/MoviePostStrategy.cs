using AutoMapper;
using Liquid.Enterprise.DTO;
using Liquid.Library.DAL;
using System;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("POST")]
    [ApiVersion("v2.0")]
    [ApiCommand("movie")]
    public class MoviePostStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var dto = context.Resolve<MovieDto>();
            using (var dbContext = new LibraryEntities())
            {
                var entity = Mapper.Map<Book>(dto);
                entity.Id = Guid.NewGuid();

                dbContext.Books.Add(entity);
                dbContext.SaveChanges();

                context.Response = entity.Id;
            }
        }
    }
}