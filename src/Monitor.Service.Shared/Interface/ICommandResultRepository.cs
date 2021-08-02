using System.Threading.Tasks;
using Count4U.Model.SelectionParams;

namespace Monitor.Model.ServiceContract.Interface
{
	public interface ICommandResultRepository
	{
		Monitor.Service.Model.CommandResults GetCommandResults();
		Monitor.Service.Model.CommandResults GetTestDataCommandResults();
		Monitor.Service.Model.CommandResults GetCommandResults(SelectParams selectParams);
		Monitor.Service.Model.CommandResult GetCommandResult(long id);

		Monitor.Service.Model.CommandResults GetCommandResultsByParentCode(string parentCommandResultCode);
		Monitor.Service.Model.CommandResult GetCommandResultByCommandResultCode(string commandResultCode);

		Task Delete(long id);
		Task DeleteAll();
		Task Delete(string commandResultCode);
		long Insert(Monitor.Service.Model.CommandResult commandResult);
		Task Insert(Monitor.Service.Model.CommandResult[] commandResultArray);
		Task Update(Monitor.Service.Model.CommandResult commandResult);
	}
}
