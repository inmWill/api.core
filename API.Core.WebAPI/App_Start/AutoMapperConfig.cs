using API.Core.Domain.Enums;
using API.Core.Domain.Models.Clients;
using API.Core.Domain.Models.Import;
using API.Core.Domain.Models.Lookup;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Domain.Models.UserIdentity;
using API.Core.Domain.ViewModels;
using API.Core.Utils.Automapper.AutoMapper;
using InputOptionType = API.Core.Domain.Models.Lookup.InputOptionType;
using OperatorType = API.Core.Domain.Models.Lookup.OperatorType;
using QuestionType = API.Core.Domain.Models.Lookup.QuestionType;
using UnitOfMeasure = API.Core.Domain.Models.Lookup.UnitOfMeasure;

namespace API.Core.Rest.WebAPI
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureAutomapperMappings();
        }

        private static void ConfigureAutomapperMappings()
        {
            // Authentication
            AutoMapperConfig.CreateMap<AuthorizedClient, API.Core.Repository.Models.Identity.AuthorizedClient>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Identity.AuthorizedClient, AuthorizedClient>();

            AutoMapperConfig.CreateMap<AppUser, API.Core.Repository.Models.Identity.AppUser>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Identity.AppUser, AppUser>();


            // Client
            AutoMapperConfig.CreateMap<Client, API.Core.Repository.Models.Client.Client>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Client.Client, Client>();
            AutoMapperConfig.CreateMap<Client, ClientViewModel>();
            AutoMapperConfig.CreateMap<ClientViewModel, Client>();

            AutoMapperConfig.CreateMap<AppUserInfo, API.Core.Repository.Models.Client.ClientEmployee>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Client.ClientEmployee, AppUserInfo>();
            AutoMapperConfig.CreateMap<AppUserInfo, ClientEmployeeViewModel>();
            AutoMapperConfig.CreateMap<ClientEmployeeViewModel, AppUserInfo>();

            AutoMapperConfig.CreateMap<EmployeeDependent, API.Core.Repository.Models.Client.EmployeeDependent>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Client.EmployeeDependent, EmployeeDependent>();
            AutoMapperConfig.CreateMap<EmployeeDependent, EmployeeDependentViewModel>();
            AutoMapperConfig.CreateMap<EmployeeDependentViewModel, EmployeeDependent>();

            AutoMapperConfig.CreateMap<ClientImportRecord, API.Core.Repository.Models.Import.ClientImportRecord>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Import.ClientImportRecord, ClientImportRecord>();

            // Lookups
            AutoMapperConfig.CreateMap<DependentType, API.Core.Repository.Models.Lookup.DependentType>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Lookup.DependentType, DependentType>();

            AutoMapperConfig.CreateMap<State, API.Core.Repository.Interfaces.State>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Interfaces.State, State>();

            AutoMapperConfig.CreateMap<InputOptionType, API.Core.Repository.Models.Lookup.InputOptionType>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Lookup.InputOptionType, InputOptionType>();

            AutoMapperConfig.CreateMap<OperatorType, API.Core.Repository.Models.Lookup.OperatorType>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Lookup.OperatorType, OperatorType>();

            AutoMapperConfig.CreateMap<QuestionType, API.Core.Repository.Models.Lookup.QuestionType>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Lookup.QuestionType, QuestionType>();

            AutoMapperConfig.CreateMap<UnitOfMeasure, API.Core.Repository.Models.Lookup.UnitOfMeasure>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Lookup.UnitOfMeasure, UnitOfMeasure>();

            #region SurveyBuilder

            //Survey
            AutoMapperConfig.CreateMap<Survey, API.Core.Repository.Models.Survey.Survey>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.Survey, Survey>();
            AutoMapperConfig.CreateMap<SurveyViewModel, Survey>();
            AutoMapperConfig.CreateMap<Survey, SurveyViewModel>();

            //Question
            AutoMapperConfig.CreateMap<Question, API.Core.Repository.Models.Survey.Question>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.Question, Question>();
            AutoMapperConfig.CreateMap<SurveyQuestionViewModel, Question>();
            AutoMapperConfig.CreateMap<Question, SurveyQuestionViewModel>();

            //Answer
            AutoMapperConfig.CreateMap<Answer, API.Core.Repository.Models.Survey.Answer>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.Answer, Answer>();
            AutoMapperConfig.CreateMap<SurveyAnswerViewModel, Answer>();
            AutoMapperConfig.CreateMap<Answer, SurveyAnswerViewModel>();


            //Dialog
            AutoMapperConfig.CreateMap<Dialog, API.Core.Repository.Models.Survey.Dialog>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.Dialog, Dialog>();

            //InputOption
            AutoMapperConfig.CreateMap<InputOption, API.Core.Repository.Models.Survey.InputOption>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.InputOption, InputOption>();

            //SkipLogicRule
            AutoMapperConfig.CreateMap<SkipLogicRule, API.Core.Repository.Models.Survey.SkipLogicRule>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.SkipLogicRule, SkipLogicRule>();

            //SurveyQuestionnaire
            AutoMapperConfig.CreateMap<SurveyQuestionnaire, API.Core.Repository.Models.Survey.SurveyQuestionnaire>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.SurveyQuestionnaire, SurveyQuestionnaire>();
            AutoMapperConfig.CreateMap<SurveyQuestionnaireViewModel, API.Core.Repository.Models.Survey.SurveyQuestionnaire>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.SurveyQuestionnaire, SurveyQuestionnaireViewModel>();

            //EmployeeSurveyAudit
            AutoMapperConfig.CreateMap<EmployeeSurveyAudit, API.Core.Repository.Models.Survey.EmployeeSurveyAudit>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.EmployeeSurveyAudit, EmployeeSurveyAudit>();

            //EmployeeQuestionnaire
            AutoMapperConfig.CreateMap<EmployeeQuestionnaire, API.Core.Repository.Models.Survey.EmployeeQuestionnaire>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Survey.EmployeeQuestionnaire, EmployeeQuestionnaire>();

            #endregion

            AutoMapperConfig.CreateMap<RefreshToken, API.Core.Repository.Models.Identity.RefreshToken>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Identity.RefreshToken, RefreshToken>();


        }
    }
}