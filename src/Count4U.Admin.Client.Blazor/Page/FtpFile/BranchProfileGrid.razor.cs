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
	public class BranchProfileGridBase : ComponentBase
	{
		[Parameter]
		public string customerCode { get; set; }
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


		public BranchProfileGridBase()
		{
			this._profileFiles = null;
		}

		protected async Task GetProfileFiles()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.BranchProfileGridBase.GetProfileFiles() : start");

			if (this._profileFileService != null)
			{
				try
				{
					Console.WriteLine($"Client.BranchProfileGridBase.GetProfileFiles() 1");
					this._profileFiles = await this._profileFileService.GetBranchProfileFilesByCustomerCode(customerCode, @"http://localhost:12389");
					Console.WriteLine($"Client.BranchProfileGridBase.GetProfileFiles() 2");
					foreach (var profileFile in this._profileFiles)
					{
						if (profileFile == null) continue; // такого не должно быть

						profileFile.Members = await this._profileFileService.GetInventorCodeListFromDb(profileFile, @"http://localhost:12389");
					}
					Console.WriteLine($"Client.BranchProfileGridBase.GetProfileFiles() 3");
				}
				catch (Exception exc)
				{
					Console.WriteLine($"Client.BranchProfileGridBase.GetProfileFiles() Exception :");
					Console.WriteLine(exc.Message);
				}
			}
			else
			{
				Console.WriteLine($"Client.BranchProfileGridBase.GetProfileFiles() : _profileFileService is null");
				this._profileFiles = new ProfileFiles();
				Console.WriteLine($"Client.BranchProfileGridBase.GetRoles() : end");
			}
		}
		//public async Task CustomerEdit(string code)
		//{
		//	this._navigationManager.NavigateTo("customeredit/" + code);
		//}

		public async Task NavigateToInventories(string branchCode)
		{
			/// branchgrid /{customerCode}
			this._navigationManager.NavigateTo("inventorgrid/" + branchCode);
		}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.BranchProfileGridBase.OnInitializedAsync() : start");
			try
			{
				await this.GetProfileFiles();
				Console.WriteLine($"Client.BranchProfileGridBase.OnInitializedAsync() : GetAuthenticationUrls");
			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.BranchProfileGridBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.BranchProfileGridBase.OnInitializedAsync() : end");
		}
	}
}
