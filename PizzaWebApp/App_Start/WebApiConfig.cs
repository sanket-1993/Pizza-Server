using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FluentValidation.WebApi;
using TokenAuth.Filters;
using TokenAuth.Validator;

namespace PizzaWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Fluent Validation check
            config.Filters.Add(new ValidateModelStateFilter());

            //config.Routes.MapHttpRoute(
            //    name: "version1",
            //    routeTemplate: "api/{controller}V1/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //name: "version2",
            //routeTemplate: "api1/{controller}V2/{action}/{id}",
            //defaults: new { id = RouteParameter.Optional }
            //);

            FluentValidationModelValidatorProvider.Configure(config, x => x.ValidatorFactory = new NinjectValidatorFactory(config));
        }
    }
}
