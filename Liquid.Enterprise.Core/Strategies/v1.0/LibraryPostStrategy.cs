using AutoMapper;
using Liquid.Enterprise.DTO;
using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("POST")]
    [ApiVersion("v1.0")]
    [ApiCommand("library")]
    public class LibraryPostStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var book = context.Resolve<BookDto>();
            using (var dbContext = new LibraryEntities())
            {
                if (book.Id != Guid.Empty)
                {
                    var entity = dbContext.Books
                        .Where(x => x.Id == book.Id)
                        .SingleOrDefault();
                    Mapper.Map(book, entity);
                    context.Response = entity.Id;
                }
                else
                {
                    var entity = Mapper.Map<Book>(book);
                    entity.Id = Guid.NewGuid();
                    context.Response = entity.Id;

                    dbContext.Books.Add(entity);
                }

                dbContext.SaveChanges();
            }
        }
    }
}