using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace Monitor.Service.Model
{
	public static class FilterInventorSelectParam
	{
		//public static string All = "All";
		public static string CustomerCode = "CustomerCode";
		public static string BranchCode = "BranchCode";
		public static string InventorCode = "InventorCode";
	//	public static string Code = "Code";
	}

	public static class FilterInventorString
	{
		public static string All = "All";
		public static string CustomerCode = "Customer Code";
		public static string BranchCode = "Branch Code";
		public static string InventorCode = "Inventory Code";
		//public static string Code = "Code";

	}
}
