namespace Liquid.Enterprise.Strategies
{
    public interface IStrategy
    {
        void Handle(IStrategyContext context);
    }
}
