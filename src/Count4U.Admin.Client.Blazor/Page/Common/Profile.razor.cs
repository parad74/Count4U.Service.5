using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Count4U.Model.Audit;
using Count4U.Model.Main;
using Count4U.Model.ProcessC4U;
using Count4U.Admin.Client.Blazor.I18nText;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Monitor.Service.Model;
using Monitor.Service.Model.Settings;
using Monitor.Service.Urls;

namespace Count4U.Admin.Client.Page
{
	[Authorize]
	public class ProfileBase : ComponentBase
	{
		protected ProfileModel _profileModel = new ProfileModel();
		protected string _userID { get; set; } = "";
		
		//protected bool? _showErrors;
		//protected bool? _showSuccessful;
		protected ProfileResult _updateProfileResult;
		protected bool? _showSuccessfulUrl;
		protected bool? _showSuccessfulPathDB;
		protected bool? _showSuccessfulProcess;
		protected bool? _showSuccessfulCustomer;
		protected bool? _showSuccessfulBranch;
		protected bool? _showSuccessfulInventor;

		protected bool? _showErrorsUrl;
		protected bool? _showErrorsPathDB;
		protected bool? _showErrorslProcess;
		protected bool? _showErrorsCustomer;
		protected bool? _showErrorsBranch;
		protected bool? _showErrorsInventor;
		protected List<string> _errors;
		protected List<string> _errorsPathDB;

		protected GetResources LocalizationResources;// = new Localization.I18nText.GetResources();

		protected List<string> _urls { get; set; }
		protected string _authenticationWebapiUrl { get; set; }

		protected Processes _processes { get; set; }
		protected List<string> _processeCodes { get; set; }
		protected List<string> _customereCodes { get; set; }
		protected List<string> _customerCodes { get; set; }
		protected List<Branch> _branches { get; set; }
		protected List<string> _branchCodes { get; set; }
		protected List<Inventor> _inventors { get; set; }
		protected List<string> _inventorCodes { get; set; }


		protected string SelectedUrl { get; set; } = "";
		protected string SelectedProcessCode { get; set; } = "";
		protected string SelectedCustomerCode { get; set; } = "";
		protected string SelectedBranchCode { get; set; } = "";
		protected string SelectedInventorCode { get; set; } = "";


		[Inject]
		protected HttpClient Http { get; set; }
		[Inject]
		protected IProcessService _processService { get; set; }
		[Inject]
		protected ICustomerService _customerService { get; set; }
		[Inject]
		protected IBranchService _branchService { get; set; }
		[Inject]
		protected IInventorService _inventorService { get; set; }
		[Inject]
		protected IWebAPISettings _webAPISettings { get; set; }
		[Inject]
		protected ISessionStorageService _sessionStorage { get; set; }
		[Inject]
		protected ILocalStorageService _localStorage { get; set; }
		[Inject]
		protected IJwtService _jwtService { get; set; }
		[Inject]
		protected IAuthService _authService { get; set; }
		[Inject]
		protected IClaimService _claimService { get; set; }
		[Inject]
		protected NavigationManager _navigationManager { get; set; }
		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		public ProfileBase()
		{
			this._profileModel = new ProfileModel();
			this._errors = new List<string>();
			this._errorsPathDB = new List<string>();

			//this._urls = null;
			this._processes = null;
			this._customereCodes = null;
			this._branches = null;
			this._inventors = null;
			this._authenticationWebapiUrl = "";
			this._urls = new List<string>();
			this._processeCodes = new List<string>();
			this._customerCodes = new List<string>();
			this._branchCodes = new List<string>();
			this._inventorCodes = new List<string>();
		}



		protected async Task GetAuthenticationUrl()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.GetAuthenticationUrl() : start");
			this._authenticationWebapiUrl = "";

			try
			{
				string url = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrls);
				if (url == null)
				{
					Console.WriteLine($"Client.ProfileBase.GetAuthenticationUrl() : url is null");
				}
				else
				{
					Console.WriteLine($"Client.ProfileBase.GetAuthenticationUrl() : Url got : {url}");
					List<string> urls = url.Split(';').ToList();
					if (urls != null)
					{
						Console.WriteLine($"Client.ProfileBase.GetAuthenticationUrl() : Count Urls {urls.Count}");
						if (urls.Count > 0)
						{
							this._authenticationWebapiUrl = urls[0];
						}
					}
					else
					{
						Console.WriteLine("Client.ProfileBase.GetAuthenticationUrl() : urls is null");
					}
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.GetAuthenticationUrl() Exception : ");
				Console.WriteLine(ecx.Message);
			}
			Console.WriteLine($"Client.ProfileBase.GetAuthenticationUrl() : end");

		}

