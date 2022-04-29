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
	public class CustomerProfileAndUserAddBase : ComponentBase
	{

		protected ProfileFile _profileFile { get; set; }
		public ProfileAndUserModel _profileAndUserModel { get; set; }
		public ProfileAndUrerResult _profileAndUserResult { get; set; }
	

		protected string _code { get; set; } = "";
		public string PingServer { get; set; }
		public string SessionStorageMode { get; set; }

		public bool Ping { get; set; }
		public bool PingMonitor { get; set; }
		public bool PingSignalRHub { get; set; }
		public string StorageMonitorWebApiUrl { get; set; }
		public string StorageSignalRHubUrl { get; set; }

		public bool IsSubmit { get; set; } = false;

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

		[Inject]
		protected IHubCommandSignalRRepository _hubCommandSignalRRepository { get; set; }
		protected IFileListEntry _selectedFile { get; set; }

		public CustomerProfileAndUserAddBase()
		{
		
			this._profileAndUserModel = new ProfileAndUserModel(new RegisterModel(), new ProfileFile());
			this._profileAndUserResult = new ProfileAndUrerResult();
			this._profileAndUserResult.RegisterResult = null;
			this._selectedFile = null;
		}

		protected async Task RegistrationAsync()
		{
			IsSubmit = true;
			this._profileAndUserResult.RegisterResult = new RegisterResult();
			this._profileAndUserResult.RegisterResult.Successful = SuccessfulEnum.Waiting;
			this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.Waiting;
			this._profileFileService.RunUpdateFtpAndDbProfiles = null;

			StateHasChanged();
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileAndUserAddBase.RegistrationAsync() : start");

			//this._showErrors = null;
			//this._showSuccessful = null;
			//this._profileAndUserResult.RegisterResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.CustomerProfileAndUserAddBase.RegistrationAsync() : _authService is null");
			}
			else
			{
				try
				{
					UserViewModel editUser = new UserViewModel() { Email = this._profileAndUserModel.RegisterModel.Email };
					editUser = await this._authService.GetUser(editUser);

					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.RegistrationAsync() : editUser 1 : {editUser.Successful}");
					Console.WriteLine($"Client.CustomerProfileAndUserEditBase.RegistrationAsync() : error 1 : {editUser.Error}");
					if (editUser != null && this._profileAndUserResult.RegisterResult.Successful != SuccessfulEnum.UserNotFound)
					{

						this._profileAndUserResult.RegisterResult.Successful = editUser.Successful;
						this._profileAndUserResult.RegisterResult.Error = editUser.Error;
						StateHasChanged();
						if (editUser.Successful == SuccessfulEnum.Successful)
						{
	  							this._profileAndUserModel.RegisterModel = this._profileAndUserModel.RegisterModel.RefreshRegisterModel(editUser);
						}
						else
						{
							Console.WriteLine($"{editUser.Error}");
						}
					}

					if (this._profileAndUserResult.RegisterResult.Successful == SuccessfulEnum.UserNotFound)
					{
						this._profileAndUserResult.RegisterResult = await this._authService.RegisterAsync(this._profileAndUserModel.RegisterModel);
						Console.WriteLine($"Client.CustomerProfileAndUserEditBase.RegistrationAsync() : editUser 2 : {this._profileAndUserResult.RegisterResult.Successful}");
						Console.WriteLine($"Client.CustomerProfileAndUserEditBase.RegistrationAsync() : error 2 : {this._profileAndUserResult.RegisterResult.Error}");
						StateHasChanged();
						if (this._profileAndUserResult != null)
						{
							if (this._profileAndUserResult.RegisterResult != null)
							{
								if (this._profileAndUserResult.RegisterResult.Successful == SuccessfulEnum.Successful)
								{
									Console.WriteLine($"Client.CustomerProfileAndUserAddBase.RegistrationAsync() : Successful2");
									//this._showSuccessful = true;
									//	this._navigationManager.NavigateTo("/customergrid");
								}
								else
								{
									Console.WriteLine($"Client.CustomerProfileAndUserAddBase.RegistrationAsync() : Errors2");
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
					Console.WriteLine("Client.CustomerProfileAndUserAddBase.RegistrationAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.CustomerProfileAndUserAddBase.RegistrationAsync() : end");
			}



			if (this._profileAndUserResult.RegisterResult.Successful == SuccessfulEnum.Successful)
			{
				if (this._profileFileService != null)
				{
					try
					{
						if (string.IsNullOrWhiteSpace(this._profileAndUserModel.RegisterModel.CustomerCode) == false)
						{
							Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() : start Register");
							this._profileAndUserModel.ProfileFile.Code = this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.CustomerCode = this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.Name = this._profileAndUserModel.ProfileFile.CustomerName;
							this._profileAndUserModel.ProfileFile.SubFolder = this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.CurrentPath = @"Customer\" + this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.DomainObject = "Customer";
							//Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() :  this._profileAndUserModel.ProfileFile.CustomerName :{this._profileAndUserModel.ProfileFile.CustomerName}");
							//this._profileAndUserModel.ProfileFile.CustomerName = this._profileAndUserModel.ProfileFile.CustomerName;
							//Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() :  this._profileAndUserModel.RegisterModel.CustomerDescription :{this._profileAndUserModel.ProfileFile.CustomerDescription}");
							//this._profileAndUserModel.ProfileFile.CustomerDescription = this._profileAndUserModel.ProfileFile.CustomerDescription;
							this._profileAndUserModel.ProfileFile.Email = this._profileAndUserModel.RegisterModel.Email;

							//await this._localStorage.SetItemAsync(SessionStorageKey.filterCustomer, FilterCustomerSelectParam.Code);
							//await this._localStorage.SetItemAsync(SessionStorageKey.filterValueCustomer, this._profileAndUserModel.RegisterModel.CustomerCode);
					
							Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() :  1 Register");

							if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.Exist)
							{
								ProfileFile customerProfileFile = await this._profileFileService.GetProfileFileFromFtp(this._profileAndUserModel.ProfileFile, @"http://localhost:12389");
								if(string.IsNullOrWhiteSpace(customerProfileFile.ProfileXml) == false)
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
							else	if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.Default)
							{

								if (_fileDefaultService != null)
								{
									Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() :  2 Register");
									ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");

									//Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() defaultProfileFile.ProfileXml : {defaultProfileFile.ProfileXml}");
									this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
									this._profileAndUserModel.ProfileFile.Successful = defaultProfileFile.Successful;
									this._profileAndUserModel.ProfileFile.Error = defaultProfileFile.Error;
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
								}
							}
							else if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.Customer)
							{
								Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() Customer 1");
								if (_profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB != null)
								{
									Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() Customer 2");
									if (string.IsNullOrWhiteSpace(_profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.SelectByCustomerProfile) == false)
									{
										Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() Customer 3");
										ProfileFile customerProfileFile = await this._profileFileService.GetProfileFileByCode(
											_profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.SelectByCustomerProfile, @"http://localhost:12389");
										Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() Customer 4");
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
									}
								}
								else 
								{
									Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() CustomerProfileCodesFromDB is null");
									this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
									this._profileAndUserModel.ProfileFile.Error = "CustomerProfileCodesFromDB is null";
								}
							}
							Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() 3 Register");
						//	StateHasChanged();

							//while(this._profileAndUserModel.ProfileFile.Successful != SuccessfulEnum.Successful)
							//{
							//	await Task.Delay(1000);
							//	Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync()  Waiting {this._profileAndUserModel.ProfileFile.Successful}");
							//}

				
							this._profileFileService.RunUpdateFtpAndDbProfiles = await this._profileFileService.AddToQueueUpdateFtpAndDbRun(this._profileAndUserModel.ProfileFile, @"http://localhost:12389");
					

							////this._profileAndUserModel.ProfileFile = await this._profileFileService.SaveOrUpdateProfileFileOnFtpAndDB(this._profileAndUserModel.ProfileFile, @"http://localhost:12389");
							Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() 4 Register");
							//if (this._profileAndUserModel.ProfileFile != null)
							//{
							//	if (this._profileAndUserModel.ProfileFile.Successful == SuccessfulEnum.Successful)
							//	{
							//		Console.WriteLine($"Client.CustomerProfileAndUserAddBase.RegistrationAsync SaveOrUpdateProfileFileOnFtpAndDB() : Successful");
							//	}
							//	else
							//	{
							//		Console.WriteLine($"Client.CustomerProfileAndUserAddBase.RegistrationAsync() SaveOrUpdateProfileFileOnFtpAndDB : Errors");
							//		Console.WriteLine($"{this._profileAndUserModel.ProfileFile.Error}");
							//	}
							//}
						}
						else
						{
							this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
							this._profileAndUserModel.ProfileFile.Error = "Customer Code is empty";

							Console.WriteLine($"Client.CustomerProfileAndUserAddBase.RegistrationAsync() Error : Customer Code is empty");

						}
					}
					catch (Exception exc)
					{
						this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
						this._profileAndUserModel.ProfileFile.Error = exc.Message;
						Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() Exception :");
						Console.WriteLine(exc.Message);
					}
				}
				else
				{
					this._profileAndUserModel.ProfileFile.Successful = SuccessfulEnum.NotSuccessful;
					this._profileAndUserModel.ProfileFile.Error = " _profileFileService is null";
					Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() : _profileFileService is null");
					Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() : end");
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
			Console.WriteLine($"Client.CustomerProfileAndUserAddBase.OnClearAsync() : start");

			//await CreateNewCustomer();
		}


		public async Task ToCustomers()
		{
			this._navigationManager.NavigateTo("/customergrid");
		}
		protected async Task GetProfileFiles()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileAndUserAddBase.GetProfileFiles() : start");

			if (this._profileFileService != null)
			{
				try
				{
					Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() 1");
					var profileFiles = await this._profileFileService.GetCustomerCodeListFromDb(@"http://localhost:12389");
					Console.WriteLine($"Client.CustomerProfileGridBase.GetProfileFiles() 2");
					foreach (var profileFile in profileFiles)
					{
						if (profileFile == null) continue; // такого не должно быть
						this._profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.CodeDictionary[profileFile.Code] = $"[{profileFile.Code}] {profileFile.Name}";
					}
					Console.WriteLine($"Client.CustomerProfileAndUserAddBase.GetProfileFiles() 3");
				}
				catch (Exception exc)
				{
					Console.WriteLine($"Client.CustomerProfileAndUserAddBase.GetProfileFiles() Exception :");
					Console.WriteLine(exc.Message);
				}
			}
			else
			{
				Console.WriteLine($"Client.CustomerProfileAndUserAddBase.GetProfileFiles() : end");
			}
		}

		public async Task GetRegisterModel()
		{
			this._profileAndUserModel.RegisterModel = new RegisterModel();
			this._profileAndUserResult.RegisterResult = null;
	
		}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileBase.OnInitializedAsync() : start");

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
				Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnInitializedAsync() : _profileFileService is null");
			}

			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);

				if (this._localStorage != null)
				{
					//await this._localStorage.SetItemAsync(SessionStorageKey.filterCustomer, FilterCustomerSelectParam.Code);
					//await this._localStorage.SetItemAsync(SessionStorageKey.filterValueCustomer, "");
					//if (this._profileAndUserModel.RegisterModel != null)
					//{
					//	if (string.IsNullOrWhiteSpace(this._profileAndUserModel.RegisterModel.CustomerCode) == false)
					//	{
					//		await this._localStorage.SetItemAsync(SessionStorageKey.filterValueCustomer, this._profileAndUserModel.RegisterModel.CustomerCode);
					//	}
					//}

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
				try
				{
					this._hubCommandSignalRRepository.HubCommandConnection.On<ProfileFile>(SignalRHubPublishFunction.ReceiveProfileFile, (result) =>
					{
						Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() Start On<ProfileFile> {result.Code}");
						Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() result.Step {result.Step}");
						Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() result.Successful {result.Successful}");
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

					Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() : GetProfileFile");
				}
				catch (Exception exc)
				{
					Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() Exception :");
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


