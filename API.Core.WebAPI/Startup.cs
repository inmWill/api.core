using System;
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
using API.Core.Rest.WebAPI.Attributes.Action;

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
            config.Filters.Add(new ValidateModelAttribute());

            WebApiConfig.Register(config);

            ConfigureOAuth(app);
         //   ConfigureAuth(app);

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
            container.RegisterType<IAccountService, AccountService>(new HierarchicalLifetimeManager());


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