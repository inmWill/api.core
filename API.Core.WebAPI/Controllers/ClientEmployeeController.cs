using System;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.Models.Clients;
using API.Core.Domain.ViewModels;
using API.Core.Service.Interfaces;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    /// <summary>
    /// End points for Client Employees
    /// Requires IClientEmployeeService
    /// </summary>
    public class ClientEmployeeController : BaseController
    {
        private readonly IClientEmployeeService _clientEmployeeService;
        private readonly IAuthService _authService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ClientEmployeeController(IClientEmployeeService clientEmployeeService, IAuthService authService)
        {
            if (clientEmployeeService == null)
            {
                throw new ArgumentNullException("clientEmployeeService");
            }
            _clientEmployeeService = clientEmployeeService;

            if (authService == null)
            {
                throw new ArgumentNullException("authService");
            }
            _authService = authService;
        }

        // GET api/ClientEmployee/GetAll
        public IHttpActionResult GetAll()
        {
            try
            {
                var clients = _clientEmployeeService.Get();
                return BuildViewModel<IQueryable<ClientEmployeeViewModel>>(Request, clients);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving client employees: {0}", ex.Message);
                return BadRequest();
            }

        }

        [API.Core.Rest.WebAPI.Attributes.Authorize(Roles = "Admin,ClientAdmin")]
        public IHttpActionResult Update([FromBody] AppUserInfo record)
        {
            try
            {
                _clientEmployeeService.Put(record);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating client employee: {0}", ex.Message);
                return BadRequest();
            }
            
        }

        // GET api/ClientEmployee/Get/1
        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var client = _clientEmployeeService.Get(id);
                return BuildViewModel<ClientEmployeeViewModel>(Request, client);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving client employee: {0}", ex.Message);
                return BadRequest();
            }
        }

        // GET api/ClientEmployee/GetByEmail?email=client@company.com
        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult GetByEmail(string email)
        {
            try
            {
                var client = _clientEmployeeService.GetByEmail(email);
                return BuildViewModel<ClientEmployeeViewModel>(Request, client);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving client employee by email: {0}", ex.Message);
                return BadRequest();
            }
        }

        public IHttpActionResult GetPagedClients(int page, int pagesize)
        {
            try
            {
                var clients = _clientEmployeeService.GetPagedClientEmployeesByExpression(t => t.CompanyEmail != null, c => c.Id, page, pagesize);
                return BuildViewModel<IQueryable<ClientEmployeeViewModel>>(Request, clients);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving paged client employee results: {0}", ex.Message);
                return BadRequest();
            }
        }
    }
}