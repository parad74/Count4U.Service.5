using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Count4U.Client.Shared.Service;
using Count4U.Service.Shared;
using Count4U.Service.Shared.Settings;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model;
using Monitor.Service.Model.Settings;
using Monitor.Service.Shared;
using Plk.Blazor.DragDrop;
using Service.Filter;
using Service.Model;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Count4U.Admin.Client.Blazor
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			//builder.Services.AddSingleton<WeatherService>();
			//app.UseLoadingBar();
			builder.RootComponents.Add<App>("#app");

			ConfigureServices(builder.Services);
			MapDependencyInjection(builder.Services);

			builder.Services.AddLoadingBar(options =>
			{
				// Specify the color of the loading bar
				// by CSS color descriptor.
				//options.LoadingBarColor = "yellow";
			}); // <-- register the service, and...
											  //	builder.Services.AddBaseAddressHttpClient();
			builder.Services.AddScoped(sp => new HttpClient { 
				BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
				}.EnableIntercept(sp));     // <- Add this!

			await builder.Build()
			 .UseLoadingBar() // <!-- declare construct loading bar UI.
				.RunAsync();
		}


		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IStartupFilter, SettingValidationStartupFilter>();   //валидация при старте чтения конфигурации приложения
																					   //services.AddHttpClient();
			services.AddBlazoredLocalStorage();
			services.AddBlazoredSessionStorage();

			services.AddBlazorDragDrop();
			//	services.AddBlazorContextMenu();

			services.AddI18nText();

			services.AddOptions();

			services.AddAuthorizationCore(config =>
			{
				config.AddPolicy(UserPolicy.IsAdmin, UserPolicy.IsAdminPolicy());
				config.AddPolicy(UserPolicy.IsUser, UserPolicy.IsUserPolicy());
				config.AddPolicy(UserPolicy.IsOwner, UserPolicy.IsOwnerPolicy());
				config.AddPolicy(UserPolicy.IsManager, UserPolicy.IsManagerPolicy());
				config.AddPolicy(UserPolicy.IsMonitor, UserPolicy.IsMonitorPolicy());
				config.AddPolicy(UserPolicy.IsContext, UserPolicy.IsContextPolicy());
				config.AddPolicy(UserPolicy.IsWorker, UserPolicy.IsWorkerPolicy());
				config.AddPolicy(UserPolicy.IsProfile, UserPolicy.IsProfilePolicy());
				config.AddPolicy(UserPolicy.HaveInventorCode, UserPolicy.HaveInventorCodePolicy());

				//https://visualstudiomagazine.com/articles/2019/10/29/aspnet-authentication.aspx
				//	config.AddPolicy("MustHaveEmail",
				//polBuilder => polBuilder.RequireClaim(ClaimTypes.Email));
				//	config.AddPolicy("MustHaveSpecificName",
				//		  polBuilder => polBuilder.RequireClaim(ClaimTypes.Name,
				//								new string[] {"Питер Фогель", "Жан Ирвин"}));

				//config.AddPolicy("MustHaveSpecificNameAndEmail", polBuilder =>
				// polBuilder.RequireClaim(ClaimTypes.Name,
				//			   new string[] {
				//	"Питер Фогель", "Жан Ирвин"})
				//		.RequireClaim(ClaimTypes.Email));

				//config.AddPolicy("MustHaveSpecificNameAndEmail", polBuilder =>
				//	polBuilder.RequireRole("Гость")
				//   .RequireClaim(ClaimTypes.Email));
			});


			services.AddLoadingBar();
		}

		private static void MapDependencyInjection(IServiceCollection services)
		{
			//managers
			services.AddScoped<IJwtService, JwtService>();
			services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IAdminService, AdminService>();
			services.AddTransient<IClaimsViewModel, ClaimsViewModel>();
			services.AddTransient<IProfileModel, ProfileModel>();
			services.AddScoped<IClaimService, ClaimService>();
			services.AddScoped<IClaimConvertRepository, ClaimConvertRepository>();
			services.AddTransient<IProfileFileService, ProfileFileService>();
			services.AddTransient<IFileDefaultService, FileDefaultService>();
			//services.AddSingleton<NumberViewModel>();           //test
			//services.AddSingleton<ToggleViewModel>();             //test
			//services.AddSingleton<IModel, MainModel>();          //test
			//services.AddSingleton<CustomerViewModel>();      //test


			//======================================== ProcessC4U ==================================================
			services.AddScoped<IProcessService, ProcessService>();
			//======================================== Main ==================================================
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<IBranchService, BranchService>();
			//======================================== Audit ==================================================
			services.AddScoped<IInventorService, InventorService>();
			//======================================== Count4U ==================================================
			services.AddScoped<ILocationService, LocationService>();
			services.AddScoped<IIturService, IturService>();
			//	services.AddScoped<IAdapterInitialazeService, AdapterInitialazeService>();

			services.AddScoped<IImportFromPdaService, ImportFromPdaService>();

			//services.AddHttpClient<IImportPdaNativPlusSqliteService, ImportPdaNativPlusSqliteService>(client =>
			//   {	   		client.Timeout = TimeSpan.FromMinutes(30);
			//});
			services.AddScoped<IFileService, FileService>();


			services.AddSingleton(new LoggerFactory());

			services.AddScoped<IWebAPISettingsService, WebAPISettingsService>();
			services.AddScoped<IWebAPISettings, WebAPISettings>();
			services.AddSingleton<IHubChatSignalRRepository, HubChatSignalRRepository>();
			services.AddSingleton<IHubCommandSignalRRepository, HubCommandSignalRRepository>();
			services.AddSingleton<ISignalRTraceService, SignalRTraceService>();

			//WebAPISettings resolveSettings = GetWebAPISettingsAsync();
			//services.AddSingleton<IWebAPISettings>(resolveSettings);      //count4uWebapiUrl Model "http://localhost:12347"

			//services.AddTransient<HubConnectionBuilder>();
		}

		//public class Program
		//{

		//    public static void Main(string[] args)
		//    {
		//        CreateHostBuilder(args).Build().Run();
		//    }

		//    public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
		//        BlazorWebAssemblyHost.CreateDefaultBuilder()
		//            .UseBlazorStartup<StartupClientBlazor>();
		//}
	}
}


//admin@admin.com
//next123
// inv.wp-funnel.com