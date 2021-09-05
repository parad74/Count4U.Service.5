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
	public class CustomerProfileGridBase : ComponentBase
	{
		protected ProfileFiles _profileFiles { get; set; }
		protected FilterCustomerModel _filterCustomerModel { get; set; }
  		protected FilterResult _filterResult { get; set; }

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

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		protected GetResources LocalizationResources { get; set; }

		protected bool IsSearching { get; set; }

		public CustomerProfileGridBase()
		{
			this._profileFiles = null;
			this._filterCustomerModel = new FilterCustomerModel();
		}

		//https://blog.jonblankenship.com/2018/10/19/adding-a-loading-spinner-to-a-button-with-blazor/
		public async Task OnSearchAsync()
		{
			IsSearching = true;
			StateHasChanged();

			this._filterResult = new FilterResult();
			try
			{
				Console.WriteLine($"Client.CustomerProfileGridBase.OnSearchAsync() 1 FilterValue: {this._filterCustomerModel.FilterValue} start1");
				Console.WriteLine($"Client.CustomerProfileGridBase.OnSearchAsync() 2 FilterSelectByField: {this._filterCustomerModel.FilterSelectByField} start2");
				if (string.IsNullOrWhiteSpace(_filterCustomerModel.FilterValue) == false)
				{
					await this._localStorage.SetItemAsync(SessionStorageKey.filterCustomer, _filterCustomerModel.FilterSelectByField);

					//if (this._filterCustomerModel.FilterSelectByField == FilterCustomerSelectParam.All)
					//{
					//	Console.WriteLine($"Client.CustomerProfileGridBase.OnSearchAsync() FilterSelectByField: {this._filterCustomerModel.FilterSelectByField} start3");
					//	SelectParams sp = new SelectParams();
					//	sp.FilterParams.Add(FilterCustomerSelectParam.Code,
					//								new FilterParam()
					//								{
					//									Operator = FilterOperator.Contains,
					//									Value = _filterCustomerModel.FilterValue
					//								});
					//	sp.FilterParams.Add(FilterCustomerSelectParam.CustomerName,
					//							new FilterParam()
					//							{
					//								Operator = FilterOperator.Contains,
					//								Value = _filterCustomerModel.FilterValue
					//							});

					//	sp.FilterParams.Add("DomainObject",
					//							new FilterParam()
					//							{
					//								Operator = FilterOperator.Equal,
					//								Value = "Customer"
					//							});
					//	await GetProfileFiles(sp);
					//}
					//else
					if (this._filterCustomerModel.FilterSelectByField == FilterCustomerSelectParam.Code)
					{
						SelectParams sp = new SelectParams();
						sp.FilterParams.Add(FilterCustomerSelectParam.Code,
													new FilterParam()
													{
														Operator = FilterOperator.Contains,
														Value = _filterCustomerModel.FilterValue
													});

						sp.FilterParams.Add("DomainObject",
												new FilterParam()
												{
													Operator = FilterOperator.Equal,
													Value = "Customer"
												});
						await GetProfileFiles(sp);
					}
					else if (this._filterCustomerModel.FilterSelectByField == FilterCustomerSelectParam.CustomerName)
					{
						SelectParams sp = new SelectParams();
						sp.FilterParams.Add(FilterCustomerSelectParam.CustomerName,
													new FilterParam()
													{
														Operator = FilterOperator.Contains,
														Value = _filterCustomerModel.FilterValue
													});

						sp.FilterParams.Add("DomainObject",
												new FilterParam()
												{
													Operator = FilterOperator.Equal,
													Value = "Customer"
												});
						await GetProfileFiles(sp);
					}
					else 
					{
						await GetProfileFiles();
					}
	
					this._filterResult.Successful = SuccessfulEnum.Successful;
				}
				else
				{
					await this._localStorage.SetItemAsync(SessionStorageKey.filterCustomer, "");
					await GetProfileFiles();
					this._filterResult.Successful = SuccessfulEnum.Successful;
				}
			}
			catch(Exception exc) 
			{
				this._filterResult.Successful = SuccessfulEnum.NotSuccessful;
				this._filterResult.Error = exc.Message;
			}
			IsSearching = false;
			StateHasChanged();
		}

		public async Task OnClearAsync()
		{
			this._filterCustomerModel.Clear();
			Console.WriteLine($"Client.CustomerProfileGridBase.Clear() : start");
			await this._localStorage.SetItemAsync(SessionStorageKey.filterCustomer, "");
			await OnSearchAsync();
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
		protected async Task GetProfileFiles(SelectParams selectParams)
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() : start");

			if (this._profileFileService != null)
			{
				try
				{
					Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() 1");
					this._profileFiles = await this._profileFileService.GetProfileFilesWithSelectParam(selectParams, @"http://localhost:12389");
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

		public async Task AddCustomer()
		{
			Console.WriteLine($"Client.CustomerProfileGridBase.AddCustomer() : customerprofile");
			this._navigationManager.NavigateTo("customerprofile");
		}


	


		public async Task OnChangePageNumber(ChangeEventArgs args)
		{
			Console.WriteLine($"OnChangePageNumber: {args.Value}");
			string perPage = args.Value as string;
			await OnChangePageSet(perPage);
		}
		//public async Task OnChangePageNumber()
		//{
		//	Console.WriteLine($"OnChangePageNumber: {OnPageNumber}");
		//	//string perPage = args.Value as string;
		//	await OnChangePageSet(OnPageNumber.ToString());
		//}

		public async Task OnChangePageSet(string perPage)
		{
			int perPageInt = 15;
			this.OnPageNumber = 15;
			try
			{
				bool ret = int.TryParse(perPage, out perPageInt);
				Console.WriteLine($"Client.CustomerProfileGridBase.OnChangePageSet() : try perPageInt to  {perPageInt}");
				this.OnPageNumber = perPageInt;
				Console.WriteLine($"Client.CustomerProfileGridBase.OnChangePageSet() : OnPageNumber to  {OnPageNumber}");
			}
			catch { }
			if (this._localStorage != null)
			{
				await this._localStorage.SetItemAsync(SessionStorageKey.onPageCustomerNumber, this.OnPageNumber);
			}
		}


		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileGridBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
				Console.WriteLine($"Client.CustomerProfileGridBase.OnInitializedAsync() : GetAuthenticationUrls");
				if (this._localStorage != null)
				{
					string perPageString = await this._localStorage.GetItemAsync<string>(SessionStorageKey.onPageCustomerNumber);
					int perPageInt = 15;
					this.OnPageNumber = 15;
					try
					{
						bool ret = int.TryParse(perPageString, out perPageInt);
						Console.WriteLine($"Client.CustomerProfileGridBase.OnInitializedAsync() : try perPageInt to  {perPageInt}");
						this.OnPageNumber = perPageInt;
					}
					catch { }
					Console.WriteLine($"Client.CustomerProfileGridBase.OnInitializedAsync() : GetonPageNumber {this.OnPageNumber}");

					this._filterCustomerModel.FilterSelectByField = await this._localStorage.GetItemAsync<string>(SessionStorageKey.filterCustomer);
					await this.OnSearchAsync();
				}

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

