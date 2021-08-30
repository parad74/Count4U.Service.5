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

namespace Count4U.Admin.Client.Blazor.Page
{
	public class InventorProfileGridBase : ComponentBase
	{
		[Parameter]
		public string branchCode { get; set; }
		protected ProfileFiles _profileFiles { get; set; }
		protected FilterInventorModel _filterInventorModel { get; set; }
		protected FilterResult _filterResult { get; set; }
		protected bool IsSearching { get; set; }
		protected string _code { get; set; } = "";
		public string PingServer { get; set; }
		public string SessionStorageMode { get; set; }
		public int OnPageNumber { get; set; }

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

			this._filterInventorModel = new FilterInventorModel();
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
					if (string.IsNullOrWhiteSpace(branchCode) == false)
					{
						Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() branchCode = {branchCode}");
						this._profileFiles = await this._profileFileService.GetInventorProfileFilesByBranchCode(branchCode, @"http://localhost:12389");
					}
					else
					{
						this._profileFiles = await this._profileFileService.GetInventorProfileFiles(@"http://localhost:12389");
					}
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


		protected async Task GetProfileFiles(SelectParams selectParams)
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() : start");

			if (this._profileFileService != null)
			{
				try
				{
					Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() 1");
					this._profileFiles = await this._profileFileService.GetInventorProfileFiles(@"http://localhost:12389");
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

		//public string CustomerCode { get; set; }
		//public string BranchCode { get; set; }
		//public string InventorCode { get; set; }
		public async Task OnSearchAsync()
		{
			IsSearching = true;
			StateHasChanged();

			this._filterResult = new FilterResult();
			try
			{
				if (string.IsNullOrWhiteSpace(_filterInventorModel.InventorCode) == false)
				{
					await this._localStorage.SetItemAsync(SessionStorageKey.filterCustomer, _filterInventorModel.InventorCode);

					SelectParams sp = new SelectParams();
					sp.FilterParams.Add("InventorCode",
												new FilterParam()
												{
													Operator = FilterOperator.Contains,
													Value = _filterInventorModel.InventorCode
												});

					sp.FilterParams.Add("DomainObject",
											new FilterParam()
											{
												Operator = FilterOperator.Equal,
												Value = "Inventor"
											});

					await GetProfileFiles(sp);
					this._filterResult.Successful = SuccessfulEnum.Successful;
				}
				else
				{
					await this._localStorage.SetItemAsync(SessionStorageKey.filterInventor, "");
					await GetProfileFiles();
					this._filterResult.Successful = SuccessfulEnum.Successful;
				}
			}
			catch (Exception exc)
			{
				this._filterResult.Successful = SuccessfulEnum.NotSuccessful;
				this._filterResult.Error = exc.Message;
			}
			IsSearching = false;
			StateHasChanged();
		}

		public async Task OnClearAsync()
		{
			_filterInventorModel.Clear();
			await OnSearchAsync();
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
				if (this._localStorage != null)
				{
					string perPageString = await this._localStorage.GetItemAsync<string>(SessionStorageKey.onPageInventorNumber);
					int perPageInt = 15;
					this.OnPageNumber = 15;
					try
					{
						bool ret = int.TryParse(perPageString, out perPageInt);
						Console.WriteLine($"Client.InventorProfileGridBase.OnInitializedAsync() : try perPageInt to  {perPageInt}");
						this.OnPageNumber = perPageInt;
					}
					catch { }
					Console.WriteLine($"Client.InventorProfileGridBase.OnInitializedAsync() : GetonPageNumber {this.OnPageNumber}");
				}
			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.InventorProfileGridBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.InventorProfileGridBase.OnInitializedAsync() : end");
		}


		public async Task OnChangePageNumber(ChangeEventArgs args)
		{
			Console.WriteLine($"OnChangePageNumber: {args.Value}");
			string perPage = args.Value as string;
			await OnChangePageSet(perPage);
		}
		public async Task OnChangePageSet(string perPage)
		{
			int perPageInt = 15;
			this.OnPageNumber = 15;
			try
			{
				bool ret = int.TryParse(perPage, out perPageInt);
				Console.WriteLine($"Client.InventorProfileGridBase.OnChangePageSet() : try perPageInt to  {perPageInt}");
				this.OnPageNumber = perPageInt;
			}
			catch { }
			if (this._localStorage != null)
			{
				Console.WriteLine($"Client.InventorProfileGridBase.OnChangePageSet() : try OnPageNumber to  {this.OnPageNumber}");
				await this._localStorage.SetItemAsync(SessionStorageKey.onPageInventorNumber, this.OnPageNumber);
				Console.WriteLine($"Client.InventorProfileGridBase.OnChangePageSet() : Changed OnPageNumber to  {this.OnPageNumber}");
			}
		}

	}
}
