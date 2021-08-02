//SAMPLE
//How to use
//this.logger.LogImageNotModified(imageContext.GetDisplayUrl());
//this.logger.LogImagePreconditionFailed(imageContext.GetDisplayUrl());
// this.logger.LogImageServed(imageContext.GetDisplayUrl(), key);
//https://andrewlock.net/defining-custom-logging-messages-with-loggermessage-define-in-asp-net-core/#creating-logging-delegates-with-the-loggermessage-helper

using System;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	/// <summary>
	/// Extensions methods for the <see cref="ILogger"/> interface.
	/// </summary>
	public static class CBIContextLoggerExtensions
	{
		private static readonly Action<ILogger, string, string, Exception> _controllerLogDebugPath;
		private static readonly Action<ILogger, string, string, string, Exception> _controllerLogDebugPathAndCBIContext;
		private static readonly Action<ILogger, string, Exception> _controllerLogDebugCBIContext;

		private static readonly Action<ILogger, string, string, Exception> _controllerLogInformationPath;
		private static readonly Action<ILogger, string, string, string, Exception> _controllerLogInformationPathAndCBIContext;
		private static readonly Action<ILogger, string, Exception> _controllerLogInformationCBIContext;

		/// <summary>
		/// Initializes static members of the <see cref="ControllerOnExeLoggerExtensions"/> class.
		/// </summary>
		static CBIContextLoggerExtensions()
		{
			//========= Debug ==============
			_controllerLogDebugPath = LoggerMessage.Define<string, string>(
				 logLevel: LogLevel.Debug,
				eventId: Model.EventId.ControllerLogDebugPath,
				formatString: "[{Action}] {Path}");

			_controllerLogDebugPathAndCBIContext = LoggerMessage.Define<string, string, string>(
			 logLevel: LogLevel.Debug,
			eventId: Model.EventId.ControllerLogDebugPathAndCBIContext,
			formatString: "[{Action}] {Path} [{CBIContext}]");

			_controllerLogDebugCBIContext = LoggerMessage.Define<string>(
			 logLevel: LogLevel.Debug,
			eventId: Model.EventId.ControllerLogDebugCBIContext,
			formatString: "[{CBIContext}]");

			//========= Information ==============
			_controllerLogDebugPath = LoggerMessage.Define<string, string>(
				 logLevel: LogLevel.Information,
				eventId: Model.EventId.ControllerLogInformationPath,
				formatString: "[{Action}] {Path}");

			_controllerLogDebugPathAndCBIContext = LoggerMessage.Define<string, string, string>(
			 logLevel: LogLevel.Information,
			eventId: Model.EventId.ControllerLogInformationPathAndCBIContext,
			formatString: "[{Action}] {Path} [{CBIContext}]");

			_controllerLogDebugCBIContext = LoggerMessage.Define<string>(
			 logLevel: LogLevel.Information,
			eventId: Model.EventId.ControllerLogInformationCBIContext,
			formatString: "[{CBIContext}]");
		}

		public static void ControllerLogDebugPath(this ILogger logger, string action, string path)
		{
			_controllerLogDebugPath(logger, action, path, null);
		}

		public static void ControllerLogDebugPathAndCBIContext(this ILogger logger, string action, string path, string cbiContext)
		{
			_controllerLogDebugPathAndCBIContext(logger, action, path, cbiContext, null);
		}

		public static void ControllerLogDebugCBIContext(this ILogger logger, string cbiContext)
		{
			_controllerLogDebugCBIContext(logger, cbiContext, null);
		}

		public static void ControllerLogInformationPath(this ILogger logger, string action, string path)
		{
			_controllerLogDebugPath(logger, action, path, null);
		}

		public static void ControllerLogInformationPathAndCBIContext(this ILogger logger, string action, string path, string cbiContext)
		{
			_controllerLogDebugPathAndCBIContext(logger, action, path, cbiContext, null);
		}

		public static void ControllerLogInformationCBIContext(this ILogger logger, string cbiContext)
		{
			_controllerLogDebugCBIContext(logger, cbiContext, null);
		}
	}
}