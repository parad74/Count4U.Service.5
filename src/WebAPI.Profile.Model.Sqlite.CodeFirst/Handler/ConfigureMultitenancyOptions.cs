//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using Monitor.Sqlite.CodeFirst;

//namespace WebAPI.Monitor.Model.Sqlite.CodeFirst
//{
//public class ConfigureMultitenancyOptions : IConfigureOptions<string>
//{
//    private readonly IServiceScopeFactory _serviceScopeFactory;
//    public ConfigureMultitenancyOptions(IServiceScopeFactory serviceScopeFactory)
//    {
//        _serviceScopeFactory = serviceScopeFactory;
//    }
//		public void Configure(string options)
//		{
//			 var cs = @"Data Source=command.db";
//            // workaround:
//        DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
//        using (var scope = _serviceScopeFactory.CreateScope())
//        {
//            var provider = scope.ServiceProvider;
//            using (var dbContext = provider.GetRequiredService<MonitorSqliteDBContext>())
//            {
//               dbContext.Database.CreateIfNotExists();
//               dbContext.SaveChanges();

//            }
//        }
//		}
//	}
//}
