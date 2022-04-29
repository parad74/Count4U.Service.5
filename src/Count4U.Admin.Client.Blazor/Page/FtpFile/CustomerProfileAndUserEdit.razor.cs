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
using System.Net.Http;
using BlazorInputFile;
using Microsoft.JSInterop;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using BlazorMonacoXml;
using Microsoft.AspNetCore.Components.Forms;
using Monitor.Service.Shared.MapperExpandoObject;
using Count4U.Service.Format;
using Microsoft.AspNetCore.SignalR.Client;
using Count4U.Model.Common;

namespace Count4U.Admin.Client.Blazor.Page
{
	public class CustomerProfileAndUserEditBase : ComponentBase
	{

		[Parameter]
		public string customerCode { get; set; }
		//public string _customerCode { get; set; }

		[Parameter]
		public string email { get; set; }
		//public string _email { get; set; }

		protected ProfileFile _profileFile { get; set; }
		public ProfileAndUserModel _profileAndUserModel { get; set; }
		public ProfileAndUrerResult _profileAndUserResult { get; set; }
	
	
		public string PingServer { get; set; }
		public string SessionStorageMode { get; set; }

		public bool Ping { get; set; }
		public bool PingMonitor { get; set; }
		public bool PingSignalRHub { get; set; }
		public string StorageMonitorWebApiUrl { get; set; }
		public string StorageSignalRHubUrl { get; set; }
		public bool IsSubmit { get; set; }

		[Inject]
		protected ISessionStorageService _sessionStorage { get; set; }

		[Inject]
		protected ILocalStorageService _localStorage { get; set; }

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		[Inject]
		protected IProfileFileService _profileFileService { get; set; }

		[Inject]
		protected IFileDefaultService _fileDefaultService { get; set; }

		[Inject]
		protected IClaimService _claimService { get; set; }

		[Inject]
		protected IHubCommandSignalRRepository _hubCommandSignalRRepository { get; set; }

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		protected GetResources LocalizationResources { get; set; }

		[Inject]
		protected IAuthService _authService { get; set; }

		[Inject]
		protected IAdminService _adminService { get; set; }

		[Inject]
		protected HttpClient Http { get; set; }

		[Inject]
		protected IJSRuntime _jsRuntime { get; set; }
		protected IFileListEntry _selectedFile { get; set; }

		public CustomerProfileAndUserEditBase()
		{
		
			this._profileAndUserModel = new ProfileAndUserModel(new RegisterModel(), new ProfileFile());
			this._profileAndUserResult = new ProfileAndUrerResult();
			this._profileAndUserResult.RegisterResult = null;
			this._selectedFile = null;
		}

