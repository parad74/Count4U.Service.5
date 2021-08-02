using System;
using Microsoft.Extensions.Logging;

namespace WebAPI.Monitor.Sqlite.CodeFirst
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
				eventId: Count4U.Service.Model.EventId.ControllerLogInformationCommandResult,
				formatString: "${command}");

		}

		public static void ControllerLogDebugCommandResult(this ILogger logger, string command)
		{
			_controllerLogDebugCommandResult(logger, command, null);
		}

	
	}
}