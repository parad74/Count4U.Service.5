using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Count4U.Admin.Server
{
	public class Program
	{

		public static void Main(string[] args)
		{
			BuildWebHost(args).Run(); 
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
											  .UseUrls(@"http://localhost:21020")
		  .UseStartup<StartupAdminServer>()
		   .Build();


		//netsh advfirewall firewall add rule name = "Http Port 27027" dir=in action=allow protocol = TCP localport=27027
		//netsh advfirewall firewall add rule name = "Http Port 27515" dir=in action=allow protocol = TCP localport=27515


		//public static void Main(string[] args)
		//{
		//	CreateHostBuilder(args).Build().Run();
		//}

		//public static IHostBuilder CreateHostBuilder(string[] args) =>
		//	Host.CreateDefaultBuilder(args) //Host.CreateDefaultBuilder(), Это настраивает конфигурацию приложения, ведение журнала и контейнер внедрения зависимости.
		//									//.UseUnityServiceProvider()   // Add Unity as default Service Provider
		//		.ConfigureWebHostDefaults(webBuilder =>     //IHostBuilder.ConfigureWebHostDefaults(), Это добавляет все остальное, необходимое для типичного приложения ASP.NET Core, например, настройку Kestrel и использование Startup.cs для настройки контейнера DI и конвейера промежуточного программного обеспечения.
		//		{
		//			webBuilder.UseStartup<StartupServer>();
		//		})
		//	// Add a new service provider configuration
		//	.UseDefaultServiceProvider((context, options) =>
		//	{
		//		options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
		//		options.ValidateOnBuild = true;        //Это позволяет контейнеру Microsoft.Extensions DI проверять наличие ошибок в конфигурации службы при первом создании поставщика услуг. https://andrewlock.net/new-in-asp-net-core-3-service-provider-validation/
		//	});
	}

	//	public static IHostBuilder CreateHostBuilder(string[] args) =>
	//		Host.CreateDefaultBuilder(args) //Host.CreateDefaultBuilder(), Это настраивает конфигурацию приложения, ведение журнала и контейнер внедрения зависимости.
	//			//.UseUnityServiceProvider()   // Add Unity as default Service Provider
	//			.ConfigureWebHostDefaults(webBuilder =>     //IHostBuilder.ConfigureWebHostDefaults(), Это добавляет все остальное, необходимое для типичного приложения ASP.NET Core, например, настройку Kestrel и использование Startup.cs для настройки контейнера DI и конвейера промежуточного программного обеспечения.
	//			{
	//				webBuilder.UseUrls("http://localhost:27577").UseStartup<StartupServer>();
	//			})
	//		 // Add a new service provider configuration
	//		.UseDefaultServiceProvider((context, options) =>
	//		{
	//			options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
	//			options.ValidateOnBuild = true;        //Это позволяет контейнеру Microsoft.Extensions DI проверять наличие ошибок в конфигурации службы при первом создании поставщика услуг. https://andrewlock.net/new-in-asp-net-core-3-service-provider-validation/
	//		});
	//}

	// См что в   https://andrewlock.net/exploring-the-new-project-file-program-and-the-generic-host-in-asp-net-core-3/
	//Не настраивает ничего конкретного для веб-хостинга.
	//public static IHostBuilder CreateDefaultBuilder(string[] args)
	//{
	//	var builder = new HostBuilder();

	//	builder.UseContentRoot(Directory.GetCurrentDirectory());
	//	builder.ConfigureHostConfiguration(config =>
	//	{
	//		// Uses DOTNET_ environment variables and command line args	  
	//	//Использует DOTNET_префикс для конфигурации хостинга переменных среды
	//	});

	//	builder.ConfigureAppConfiguration((hostingContext, config) =>
	//	{
	//		// JSON files, User secrets, environment variables and command line arguments
	//     //Использует переменные командной строки для конфигурации хостинга
	//	})
	//	.ConfigureLogging((hostingContext, logging) =>
	//	{
	//	// Adds loggers for console, debug, event source, and EventLog (Windows only)
	//Добавляет EventSourceLoggerи EventLogLogger регистратор провайдеров
	//})
	//	.UseDefaultServiceProvider((context, options) =>
	//	{
	//	// Configures DI provider validation
	////Опционально включает проверку ServiceProvider
	//});

	//	return builder;
	//}

	//public class Program
	//{
	//	public static void Main(string[] args)
	//	{
	//		//CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
	//		BuildWebHost(args).Run();
	//	}
	//	public static IWebHost BuildWebHost(string[] args) =>
	//  WebHost.CreateDefaultBuilder(args)
	//   .UseConfiguration(new ConfigurationBuilder()
	//	   .AddCommandLine(args)
	//	   .Build())
	//   .UseStartup<Startup>()
	//  //.ConfigureLogging(logging =>
	//  //{
	//  //	logging.ClearProviders();
	//  //	logging.AddConsole();
	//  //})
	//  .Build();
	//}

	//public static IWebHostBuilder BuildWebHost(string[] args) =>
	//WebHost.CreateDefaultBuilder(args)
	//	.UseStartup<Startup>()
	//	.ConfigureLogging(logging =>
	//	{
	//		logging.ClearProviders();  // <---------- clear console etc
	//		logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
	//	})
	//	.UseNLog();  // NLog: setup NLog for Dependency injection
}
//dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true

//https://dotnetcoretutorials.com/2019/06/20/publishing-a-single-exe-file-in-net-core-3-0/

//Чтобы опубликовать приложение .NET Core как автономное, вам нужно
//запустить следующую команду из каталога проекта в командной строке / powershell:
//dotnet publish --configuration Release --self-contained -r win10-x64
//dotnet publish -r win-x64 -c Release --self-contained
//dotnet publish -c Release -r win-x64 --self-contained true

//Это из MSDN
//dotnet publish -c Release -r <RID> --self-contained true
//Мы делаем публикацию, используя конфигурацию релиза, мы проходим через самодостаточный флаг и проходим,
//	что среда выполнения, для которой мы создаем, является Windows 10 - 64-битной.
//Из каталога вашего проекта вы можете перейти по адресу :  \ bin \ Release \ netcoreapp2.1 \ win10-x64 \ publish
//Вы можете скопировать и вставить эту папку публикации на любой компьютер с Windows 10
//https://dotnetcoretutorials.com/2018/09/12/hosting-an-asp-net-core-web-application-as-a-windows-service/
//Во-первых, нам нужно выполнить несколько изменений кода, чтобы наше приложение работало как в качестве службы, 
//и все еще работало как исполняемый файл(как для целей отладки, так и в случае, если мы хотим работать в окне консоли, а не как служба).
// Нам нужно установить следующее из консоли диспетчера пакетов:
//Install-Package Microsoft.AspNetCore.Hosting.WindowsServices
//Далее нам нужно зайти в наш program.exe и сделать так, чтобы ваш основной метод выглядел следующим образом:


//public static void Main(string[] args)
//{
//	var isService = !(Debugger.IsAttached || args.Contains("--console"));
//	var builder = CreateWebHostBuilder(args.Where(arg => arg != "--console").ToArray());

//	if (isService)
//	{
//		var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
//		var pathToContentRoot = Path.GetDirectoryName(pathToExe);
//		builder.UseContentRoot(pathToContentRoot);
//	}

//	var host = builder.Build();

//	if (isService)
//	{
//		host.RunAsService();
//	}
//	else
//	{
//		host.Run();
//	}
//}



//dotnet publish -c Release -r <RID> --self-contained true
//https://medium.com/bluekiri/packaging-a-net-core-service-for-ubuntu-4f8e9202d1e5 ubuntu  
//$ dotnet publish -c Release --self-contained -r ubuntu.18.04-x64

//при необходимости запуска задач при старет приложения 
//public static async Task Main(string[] args)
//{
//	IWebHost webHost = CreateWebHostBuilder(args).Build();

//	// Create a new scope
//	using (var scope = webHost.Services.CreateScope())
//	{
//		// Get the DbContext instance
//		var myDbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

//		//Do the migration asynchronously
//		await myDbContext.Database.MigrateAsync();
//	}

//	// Run the WebHost, and start listeningaccepting requests
//	// There's an async overload, so we may as well use it
//	await webHost.RunAsync();
//}