using System;
using CommonServiceLocator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Unity;
using Unity.ServiceLocation;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using System.Text;
using Monitor.Model.ServiceContract.Interface;
using Monitor.Service.Shared;
using Monitor.Service.Model;
using Monitor.Service.Model.Settings;
using Monitor.Service.Urls;
using Service.Filter;
using Count4U.Model;
using Monitor.Sqlite.CodeFirst;
using Microsoft.EntityFrameworkCore;
using Count4U.Model.Common;
using WebAPI.Filter.Sqlite.CodeFirst;
using Monitor.Profile.Sqlite.CodeFirst.ExportImport;
using Unity.Lifetime;

namespace WebAPI.Monitor.Sqlite.CodeFirst
{
	//[ApiConventionType(typeof(DefaultApiConventions))]
	public class StartupMonitorModelWebAPI
	{
		//http://qaru.site/questions/69404/resolving-instances-with-aspnet-core-di
		//Среда выполнения может внедрить службы в конструктор класса Startup, 
		//такие как IHostingEnvironment, IConfiguration и IServiceProvider. 
		//Обратите внимание, что этот поставщик услуг является экземпляром, созданным на уровне хостинга, 
		//и содержит только службы для запуска приложения.
		//public Startup(IServiceProvider serviceProvider, IHostingEnvironment hostingEnvironment,	ILoggerFactory loggerFactory)
		//{
		//	var hostingEnv = serviceProvider.GetService<IHostingEnvironment>();
		//}
		public StartupMonitorModelWebAPI(IConfiguration configuration, IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{
			Configuration = configuration;
		}


		public IConfiguration Configuration { get; }

		//Если надо реазрешить сервис
		//public void ConfigureServices(IServiceCollection services)
		//{
		//	services.AddSingleton<IFooService, FooService>();

		//	// Build the intermediate service provider
		//	var sp = services.BuildServiceProvider();
		//	var fooService = sp.GetService<IFooService>();
		//}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IStartupFilter, SettingValidationStartupFilter>();   //валидация при старте чтения конфигурации приложения
			services.AddControllers().
				AddNewtonsoftJson(); 

			services.AddMvc()
				.AddNewtonsoftJson()
				.AddControllersAsServices(); // IMPORTANT: Adding this line instructs WebHost to resolve Controllers from DI (Unity)

			 services.AddHttpClient();
			 services.AddSignalR();

			services.AddSession();

			services.AddLogging();
			services.AddLogging(config =>
			{
				// clear out default configuration
				config.ClearProviders();

				config.AddConfiguration(Configuration.GetSection("Logging"));
				config.AddDebug();
				config.AddEventSourceLogger();

				if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ==
				Microsoft.Extensions.Hosting.Environments.Development)
				{
					config.AddConsole();
				}
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "WebAPI.Monitor.Model.EF.Sqlite.CodeFirst",
					Description = "MONITOR WEB API [Sqlite - DBSET - CODE FIRST]"
				});

