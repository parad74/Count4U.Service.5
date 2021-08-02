using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Monitor.Sqlite.CodeFirst;
using Unity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using Unity.Microsoft.DependencyInjection;

namespace WebAPI.Monitor.Sqlite.CodeFirst
{
	public class Program
	{
		private static readonly UnityContainer _container = new UnityContainer();

		public static void Main(string[] args)
		{

		//	BuildWebHost(args).Run();
          IWebHost host = BuildWebHost(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
		}
	    private static void CreateDbIfNotExists(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<MonitorSqliteDBContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

		public static IWebHostBuilder BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
		   .UseUnityServiceProvider(_container)// < ----or add this line
											   .UseUrls("http://0.0.0.0:12389")
		  .UseStartup<StartupMonitorModelWebAPI>();
		   //.Build();
	}
}
	//===================
//WebAPI.Monitor.Model.CE.CodeFirst: "http://localhost:12359"
//WebAPI.Monitor.Model.CE.DBFirst: "http://localhost:12349
//WebAPI.Monitor.Model.MSSQL.CodeFirst:  "http://localhost:12379"
//WebAPI.Monitor.Model.Sqlite.CodeFirst:  "http://localhost:12389"

 