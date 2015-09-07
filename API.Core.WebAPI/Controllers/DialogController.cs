using System;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Service.Interfaces;
using API.Core.Utils.Common;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class DialogController : BaseController
    {
        private readonly IDialogService _dialogService = null;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DialogController(IDialogService dialogService)
        {
            _dialogService = dialogService.CheckNull<IDialogService>("dialogService");            
        }


        public IHttpActionResult Get()
        {
            try
            {
                var dialogs = _dialogService.Get().AsQueryable<Dialog>();

                if (dialogs == null)
                    return NotFound();

                return Ok(dialogs);
            }
            catch(Exception ex)
            {
                Logger.Error("Error retrieving dialogs: {0}", ex.Message);
                return BadRequest();
            }

        }

        public IHttpActionResult Get(int id)
        {
            try
            {

                var dialog = _dialogService.Get(id);

                if (dialog == null)
                    return NotFound();

                return Ok(dialog);
            }
            catch(Exception ex)
            {
                Logger.Error("Error retrieving dialog: {0}", ex.Message);
                return BadRequest();
            }

        }

        public void Post([FromBody] Dialog dialog)
        {
            try
            {
                _dialogService.Post(dialog);
            }
            catch(Exception ex)
            {
                Logger.Error("Error creating dialog: {0}", ex.Message);                
            }
        }

        public IHttpActionResult Put([FromBody] Dialog dialog)
        {
            try
            {
                var putValue = _dialogService.Put(dialog);
                return Ok(putValue);

            }
            catch (Exception ex)
            {
                Logger.Error("Error updating dialog: {0}", ex.Message);
                return BadRequest();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dialogService.Delete(id);
            }
            catch(Exception ex)
            {
                Logger.Error("Error deleting dialog: {0}", ex.Message);
            }
        }

        public void Delete([FromBody] Dialog dialog)
        {
            try
            {
                _dialogService.Delete(dialog);
            }
            catch(Exception ex)
            {
                Logger.Error("Error deleting dialog: {0}", ex.Message);
            }
        }

      
    }
}