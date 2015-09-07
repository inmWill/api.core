using System.Net.Http;
using System.Web.Http;
using API.Core.Rest.WebAPI.ActionResults;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class BaseController : ApiController
    {

        public ViewModelActionResult BuildViewModel<TDestination>(HttpRequestMessage request, params object[] domainSources)
        {
            return new ViewModelActionResult(typeof(TDestination), request, domainSources);
        }

    }
}