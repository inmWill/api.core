using System;
using System.Collections.Generic;
using System.Reflection;
using API.Core.Domain.Enums;
using API.Core.Domain.InputModels;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Repository.Interfaces;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;
using API.Core.Service.RuleEngine;


namespace API.Core.Service.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SkipLogicRuleService : BaseServiceApi<API.Core.Repository.Models.Survey.SkipLogicRule, SkipLogicRule>, ISkipLogicRuleService
    {
        public SkipLogicRuleService(IRepository dataRepository)
            : base(dataRepository) {
                Includes = new[] { "NextQuestion", "Survey", "Unit", "OperatorType"};
        }

        /// <summary>
        /// This method return next question based on the employee response.
        /// </summary>
        /// <param name="Question"></param>
        /// <param name="CurrentQuestionId"></param>
        /// <param name="SurveyId"></param>
        /// <returns></returns>
        public IEnumerable<SkipLogicRule> GetNextRule(EmployeeResponseModel response)
        {
            //add these for just testing            
            EmployeeQuestionnaire question = new EmployeeQuestionnaire();            
            question.Response = response.Response;            

            //Get all the rules for the current question with in the survey
            var rules = Filter(p => p.Question.Id ==response.CurrentQuestionId
                                            && p.Survey.Id == response.SurveyId);

            var validRules = new List<SkipLogicRule>();         
            
            //figure out type param based on the unit measure
            foreach(var rule in rules)
            {                
                string type = UnitType.GetUnitType((UnitOfMeasure) rule.Unit.Id);
                object classInstance = Activator.CreateInstance(typeof(RuleValidation));
               
                ////create type arguments
                Type typeArg = Type.GetType(type);
                Type typeTarget = typeof(SkipLogicRule);
                Type typeValue = typeof(EmployeeQuestionnaire);

                //input params 
                object[] inputParams = new object[] { (OperatorType)rule.OperatorType.Id, rule, question };


                //using reflection methodinfo to call the method since we don't know the type param at compile time.

                MethodInfo method = typeof(RuleValidation).GetMethod("IsRuleValid");
                MethodInfo generic = method.MakeGenericMethod(new Type[] { typeTarget, typeValue, typeArg });

                var result = false;

                result = (method.IsStatic == true) ? (bool)generic.Invoke(null, inputParams)
                                                    : (bool)generic.Invoke(classInstance, inputParams);                

                if (result)
                    validRules.Add(rule);                

            }

            return validRules;
        }
    }
}
