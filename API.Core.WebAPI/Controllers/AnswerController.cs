using System;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Service.Interfaces;
using API.Core.Utils.Common;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class AnswerController : BaseController
    {

        private readonly IAnswerService _answerService;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService.CheckNull<IAnswerService>("answerService");
        }

        public IHttpActionResult Get()
        {

            try
            {
                var answers = _answerService.Get().AsQueryable<Answer>();

                if (answers == null)
                    return NotFound();

                return Ok(answers);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving answers: {0}", ex.Message);
                return BadRequest();
            }

        }

        public IHttpActionResult Get(int id)
        {
            try
            {

                var answer = _answerService.Get(id);

                if (answer == null)
                    return NotFound();

                return Ok(answer);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving answer: {0}", ex.Message);
                return BadRequest();

            }

        }

        public void Post([FromBody] Answer answer)
        {
            try
            {
                _answerService.Post(answer);
            }
            catch (Exception ex)
            {
                Logger.Error("Error creating answer: {0}", ex.Message);               
            }
        }

        public IHttpActionResult Put([FromBody] Answer answer)
        {
            try
            {
                var putValue = _answerService.Put(answer);
                return Ok(putValue);
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating answer: {0}", ex.Message);
                return BadRequest();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _answerService.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.Error("Error deleting answer: {0}", ex.Message);
            }
        }

        public void Delete([FromBody] Answer answer)
        {
            try
            {
                _answerService.Delete(answer);
            }
            catch (Exception ex)
            {
                Logger.Error("Error deleting answer: {0}", ex.Message);
            }
        }
    }
}