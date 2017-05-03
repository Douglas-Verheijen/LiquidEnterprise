using Liquid.Enterprise.Exceptions;

namespace Liquid.Enterprise.Strategies
{
    [ApiVersion("v1.0")]
    public class NotFoundStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            throw new NotFoundException();
        }
    }
}