		protected async Task GetCount4UModelUrls()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.GetCount4UModelUrls() : start");
			try
			{
				string url = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.count4uWebapiUrls);
				if (url == null)
				{
					Console.WriteLine($"Client.ProfileBase.GetCount4UModelUrls() : url is null");
				}
				else
				{
					Console.WriteLine($"Client.ProfileBase.GetCount4UModelUrls() : url got : {url}");
					this._urls = url.Split(';').ToList();
					if (this._urls != null)
					{
						Console.WriteLine($"Client.ProfileBase.GetCount4UModelUrls() : Count Urls {this._urls.Count}");
					}
					else
					{
						Console.WriteLine("Client.ProfileBase.GetCount4UModelUrls() : urls is null");
					}
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.GetCount4UModelUrls() Exception : ");
				Console.WriteLine(ecx.Message);
			}
			Console.WriteLine($"Client.ProfileBase.GetCount4UModelUrls() : end");

		}

		protected async Task UrlOnInput(ChangeEventArgs urlEvent)
		{
			Console.WriteLine($"Client.ProfileBase.UrlOnInput() : start");
			try
			{
				if (urlEvent != null)
				{
					string url = urlEvent.Value.ToString();
					this._profileModel = new ProfileModel();
					this._profileModel.ID = this._userID;
					this._processes = null;
					this._customereCodes = null;
					this._branches = null;
					this._inventors = null;
					this._processeCodes = new List<string>();
					this._customerCodes = new List<string>();
					this._branchCodes = new List<string>();
					this._inventorCodes = new List<string>();

					this._profileModel.DataServerAddress = url;
					await this.UpdateUrlAsync();
					Console.WriteLine($"Client.ProfileBase.UrlOnInput() : _profileModel.DataServerAddress {this._profileModel.DataServerAddress}");
					Console.WriteLine($"Client.ProfileBase.UrlOnInput() : url {url}");
					if (string.IsNullOrWhiteSpace(url) == false)
					{
						await this.GetProcesses(url);
					}
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.UrlOnInput() Exception : ");
				Console.WriteLine(ecx.Message);
			}

		}


		protected async Task ProcessCodeOnInput(ChangeEventArgs processCodeEvent)
		{
			Console.WriteLine($"Client.ProfileBase.ProcessCodeOninput() : start");
			try
			{
				if (processCodeEvent != null)
				{
					string processCode = processCodeEvent.Value.ToString();
					ProfileModel profileModelNew = new ProfileModel();
					profileModelNew.ID = this._userID;
					profileModelNew.DataServerAddress = this._profileModel.DataServerAddress;
					profileModelNew.AccessKey = processCode;
					//this._processes = null;
					this._customereCodes = null;
					this._branches = null;
					this._inventors = null;
					this._customerCodes = new List<string>();
					this._branchCodes = new List<string>();
					this._inventorCodes = new List<string>();
					this._profileModel = profileModelNew;

					await this.UpdateProfileAsync();
					Console.WriteLine($"Client.ProfileBase.ProcessCodeOninput() : _profileModel.DataServerAddress {this._profileModel.DataServerAddress}");
					Console.WriteLine($"Client.ProfileBase.ProcessCodeOninput() : _profileModel.AccessKey {this._profileModel.AccessKey}");
					if (string.IsNullOrWhiteSpace(this._profileModel.DataServerAddress) == false)
					{
						await this.GetCustomers(this._profileModel.DataServerAddress);
					}
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.ProcessCodeOninput() Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}


		protected async Task CustomerCodeOnInput(ChangeEventArgs customerCodeEvent)
		{
			Console.WriteLine($"Client.ProfileBase.CustomerCodeOninput() : start");
			try
			{
				if (customerCodeEvent != null)
				{
					string customerCode = customerCodeEvent.Value.ToString();
					ProfileModel profileModelNew = new ProfileModel();
					profileModelNew.ID = this._userID;
					profileModelNew.DataServerAddress = this._profileModel.DataServerAddress;
					profileModelNew.AccessKey = this._profileModel.AccessKey;
					profileModelNew.CustomerCode = customerCode;
					//this._processes = null;
					//this._customeres = null;
					this._branches = null;
					this._inventors = null;
					this._branchCodes = new List<string>();
					this._inventorCodes = new List<string>();
					this._profileModel = profileModelNew;
					await this.UpdateProfileAsync();
					Console.WriteLine($"Client.ProfileBase.CustomerCodeOninput() : _profileModel.DataServerAddress {this._profileModel.DataServerAddress}");
					Console.WriteLine($"Client.ProfileBase.CustomerCodeOninput() : _profileModel.AccessKey {this._profileModel.AccessKey}");
					Console.WriteLine($"Client.ProfileBase.CustomerCodeOninput() : _profileModel.CustomerCode {this._profileModel.CustomerCode}");
					if (string.IsNullOrWhiteSpace(this._profileModel.DataServerAddress) == false)
					{
						await this.GetBranches(this._profileModel.DataServerAddress);
					}
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.CustomerCodeOninput() Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}



		protected async Task BranchCodeOnInput(ChangeEventArgs branchCodeEvent)
		{
			Console.WriteLine($"Client.ProfileBase.BranchCodeOninput() : start");
			try
			{
				if (branchCodeEvent != null)
				{
					string branchCode = branchCodeEvent.Value.ToString();
					ProfileModel profileModelNew = new ProfileModel();
					profileModelNew.ID = this._userID;
					profileModelNew.DataServerAddress = this._profileModel.DataServerAddress;
					profileModelNew.AccessKey = this._profileModel.AccessKey;
					profileModelNew.CustomerCode = this._profileModel.CustomerCode;
					profileModelNew.BranchCode = branchCode;

					//this._processes = null;
					//this._customeres = null;
					//this._branches = null;
					this._inventors = null;
					this._inventorCodes = new List<string>();
					this._profileModel = profileModelNew;
					await this.UpdateProfileAsync();
					Console.WriteLine($"Client.ProfileBase.BranchCodeOninput() : _profileModel.DataServerAddress {this._profileModel.DataServerAddress}");
					Console.WriteLine($"Client.ProfileBase.BranchCodeOninput() : _profileModel.AccessKey {this._profileModel.AccessKey}");
					Console.WriteLine($"Client.ProfileBase.BranchCodeOninput() : _profileModel.CustomerCode {this._profileModel.CustomerCode}");
					Console.WriteLine($"Client.ProfileBase.BranchCodeOninput() : _profileModel.BranchCode {this._profileModel.BranchCode}");
					if (string.IsNullOrWhiteSpace(this._profileModel.DataServerAddress) == false)
					{
						await this.GetInventors(this._profileModel.DataServerAddress);
					}
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.CustomerCodeOninput() Exception : ");
				Console.WriteLine(ecx.Message);
			}

		}


		protected async Task InventorCodeOnInput(ChangeEventArgs inventorCodeEvent)
		{
			Console.WriteLine($"Client.ProfileBase.BranchCodeOninput() : start");
			try
			{

				if (inventorCodeEvent != null)
				{
					string inventorCode = inventorCodeEvent.Value.ToString();
					ProfileModel profileModelNew = new ProfileModel();
					profileModelNew.ID = this._userID;
					profileModelNew.DataServerAddress = this._profileModel.DataServerAddress;
					profileModelNew.AccessKey = this._profileModel.AccessKey;
					profileModelNew.CustomerCode = this._profileModel.CustomerCode;
					profileModelNew.BranchCode = this._profileModel.BranchCode;
					profileModelNew.InventorCode = inventorCode;
					string inventorPathDb = this.GetPathDb(inventorCode);
					profileModelNew.DBPath = inventorPathDb;
					//this._processes = null;
					//this._customeres = null;
					//this._branches = null;
					//this._inventors = null;
					//_inventorCodes = new List<string>();
					this._profileModel = profileModelNew;
					await this.UpdateDBPathAsync();
					await this.UpdateProfileAsync();
					Console.WriteLine($"Client.ProfileBase.InventorCodeOninput() : _profileModel.DataServerAddress {this._profileModel.DataServerAddress}");
					Console.WriteLine($"Client.ProfileBase.InventorCodeOninput() : _profileModel.AccessKey {this._profileModel.AccessKey}");
					Console.WriteLine($"Client.ProfileBase.InventorCodeOninput() : _profileModel.CustomerCode {this._profileModel.CustomerCode}");
					Console.WriteLine($"Client.ProfileBase.InventorCodeOninput() : _profileModel.BranchCode {this._profileModel.BranchCode}");
					Console.WriteLine($"Client.ProfileBase.InventorCodeOninput() : _profileModel.InventorCode {this._profileModel.InventorCode}");
					Console.WriteLine($"Client.ProfileBase.InventorCodeOninput() : _profileModel.DBPath {this._profileModel.DBPath}");
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.CustomerCodeOninput() Exception : ");
				Console.WriteLine(ecx.Message);
			}

		}

		private string GetPathDb(string inventorCode)
		{
			string inventorPathDb = "";
			try
			{
				var inventor = this._inventors.Where(x => x.Code == inventorCode).Select(x => x).ToList();
				if (inventor != null)
				{
					if (inventor.Count > 0)
					{
						inventorPathDb = inventor[0].DBPath;
					}
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.GetPathDb() Exception : ");
				Console.WriteLine(ecx.Message);
			}

			return inventorPathDb;
		}

		protected async Task UpdateDBPathAsync()
		{
			this._showSuccessfulPathDB = null;
			this._showErrorsPathDB = null;
			this._errorsPathDB.Clear();
			try
			{
				await this.UpdateProfileAsync();
				var result = await this._claimService.PingWebApiCount4UFileAsync(this._profileModel);
				if (result != PingOpetarion.Pong)
				{
					this._showSuccessfulPathDB = false;
					this._showErrorsPathDB = true;
					this._errorsPathDB.Add($"File db Count4UDB.sdf not Exists {result}");
				}
				else
				{
					this._showSuccessfulPathDB = true;
					this._showErrorsPathDB = false;
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.HandleUpdateDBPath() Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}

		protected async Task GetProcesses(string dataServerAddress)
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.GetProcesses() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.ProfileBase.GetProcesses() : _profileModel is null");
			}
			else if (string.IsNullOrWhiteSpace(dataServerAddress) == true)
			{
				Console.WriteLine($"Client.ProfileBase.GetProcesses() : _profileModel.DataServerAddress is Empty");
			}
			else if (this._processService == null)
			{
				Console.WriteLine($"Client.ProfileBase.GetProcesses() : _processService is null");
			}
			else
			{
				try
				{
					this._processes = await this._processService.GetProcesses(dataServerAddress);
					if (this._processes != null)
					{
						Console.WriteLine($"Client.ProfileBase.GetProcesses() : count processes {this._processes.Count}");
						this._processeCodes = this._processes.Select(x => x.ProcessCode).ToList();
						Console.WriteLine($"Client.ProfileBase.GetProcesses() : count _processeCodes {this._processeCodes.Count}");

					}
					else
					{
						Console.WriteLine("Client.ProfileBase.GetProcesses() : processes is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.ProfileBase.GetProcesses() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.ProfileBase.GetProcesses() : end");
			}
		}


		protected async Task GetCustomers(string dataServerAddress)
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.GetCustomers() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.ProfileBase.GetCustomers() : _profileModel is null");
			}
			else if (string.IsNullOrWhiteSpace(dataServerAddress) == true)
			{
				Console.WriteLine($"Client.ProfileBase.GetCustomers() : _profileModel.DataServerAddress is Empty");
			}
			else if (this._customerService == null)
			{
				Console.WriteLine($"Client.ProfileBase.GetCustomers() : _customerService is null");
			}
			else
			{
				try
				{
					this._customereCodes = await this._customerService.GetCustomerCodes(dataServerAddress);
					if (this._customereCodes != null)
					{

						Console.WriteLine($"Client.ProfileBase.GetCustomers() : count customeres {this._customereCodes.Count}");
						this._customerCodes = this._customereCodes.Select(x => x).OrderBy(x => x).ToList();
						Console.WriteLine($"Client.ProfileBase.GetCustomers() : count _customerCodes {this._customerCodes.Count}");
					}
					else
					{
						Console.WriteLine("Client.ProfileBase.GetCustomers() : customeres is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.ProfileBase.GetCustomers() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.ProfileBase.GetCustomers() : end");
			}
		}

		protected async Task GetBranches(string dataServerAddress)
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.GetBranches() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.ProfileBase.GetBranches() : _profileModel is null");
			}
			else if (string.IsNullOrWhiteSpace(dataServerAddress) == true)
			{
				Console.WriteLine($"Client.ProfileBase.GetBranches() : _profileModel.DataServerAddress is Empty");
			}
			else if (this._branchService == null)
			{
				Console.WriteLine($"Client.ProfileBase.GetBranches() :_branchService is null");
			}
			else
			{
				try
				{
					this._branches = await this._branchService.GetBranchesByCurrnetCustomer(dataServerAddress);
					if (this._branches != null)
					{
						Console.WriteLine($"Client.ProfileBase.GetBranches() : count branches {this._branches.Count}");
						this._branchCodes = this._branches.OrderBy(x => x.Code).Select(x => x.Code).ToList();
						Console.WriteLine($"Client.ProfileBase.GetBranches() : count _branchCodes {this._branchCodes.Count}");
					}
					else
					{
						Console.WriteLine("Client.ProfileBase.GetBranches() : branches is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.ProfileBase.GetBranches() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.ProfileBase.GetBranches() : end");
			}
		}


		protected async Task GetInventors(string dataServerAddress)
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.GetInventors() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.ProfileBase.GetInventors() : _profileModel is null");
			}
			else if (string.IsNullOrWhiteSpace(dataServerAddress) == true)
			{
				Console.WriteLine($"Client.ProfileBase.GetInventors() : _profileModel.DataServerAddress is Empty");
			}
			else if (this._inventorService == null)
			{
				Console.WriteLine($"Client.ProfileBase.GetInventors() : _inventorService is null");
			}
			else
			{
				try
				{
					this._inventors = await this._inventorService.GetInventoresByCurrnetBranch(dataServerAddress);
					if (this._inventors != null)
					{
						Console.WriteLine($"Client.ProfileBase.GetInventors() : count inventors {this._inventors.Count}");
						this._inventorCodes = this._inventors.Select(x => x.Code).ToList();
						Console.WriteLine($"Client.ProfileBase.GetInventors() : count _inventorCodes {this._inventorCodes.Count}");
					}
					else
					{
						Console.WriteLine("Client.ProfileBase.GetInventors() : inventors is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.ProfileBase.GetInventors() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.ProfileBase.GetInventors() : end");
			}
		}


		protected override void OnInitialized()
		{
			//profileModel = ClaimService.GetProfileModelAsync();
		}
		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : start");
			this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);

			if (this._sessionStorage == null)
			{
				Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : _sessionStorage is null");
			}
			else if (this._jwtService == null)
			{
				Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : _jwtService is null");
			}
			else
			{
				try
				{
					string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
					this._profileModel = this._jwtService.GetProfileModelFromStoragedToken(tokenFromStorage);
					this._userID = this._profileModel.ID;
					Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : _userID = {this._userID} ");
				
					await this.GetCount4UModelUrls();
					await this.UpdateUrlAsync();

					if (this._showSuccessfulUrl == false)
					{
						Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : Data Server with Url {this._profileModel.DataServerPort} not ping");
						return;
					}
					//					await this.GetUrls();
					Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : Got GetUrls()");

					await this.GetAuthenticationUrl();
					Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : GetAuthenticationUrl() >> {this._authenticationWebapiUrl}");


					if (string.IsNullOrWhiteSpace(this._profileModel.DataServerAddress) == false)
					{
						await this.GetProcesses(this._profileModel.DataServerAddress);
						Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : GetProcesses({this._profileModel.DataServerAddress})");
						await this.GetCustomers(this._profileModel.DataServerAddress);
						Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : GetCustomers({this._profileModel.DataServerAddress})");
						await this.GetBranches(this._profileModel.DataServerAddress);
						Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : GetBranches({this._profileModel.DataServerAddress})");
						await this.GetInventors(this._profileModel.DataServerAddress);
						Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : GetInventors({this._profileModel.DataServerAddress})");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.ProfileBase.OnInitializedAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : end");
			}
		}

		protected async Task UpdateProfileAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.HandleUpdate() : start");

			//this._showErrors = null;
			//this._showSuccessful = null;
			//this._errors.Clear();
			this._updateProfileResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.ProfileBase.HandleUpdate() : _authService is null");
			}
			else
			{
				try
				{
					this._updateProfileResult = await this._authService.UpdateProfileAsync(this._profileModel);

					if (this._updateProfileResult != null)
					{
						if (this._updateProfileResult.Successful == SuccessfulEnum.Successful)
						{
							//this._showSuccessful = true;
							Console.WriteLine($"Client.ProfileBase.UpdateProfile() : Successful");
							//await AuthService.Logout();
							//NavigationManager.NavigateTo("/profile");
						}
						else
						{
							Console.WriteLine($"Client.ProfileBase.UpdateProfile() : Errors");
							Console.WriteLine($"{this._updateProfileResult.Error}");
							//this._errors.Add(result.Error);
							//this._showErrors = true;
							//await _authService.Logout();
							//_navigationManager.NavigateTo("/");
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.ProfileBase.HandleUpdate() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.ProfileBase.HandleUpdate() : end");
			}

		}


		protected async Task UpdateUrlAsync()
		{
			this._showSuccessfulUrl = null;
			this._showErrorsUrl = null;
			this._errors.Clear();
			await this.UpdateProfileAsync();
			try
			{
				var result = await this._claimService.PingWebApiAsync(this._profileModel);
				if (result != PingOpetarion.Pong)
				{
					this._showSuccessfulUrl = false;
					this._showErrorsUrl = true;
					this._errors.Add("Server address does not respond");
				}
				else
				{
					this._showSuccessfulUrl = true;
					this._showErrorsUrl = false;
					//await this.UpdateProfileAsync();
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ProfileBase.HandleUpdateUrl() Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}

		//protected async Task HandleUpdateProcess()
		//{
		//	this._showSuccessfulProcess = null;
		//	this._showErrorslProcess = null;
		//	 await HandleUpdate();
		//	this._showSuccessfulProcess = this._showSuccessful;
		//	this._showErrorslProcess = this._showErrors;
		//}


		//protected async Task HandleUpdateCustomer()
		//{
		//	this._showSuccessfulCustomer = null;
		//	this._showErrorsCustomer = null;
		//	await HandleUpdate();
		//	this._showSuccessfulCustomer = this._showSuccessful;
		//	this._showErrorsCustomer = this._showErrors;
		//}




		//protected async Task HandleUpdateBranch()
		//{
		//	this._showSuccessfulBranch = null;
		//	this._showErrorsBranch = null;
		//	await HandleUpdate();
		//	this._showSuccessfulBranch = this._showSuccessful;
		//	this._showErrorsBranch = this._showErrors;
		//}


		//protected async Task HandleUpdateInventor()
		//{
		//	this._showSuccessfulInventor = null;
		//	this._showErrorsInventor = null;
		//	await HandleUpdate();
		//	this._showSuccessfulInventor = this._showSuccessful;
		//	this._showErrorsInventor = this._showErrors;
		//}



		//Not used now, work, old vertion
		//protected async Task HandleRegistration()
		//{
		//	Console.WriteLine();
		//	Console.WriteLine($"Client.ProfileBase.HandleRegistration() : start");

		//	this._showErrors = null;
		//	this._showSuccessful = null;
		//	this._errors.Clear();

		//	if (this._authService == null)
		//	{
		//		Console.WriteLine($"Client.ProfileBase.HandleRegistration() : _authService is null");
		//	}
		//	else
		//	{
		//		try
		//		{
		//			var result = await _authService.ProfileAsync(this._profileModel);

		//			//if (result.Successful)
		//			if (result.Successful == SuccessfulEnum.Successful)
		//			{
		//				this._showSuccessful = true;
		//			 	await this._authService.LogoutAaync();
		//				Console.WriteLine($"Client.ProfileBase.HandleRegistration() : Successful");
		//				this._navigationManager.NavigateTo("/");
		//			}
		//			else
		//			{
		//				Console.WriteLine($"Client.ProfileBase.HandleRegistration() : Errors");
		//				Console.WriteLine($"{result.Error}");
		//				this._errors.Add(result.Error);
		//				this._showErrors = true;
		//			}
		//		}
		//		catch (Exception ecx)
		//		{
		//			Console.WriteLine("$Client.ProfileBase.HandleRegistration() Exception : ");
		//			Console.WriteLine(ecx.Message);
		//		}
		//		Console.WriteLine($"Client.ProfileBase.HandleRegistration() : end");
		//	}
		//}


	}
}



