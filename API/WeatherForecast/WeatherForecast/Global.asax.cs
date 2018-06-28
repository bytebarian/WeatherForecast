using Autofac;
using Autofac.Integration.WebApi;
using Swashbuckle.Application;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WeatherForecast.Services.Interfaces;
using WeatherForecast.Services.Services;

namespace WeatherForecast
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<OpenWeatherMapService>().As<IWeatherService>().InstancePerRequest();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.EnableSwagger(c =>
            {
                c.RootUrl(ResolveUrl);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                //c.DocumentFilter<HideInDocsFilter>();
                c.SingleApiVersion("v1", "WeatherForecast");
                AddXmlcommentsPaths(c);

            }).EnableSwaggerUi();
        }

        private static string ResolveUrl(HttpRequestMessage request)
        {
            var baseUrl = request.RequestUri.GetLeftPart(UriPartial.Authority) + request.GetRequestContext().VirtualPathRoot.TrimEnd('/');
            return baseUrl;
        }

        private static void AddXmlcommentsPaths(SwaggerDocsConfig c)
        {
            var baseDir = System.AppDomain.CurrentDomain.BaseDirectory;

            c.IncludeXmlComments(baseDir + "bin\\WeatherForecast.xml");
        }
    }
}
