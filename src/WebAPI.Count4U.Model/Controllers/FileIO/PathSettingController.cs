using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Count4U.Common.Constants;
using Count4U.Model.Audit;
using Count4U.Model.Common;
using Count4U.Model.Interface;
using Count4U.Service.Common;
using Monitor.Service.Urls;
using Count4U.Service.Contract;
using Count4U.Service.WebAPI.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model;

namespace Count4U.Service.Server.Controllers
{
    //Работает
    //[Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
	[Consumes("application/json")]
	[ServiceFilter(typeof(ControllerDb3ContextServiceFilter))]
    public class PathSettingController : ControllerBase
    {
        private readonly ILogger<PathSettingController> _logger;
        private readonly ICount4uContext _count4uContext;
		private readonly  ISettingsdb3Repository _settingsdb3Repository;
		public PathSettingController(
             ILoggerFactory loggerFactory
            , ICount4uContext count4uContext
			, ISettingsdb3Repository settingsdb3Repository )
        {
            this._logger = loggerFactory.CreateLogger<PathSettingController>();
            this._count4uContext = count4uContext ??
                        throw new ArgumentNullException(nameof(count4uContext));
			this._settingsdb3Repository = settingsdb3Repository ??
					   throw new ArgumentNullException(nameof(settingsdb3Repository));

        }

         //Работает
        //[HttpGet]
        [HttpGet(WebApiCount4UPathSetting.FromPdaProcessPath)]
        public ActionResult<string> FromPdaProcessPath()
        {
            string path = _settingsdb3Repository.FromPdaProcessPath;
            return path;
        }


       [HttpGet(WebApiCount4UPathSetting.GetFilesInfoInDataFolder)]
        public ActionResult<List<FileInfo>> GetFilesInfoInDataFolder()
        {
            var filesInDataFolder = _settingsdb3Repository.FilesInDataFolder;
            return filesInDataFolder;
        }
        
        [HttpGet(WebApiCount4UPathSetting.GetFilesItemInDataFolder)]
        public ActionResult<FileItems> GetFilesItemInDataFolder()
         {
            FileItems retFileItemList = new FileItems();
            List<FileInfo> filesInfoList = _settingsdb3Repository.FilesInDataFolder;
            if (filesInfoList == null)
                return retFileItemList;
            foreach (FileInfo filesInfo in filesInfoList)
            {
                try
                {
                    FileItem fileItem = filesInfo.ToFileItem();
                    retFileItemList.Add(fileItem);
                }
                catch { }
            }
            return retFileItemList;
        }

     

	}
}

