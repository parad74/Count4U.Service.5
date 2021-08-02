using System.Collections.ObjectModel;

namespace Monitor.Service.Model
{

	public class CommandResults : ObservableCollection<CommandResult>
	{
		public static CommandResults FromEnumerable(System.Collections.Generic.IEnumerable<CommandResult> List)
		{
			CommandResults commandResults = new CommandResults();
			foreach (CommandResult item in List)
			{
				commandResults.Add(item);
			}
			return commandResults;
		}

		public CommandResult CurrentItem { get; set; }

		public System.EventHandler CurrentChanged { get; set; }

		public long TotalCount { get; set; }
	}
}
