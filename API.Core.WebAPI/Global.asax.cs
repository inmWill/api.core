using System.Web;

namespace API.Core.Rest.WebAPI
{
    public class WebApiApplication : HttpApplication
    {
    
        protected void Application_Start()
        {
           
           //GlobalConfiguration.Configure(WebApiConfig.Register);           
           //AutoMapperWebConfiguration.Configure();
           //GlobalConfiguration.Configure(config => config.Filters.Add(new ValidateModelStateAttribute()));
        }
    }
}
