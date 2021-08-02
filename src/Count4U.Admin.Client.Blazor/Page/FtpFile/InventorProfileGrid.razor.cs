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
	public class InventorProfileGridBase : ComponentBase
	{
		[Parameter]
		public string branchCode { get; set; }
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


		public InventorProfileGridBase()
		{
			this._profileFiles = null;
		}

		protected async Task GetProfileFiles()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() : start");

			if (this._profileFileService != null)
			{
				try
				{
					Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() 1");
					this._profileFiles = await this._profileFileService.GetInventorProfileFilesByBranchCode(branchCode, @"http://localhost:12389");
					Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() 2");
					//foreach (var profileFile in this._profileFiles)
					//{
					//	if (profileFile == null) continue; // такого не должно быть

					//	profileFile.Members = await this._profileFileService.GetInventorCodeListFromDb(profileFile, @"http://localhost:12389");
					//}
					Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() 3");
				}
				catch (Exception exc)
				{
					Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() Exception :");
					Console.WriteLine(exc.Message);
				}
			}
			else
			{
				Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() : _profileFileService is null");
				this._profileFiles = new ProfileFiles();
				Console.WriteLine($"Client.InventorProfileGridBase.GetRoles() : end");
			}
		}


		public async Task ProfileFileEdit(string code)
		{
			this._navigationManager.NavigateTo("inventorprofilefileedit/" + code);
		}

		public async Task ProfileFileShow(string code)
		{
			this._navigationManager.NavigateTo("inventorprofilefileshow/" + code);
		}
		


		//public async Task NavigateToBranches(string branchCode)
		//{
		//	/// branchgrid /{customerCode}
		//	this._navigationManager.NavigateTo("branchgrid/" + branchCode);
		//}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InventorProfileGridBase.OnInitializedAsync() : start");
			try
			{
				await this.GetProfileFiles();
				Console.WriteLine($"Client.InventorProfileGridBase.OnInitializedAsync() : GetAuthenticationUrls");
			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.InventorProfileGridBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.InventorProfileGridBase.OnInitializedAsync() : end");
		}

	}
}
