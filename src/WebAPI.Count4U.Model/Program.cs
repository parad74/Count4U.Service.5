using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace Count4U.Service.WebAPI.Model
{
	public class Program
	{
		private static readonly UnityContainer _container = new UnityContainer();

		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
		   .UseUnityServiceProvider(_container)// < ----or add this line
											   //.UseUrls("http://0.0.0.0:12347")
												.UseUrls("http://localhost:12347")
		  .UseStartup<StartupModelWebAPI>()
		   .Build();

		//https://weblog.west-wind.com/posts/2016/sep/28/external-network-access-to-kestrel-and-iis-express-in-aspnet-core
		//netsh advfirewall firewall add rule name = "Http Port 12347" dir=in action=allow protocol = TCP localport=12347
		//https://dotnetcoretutorials.com/2018/09/12/hosting-an-asp-net-core-web-application-as-a-windows-service/
		/* работает!
		 * public static void Main(string[] args)
		{
			// проверяет, используем ли мы отладчик, или передан ли нам консольный аргумент «–console».
			var isService = !(Debugger.IsAttached || args.Contains("--console"));
			var builder = CreateWebHostBuilder(args.Where(arg => arg != "--console").ToArray());

			//Если ни один из вышеперечисленных не верен, он вручную устанавливает корневой каталог
			//содержимого в том месте, где работает исполняемый файл. Это специально для службы времени выполнения
			if (isService)
			{
				var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
				var pathToContentRoot = Path.GetDirectoryName(pathToExe);
				builder.UseContentRoot(pathToContentRoot);
			}

			var host = builder.Build();

			//	Затем, если мы являемся сервисом, мы используем специальный метод RunAsService(), который нам дает.NET Core.
			//В противном случае мы просто делаем «Run()» как обычно.
			if (isService)
			{
				host.RunAsService();
			}
			else
			{
				host.Run();
			}
		}
		
		 //Windows service
		public static void Main(string[] args)
{
    var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
    var pathToContentRoot = Path.GetDirectoryName(pathToExe);
 
    var host = WebHost.CreateDefaultBuilder(args)
        .UseContentRoot(pathToContentRoot)
        .UseStartup<Startup>()
        .Build();
 
    host.RunAsService();
}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			//var h = new WebHostBuilder();
			//var environment = h.GetSetting("environment");
			//var builder = new ConfigurationBuilder()
			//		.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			//		.AddJsonFile($"appsettings.{environment}.json", optional: true)
			//		.AddEnvironmentVariables();
			//var configuration = builder.Build();

			var h = new WebHostBuilder();
		//	var environment = h.GetSetting("environment");
			var config = new ConfigurationBuilder()
			   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			 //  .AddJsonFile($"appsettings.{environment}.json", optional: true)
			   .AddEnvironmentVariables()
			   .AddCommandLine(args)
			   .Build();

			var hostUrl = config["hosturl"];

			if (string.IsNullOrEmpty(hostUrl))	 hostUrl = "http://localhost:12347";

			var host = WebHost.CreateDefaultBuilder(args)
		   .UseUnityServiceProvider(_container)// < ----or add this line
											   .UseUrls(hostUrl)
		  //.UseStartup<StartupWithServer>()
		  .UseStartup<StartupWebAPI>();
		  // .Build();
			
			return host;
		}			   */


	}
}


//netsh advfirewall firewall add rule name = "Http Port 8500" dir=in action=allow protocol = TCP localport=8500
//netsh advfirewall firewall add rule name = "Http Port 8600" dir=in action=allow protocol = TCP localport=8600

//test ftp://91.122.30.115/