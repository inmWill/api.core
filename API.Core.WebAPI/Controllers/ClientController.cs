using System;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.ViewModels;
using API.Core.Service.Interfaces;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
     /// <summary>
     /// End points for Client db access
     /// Requires IClientService
     /// </summary>
     public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

         public ClientController(IClientService clientService)
         {
             if (clientService == null)
             {
                 throw new ArgumentNullException("clientService");
             }
             _clientService = clientService;
         }

         // GET api/AppUser/GetAll
         [API.Core.Rest.WebAPI.Attributes.Authorize(Roles= "Admin")]
         public IHttpActionResult GetAll()
         {
             try
             {
                 var clients = _clientService.Get();
                 return BuildViewModel<IQueryable<ClientViewModel>>(Request, clients);
             }
             catch (Exception ex)
             {
                 Logger.Error("Error retrieving clients: {0}", ex.Message);
                 return null;
             }

         }

         // GET api/AppUser/Get/1
         [API.Core.Rest.WebAPI.Attributes.Authorize]
         public IHttpActionResult Get(int id)
         {
             try
             {
                 var client = _clientService.Get(id);
                 return BuildViewModel<ClientViewModel>(Request, client);
             }
             catch (Exception ex)
             {
                 Logger.Error("Error retrieving client: {0}", ex.Message);
                 return null;
             }
         }

         // GET api/AppUser/GetByEmail?email=client@company.com
         [API.Core.Rest.WebAPI.Attributes.Authorize]
         public IHttpActionResult GetByEmail(string email)
         {
             try
             {
                 var client = _clientService.GetByEmail(email);
                 return BuildViewModel<ClientViewModel>(Request, client);
             }
             catch (Exception ex)
             {
                 Logger.Error("Error retrieving client by email: {0}", ex.Message);
                 return null;
             }
         }

         public IHttpActionResult GetPagedClients(int page, int pagesize)
         {
             try
             {
                 var clients = _clientService.GetPagedClientsByExpression(t => t.Email != null, c => c.Id, page, pagesize);
                 return BuildViewModel<IQueryable<ClientViewModel>>(Request, clients);
             }
             catch (Exception ex)
             {
                 Logger.Error("Error retrieving paged results: {0}", ex.Message);
                 return null;
             }
         }
    }
}