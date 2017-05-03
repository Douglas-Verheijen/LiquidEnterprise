using System;

namespace Liquid.Enterprise.Strategies
{
    public class ApiCommandAttribute : Attribute
    {
        public ApiCommandAttribute(string version)
            : base() { }
    }
}