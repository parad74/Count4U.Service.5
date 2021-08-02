//SAMPLE
//How to use
//this.logger.LogImageNotModified(imageContext.GetDisplayUrl());
//this.logger.LogImagePreconditionFailed(imageContext.GetDisplayUrl());
// this.logger.LogImageServed(imageContext.GetDisplayUrl(), key);
//https://andrewlock.net/defining-custom-logging-messages-with-loggermessage-define-in-asp-net-core/#creating-logging-delegates-with-the-loggermessage-helper

using System;
using Microsoft.Extensions.Logging;

namespace Count4U.Model
{
	/// <summary>
	/// Extensions methods for the <see cref="ILogger"/> interface.
	/// </summary>
	public static class Count4ULoggerExtensions
	{
		private static readonly Action<ILogger, string, Exception> _errorException;
		private static readonly Action<ILogger, string, Exception> _warningException;
		private static readonly Action<ILogger, string, Exception> _debugException;
		private static readonly Action<ILogger, string, Exception> _traceException;
		private static readonly Action<ILogger, string, string, Exception> _traceFunctionException;
		private static readonly Action<ILogger, string, Exception> _information;


		/// <summary>
		/// Initializes static members of the <see cref="ControllerOnExeLoggerExtensions"/> class.
		/// </summary>
		static Count4ULoggerExtensions()
		{
			//========= Information ==============
			_information = LoggerMessage.Define<string>(
					 logLevel: LogLevel.Information,
					eventId: Count4UEventId.Information,
					formatString: "[{Message}]");

			//========= Trace ==============
			_traceException = LoggerMessage.Define<string>(
					 logLevel: LogLevel.Trace,
					eventId: Count4UEventId.TraceException,
					formatString: "[{Message}]");

			_traceFunctionException = LoggerMessage.Define<string, string>(
					 logLevel: LogLevel.Trace,
					eventId: Count4UEventId.TraceException,
					formatString: "[{Context}] [{Message}]");

			//========= Debug ==============
			_debugException = LoggerMessage.Define<string>(
				 logLevel: LogLevel.Debug,
				eventId: Count4UEventId.DebugException,
				formatString: "[{Message}]");

			//========= Warning ==============
			_warningException = LoggerMessage.Define<string>(
				 logLevel: LogLevel.Warning,
				eventId: Count4UEventId.WarningException,
				formatString: "[{Message}]");

 			//========= Error ==============
			_errorException = LoggerMessage.Define<string>(
				 logLevel: LogLevel.Error,
				eventId: Count4UEventId.ErrorException,
				formatString: "[{Message}]");
		}

		public static void ErrorException(this ILogger logger,string message, Exception exception)
		{
			_errorException(logger, message, exception);
		}

		public static void Error(this ILogger logger, string message)
		{
			_errorException(logger, message, null);
		}

		public static void WarningException(this ILogger logger, string message, Exception exception)
		{
			_warningException(logger, message, exception);
		}

		public static void Warning(this ILogger logger, string message)
		{
			_warningException(logger, message, null);
		}

		public static void DebugException(this ILogger logger, string message, Exception exception)
		{
			_debugException(logger, message, exception);
		}

		public static void Debug(this ILogger logger, string message)
		{
			_debugException(logger, message, null);
		}

		public static void TraceException(this ILogger logger, string message, Exception exception)
		{
			_traceException(logger, message, exception);
		}

		public static void Trace(this ILogger logger, string message)
		{
			_traceException(logger, message, null);
		}

		public static void Trace(this ILogger logger, string context, string message)
		{
			_traceFunctionException(logger, context, message, null);
		}

		

		public static void Information(this ILogger logger, string message)
		{
			_information(logger, message, null);
		}


		public static void Info(this ILogger logger, string message)
		{
			_information(logger, message, null);
		}
		



	}
}