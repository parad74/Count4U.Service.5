using Microsoft.AspNetCore.Authorization;

namespace Monitor.Service.Model
{
	public class CanUseInventorRequirement : IAuthorizationRequirement
	{
		public CanUseInventorRequirement(/*int age*/)
		{
			//this.Age = age;
		}

		//public int Age { get; private set; }
	}
}
