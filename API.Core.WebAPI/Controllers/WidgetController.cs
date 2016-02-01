using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Core.Domain.Enums;
using API.Core.Domain.Models.Widgets;
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

        /// <summary>
        /// Gets all widgets
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Updates a widget, request must be authorized, expects a Widget object in the body of the request.
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        [HttpPut]
        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult Put([FromBody] Widget widget)
        {
            try
            {  
                widget.State = State.Modified;              
                var result = _widgetService.Put(widget);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating widget: {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates a widget, request must be authorized, expects a Widget object in the body of the request.
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        [HttpPost]
        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult Post([FromBody] Widget widget)
        {
            try
            {
                widget.State = State.Added;
                var result = _widgetService.Post(widget);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.Error("Error creating widget: {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a widget, request must be authorized, expects a Widget Id in the uri of the request.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult Delete([FromUri] int id)
        {
            try
            {
                //widget.State = State.Deleted;
                var result = _widgetService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.Error("Error creating widget: {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetByManufacturer(string whichManufacturer)
        {
            try
            {
                var widgets = _widgetService.Filter(m => m.Manufacturer == whichManufacturer);
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
