using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Count4U.Service.Model;
using Count4U.Service.Contract;

namespace Count4U.Service.Common
{
	/// <summary>
	/// Extensions methods for the <see cref="ILogger"/> interface.
	/// </summary>
	public static class CommandResultLoggerExtensions
	{
		private static readonly Action<ILogger, string, Exception> _controllerLogDebugCommandResult;

		/// <summary>
		/// Initializes static members of the <see cref="ControllerOnExeLoggerExtensions"/> class.
		/// </summary>
		static CommandResultLoggerExtensions()
		{
			//========= Debug ==============
			_controllerLogDebugCommandResult = LoggerMessage.Define<string>(
				 logLevel: LogLevel.Information,
				eventId: Model.EventId.ControllerLogInformationCommandResult,
				formatString: "${command}");

			}

		public static void ControllerLogDebugCommandResult(this ILogger logger, string command)
		{
			_controllerLogDebugCommandResult(logger, command, null);
		}

	
	}
}