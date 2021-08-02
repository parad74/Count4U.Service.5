//SAMPLE
//How to use
//this.logger.LogImageNotModified(imageContext.GetDisplayUrl());
//this.logger.LogImagePreconditionFailed(imageContext.GetDisplayUrl());
// this.logger.LogImageServed(imageContext.GetDisplayUrl(), key);
//https://andrewlock.net/defining-custom-logging-messages-with-loggermessage-define-in-asp-net-core/#creating-logging-delegates-with-the-loggermessage-helper

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	/// <summary>
	/// Extensions methods for the <see cref="ILogger"/> interface.
	/// </summary>
	public static class ControllerOnExeLoggerExtensions
	{
		private static readonly Action<ILogger, string, Exception> _controllerOnStart;
		private static readonly Action<ILogger, string, Exception> _controllerOnEnd;
		private static readonly Action<ILogger, string, string, Exception> _controllerErrorOnStart;
		private static readonly Action<ILogger, string, string, Exception> _controllerErrorOnEnd;
		private static readonly Action<ILogger, string, string, Exception> _controllerWarningOnStart;
		private static readonly Action<ILogger, string, string, Exception> _controllerWarningOnEnd;


		/// <summary>
		/// Initializes static members of the <see cref="ControllerOnExeLoggerExtensions"/> class.
		/// </summary>
		static ControllerOnExeLoggerExtensions()
		{
			_controllerOnStart = LoggerMessage.Define<string>(
				 //logLevel: LogLevel.Debug,
				 logLevel: LogLevel.Information,
				eventId: Model.EventId.ControllerOnStart,
				formatString: "		On Start {Uri}");

			_controllerOnEnd = LoggerMessage.Define<string>(
			 //logLevel: LogLevel.Debug,
			 logLevel: LogLevel.Information,
			eventId: Model.EventId.ControllerOnEnd,
			formatString: "		On End {Uri}");

			_controllerErrorOnStart = LoggerMessage.Define<string, string>(
				 logLevel: LogLevel.Error,
				eventId: Model.EventId.ControllerErrorOnStart,
				formatString: "		ERROR On Start {Uri} >> {Exception}");

			_controllerErrorOnEnd = LoggerMessage.Define<string, string>(
			 logLevel: LogLevel.Error,
			eventId: Model.EventId.ControllerErrorOnEnd,
			formatString: "		ERROR On End {Uri} >> {Exception}");

			_controllerWarningOnStart = LoggerMessage.Define<string, string>(
				 logLevel: LogLevel.Warning,
				eventId: Model.EventId.ControllerWarningOnStart,
				formatString: "		Warning On Start {Uri} >> {Warning}");

			_controllerWarningOnEnd = LoggerMessage.Define<string, string>(
			 logLevel: LogLevel.Warning,
			eventId: Model.EventId.ControllerWarningOnEnd,
			formatString: "		Warning On End {Uri} >> {Warning}");


		}


		public static void ControllerOnStart(this ILogger logger, HttpContext httpContext, RouteData routeData)
		{
			//context.RouteData.Values. - доступно в actionFilter
			if (httpContext == null)
				return;
			if (httpContext.Request == null)
				return;

			PathString url = httpContext.Request.Path;
			if (url == null)
			{
				_controllerWarningOnStart(logger, "", "Url Is Empty", null);
				return;  //ERROR
			}

			if (routeData == null)
			{
				_controllerWarningOnStart(logger, url.ToString(), "RouteData Is Null", null);
				return;  //ERROR
			}
			try
			{
				using (logger.BeginScope(routeData))       //!!! Exceptions inside scope blocks lose the scope
				{
					_controllerOnStart(logger, url.ToString(), null);
				}
			}
			catch (Exception ex) when (LogError(ex))       //Теперь , когда происходит исключение, он регистрируется со всеми активными областями в точке происходит исключение ( Scope, WithValueили ViaDictionary), а не из активных областей внутри catchблока.
			{
				_controllerErrorOnStart(logger, url.ToString(), ex.Message, ex);
			}
		}
		//!!!  код в фильтре исключений выполняется в том же контексте, в котором произошло исходное исключение 
		// стек не поврежден и выгружается только в том случае, если фильтр исключений оценивает к true.

		public static void ControllerOnEnd(this ILogger logger, HttpContext httpContext, RouteData routeData)
		{
			if (httpContext == null)
				return;
			if (httpContext.Request == null)
				return;

			PathString url = httpContext.Request.Path;
			if (url == null)
			{
				_controllerWarningOnStart(logger, "", "Url Is Empty", null);
				return;  //ERROR
			}
			if (routeData == null)
			{
				_controllerWarningOnEnd(logger, url.ToString(), "RouteData Is Null", null);
				return;  //ERROR
			}
			//using (logger.BeginScope("{Controller}", routeData.Values["controller"]))
			//using (logger.BeginScope("{Action}", routeData.Values["action"]))
			try
			{
				using (logger.BeginScope(routeData.Values))
				{
					_controllerOnEnd(logger, url.ToString(), null);
				}
			}
			catch (Exception ex) when (LogError(ex))       //Теперь , когда происходит исключение, он регистрируется со всеми активными областями в точке происходит исключение ( Scope, WithValueили ViaDictionary), а не из активных областей внутри catchблока.
			{
				_controllerErrorOnEnd(logger, url.ToString(), ex.Message, ex);
			}
		}

		static bool LogError(Exception ex)
		{
			return true;
		}


	}
}