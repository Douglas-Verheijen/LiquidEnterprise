using Liquid.Enterprise.Exceptions;
using Newtonsoft.Json.Linq;
using System;

namespace Liquid.Enterprise.Strategies
{
    public class StrategyContext : IStrategyContext
    {
        public string Action { get; set; }

        public string Version { get; set; }

        public string Command { get; set; }

        public object Request { get; set; }

        public object Response { get; set; }

        public StrategyContext(string action, string version, string command)
        {
            Action = action;
            Version = version;
            Command = command;
        }

        public StrategyContext(object request, string action, string version, string command)
            : this(action, version, command)
        {
            Request = request;
        }

        public T Resolve<T>()
        {
            if (Request == null)
                return default(T);

            if (Request is T)
                return (T)Request;

            var request = Request as JObject;
            if (request != null)
                return request.ToObject<T>();

            throw new BadRequestException();
        }
    }
}