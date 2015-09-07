using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.InputModels;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Service.Interfaces;
using API.Core.Utils.Common;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class SurveyQuestionnaireController : BaseController
    {
        private readonly ISurveyQuestionnaireService _surveyQService = null;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ISkipLogicRuleService _ruleService = null;

        public SurveyQuestionnaireController(ISurveyQuestionnaireService surveyQService, ISkipLogicRuleService ruleService)
        {
            _surveyQService = surveyQService.CheckNull<ISurveyQuestionnaireService>("surveyQService");
            _ruleService = ruleService.CheckNull<ISkipLogicRuleService>("ruleService");
        }


        public IHttpActionResult Get()
        {

            try
            {
                var surveyQ = _surveyQService.Get().AsQueryable<SurveyQuestionnaire>();

                if (surveyQ == null)
                    return NotFound();

                return Ok(surveyQ);
            }
            catch(Exception ex)
            {
                Logger.Error("Error retrieving  survey questions: {0}", ex.Message);
                return BadRequest();
            }

        }

        public IHttpActionResult Get(int id)
        {
            try
            {

                var surveyQ = _surveyQService.Get(id);

                if (surveyQ == null)
                    return NotFound();

                return Ok(surveyQ);
            }
            catch(Exception ex)
            {
                Logger.Error("Error retrieving survey question: {0}", ex.Message);
                return BadRequest();
            }

        }
        
        public void Post([FromBody] SurveyQuestionnaire surveyQ)
        {
            try
            {
                _surveyQService.Post(surveyQ);
            }
            catch(Exception ex)
            {
                Logger.Error("Error creating survey question: {0}", ex.Message);                
            }
        }

        public IHttpActionResult Put([FromBody] SurveyQuestionnaire surveyQ)
        {
            try
            {
                var putValue = _surveyQService.Put(surveyQ);
                return Ok(putValue);

            }
            catch (Exception ex)
            {
                Logger.Error("Error updating question: {0}", ex.Message);
                return BadRequest();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _surveyQService.Delete(id);
            }
            catch(Exception ex)
            {
                Logger.Error("Error deleting survey question: {0}", ex.Message);
            }
        }

        public void Delete([FromBody] SurveyQuestionnaire surveyQ)
        {
            try
            {
                _surveyQService.Delete(surveyQ);
            }
            catch(Exception ex)
            {
                Logger.Error("Error deleting survey question: {0}", ex.Message);

            }
        }

        public IHttpActionResult GetNextQuestionnaire()//EmployeeResponseModel response)
        {
            EmployeeResponseModel response = new EmployeeResponseModel {
                 CurrentQuestionId = 1, Response = "Yes", SurveyId = 4
                   
            };

            try
            {

                var rules = _ruleService.GetNextRule(response).AsQueryable<SkipLogicRule>();
               
                var questionnaire = new List<SurveyQuestionnaire>();

                foreach (var rule in rules) {

                    var results = _surveyQService.Filter(p => p.Question.Id == rule.NextQuestionId
                                            && p.Survey.Id == response.SurveyId).ToList();

                    foreach(var q in results)  {
                        questionnaire.Add(q);
                    }
                }

                return Ok(questionnaire);

               //return BuildViewModel<SurveyQuestionnaireViewModel>(Request, questionnaire.First());
            }
            catch(Exception ex)
            {
                Logger.Error("Error retrieving questionnaire survey question: {0}", ex.Message);
                return BadRequest();
            }
        }

     
    }
}