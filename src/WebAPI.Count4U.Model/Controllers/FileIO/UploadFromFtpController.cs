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
    public class UploadFromFtpController : ControllerBase
    {
        private readonly ILogger<UploadFromFtpController> _logger;
        private readonly ICount4uContext _count4uContext;
        private readonly IWebHostEnvironment _environment;
		private readonly IDBSettings _dbSettings;
		private readonly  ISettingsdb3Repository _settingsdb3Repository;
		public UploadFromFtpController(
             ILoggerFactory loggerFactory
            , ICount4uContext count4uContext
			, ISettingsdb3Repository settingsdb3Repository
			,IDBSettings dbSettings
		   , IWebHostEnvironment environment)
        {
            this._logger = loggerFactory.CreateLogger<UploadFromFtpController>();
            this._count4uContext = count4uContext ??
                        throw new ArgumentNullException(nameof(count4uContext));
			this._dbSettings = dbSettings ??
					   throw new ArgumentNullException(nameof(dbSettings));
			this._settingsdb3Repository = settingsdb3Repository ??
					   throw new ArgumentNullException(nameof(settingsdb3Repository));
			this._environment = environment ??
                      throw new ArgumentNullException(nameof(environment));
        }

         //Работает
        [HttpPost]
        public async Task Post()
        {
			string pathtest = _settingsdb3Repository.ToPdaPath;
            if (HttpContext.Request.Form.Files.Any()) {
                foreach (var file in HttpContext.Request.Form.Files) {
                    var path = Path.Combine("C:", "uploads", file.FileName); //environment.ContentRootPath
                    using (var stream = new FileStream(path, FileMode.Create)) {
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }



	}
}

