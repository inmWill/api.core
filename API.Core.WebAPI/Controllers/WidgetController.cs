using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Core.Service.Interfaces;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class WidgetController : BaseController
    {
        private readonly IWidgetService _widgetService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public WidgetController(IWidgetService widgetService)
        {
            if (widgetService == null)
            {
                throw new ArgumentNullException("widgetService");
            }
            _widgetService = widgetService;
        }

        public IHttpActionResult GetAll()
        {
            try
            {
                var widgets = _widgetService.Get();
                return Ok(widgets);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving widgets: {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
