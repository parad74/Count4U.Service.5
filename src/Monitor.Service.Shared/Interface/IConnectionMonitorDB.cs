namespace Monitor.Model.ServiceContract.Interface
{
	public interface IConnectionMonitorDB
	{
		string BuildMonitorDBConnectionString();
		string MonitorDBConnectionString { get; }
		string MonitorDBFilePath();

	}
}
