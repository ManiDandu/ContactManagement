using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using Unity;
using ContactManagement.Interfaces;
using ContactManagement.Business;
using Unity.Lifetime;
using System.Web.Http.ExceptionHandling;
using ContactManagement.Utilities;

namespace ContactManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));


            var container = new UnityContainer();
            //Registering the dependency type
            container.RegisterType<IContactInfoInstance, ContactInfoJsonInstance>(new HierarchicalLifetimeManager());
            //container.RegisterType<IContactInfoInstance, ContactInfoSQLInstance>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
