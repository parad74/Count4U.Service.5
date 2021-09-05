using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class FilterUserModel
	{
		public string FilterValue { get; set; }
		public string FilterSelectByField { get; set; }
		public Dictionary<string, string> FilterStringDictionary { get; set; }
  		public Dictionary<string, string> FilterSelectParamDictionary { get; set; }
	

		public FilterUserModel()
		{
			FilterSelectByField = FilterUserSelectParam.CustomerCode;

			FilterStringDictionary = new Dictionary<string, string>();
		//	FilterStringDictionary[FilterUserString.All] = FilterUserSelectParam.All;
			FilterStringDictionary[FilterUserString.CustomerCode] = FilterUserSelectParam.CustomerCode;
			FilterStringDictionary[FilterUserString.Email] = FilterUserSelectParam.Email;
			//FilterStringDictionary[FilterUserString.Description] = FilterUserSelectParam.FistName;
	

			FilterSelectParamDictionary = new Dictionary<string, string>();
		//	FilterSelectParamDictionary[FilterUserSelectParam.All] = FilterInventorString.All;
			FilterSelectParamDictionary[FilterUserSelectParam.CustomerCode] = FilterUserString.CustomerCode;
			FilterSelectParamDictionary[FilterUserSelectParam.Email] = FilterUserString.Email;
			//FilterSelectParamDictionary[FilterUserSelectParam.FistName] = FilterUserString.Description;
		}
		
		public void Clear()
		{
			this.FilterValue = "";
			this.FilterSelectByField = FilterInventorString.All;
		}


	}
	public static class FilterUserSelectParam
	{
	//	public static string All = "All";
		public static string CustomerCode = "CustomerCode";
		//public static string FistName = "FistName";
		public static string Email = "Email";
	}

	public static class FilterUserString
	{
	//	public static string All = "All";
		public static string CustomerCode = "Customer Code";
		//public static string Description = "Description";
		public static string Email = "Email";
	}
}
