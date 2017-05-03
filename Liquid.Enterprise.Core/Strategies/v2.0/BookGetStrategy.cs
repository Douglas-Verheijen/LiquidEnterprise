using AutoMapper;
using Liquid.Enterprise.DTO;
using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("GET")]
    [ApiVersion("v2.0")]
    [ApiCommand("book")]
    public class BookGetStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var id = context.Resolve<Guid>();
            using (var dbContext = new LibraryEntities())
            {
                if (id != Guid.Empty)
                {
                    var entity = dbContext.Books.FirstOrDefault(x => x.Id == id);
                    context.Response = Mapper.Map<BookDto>(entity);
                }
                else
                {
                    context.Response = dbContext.Books
                        .AsEnumerable()
                        .Select(x => Mapper.Map<BookDto>(x))
                        .ToList();
                }
            }
        }
    }
}