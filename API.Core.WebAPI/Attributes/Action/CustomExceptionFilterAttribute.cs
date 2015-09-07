using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace API.Core.Rest.WebAPI.Attributes.Action
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            var request = actionExecutedContext.ActionContext.Request;
            actionExecutedContext.Response = request.CreateResponse(HttpStatusCode.BadRequest);

            //base.OnException(actionExecutedContext);          
        }
    }
}