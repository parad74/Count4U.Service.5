using System;
using Monitor.Service.Model;

namespace Service.Model
{
	[Serializable]
	public class ClaimItem
	{
		public string GroupName { get; private set; }
		public string ShortName { get; private set; }
		public string Description { get; private set; }
		public ClaimEnum ClaimType { get; private set; }
		public ClaimItem(string groupName, string name, string description, ClaimEnum claimType)
		{
			this.ClaimType = claimType;
			this.GroupName = groupName;
			this.ShortName = name;
			this.Description = description;
		}
	}

}
