using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class FilterCustomerModel
	{
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Code")]
		public string Code { get; set; }
		public Dictionary<string, string> FilterStringDictionary { get; set; }
		public Dictionary<string, string> FilterSelectParamDictionary { get; set; }

		public string SelectedParam { get; set; }

		public FilterCustomerModel()
		{
			SelectedParam = FilterCustomerSelectParam.Code;
			FilterStringDictionary = new Dictionary<string, string>();
			FilterStringDictionary[FilterCustomerString.All] = FilterCustomerSelectParam.All;
			FilterStringDictionary[FilterCustomerString.Code] = FilterCustomerSelectParam.Code;
			FilterStringDictionary[FilterCustomerString.Name] = FilterCustomerSelectParam.Name;

			FilterSelectParamDictionary = new Dictionary<string, string>();
			FilterSelectParamDictionary[FilterCustomerSelectParam.All] = FilterCustomerString.All;
			FilterSelectParamDictionary[FilterCustomerSelectParam.Code] = FilterCustomerString.Code;
			FilterSelectParamDictionary[FilterCustomerSelectParam.Name] = FilterCustomerString.Name;
		}

		public void Clear()
		{
			this.Name = "";
			this.Code = "";
		}

	}

	public static class FilterCustomerSelectParam
	{
		public static string All = "All";
		public static string Name = "Name";
		public static string Code = "Code";
	}

	public static class FilterCustomerString
	{
		public static string All = "All";
		public static string Name = "Name";
		public static string Code = "Code";
	}


}
