using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("DELETE")]
    [ApiVersion("v1.0")]
    [ApiCommand("library")]
    public class LibraryDeleteStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var id = context.Resolve<Guid>();
            using (var dbContext = new LibraryEntities())
            {
                var load = dbContext.Books.FirstOrDefault(x => x.Id == id);
                if (load != null)
                {
                    dbContext.Books.Remove(load);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}