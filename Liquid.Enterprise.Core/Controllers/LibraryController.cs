using Liquid.Enterprise.Exceptions;
using Liquid.Enterprise.Strategies;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace Liquid.Enterprise.Controllers
{
    public class LibraryController : ApiController
    {
        private StrategyResolver _resolver => new StrategyResolver();
        
        [Route("api/{version}/{command}/")]
        public IHttpActionResult Get(string version, string command)
        {
            try
            {
                var context = new StrategyContext("GET", version, command);
                _resolver.Execute(context);
                return Ok(context.Response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("api/{version}/{command}/{id}")]
        public IHttpActionResult Get(string version, string command, Guid id)
        {
            try
            {
                var context = new StrategyContext(id, "GET", version, command);
                _resolver.Execute(context);
                return Ok(context.Response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("api/{version}/{command}/")]
        public IHttpActionResult Post([FromBody]JObject obj, string version, string command)
        {
            try
            {
                var context = new StrategyContext(obj, "POST", version, command);
                _resolver.Execute(context);
                return Ok(context.Response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("api/{version}/{command}/")]
        public IHttpActionResult Patch([FromBody]JObject obj, string version, string command)
        {
            try
            {
                var context = new StrategyContext(obj, "PATCH", version, command);
                _resolver.Execute(context);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("api/{version}/{command}/{id}")]
        public IHttpActionResult Delete(string version, string command, Guid id)
        {
            try
            {
                var context = new StrategyContext(id, "DELETE", version, command);
                _resolver.Execute(context);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        private IHttpActionResult HandleException(Exception ex)
        {
            if (ex is NotFoundException)
                return NotFound();

            if (ex is BadRequestException)
                return BadRequest();

            return InternalServerError();
        }
    }
}
