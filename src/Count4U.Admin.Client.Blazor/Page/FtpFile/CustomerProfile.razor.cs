using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Count4U.Model.Count4U;
using Count4U.Model.SelectionParams;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Monitor.Service.Model;
using Monitor.Service.Shared;
using Monitor.Service.Urls;
using Count4U.Admin.Client.Blazor.Component;
using Count4U.Admin.Client.Blazor.I18nText;

namespace Count4U.Admin.Client.Blazor.Page
{
	public class CustomerProfileBase : ComponentBase
	{
		protected ProfileFile _profileFile { get; set; }
		protected string _code { get; set; } = "";
		public string PingServer { get; set; }
		public string SessionStorageMode { get; set; }

		[Inject]
		protected ISessionStorageService _sessionStorage { get; set; }

		[Inject]
		protected ILocalStorageService _localStorage { get; set; }

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		[Inject]
		protected IProfileFileService _profileFileService { get; set; }

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		protected GetResources LocalizationResources { get; set; }

		protected bool IsSearching { get; set; }

		public CustomerProfileBase()
		{
			this._profileFile = null;
		}

		
		public async Task OnClearAsync()
		{
			this._profileFile = new ProfileFile();
			Console.WriteLine($"Client.CustomerProfileBase.OnClearAsync() : start");

			//await CreateNewCustomer();
		}


		public async Task OnAddCustomer()
		{
			Console.WriteLine($"Client.CustomerProfileBase.OnAddCustomer() : customerprofile");
			
		}




		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
		
				//await CreateNewCustomer(); ;

			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.CustomerProfileBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.CustomerProfileBase.OnInitializedAsync() : end");
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{

			//	Console.WriteLine();
			//	Console.WriteLine($"Client.CustomerProfileBase.OnAfterRenderAsync() : start");
			//	try
			//	{
			//		Console.WriteLine($"Client.CustomerProfileBase.OnAfterRenderAsync() ");
		
			//	}
			//	catch (Exception exc)
			//	{
			//		Console.WriteLine($"Client.CustomerProfileBase.OnAfterRenderAsync() Exception :");
			//		Console.WriteLine(exc.Message);
			//	}
			//	Console.WriteLine($"Client.CustomerProfileBase.OnAfterRenderAsync() : end");
			}
		}
	}
}


