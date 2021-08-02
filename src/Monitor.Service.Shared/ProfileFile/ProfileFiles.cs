using System.Collections.ObjectModel;

namespace Monitor.Service.Model
{

	public class ProfileFiles : ObservableCollection<ProfileFile>
	{
		public static ProfileFiles FromEnumerable(System.Collections.Generic.IEnumerable<ProfileFile> List)
		{
			ProfileFiles profileFiles = new ProfileFiles();
			foreach (ProfileFile item in List)
			{
				profileFiles.Add(item);
			}
			return profileFiles;
		}

		public ProfileFile CurrentItem { get; set; }

		public System.EventHandler CurrentChanged { get; set; }

		public long TotalCount { get; set; }
	}
}
