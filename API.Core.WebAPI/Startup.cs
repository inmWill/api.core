﻿using System;
using System.Web.Http;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Repositories;
using API.Core.Rest.WebAPI;
using API.Core.Rest.WebAPI.Providers;
using API.Core.Rest.WebAPI.Resolver;
using API.Core.Service.Interfaces;
using API.Core.Service.Services;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace API.Core.Rest.WebAPI
{

    /// <summary>
    /// Composition root for the OCV Framework
    /// Configures Unity Dependencies
    /// Owin wrapper oauth interceptors
    /// </summary>
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            app.UseCors(CorsOptions.AllowAll);
            var container = RegisterUnityRootContainer();

            config.DependencyResolver = new UnityResolver(container);

            WebApiConfig.Register(config);

            ConfigureOAuth(app);


            app.UseWebApi(config);
            AutoMapperWebConfiguration.Configure();            



        }

        private static UnityContainer RegisterUnityRootContainer()
        {
            var container = new UnityContainer();

            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Hierarchical);
            
            container.RegisterType<IRepository, EntityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthService, AuthService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISurveyService, SurveyService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientEmployeeService, ClientEmployeeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientService, ClientService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISurveyService, SurveyService>(new HierarchicalLifetimeManager());
            container.RegisterType<IQuestionService, QuestionService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISurveyQuestionnaireService, SurveyQuestionnaireService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISkipLogicRuleService, SkipLogicRuleService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAnswerService, AnswerService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeQuestionnaireService, EmployeeQuestionnaireService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDialogService, DialogService>(new HierarchicalLifetimeManager());


            return container;
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            // Default Authentication 30 minute life span
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new SimpleAuthorizationServerProvider(),              
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }

}