using System.Data.Entity;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using TaxScheduler.DataAccess;
using TaxScheduler.DataAccess.Repositories;
using TaxScheduler.Services.Municipality;

namespace TaxScheduler
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

			container.Register<TaskSchedulerDataContext>(Lifestyle.Scoped);

			container.Register<IMunicipalityRepository, MunicipalityRepository>(Lifestyle.Scoped);
			container.Register<IMunicipalityService, MunicipalityService>(Lifestyle.Scoped);

			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			container.Verify();

			GlobalConfiguration.Configuration.DependencyResolver =
							new SimpleInjectorWebApiDependencyResolver(container);

			//json formater
			config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
			config.Formatters.JsonFormatter.Indent = true;


			Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskSchedulerDataContext, TaxScheduler.DataAccess.Migrations.Configuration>());

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
