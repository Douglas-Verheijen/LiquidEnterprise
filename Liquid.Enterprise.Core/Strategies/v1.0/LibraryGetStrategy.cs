using AutoMapper;
using Liquid.Enterprise.DTO;
using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [Obsolete]
    [ApiAction("GET")]
    [ApiVersion("v1.0")]
    [ApiCommand("library")]
    public class LibraryGetStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var id = context.Resolve<Guid>();
            using (var dbContext = new LibraryEntities())
            {
                if (id != Guid.Empty)
                {
                    var data = dbContext.Books.FirstOrDefault(x => x.Id == id);
                    context.Response = Mapper.Map<BookDto>(data);
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