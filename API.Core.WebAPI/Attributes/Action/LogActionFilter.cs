using System.Web.Http.Filters;
using NLog;

namespace API.Core.Rest.WebAPI.Attributes.Action
{
    public class LogActionFilter : ExceptionFilterAttribute
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            var controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

            Logger.Error("Error executing action" + actionName + "in controller" + controllerName, 
                         actionExecutedContext.Exception.Message);            

            base.OnException(actionExecutedContext);

        }
    }
}