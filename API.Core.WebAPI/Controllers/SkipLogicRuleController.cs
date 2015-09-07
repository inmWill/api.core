using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.InputModels;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Domain.ViewModels;
using API.Core.Service.Interfaces;
using API.Core.Utils.Common;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class SkipLogicRuleController : BaseController
    {
        private readonly ISkipLogicRuleService _ruleService = null;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public SkipLogicRuleController(ISkipLogicRuleService ruleService)
        {
            _ruleService = ruleService.CheckNull<ISkipLogicRuleService>("ruleService");            
        }


        public IHttpActionResult Get()
        {

            try
            {
                var rules = _ruleService.Get().AsQueryable<SkipLogicRule>();

                if (rules == null)
                    return NotFound();

                return Ok(rules);
            }
            catch(Exception ex)
            {
                Logger.Error("Error retrieving rules: {0}", ex.Message);
                return BadRequest();
            }

        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var rule = _ruleService.Get(id);

                if (rule == null)
                    return NotFound();

                return Ok(rule);
            }
            catch(Exception ex)
            {
                Logger.Error("Error retrieving rule: {0}", ex.Message);
                return BadRequest();
            }

        }
        
        public void Post([FromBody] SkipLogicRule rule)
        {
            try
            {
                _ruleService.Post(rule);
            }
            catch(Exception ex)
            {
                Logger.Error("Error creating rule: {0}", ex.Message);                
            }
        }

        public IHttpActionResult Put([FromBody] SkipLogicRule rule)
        {
            try
            {
                var putValue = _ruleService.Put(rule);
                return Ok(putValue);

            }
            catch (Exception ex)
            {
                Logger.Error("Error updating rule: {0}", ex.Message);
                return BadRequest();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _ruleService.Delete(id);
            }
            catch(Exception ex)
            {
                Logger.Error("Error deleting rule: {0}", ex.Message);
            }
        }

        public void Delete([FromBody] SkipLogicRule rule)
        {
            try
            {
                _ruleService.Delete(rule);
            }
            catch(Exception ex)
            {
                Logger.Error("Error deleting rule: {0}", ex.Message);
            }
        }

        public IHttpActionResult GetNextRule(EmployeeResponseModel response)
        {

            try
            {
                var rules = _ruleService.GetNextRule(response).AsQueryable<SkipLogicRule>();

                List<object> lstObj = new List<object>();


                foreach(var rule in rules)
                {
                    lstObj.Add(rule.NextQuestion);
                }

                return BuildViewModel<SurveyQuestionViewModel>(Request, lstObj.ToArray());

                if (rules == null)
                    return NotFound();

                return Ok(rules);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving rules: {0}", ex.Message);
                return BadRequest();
            }

        }

    }
}