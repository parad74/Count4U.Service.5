using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace Monitor.Service.Model
{
	public class FilterModel
	{

		public string FilterValue { get; set; }
		private string _filterSelectByField { get; set; }
	
		public Dictionary<string, string> FilterStringDictionary { get; set; }
		public Dictionary<string, string> FilterSelectParamDictionary { get; set; }

	

		public FilterModel()
		{
			FilterStringDictionary = new Dictionary<string, string>();
			FilterSelectParamDictionary = new Dictionary<string, string>();
		}

		public void Clear()
		{
			this.FilterValue = "";
			this.FilterSelectByField = "";
		}


		public string FilterSelectByField
		{
			get
			{
				return _filterSelectByField;
			}
			set
			{
				ChangeEventArgs selectedEventArgs = new ChangeEventArgs();
				selectedEventArgs.Value = value;
				OnChangeSelected(selectedEventArgs);
			}
		}

		private void OnChangeSelected(ChangeEventArgs e)
		{
			if (e.Value.ToString() != string.Empty)
			{
				_filterSelectByField = e.Value.ToString();
			}
		}

		public void InitCustomerFilter()
		{
			FilterStringDictionary = new Dictionary<string, string>();
			////	FilterStringDictionary[FilterCustomerString.All] = FilterCustomerSelectParam.All;
			FilterStringDictionary[FilterCustomerString.Code] = FilterCustomerSelectParam.Code;
			FilterStringDictionary[FilterCustomerString.Name] = FilterCustomerSelectParam.CustomerName;

			FilterSelectParamDictionary = new Dictionary<string, string>();
			////		FilterSelectParamDictionary[FilterCustomerSelectParam.All] = FilterCustomerString.All;
			FilterSelectParamDictionary[FilterCustomerSelectParam.Code] = FilterCustomerString.Code;
			FilterSelectParamDictionary[FilterCustomerSelectParam.CustomerName] = FilterCustomerString.Name;

			FilterSelectByField = FilterCustomerSelectParam.Code;
		}

		public void InitInventorFilter()
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

		public void InitUserFilter()
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

	}

}
