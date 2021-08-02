using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Count4U.Model.Count4U;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Monitor.Service.Model;
using Monitor.Service.Shared;
using Monitor.Service.Urls;


namespace Count4U.Admin.Client.Blazor.Page
{
	public class CustomerProfileGridBase : ComponentBase
	{
		protected ProfileFiles _profileFiles { get; set; }
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

		protected bool IsSearching { get; set; }

		public CustomerProfileGridBase()
		{
			this._profileFiles = null;
		}

		//https://blog.jonblankenship.com/2018/10/19/adding-a-loading-spinner-to-a-button-with-blazor/
		public async Task OnSearchAsync()
		{
			IsSearching = true;
			StateHasChanged();

			//if (CheckIsValid())
			//{
				// Make my long-running web service call and do something with the results
			//}

			IsSearching = false;
			StateHasChanged();
		}
		protected async Task GetProfileFiles()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() : start");

			if (this._profileFileService != null)
			{
				try
				{
					Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() 1");
					this._profileFiles = await this._profileFileService.GetCustomerProfileFiles(@"http://localhost:12389");
					Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() 2");
					foreach (var profileFile in this._profileFiles)
					{
						if (profileFile == null) continue; // такого не должно быть

						profileFile.Members = await this._profileFileService.GetBranchCodeListFromDb(profileFile, @"http://localhost:12389");
					}
					Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() 3");
				}
				catch (Exception exc)
				{
					Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() Exception :");
					Console.WriteLine(exc.Message);
				}
			}
			else
			{
				Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() : _profileFileService is null");
				this._profileFiles = new ProfileFiles();
				Console.WriteLine($"Client.CustomerProfileGridBase.GetRoles() : end");
			}
		}
		//public async Task CustomerEdit(string code)
		//{
		//	this._navigationManager.NavigateTo("customeredit/" + code);
		//}

		public async Task NavigateToBranches(string customerCode)
		{
			/// branchgrid /{customerCode}
			this._navigationManager.NavigateTo("branchgrid/" + customerCode);
		}


		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileGridBase.OnInitializedAsync() : start");
			try
			{
		   		await this.GetProfileFiles();
				Console.WriteLine($"Client.CustomerProfileGridBase.OnInitializedAsync() : GetAuthenticationUrls");
			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.CustomerProfileGridBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.CustomerProfileGridBase.OnInitializedAsync() : end");
		}

	}
}

