using System;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Service.Interfaces;
using API.Core.Utils.Common;
using Microsoft.AspNet.Identity;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class SurveyController : BaseController
    {
        private readonly ISurveyService _surveyService = null;
        private readonly IAuthService _authService = null;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public SurveyController(ISurveyService surveyService, IAuthService authService)
        {
            _authService = authService.CheckNull("surveyService");
            _surveyService = surveyService.CheckNull("surveyService");
        }


        public IHttpActionResult Get()
        {

            try
            {
                var surveys = _surveyService.Get().AsQueryable<Survey>();

                if (surveys == null) // expression is always false
                    return NotFound();

                return Ok(surveys);
            }
            catch (Exception ex)
            {
                _logger.Error("Error retrieving surveys: {0}", ex.Message);
                return BadRequest();
            }

        }

        public IHttpActionResult Get(int id)
        {
            try
            {

                var survey = _surveyService.Get(id);

                if (survey == null)
                    return NotFound();

                return Ok(survey);
            }
            catch (Exception ex)
            {
                _logger.Error("Error retrieving survey: {0}", ex.Message);
                return BadRequest();

            }

        }

        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult GetSurveyByActiveUser()
        {
            try
            {
                var identity = User.Identity;
                var userAccount = _authService.FindActiveUserProfile(identity.GetUserName());
                var survey = _surveyService.GetActiveClientSurvey(userAccount.ClientEmployee.Client_Id);

                if (survey == null)
                    return NotFound();

                return Ok(survey);
            }
            catch (Exception ex)
            {
                _logger.Error("Error retrieving survey: {0}", ex.Message);
                return BadRequest();

            }

        }

        public void Post([FromBody] Survey survey)
        {
            try
            {
                _surveyService.Post(survey);
            }
            catch (Exception ex)
            {
                _logger.Error("Error creating survey: {0}", ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] Survey survey)
        {
            try
            {
                var putValue = _surveyService.Put(survey);
                return Ok(putValue);

            }
            catch (Exception ex)
            {
                _logger.Error("Error updating survey: {0}", ex.Message);
                return null;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _surveyService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.Error("Error deleting survey: {0}", ex.Message);
            }
        }

        public void Delete([FromBody] Survey survey)
        {
            try
            {
                _surveyService.Delete(survey);
            }
            catch (Exception ex)
            {
                _logger.Error("Error deleting survey: {0}", ex.Message);
            }
        }


    }
}