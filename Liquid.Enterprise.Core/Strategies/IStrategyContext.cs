using Newtonsoft.Json.Linq;

namespace Liquid.Enterprise.Strategies
{
    public interface IStrategyContext
    {
        string Action { get; set; }

        string Version { get; set; }

        string Command { get; set; }

        object Request { get; set; }

        object Response { get; set; }

        T Resolve<T>();
    }
}
