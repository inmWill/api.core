using System;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.ViewModels;
using API.Core.Service.Interfaces;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    /// <summary>
    /// End points for Employee Dependents
    /// Requires IEmployeeDependentService
    /// </summary>
    public class EmployeeDependentController : BaseController
    {
        private readonly IEmployeeDependentService _EmployeeDependentService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public EmployeeDependentController(IEmployeeDependentService EmployeeDependentService)
        {
            if (EmployeeDependentService == null)
            {
                throw new ArgumentNullException("EmployeeDependentService");
            }
            _EmployeeDependentService = EmployeeDependentService;
        }

        // GET api/EmployeeDependent/GetAll

        public IHttpActionResult GetAll()
        {
            try
            {
                var dependents = _EmployeeDependentService.Get();
                return BuildViewModel<IQueryable<EmployeeDependentViewModel>>(Request, dependents);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving dependents: {0}", ex.Message);
                return null;
            }

        }

        // GET api/EmployeeDependent/Get/1
        //[Authorize]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var dependent = _EmployeeDependentService.Get(id);
                return BuildViewModel<EmployeeDependentViewModel>(Request, dependent);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving dependent: {0}", ex.Message);
                return null;
            }
        }

        public IHttpActionResult GetPagedDependents(int page, int pagesize)
        {
            try
            {
                var dependents = _EmployeeDependentService.GetPagedByExpression(t => t.DependentType != null, c => c.Id, page, pagesize);
                return BuildViewModel<IQueryable<EmployeeDependentViewModel>>(Request, dependents);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving paged results: {0}", ex.Message);
                return null;
            }
        }
    }
}