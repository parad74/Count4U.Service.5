using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class FilterCustomerModel
	{

		public string FilterValue { get; set; }
		public string FilterSelectByField { get; set; }
		public Dictionary<string, string> FilterStringDictionary { get; set; }
		public Dictionary<string, string> FilterSelectParamDictionary { get; set; }

	

		public FilterCustomerModel()
		{
			FilterSelectByField = FilterCustomerSelectParam.Code;
			FilterStringDictionary = new Dictionary<string, string>();
		//	FilterStringDictionary[FilterCustomerString.All] = FilterCustomerSelectParam.All;
			FilterStringDictionary[FilterCustomerString.Code] = FilterCustomerSelectParam.Code;
			FilterStringDictionary[FilterCustomerString.Name] = FilterCustomerSelectParam.CustomerName;

			FilterSelectParamDictionary = new Dictionary<string, string>();
	//		FilterSelectParamDictionary[FilterCustomerSelectParam.All] = FilterCustomerString.All;
			FilterSelectParamDictionary[FilterCustomerSelectParam.Code] = FilterCustomerString.Code;
			FilterSelectParamDictionary[FilterCustomerSelectParam.CustomerName] = FilterCustomerString.Name;
		}

		public void Clear()
		{
			this.FilterValue = "";
			this.FilterSelectByField = "";
		}

	}

	public static class FilterCustomerSelectParam
	{
		//public static string All = "All";
		public static string CustomerName = "CustomerName";
		public static string Code = "Code";
	}

	public static class FilterCustomerString
	{
		//public static string All = "All";
		public static string Name = "Name";
		public static string Code = "Code";
	}


}
