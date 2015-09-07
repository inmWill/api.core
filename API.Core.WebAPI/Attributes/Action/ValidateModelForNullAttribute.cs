using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API.Core.Rest.WebAPI.Attributes.Action
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateModelForNullAttribute : ActionFilterAttribute 
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            
        }
    }
}