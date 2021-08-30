using System;
using Count4U.Service.Common.Filter.ActionFilterFactory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model;
using Monitor.Service.Model.Settings;
using Monitor.Service.Urls;

namespace RestApi.Local.Controllers
{
	[ApiController]
	[ServiceFilter(typeof(ControllerTraceServiceFilter))]
	public class WebApiSettingsController : ControllerBase
	{
		private IWebAPISettings _webAPISettings;
		private readonly ILogger<WebApiSettingsController> _logger;

		public WebApiSettingsController(ILoggerFactory loggerFactory,
			IWebAPISettings webAPISettings)
		{
			this._logger = loggerFactory.CreateLogger<WebApiSettingsController>();
			this._webAPISettings = webAPISettings ??
				  throw new ArgumentNullException(nameof(webAPISettings));
		}


		[AllowAnonymous]
		[Produces("application/json")]
		[HttpGet(ServerSettings.GetWebAPISettings)]
		public ActionResult<WebAPISettingsResult> GetWebAPISettings()
		{
			if (this._webAPISettings == null)
			{
				return new WebAPISettingsResult() { Successful = SuccessfulEnum.NotSuccessful, _webAPISettings = null };
			}
			return new WebAPISettingsResult() { Successful = SuccessfulEnum.Successful, _webAPISettings = this._webAPISettings as WebAPISettings };
		}

		[AllowAnonymous]
		[HttpGet(ServerSettings.Count4uWebapiUrl)]
		[Produces("application/json")]
		public ActionResult<string> GetCount4uWebAPIUrls()
		{
			if (this._webAPISettings == null)
			{
				return "";
			}
			return this._webAPISettings.count4uWebapiUrls;
		}


		[AllowAnonymous]
		[HttpGet(ServerSettings.AuthenticationWebapiUrls)]
		[Produces("application/json")]
		public ActionResult<string> GetAuthenticationWebAPIUrls()
		{
			if (this._webAPISettings == null)
			{
				return "";
			}
			return this._webAPISettings.authenticationWebapiUrls;
		}

		[AllowAnonymous]
		[HttpGet(ServerSettings.AuthenticationWebapiUrl)]
		[Produces("application/json")]
		public ActionResult<string> GetAuthenticationWebAPIUrl()
		{
			if (this._webAPISettings == null)
			{
				return string.Empty;
			}
			return this._webAPISettings.authenticationWebapiUrl;
		}

		[AllowAnonymous]
		[HttpGet(ServerSettings.MonitorWebapiUrls)]
		[Produces("application/json")]
		public ActionResult<string> GetMonitorWebAPIUrls()
		{
			if (this._webAPISettings == null)
			{
				return "";
			}
			return this._webAPISettings.monitorWebapiUrls;
		}

		[AllowAnonymous]
		[HttpGet(ServerSettings.MonitorWebapiUrl)]
		[Produces("application/json")]
		public ActionResult<string> GetMonitorWebAPIUrl()
		{
			if (this._webAPISettings == null)
			{
				return string.Empty;
			}
			return this._webAPISettings.monitorWebapiUrl;
		}


		[AllowAnonymous]
		[HttpGet(ServerSettings.GetSignalRUrls)]
		[Produces("application/json")]
		public ActionResult<string> GetSignalRUrls()
		{
			if (this._webAPISettings == null)
			{
				return "";
			}
			return this._webAPISettings.signalRHubUrls;
		}

		[AllowAnonymous]
		[HttpGet(ServerSettings.GetSignalRUrl)]
		[Produces("application/json")]
		public ActionResult<string> GetSignalRUrl()
		{
			if (this._webAPISettings == null)
			{
				return string.Empty;
			}
			return this._webAPISettings.signalRHubUrl;
		}

	}
}
