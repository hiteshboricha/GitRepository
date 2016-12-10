using Microsoft.Practices.Unity;
using SMart.Business;
using SMart.Controllers;
using SMart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace SMart
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.DependencyResolver = CastleHelper.GetDependencyResolver();
            

            var container = new UnityContainer();
            container.RegisterType<IProductDL, ProductDL>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityBootStrapper(container);
        }
    }
}