		protected async Task EditOrRegisterAsync()
		{
			IsSubmit = true;
			this._profileAndUserResult.RegisterResult = new RegisterResult();
			this._profileAndUserResult.RegisterResult.Successful = SuccessfulEnum.Waiting;
			this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.Waiting;
			this._profileFileService.RunUpdateFtpAndDbProfiles = null;

			StateHasChanged();
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : start");

			//this._showErrors = null;
			//this._showSuccessful = null;
			//this._profileAndUserResult.RegisterResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : _authService is null");
			}
			else
			{
				try
				{
					UserViewModel editUser = new UserViewModel() { Email = this._profileAndUserModel.RegisterModel.Email };
					editUser = await this._authService.GetUser(editUser);
					if (editUser != null && this._profileAndUserResult.RegisterResult.Successful != SuccessfulEnum.UserNotFound)
					{
						this._profileAndUserResult.RegisterResult = new RegisterResult();
						this._profileAndUserResult.RegisterResult.Successful = editUser.Successful;
						this._profileAndUserResult.RegisterResult.Error = editUser.Error;
						StateHasChanged();
						if (editUser.Successful == SuccessfulEnum.Successful)
						{

							Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : Successful");
							this._profileAndUserModel.RegisterModel = this._profileAndUserModel.RegisterModel.RefreshRegisterModel(editUser);
						}
						else
						{
							Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : Errors");
							Console.WriteLine($"{editUser.Error}");
						}
					}

					if (this._profileAndUserResult.RegisterResult.Successful == SuccessfulEnum.UserNotFound)
					{
						this._profileAndUserResult.RegisterResult = await this._authService.RegisterAsync(this._profileAndUserModel.RegisterModel);
						StateHasChanged();
						if (this._profileAndUserResult != null)
						{
							if (this._profileAndUserResult.RegisterResult != null)
							{
								if (this._profileAndUserResult.RegisterResult.Successful == SuccessfulEnum.Successful)
								{
									Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : Successful");
									//this._showSuccessful = true;
									//	this._navigationManager.NavigateTo("/customergrid");
								}
								else
								{
									Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : Errors");
									Console.WriteLine($"{this._profileAndUserResult.RegisterResult.Error}");
									//this._errors.Add(result.Error);
									//this._showErrors = true;
								}
							}
						}
					}
					if (editUser == null)
					{
						this._profileAndUserResult.RegisterResult.Successful = SuccessfulEnum.NotSuccessful;
						this._profileAndUserResult.RegisterResult.Error = "editUser == null";
						StateHasChanged();
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : end");
			}


			//Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() : start");
			if (this._profileAndUserResult.RegisterResult.Successful == SuccessfulEnum.Successful)
			{
				if (this._profileFileService != null)
				{
					try
					{
					

						if (string.IsNullOrWhiteSpace(this._profileAndUserModel.RegisterModel.CustomerCode) == false)
						{
							this._profileAndUserModel.ProfileFile.Code = this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.CustomerCode = this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.Name = this._profileAndUserModel.ProfileFile.CustomerName;
							this._profileAndUserModel.ProfileFile.SubFolder = this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.CurrentPath = @"Customer\" + this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.DomainObject = "Customer";
							//this._profileAndUserModel.ProfileFile.CustomerDescription = this._profileAndUserModel.ProfileFile.CustomerDescription;
							//this._profileAndUserModel.ProfileFile.CustomerName = this._profileAndUserModel.ProfileFile.CustomerName;
							this._profileAndUserModel.ProfileFile.Email = this._profileAndUserModel.RegisterModel.Email; // TODO 	AuditCode => CustomerEmail

							if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.Exist)
							{
								this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.Successful;
								this._profileAndUserModel.ProfileFile.Error = "";
								//ProfileFile customerProfileFile = await this._profileFileService.GetProfileFileFromFtp(this._profileAndUserModel.ProfileFile, @"http://localhost:12389");
								//if (string.IsNullOrWhiteSpace(customerProfileFile.ProfileXml) == false)
								//{
								//	this._profileAndUserModel.ProfileFile.ProfileXml = customerProfileFile.ProfileXml;
								//	this._profileAndUserModel.ProfileFile.Successful = customerProfileFile.Successful;
								//	this._profileAndUserModel.ProfileFile.Error = customerProfileFile.Error;
								//}
								//else
								//{
								//	ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");
								//	this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
								//	this._profileAndUserModel.ProfileFile.Successful = defaultProfileFile.Successful;
								//	this._profileAndUserModel.ProfileFile.Error = defaultProfileFile.Error;
								//}
							}
							else	if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.Default)
							{
								if (_fileDefaultService != null)
								{
									ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");
									//Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() defaultProfileFile.ProfileXml : {defaultProfileFile.ProfileXml}");
									this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
									this._profileAndUserModel.ProfileFile.Successful = defaultProfileFile.Successful;
									this._profileAndUserModel.ProfileFile.Error = defaultProfileFile.Error;
									Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : InheritProfileString.Default");
								}
							}
							else if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.File)
							{
								if (this._selectedFile != null && this._selectedFile.Data != null)
								{
									try
									{
										using (var reader = new StreamReader(this._selectedFile.Data))
									{
										this._profileAndUserModel.ProfileFile.ProfileXml = await reader.ReadToEndAsync();
										this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.Successful;
											Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : InheritProfileString.File");
									}
									}
									catch (Exception ecx)
									{
										this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
										this._profileAndUserModel.ProfileFile.Error = ecx.Message;
									}
								}
								else
								{
									ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");
									this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
									this._profileAndUserModel.ProfileFile.Successful = defaultProfileFile.Successful;
									this._profileAndUserModel.ProfileFile.Error = defaultProfileFile.Error;
									Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : InheritProfileString.Default");
								}
							}
							else if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.Customer)
	   						{
								if (_profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB != null)
								{
									if (string.IsNullOrWhiteSpace(_profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.SelectByCustomerProfile) == false)
								{
									ProfileFile customerProfileFile = await this._profileFileService.GetProfileFileByCode(
										_profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.SelectByCustomerProfile, @"http://localhost:12389");
										if (customerProfileFile != null)
										{
											this._profileAndUserModel.ProfileFile.ProfileXml = customerProfileFile.ProfileXml;
											this._profileAndUserModel.ProfileFile.Successful = customerProfileFile.Successful;
											this._profileAndUserModel.ProfileFile.Error = customerProfileFile.Error;
										}
										else
										{
											ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");
											this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
											this._profileAndUserModel.ProfileFile.Successful = defaultProfileFile.Successful;
											this._profileAndUserModel.ProfileFile.Error = defaultProfileFile.Error;
										}
									}
								else
								{
									ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");
									this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
									this._profileAndUserModel.ProfileFile.Successful = defaultProfileFile.Successful;
									this._profileAndUserModel.ProfileFile.Error = defaultProfileFile.Error;
									Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : InheritProfileString.Default");
								}
							}
							else
							{
								Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() CustomerProfileCodesFromDB is null");
								this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
								this._profileAndUserModel.ProfileFile.Error = "CustomerProfileCodesFromDB is null";
							}
						}

								Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() profileFiles 1");

							this._profileFileService.RunUpdateFtpAndDbProfiles = await this._profileFileService.AddToQueueUpdateFtpAndDbRun(this._profileAndUserModel.ProfileFile, @"http://localhost:12389");

						//	this._profileAndUserModel.ProfileFile = await this._profileFileService.SaveOrUpdateProfileFileOnFtpAndDB(this._profileAndUserModel.ProfileFile, @"http://localhost:12389");
								Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() profileFiles 2");

						}
						else
						{
							this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
							this._profileAndUserModel.ProfileFile.Error = "Customer Code is empty";

							Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() Error : Customer Code is empty");

						}
					}
					catch (Exception exc)
					{
						this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
						this._profileAndUserModel.ProfileFile.Error = exc.Message;
						Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() Exception :");
						Console.WriteLine(exc.Message);
					}
				}
				else
				{
					this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
					this._profileAndUserModel.ProfileFile.Error = " _profileFileService is null";
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : _profileFileService is null");
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : end");
				}
			}
			//IsSubmit = false;
			StateHasChanged();
		}

		public async Task OnClearAsync()
		{
			this._profileFile = null;
			this._profileAndUserModel = new ProfileAndUserModel(new RegisterModel(), new ProfileFile());
			this._profileAndUserResult = new ProfileAndUrerResult();
			Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnClearAsync() : start");

			//await CreateNewCustomer();
		}


	
		public async Task OnAddCustomer()
		{
			Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnAddCustomer() : customerprofile");
			
		}

		public async Task ToCustomers()
		{
			this._navigationManager.NavigateTo("/customergrid");
		}

		protected async Task GetProfileFiles()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileAndUserEditBase.GetProfileFiles() : start");

			if (this._profileFileService != null)
			{
				try
				{
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.GetProfileFiles() 1");
					var profileFiles = await this._profileFileService.GetCustomerCodeListFromDb(@"http://localhost:12389");
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.GetProfileFiles() 2");
					foreach (var profileFile in profileFiles)
					{
						if (profileFile == null) continue; // такого не должно быть
						//Console.WriteLine($"{profileFile.Code} - {profileFile.Name}");
						
						this._profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.CodeDictionary[profileFile.Code] = $"[{ profileFile.Code}]  {profileFile.Name}";
					}
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.GetProfileFiles() 3");
				}
				catch (Exception exc)
				{
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.GetProfileFiles() Exception :");
					Console.WriteLine(exc.Message);
				}
			}
			else
			{
				Console.WriteLine($"Client.CustomerProfileAndUserEditBase.GetProfileFiles() : end");
			}
		}

		public async Task GetRegisterModel()
		{
			this._profileAndUserModel.RegisterModel = new RegisterModel();
			//this._profileAndUserResult.RegisterResult = null;
		}


		protected async Task InitCustomerProfileAndUser()
		{
			//IsSubmit = true;
			Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : start");

			this._profileAndUserResult.GetUserResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : _authService is null");
			}
			else
			{
				try
				{
					//if (this._profileAndUserModel == null) Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : _profileAndUserModel is null");
					//if (this._profileAndUserModel.RegisterModel == null) Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : _profileAndUserModel.RegisterModel is null");
					//if (this._profileAndUserResult == null) Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : _profileAndUserResult is null");
					//if (this._profileAndUserResult.GetUserResult == null) Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : _profileAndUserResult.GetUserResult is null");

					if (string.IsNullOrWhiteSpace(this.customerCode) == false)
					{
						this._profileAndUserModel.RegisterModel.CustomerCode = this.customerCode;
						this._profileAndUserModel.RegisterModel.Email = this.customerCode + @"@customer.com";
						this._profileAndUserModel.RegisterModel.Password = this.customerCode + @"@customer.com";
						this._profileAndUserModel.RegisterModel.ConfirmPassword = this.customerCode + @"@customer.com";

						this._profileAndUserModel.RegisterModel.InheritProfile = InheritProfileString.Default;
						this._profileAndUserModel.RegisterModel.CustomerExist = false;
						this._profileAndUserModel.RegisterModel._hidden = "visibility: visible;";//"hidden";
						if (this._profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.CodeDictionary.ContainsKey(this.customerCode))
						{
							this._profileAndUserModel.RegisterModel.CustomerExist = true;
							this._profileAndUserModel.RegisterModel._hidden = "visibility: hidden;";
							this._profileAndUserModel.RegisterModel.InheritProfile = InheritProfileString.Exist;
						}

						this._profileAndUserResult.GetUserResult = new RegisterResult();
						this._profileAndUserResult.GetUserResult.Successful = SuccessfulEnum.Successful;
						this._profileAndUserResult.GetUserResult.Error = "";

						UserViewModel editUser = new UserViewModel() { Email = this._profileAndUserModel.RegisterModel.Email };
						editUser = await this._authService.GetUser(editUser);
						if (editUser != null)
						{
							//if (this._profileAndUserResult.RegisterResult != null)
							//{
							this._profileAndUserResult.GetUserResult.Successful = editUser.Successful;
							this._profileAndUserResult.GetUserResult.Error = editUser.Error;
							if (editUser.Successful == SuccessfulEnum.Successful)
							{

								Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : Successful");
								this._profileAndUserModel.RegisterModel = this._profileAndUserModel.RegisterModel.RefreshRegisterModel(editUser);
							}
							else
							{
								Console.WriteLine($"Client.CustomerProfileAndUserEditBase.RegistrationAsync() : Errors");
								Console.WriteLine($"{editUser.Error}");
							}
						}
					}
					else
					{
						this._profileAndUserResult.GetUserResult.Successful = SuccessfulEnum.NotSuccessful;
						this._profileAndUserResult.GetUserResult.Error = "Customer Code is empty";
					}
					
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() Exception1 : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : end");
			}


			//Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() : start");
			if (this._profileAndUserResult.GetUserResult.Successful == SuccessfulEnum.Successful)
			{
				if (this._profileFileService != null)
				{
					try
					{
						if (string.IsNullOrWhiteSpace(customerCode) == false)
						{
							ProfileFile customerProfileFile = await this._profileFileService.GetProfileFileByCode(customerCode, @"http://localhost:12389");
							this._profileAndUserModel.ProfileFile = customerProfileFile;
							this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotStart;
						}
						else
						{
							this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
							this._profileAndUserModel.ProfileFile.Error = "Customer Code is empty";

							Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() Error : Customer Code is empty");

						}
					}
					catch (Exception exc)
					{
						this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
						this._profileAndUserModel.ProfileFile.Error = exc.Message;
						Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() Exception2 :");
						Console.WriteLine(exc.Message);
					}
				}
				else
				{
					this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
					this._profileAndUserModel.ProfileFile.Error = " _profileFileService is null";
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : _profileFileService is null");
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.InitCustomerProfileAndUser() : end");
				}
			}
			//IsSubmit = false;
			//StateHasChanged();
		}
		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnInitializedAsync() : start");
			this.StorageMonitorWebApiUrl = "";
			this.StorageSignalRHubUrl = "";
			this.Ping = false;
			this.PingMonitor = false;
			this.PingSignalRHub = false;

			if (this._profileFileService != null)
			{
				this._profileFileService.RunUpdateFtpAndDbProfiles = null;

			}
			else
			{
				Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnInitializedAsync() : _profileFileService is null");
			}

			try
			{
				//this._customerCode = customerCode;
				//this._email = email;

				
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);

				if (this._localStorage != null)
				{
					this.StorageMonitorWebApiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
					this.StorageSignalRHubUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
					if (string.IsNullOrWhiteSpace(this.StorageMonitorWebApiUrl) == false)
					{
						string result = await this._claimService.PingWebApiMonitorAsync();
						if (result == PingOpetarion.Pong)
						{ this.PingMonitor = true; }
					}

					if (string.IsNullOrWhiteSpace(this.StorageSignalRHubUrl) == false)
					{
						string result = await this._claimService.PingSignalRHubAsync();
						if (result == PingOpetarion.Pong)
						{ this.PingSignalRHub = true; }

					}
				}
				if (this._sessionStorage == null)
				{
					Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnInitializedAsync() : _sessionStorage is null");
				}
				else
				{
					//  string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
					//  Console.WriteLine($"Client.InventorProfileFileEditBase.OnInitializedAsync() : got Token");
				}

				await GetRegisterModel();
				await GetProfileFiles();
				await InitCustomerProfileAndUser();
				this._profileAndUserResult.RegisterResult = null;
			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnInitializedAsync() : end");
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				try
				{
					this._hubCommandSignalRRepository.HubCommandConnection.On<ProfileFile>(SignalRHubPublishFunction.ReceiveProfileFile, (result) =>
					{
						Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnAfterRenderAsync() Start On<ProfileFile> {result.Code}");
						Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnAfterRenderAsync() result.Step {result.Step}");
						Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnAfterRenderAsync() result.Successful {result.Successful}");
						//this._importFromPdaService.FileItemsInData = this._importFromPdaService.FileItemsInData.UpdateCommandResultInFileItems(
						// this._importFromPdaService.FileItemsInData, result);
						// this._importFromPdaService.RunImportCommandResults.UpdateCommandResulByOperationCode(result);

						this._profileFileService.RunUpdateFtpAndDbProfiles.UpdateProfileFileByOperationCode(result);
						// this._profileFileService.RunUpdateFtpAndDbProfiles.UpdateProfileFileByOperationCode(result);

						//SaveOrUpdatOnFtp = 5,
						//UpdateOrInsertInventorFromFtpToDb = 6,
						//GetByInventorCodeFromFtp = 7,
						if (result.Step == ProfiFileStepEnum.SaveOrUpdatOnFtp)
						{
							if (result.Successful == SuccessfulEnum.Successful)
							{
								Console.WriteLine($"{ProfiFileStepEnum.SaveOrUpdatOnFtp.ToString()} : {SuccessfulEnum.Successful.ToString()}");
							}
						}
						else if (result.Step == ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb)
						{
							if (result.Successful == SuccessfulEnum.Successful)
							{
								Console.WriteLine($"{ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb.ToString()} : {SuccessfulEnum.Successful.ToString()}");
								IsSubmit = false;
								Console.WriteLine($"{ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb.ToString()} Wait end with Successful");
							}
							if (result.Successful == SuccessfulEnum.NotSuccessful)
							{
								IsSubmit = false;
								Console.WriteLine($"{ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb.ToString()} Wait end  with NotSuccessful");
							}
							this.StateHasChanged();
						}
						//else if (result.Step == ProfiFileStepEnum.GetByCodeFromFtp)
						//{
						//    if (result.Successful == SuccessfulEnum.Successful)
						//    {
						//        Console.WriteLine($"{ProfiFileStepEnum.SaveOrUpdatOnFtp.ToString()} : {SuccessfulEnum.Successful.ToString()}");
						//    }
						//}
						this.StateHasChanged();
					});

					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnAfterRenderAsync() : GetProfileFile");
				}
				catch (Exception exc)
				{
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.OnAfterRenderAsync() Exception :");
					Console.WriteLine(exc.Message);
				}


			}


		}


		public async void OnButtonClick(string elementID)
		{
			await _jsRuntime.InvokeAsync<string>("BlazorInputFile.wrapInput", elementID);
		}

		public async Task HandleSelection(IFileListEntry[] files)
		{
			foreach (var file in files)
			{
				this._selectedFile = file;
				Console.WriteLine("file.Name : " + file.Name);
				StateHasChanged();
			}
			
		}

		//private async Task OnCodeChanged(string value)
		//{
		//	//_profileAndUserModel.RegisterModel.CustomerCode
		//	//Contact.Name = value;
		//}
	}
}