				//// Set the comments path for the Swagger JSON and UI.
				var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
				c.CustomSchemaIds(i => i.FullName);
			});

			services.AddHttpContextAccessor();// вы можете запросить объект IHttpContextAccessor в конструкторе объекта. Хотя объект IHttpContextAccessor не имеет свойства User, он дает вам доступ к объекту HttpContext, который имеет свойство User. 

			services.AddOptions();    //			добавляет базовую поддержку для внедрения IOptions<T>объектов на основе в ваш код, заполненный данными конфигурации из магазина.Затем вы регистрируете свой фактический класс конфигурации и сопоставляете его с разделом конфигурации, который он должен использовать для чтения данных.
			
			// Bind the configuration using IOptions   https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-in-asp-net-core/
			services.Configure<Count4uSettings>(Configuration.GetSection("Count4USettings"));
			// Explicitly register the settings object so IOptions not required (optional)
			services.AddSingleton(resolver =>
				resolver.GetRequiredService<IOptions<Count4uSettings>>().Value);            //IOptionsSnapshot
																							 // Register as an IValidatable
			services.AddSingleton<IValidatable>(resolver =>
				resolver.GetRequiredService<IOptions<Count4uSettings>>().Value);

			services.AddScoped<ControllerFtpServiceFilter>();

			//services.AddSingleton<ICount4USettings>(resolver =>
			//resolver.GetRequiredService<IOptions<Count4USettings>>().Value);


			services.AddScoped<IJwtService, JwtService>();
			services.EnableLoggingForBadRequests();

			services.AddDbContext<MonitorSqliteDBContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

			ConfigureHubSignalRClient(services);
		}

		//http://qaru.site/questions/69404/resolving-instances-with-aspnet-core-di
		// Службы также могут быть добавлены в метод Configure(). 
		//Вы можете добавить произвольный список параметров после параметра IApplicationBuilder.
		//Вы также можете добавить свои собственные сервисы, которые зарегистрированы в методе ConfigureServices() 
		//здесь они будут решаться не поставщиком услуг хостинга, а поставщиком услуг приложения.
		//public void Configure(IApplicationBuilder app)
		//{
		//	var serviceProvider = app.ApplicationServices;
		//	var hostingEnv = serviceProvider.GetService<IHostingEnvironment>();
		//}
		//public void Configure(
		//IApplicationBuilder application,
		//IHostingEnvironment hostingEnvironment,
		//IServiceProvider serviceProvider,
		//ILoggerFactory loggerfactory,
		//IApplicationLifetime applicationLifetime)
		//{
		//}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{
			Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger<StartupMonitorModelWebAPI>();
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			if (env.IsDevelopment())
			{
				logger.LogInformation("Is Development enviroment");
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core 3.0 web API v1");
				//c.RoutePrefix = string.Empty;
			});

			app.UseRouting();

			app.UseCors(policy =>
			policy.AllowAnyOrigin() //WithOrigins("http://localhost:5000", "https://localhost:5001"
			.AllowAnyMethod()
			//.AllowAnyHeader()
			.WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization));//.AllowCredentials());

			app.UseAuthorization();

			app.UseSession(); //мы сможем использовать сессии у объекта HttpContext //context.Session.Keys.Contains("name")
							  //app.UseMailAsCorrelationId();

			//app.UseCount4uHeaderFromJWT();       //Always!!! must use 
			//app.UseCount4uContextFromHeader();       //после 	 app.UseCount4uHeaderFromJWT();

			//app.UseLoggerDebugPathAndCount4uContext();

			app.UseStatusCodePagesWithReExecute("/error/{0}");      //https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api
			app.UseExceptionHandler("/error/500");
			
			string chatHubAddress = Opetarion.UrlCombine(SignalRHub.HostHub, SignalRHub.ChatHub);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			//	endpoints.MapHub<Count4U.Service.Model.ChatHub>(chatHubAddress); это запуск сервера а не клиента
			});
		}

		public void ConfigureContainer(IUnityContainer container)
		{
			//https://unitycontainer.github.io/tutorials/lifetime/hierarchical.html
			//https://github.com/unitycontainer/unity/wiki/Unity-Lifetime-Managers
			//container.RegisterInstance(typeof(IService), "xyz", instance)

			container.RegisterInstance<IServiceLocator>(new UnityServiceLocator(container));

			//Test
			try
			{
				//container.RegisterType<IUserSettingsManager, UserSettingsManager>( TypeLifetime.Scoped);
				//container.RegisterType<ISettingsRepository, SettingsRepository>( TypeLifetime.Scoped);
				//container.RegisterType<IConnectionSqliteMonitorDB, ConnectionSqliteMonitorDB>(TypeLifetime.Scoped);
				//	http://elvanydev.com/SignalR-Core-SqlDependency-part2/		SqlTableDependency  SqlDependency
				//	container.RegisterType<ICommandResultRepository, CommandResultEFRepository>(TypeLifetime.Scoped);
				container.RegisterType<IProfileFileRepository, ProfileFileERRepository>(TypeLifetime.Scoped);
				container.RegisterType<ISettingsFtpRepository, SettingsFtpRepository>(TypeLifetime.Scoped);
				container.RegisterType<DataflowProfileQueue, DataflowProfileQueue>(new ContainerControlledLifetimeManager());
				container.RegisterType<IProfileHandler, ProfileHandler>(TypeLifetime.Scoped);

				try
				{
					IServiceLocator serviceLocator = container.Resolve<IServiceLocator>();
					IOptions<Count4uSettings> count4USettings = serviceLocator.GetInstance<IOptions<Count4uSettings>>();
					FileSystem._count4USettings = count4USettings.Value;
				}
				catch (Exception exc)
				{
					throw exc;
				}
			}
			catch (Exception exc)
			{
				//_logger.DebugException("InitializeShell error", exc);
			}

		
		}
		public void ConfigureHubSignalRClient(IServiceCollection services)
		{

			services.AddSingleton<IHubChatSignalRRepository, HubChatSignalRRepository>();
			services.AddSingleton<IHubCommandSignalRRepository, HubCommandSignalRRepository>();
		}

		//case ServiceLifetime.Scoped:
  //                  return new HierarchicalLifetimeManager();
  //              case ServiceLifetime.Singleton:
  //                  return new InjectionSingletonLifetimeManager(lifetime);
  //              case ServiceLifetime.Transient:
  //                  return new InjectionTransientLifetimeManager();
	}
}
