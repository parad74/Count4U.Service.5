using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class FilterInventorModel
	{
 		public string FilterValue { get; set; }
		public string FilterSelectByField { get; set; }
  		public Dictionary<string, string> FilterStringDictionary { get; set; }
  		public Dictionary<string, string> FilterSelectParamDictionary { get; set; }

		public FilterInventorModel()
		{
			FilterSelectByField = FilterInventorSelectParam.InventorCode;

			FilterStringDictionary = new Dictionary<string, string>();
			//FilterStringDictionary[FilterInventorString.All] = FilterInventorSelectParam.All;
			FilterStringDictionary[FilterInventorString.CustomerCode] = FilterInventorSelectParam.CustomerCode;
			FilterStringDictionary[FilterInventorString.BranchCode] = FilterInventorSelectParam.BranchCode;
			FilterStringDictionary[FilterInventorString.InventorCode] = FilterInventorSelectParam.InventorCode;
			//FilterStringDictionary[FilterInventorString.Code] = FilterInventorSelectParam.InventorCode;

			FilterSelectParamDictionary = new Dictionary<string, string>();
			//FilterSelectParamDictionary[FilterInventorSelectParam.All] = FilterInventorString.All;
			FilterSelectParamDictionary[FilterInventorSelectParam.CustomerCode] = FilterInventorString.CustomerCode;
			FilterSelectParamDictionary[FilterInventorSelectParam.BranchCode] = FilterInventorString.BranchCode;
			FilterSelectParamDictionary[FilterInventorSelectParam.InventorCode] = FilterInventorString.InventorCode;
		}
		
		public void Clear()
		{
			this.FilterValue = "";
			this.FilterSelectByField = FilterInventorString.All;
		}


	}
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
