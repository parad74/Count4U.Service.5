using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Count4U.Model.Audit;
using Count4U.Model.Common;
using Count4U.Model.Interface;
using Count4U.Service.Common;
using Count4U.Service.WebAPI.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Model;
using Monitor.Service.Model;

namespace Count4U.Service.Server.Controllers
{
    //Работает
    [Route("[controller]")]
    [ApiController]
	[ServiceFilter(typeof(ControllerDb3ContextServiceFilter))]
    public class Download4UnZipToInDataController : ControllerBase
    {
        private readonly ILogger<Download4UnZipToInDataController> _logger;
        private readonly ICount4uContext _count4uContext;
		private readonly  ISettingsdb3Repository _settingsdb3Repository;
		public Download4UnZipToInDataController(
             ILoggerFactory loggerFactory
            , ICount4uContext count4uContext
			, ISettingsdb3Repository settingsdb3Repository 
		   )
        {
            this._logger = loggerFactory.CreateLogger<Download4UnZipToInDataController>();
            this._count4uContext = count4uContext ??
                        throw new ArgumentNullException(nameof(count4uContext));
			this._settingsdb3Repository = settingsdb3Repository ??
					   throw new ArgumentNullException(nameof(settingsdb3Repository));
       }

         //Работает
        [HttpGet]
        public async Task Get()
        {
             if (HttpContext.Request.Form.Files.Any()) 
            {
                foreach (var file in HttpContext.Request.Form.Files) 
                 {
                   	string path = _settingsdb3Repository.GetPathForInDataZip(file.Name);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }



	}
}

