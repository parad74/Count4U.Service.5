using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model.Settings;
using System.Collections.Generic;
using Count4U.Model.Interface.Count4U;
using Count4U.Model.Count4U;
using Count4U.Service.Common;
using System;
using Monitor.Service.Urls;
using Count4U.Model.Interface;
using Monitor.Service.Model;

namespace Count4U.Service.WebAPI.Model.Controllers
{
	[ApiController]
//	[Route("api/[controller]")]
	public class LocationController : ControllerBase
	{
		private readonly ILogger<LocationController> _logger;
		private readonly ILocationRepository _locationRepository;
		private readonly ICount4uContext _count4uContext;
		private readonly IConnectionDB _connectionDB;

		//private readonly IUnityContainer _container;
		//private readonly IServiceLocator _serviceLocator;
		public LocationController(
			  ILoggerFactory loggerFactory
			, ICount4uContext count4uContext
			, ILocationRepository locationRepository
			, IConnectionDB connectionDB
			//,IServiceLocator serviceLocator
			//,IUnityContainer container 
			)
		{
			this._logger = loggerFactory.CreateLogger<LocationController>();
			this._count4uContext = count4uContext ??
					throw new ArgumentNullException(nameof(count4uContext));
			this._locationRepository = locationRepository ??
						   throw new ArgumentNullException(nameof(locationRepository));
			this._connectionDB = connectionDB ??
						   throw new ArgumentNullException(nameof(connectionDB));

			

			//_serviceLocator = serviceLocator;
			//_container = container;
		}

		//Locations GetLocations(string pathDB);
		[HttpGet(WebApiCount4UModelLocation.GetLocations)]
		public ActionResult<IEnumerable<Location>> GetLocations()
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return null;//return NotFound();
			Locations locations = this._locationRepository.GetLocations($"Inventor\\{_count4uContext.DBPath}");
			//if (locations == null) return NotFound();
			return locations;
		}

		

	}
}

//Locations GetLocations(string pathDB);
//Locations GetLocations(int topCount, string pathDB);
//Locations GetLocations(SelectParams selectParams, string pathDB);
//Location GetLocationByName(string name, string pathDB);
//Location GetLocationByCode(string code, string pathDB);
//void Delete(Location location, string pathDB);
//void DeleteAll(string pathDB);
//void Insert(Location location, string pathDB);
//void Insert(List<Location> locations, string pathDB);
//void Update(Location location, string pathDB);
//void Update(Locations locations, string pathDB);
//Dictionary<string, Location> GetLocationDictionary(string pathDB, bool refill = false);
//void ClearLocationDictionary();
//void AddLocationInDictionary(string code, Location location);
//void RemoveLocationFromDictionary(string code);
//bool IsExistLocationInDictionary(string code);
//Location GetLocationByCodeFromDictionary(string code);
//void FillLocationDictionary(string pathDB);
//List<string> GetLocationCodeList(string pathDB);
//List<string> GetLocationCodeListByTag(string pathDB, string tag);
//List<string> GetLocationCodeListIncludedTag(string pathDB, string tag);
//Locations GetLocationListByTag(string pathDB, string tag);
//void RepairCodeFromDB(string pathDB);
//string GetFistLocationCodeWithoutIturs(string pathDB);
//string GetFistLocationCodeWithoutIturs(Locations locations, string pathDB);
