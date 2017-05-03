using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("DELETE")]
    [ApiVersion("v2.0")]
    [ApiCommand("movie")]
    public class MovieDeleteStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var id = context.Resolve<Guid>();
            using (var dbContext = new LibraryEntities())
            {
                var entity = dbContext.Movies.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    dbContext.Movies.Remove(entity);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}