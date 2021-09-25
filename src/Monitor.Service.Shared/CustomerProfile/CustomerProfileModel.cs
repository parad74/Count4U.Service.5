using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace Monitor.Service.Model
{
	public class CustomerProfileModel
	{

		public string Value { get; set; }
		private string _selectByCustomerProfile { get; set; }
	
		public Dictionary<string, string> StringDictionary { get; set; }
		public Dictionary<string, string> CodeDictionary { get; set; }

	

		public CustomerProfileModel()
		{
			StringDictionary = new Dictionary<string, string>();	  //name,code
			CodeDictionary = new Dictionary<string, string>();	   //code,name
		}

		public void Clear()
		{
			this.Value = "";
			this.SelectByCustomerProfile = "";
		}


		public string SelectByCustomerProfile
		{
			get
			{
				return _selectByCustomerProfile;
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
				_selectByCustomerProfile = e.Value.ToString();
			}
		}

		

	}

}
