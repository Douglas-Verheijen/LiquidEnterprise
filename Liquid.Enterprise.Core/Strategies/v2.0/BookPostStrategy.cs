using AutoMapper;
using Liquid.Enterprise.DTO;
using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("POST")]
    [ApiVersion("v2.0")]
    [ApiCommand("book")]
    public class BookPostStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var dto = context.Resolve<BookDto>();
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