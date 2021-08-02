using System;
using System.IO;
//using Monitor.Localization;
using Microsoft.Extensions.Logging;
using Count4U.Model;
using Monitor.Model.ServiceContract.Interface;

namespace Monitor.Sqlite.CodeFirst
{
    public class ConnectionSqliteMonitorDB : IConnectionSqliteMonitorDB
    {
        private readonly ILogger _logger;
        private string _monitorDBConnectionString;
        public ConnectionSqliteMonitorDB(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<ConnectionSqliteMonitorDB>();
            this._monitorDBConnectionString =@"Data Source=command.db";
        }

     
        public string MonitorSqliteDBConnectionString
        {
            get
            {
                return this._monitorDBConnectionString;
            }
        }

       
   

	}
}
