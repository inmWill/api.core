using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace ConSova.OCV.WebAPI.Attributes.Action
{
    public class NullObjectResultActionFilter : ActionFilterAttribute 
    {

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            object value = null;
            actionExecutedContext.Response.TryGetContentValue<object>(out value);
                        
            if(value == null)            
                throw new HttpResponseException(HttpStatusCode.NotFound);            

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}