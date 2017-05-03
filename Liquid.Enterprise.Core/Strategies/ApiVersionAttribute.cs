using System;

namespace Liquid.Enterprise.Strategies
{
    public class ApiVersionAttribute : Attribute
    {
        public ApiVersionAttribute(string version)
            : base() { }
    }
}