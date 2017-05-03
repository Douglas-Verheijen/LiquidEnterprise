using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("DELETE")]
    [ApiVersion("v2.0")]
    [ApiCommand("book")]
    public class BookDeleteStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var id = context.Resolve<Guid>();
            using (var dbContext = new LibraryEntities())
            {
                var entity = dbContext.Books.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    dbContext.Books.Remove(entity);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}