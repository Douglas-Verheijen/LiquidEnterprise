using System;

namespace Liquid.Enterprise.Strategies
{
    public class ApiActionAttribute : Attribute
    {
        public ApiActionAttribute(string version)
            : base() { }
    }
}