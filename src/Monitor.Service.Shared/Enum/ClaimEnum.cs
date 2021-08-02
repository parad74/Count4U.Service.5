using System;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public enum ClaimEnum : short
	{
		NotSet = 0, //error condition

		//Here is an example of very detailed control over something
		[Display(GroupName = "CBIContext", Name = "Access Key", Description = "Can work with Coun4U")]
		AccessKey = 0x10,
		[Display(GroupName = "CBIContext", Name = "Customer Code", Description = "There is selected Customer")]
		CustomerCode = 0x11,
		[Display(GroupName = "CBIContext", Name = "Branch Code", Description = "There is selected Branch")]
		BranchCode = 0x12,
		[Display(GroupName = "CBIContext", Name = "Inventor Code", Description = "There is selected Inventor")]
		InventorCode = 0x13,
		[Display(GroupName = "CBIContext", Name = "DB Path", Description = "There is DB Path of Inventor")]
		DBPath = 0x14,

		[Display(GroupName = "CBIContext", Name = "Application User ID", Description = "Application User ID in db")]
		ApplicationUserId = 0x15,


		[Display(GroupName = "CBIContext", Name = "Data Server Address", Description = "Data Server Address")]
		DataServerAddress = 0x20,
		[Display(GroupName = "CBIContext", Name = "Data Server Port", Description = "Data Server Port")]
		DataServerPort = 0x21,


		[Display(GroupName = "UserAdmin", Name = "Read users", Description = "Can list User")]
		UserRead = 0x30,
		//This is an example of grouping multiple actions under one permission
		[Display(GroupName = "UserAdmin", Name = "Alter user", Description = "Can do anything to the User")]
		UserChange = 0x31,

		[Display(GroupName = "UserAdmin", Name = "Read Roles", Description = "Can list Role")]
		RoleRead = 0x38,
		[Display(GroupName = "UserAdmin", Name = "Change Role", Description = "Can create, update or delete a Role")]
		RoleChange = 0x39,

		[Display(GroupName = "FistName", Name = "Fist Name", Description = "Fist Name")]
		FistName = 0x41,
		[Display(GroupName = "LastName", Name = "Last Name", Description = "Last Name")]
		LastName = 0x42,

		//This is an example of a permission linked to a optional (paid for?) feature
		//The code that turns roles to permissions can
		//remove this permission if the user isn't allowed to access this feature
		//[LinkedToModule(PaidForModules.Feature1)]
		//[Display(GroupName = "Features", Name = "Feature1", Description = "Can access feature1")]
		//Feature1Access = 0x30,
		//[LinkedToModule(PaidForModules.Feature2)]
		//[Display(GroupName = "Features", Name = "Feature2", Description = "Can access feature2")]
		//Feature2Access = 0x31,

		//This is an example of what to do with permission you don't used anymore.
		//You don't want its number to be reused as it could cause problems 
		//Just mark it as obsolete and the PermissionDisplay code won't show it
		[Obsolete]
		[Display(GroupName = "Old", Name = "Not used", Description = "example of old permission")]
		OldPermissionNotUsed = 0x40,

		[Display(GroupName = "DataAuth", Name = "Not used", Description = "Permissions aren't used in Count4U")]
		DataAuthPermission,

		[Display(GroupName = "Role", Name = "owner", Description = "Owner Role Full")]
		owner = 0x71,

		[Display(GroupName = "Role", Name = "admin", Description = "Admin Role Full")]
		admin = 0x72,

		[Display(GroupName = "Role", Name = "manager", Description = "Manager Role Full")]
		manager = 0x73,

		[Display(GroupName = "Role", Name = "monitor", Description = "Monitor Role Full")]
		monitor = 0x74,

		[Display(GroupName = "Role", Name = "context", Description = "Context Role Full")]
		context = 0x75,

		[Display(GroupName = "Role", Name = "worker", Description = "Worker Role Full")]
		worker = 0x76,

		[Display(GroupName = "Role", Name = "profile", Description = "Profile Role Full")]
		profile = 0x77,
	}

}

