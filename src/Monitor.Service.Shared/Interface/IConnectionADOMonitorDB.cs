namespace Monitor.Model.ServiceContract.Interface
{
	public interface IConnectionADOMonitorDB
	{
		string BuildMonitorDBPathFileADO();
		string GetMonitorDBADOConnectionString();
		string GetConnectionString(string pathFileDB);
		string MonitorDBADOConnectionString { get; }
		string MonitorDBFilePath();



	}
}
