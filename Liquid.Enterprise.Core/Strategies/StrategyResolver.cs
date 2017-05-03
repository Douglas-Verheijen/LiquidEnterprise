using System;
using System.Linq;
using System.Reflection;

namespace Liquid.Enterprise.Strategies
{
    public class StrategyResolver
    {
        public void Execute(IStrategyContext context)
        {
            var interfaceType = typeof(IStrategy);

            var strategyType = Assembly.GetAssembly(interfaceType).GetTypes()
                .FirstOrDefault(x => x.GetInterfaces().Any(y => interfaceType.IsAssignableFrom(y))
                    && x.CustomAttributes.Any(y => typeof(ApiActionAttribute).IsAssignableFrom(y.AttributeType) 
                        && y.ConstructorArguments.Any(z => z.Value.ToString() == context.Action))

                    && x.CustomAttributes.Any(y => typeof(ApiVersionAttribute).IsAssignableFrom(y.AttributeType) 
                        && y.ConstructorArguments.Any(z => z.Value.ToString() == context.Version))

                    && x.CustomAttributes.Any(y => typeof(ApiCommandAttribute).IsAssignableFrom(y.AttributeType) 
                        && y.ConstructorArguments.Any(z => z.Value.ToString() == context.Command)));

            if (strategyType == null)
                strategyType = typeof(NotFoundStrategy);

            var strategy = Activator.CreateInstance(strategyType) as IStrategy;
            strategy.Handle(context);
        }
    }
}