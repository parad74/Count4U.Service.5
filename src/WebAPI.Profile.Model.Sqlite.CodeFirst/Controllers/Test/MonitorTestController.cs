using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unity;
using CommonServiceLocator;
using System.Data.Common;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Count4U.Service.Shared;
using Monitor.Service.Model;
using Monitor.Service.Model.Settings;

namespace WebAPI.Monitor.Sqlite.CodeFirst.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MonitorTestController : ControllerBase
	{
		private readonly ILogger<MonitorTestController> _logger;
		IUnityContainer _container;
		IServiceLocator _serviceLocator;
		//IWeatherForecastWebApi _weatherForecast;
		IWebHostEnvironment _environment;
		Count4uSettings _count4USettings;
		private readonly IJwtService _jwtService;

		public MonitorTestController(
			IWebHostEnvironment environment,
			 ILoggerFactory loggerFactory,
			IServiceLocator serviceLocator,
			IUnityContainer container
			//IWeatherForecastWebApi weatherForecast
			, Count4uSettings count4USettings
			, IJwtService jwtService
			)
		{
			_logger = loggerFactory.CreateLogger<MonitorTestController>();
			_container = container;
			_serviceLocator = serviceLocator;
			//_weatherForecast = weatherForecast;
			//_weatherForecast.TemperatureC = 5;
			_environment = environment;
			_jwtService = jwtService;

			_count4USettings = count4USettings;
			// Verify controller was created by Unity container
			//Debug.Assert(null != container);
		}

		//public async Task<ContentResult> Connect()
		//   public async Task<ActionResult<Product>> CreateAsync(Product product)
		//[HttpGet("sp")]
		//public IEnumerable<int> sp([FromServices] IServiceProvider serviceProvider)
		//{
		//	List<int> result = new List<int>();
		//	result.Add(3);
		//	IWeatherForecastWebApi service = (IWeatherForecastWebApi)serviceProvider.GetService(typeof(IWeatherForecastWebApi));
		//	IWeatherForecastWebApi weatherForecastTest = serviceProvider.GetService<IWeatherForecastWebApi>();
		//	try
		//	{
		//		int vv = _weatherForecast.TemperatureC++;
		//		result.Add(vv);
		//		vv = service.TemperatureC;
		//		result.Add(vv);
		//	}
		//	catch { }

		//	return result;
		//}

		//[HttpGet("show")]
		//public IEnumerable<int> Show([FromServices] IWeatherForecastWebApi weatherForecast)
		//{

		//	int ret = weatherForecast.TemperatureC;
		//	List<int> result = new List<int>();
		//	result.Add(2);
		//	try
		//	{
		//		int vv = _weatherForecast.TemperatureC;
		//		result.Add(vv);
		//	}
		//	catch { }

		//	return result;
		//}


		//[HttpGet("name")]
		//public IEnumerable<string> name()
		//{
		//	var vNotTest = _container.Resolve<IWeatherForecastTest>("WeatherForecastTest");
		//	var vTest = _container.Resolve<IWeatherForecastTest>("WeatherForecastTest1");

		//	List<string> result = new List<string>();
		//	result.Add("name");
		//	try
		//	{
		//		string vv = vNotTest.Summary;
		//		result.Add(vv);
		//		string vv1 = vTest.Summary;
		//		result.Add(vv1);
		//	}

		//	catch { }

		//	return result;

		//}

		//[HttpGet("sl")]
		//public IEnumerable<string> sl()
		//{

		//	IWeatherForecastTest vNotTest = _serviceLocator.GetInstance<IWeatherForecastTest>("WeatherForecastTest");
		//	IWeatherForecastTest vTest = _serviceLocator.GetInstance<IWeatherForecastTest>("WeatherForecastTest1");

		//	List<string> result = new List<string>();
		//	result.Add("name");
		//	try
		//	{
		//		string vv = vNotTest.Summary;
		//		result.Add(vv);
		//		string vv1 = vTest.Summary;
		//		result.Add(vv1);
		//	}

		//	catch { }

		//	return result;
		//}

		////[HttpGet]
		////public IEnumerable<WeatherForecast> Get()
		////{
		////	var rng = new Random();
		////	return Enumerable.Range(1, 5).Select(index => new WeatherForecast
		////	{
		////		Date = DateTime.Now.AddDays(index),
		////		TemperatureC = rng.Next(-20, 55),
		////		Summary = Summaries[rng.Next(Summaries.Length)]
		////	})
		////	.ToArray();
		////}

		//[HttpGet]
		//public IEnumerable<int> Get()
		//{
		////	IWeatherForecast ttt = _serviceLocator.GetInstance<IWeatherForecast>();
		//	List<int> result = new List<int>();
		//	result.Add(1);
		//	try
		//	{
		//		_weatherForecast.TemperatureC = 25;
		//		int vv = _weatherForecast.TemperatureC++;

		//		result.Add(vv);
		//		//ttt.TemperatureC = 777;
		//		//int vv7 = ttt.TemperatureC + 1;
		//		//result.Add(vv7);
		//	}
		//	catch { }
		//	return result;

		//}


		//[HttpGet("CommandResultADO")]
		//public IEnumerable<string> CommandResultADO()
		//{
		//	List<string> customers = new List<string>();
		//	DbProviderFactories.RegisterFactory("System.Data.SqlServerCe.4.0", new SqlCeProviderFactory());
		//	var pp = DbProviderFactories.GetFactory("System.Data.SqlServerCe.4.0");
		//	string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\App_Data";


		//	//ADO - work!!!
		//	using (DbConnection connection = pp.CreateConnection())       //System.Data.SqlServerCe.SqlCeConnection
		//	{
		//		connection.ConnectionString = @"Data Source = " + path + @"\MonitorDB.sdf";
		//		connection.Open();
		//		using (DbCommand command = connection.CreateCommand())
		//		{
		//			command.CommandText = "select * from [CommandResult]	";
		//			command.CommandType = CommandType.Text;

		//			using (DbDataReader reader = command.ExecuteReader())
		//			{
		//				while (reader.Read())
		//				{
		//					var result = reader.GetValue(3);
		//					if (!reader.IsDBNull(0))
		//					{
		//						var customer = result;
		//						customers.Add(customer as String);
		//					}
		//				}
		//			}
		//		}
		//	}
		//	return customers;
		//}



		//[HttpGet("context")]
		//public IEnumerable<Customer> GetCustomersContext()
		//{
		//	//C:\ProgramData\Count4U\App_Data
		//	string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\App_Data";
		//	List<Customer> entertiList = new List<Customer>();
		//	//ObjectContext	   work!!!
		//	var cs = @"metadata=res://*/App_Data.MainDB.csdl|res://*/App_Data.MainDB.ssdl|res://*/App_Data.MainDB.msl;provider=System.Data.SqlServerCe.4.0;provider connection string='Data Source =" + path + @"\MainDB.sdf'";

		//	using (MainDB dc = new MainDB(cs))
		//	{
		//		try
		//		{
		//			var entertis = dc.Customer;
		//			entertiList = entertis.ToList();
		//		}
		//		catch (Exception ext)
		//		{
		//			string message = ext.Message;
		//		}
		//	}

		//	return entertiList;
		//}

		//[HttpGet("pro")]
		//public IEnumerable<Count4U.Model.App_Data.Process> GetProcessDBContext()
		//{
		//	//C:\ProgramData\Count4U\App_Data
		//	string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\App_Data";
		//	List<Count4U.Model.App_Data.Process> entertiList = new List<Count4U.Model.App_Data.Process>();
		//	//ObjectContext	   work!!!
		//	//var cs = @"metadata=res://*/App_Data.MainDB.csdl|res://*/App_Data.MainDB.ssdl|res://*/App_Data.MainDB.msl;provider=System.Data.SqlServerCe.4.0;provider connection string='Data Source =" + path + @"\MainDB.sdf'";
		//	var cs = @"metadata=res://*/App_Data.ProcessDB.csdl|res://*/App_Data.ProcessDB.ssdl|res://*/App_Data.ProcessDB.msl;provider=System.Data.SqlServerCe.4.0;provider connection string='Data Source=" + path + @"\ProcessDB.sdf'";

		//	using (ProcessDB dc = new ProcessDB(cs))
		//	{
		//		try
		//		{
		//			var entertis = dc.Process;
		//			entertiList = entertis.ToList();
		//		}
		//		catch (Exception ext)
		//		{
		//			string message = ext.Message;
		//		}
		//	}

		//	return entertiList;
		//}


		//[HttpGet("rep")]
		//public IEnumerable<Count4U.Model.ProcessC4U.Process> GetProcessProcessRepository([FromServices] IProcessRepository processRepository)
		//{
		//	//IProcessRepository processRepository = serviceLocator.GetInstance<IProcessRepository>();
		//	var processes = processRepository.GetProcesses();

		//	return processes;
		//}


		//[HttpGet("count4u")]
		//public ActionResult<string> GetCount4UContext([FromServices] IDBSettings dbSettings)
		//{
		//	string processCode = dbSettings.ProcessCode;
		//	StringValues accessKey = new StringValues();
		//	this.HttpContext.Request.Headers.TryGetValue(ClaimEnum.AccessKey.ToString(), out accessKey);
		//	return processCode;
		//}

		////Тест синхронный
		//[HttpGet("[action]")]
		//public ActionResult<IEnumerable<ClaimConvertItem>> GetClaimWebApiConvertItems([FromServices] IDBSettings dbSettings)
		//{
		//	string processCode = dbSettings.ProcessCode;
		//	StringValues accessKey = new StringValues();
		//	this.HttpContext.Request.Headers.TryGetValue(ClaimEnum.AccessKey.ToString(), out accessKey);


		//	List<ClaimConvertItem> retList = new List<ClaimConvertItem>();
		//	StringValues savedTokens = new StringValues();
		//	 this.HttpContext.Request.Headers.TryGetValue(HeaderNames.Authorization, out savedTokens);
		//	if (savedTokens.Count == 0)
		//		return NotFound();
		//	//this.HttpContext.Response.Headers.Add(HeaderNames.Authorization, savedTokens);
		//	string savedToken = savedTokens[0];

		//	ClaimsPrincipal authenticatedUser = _jwtService.GetClaimsPrincipalFromToken(savedToken);
		//	//ClaimsPrincipal authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt"));
		//	if (authenticatedUser == null)
		//		return NotFound();
		//	if (authenticatedUser.Claims == null)
		//		return NotFound();

		//	var claimList = authenticatedUser.Claims.ToList();
		//	if (claimList == null)
		//		return NotFound(); 

		//	foreach (var claim in claimList)
		//	{
		//		string name = claim.Subject != null ? claim.Subject.Name : "";
		//		string type = claim.Type != null ? claim.Type : "";
		//		string claimType = type.Split('/', '_').Last();
		//		ClaimConvertItem ret = new ClaimConvertItem(name, claim.Issuer, claimType, claim.Value);
		//		retList.Add(ret);
		//	}

		//	return Ok(retList);
		//}


	}
}
