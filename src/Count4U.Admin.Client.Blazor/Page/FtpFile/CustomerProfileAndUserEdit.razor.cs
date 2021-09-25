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
			this._selectedFile = null;
		}

		protected async Task EditOrRegisterAsync()
		{
			IsSubmit = true;
			StateHasChanged();
			Console.WriteLine();
			Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() : start");

			//this._showErrors = null;
			//this._showSuccessful = null;
			this._profileAndUserResult.RegisterResult = null;

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
					if (editUser != null)
					{
						this._profileAndUserResult.RegisterResult = new RegisterResult();
						this._profileAndUserResult.RegisterResult.Successful = editUser.Successful;
						this._profileAndUserResult.RegisterResult.Error = editUser.Error;
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

					if (editUser == null || this._profileAndUserResult.RegisterResult.Successful == SuccessfulEnum.NotSuccessful)
					{
						this._profileAndUserResult.RegisterResult = await this._authService.RegisterAsync(this._profileAndUserModel.RegisterModel);
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
							this._profileAndUserModel.ProfileFile.SubFolder = this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.CurrentPath = @"Customer\" + this._profileAndUserModel.RegisterModel.CustomerCode;
							this._profileAndUserModel.ProfileFile.DomainObject = "Customer";
							//this._profileAndUserModel.ProfileFile.CustomerDescription = this._profileAndUserModel.ProfileFile.CustomerDescription;
							//this._profileAndUserModel.ProfileFile.CustomerName = this._profileAndUserModel.ProfileFile.CustomerName;
							this._profileAndUserModel.ProfileFile.Email = this._profileAndUserModel.RegisterModel.Email; // TODO 	AuditCode => CustomerEmail

							if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.Default)
							{
								if (_fileDefaultService != null)
								{
									ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");

									//Console.WriteLine($"Client.InventorProfileGridBase.RegistrationAsync() defaultProfileFile.ProfileXml : {defaultProfileFile.ProfileXml}");
									this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
								}
							}
							else if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.File)
							{
								if (this._selectedFile != null && this._selectedFile.Data != null)
								{
									using (var reader = new StreamReader(this._selectedFile.Data))
									{
										this._profileAndUserModel.ProfileFile.ProfileXml = await reader.ReadToEndAsync();
									}
								}
								else 
								{
									ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");
									this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
								}
							}
							else if (_profileAndUserModel.RegisterModel.InheritProfile == @InheritProfileString.Customer)
							{
								if (string.IsNullOrWhiteSpace(_profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.SelectByCustomerProfile) == false)
								{
									ProfileFile customerProfileFile = await this._profileFileService.GetProfileFileByCode(_profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.SelectByCustomerProfile, @"http://localhost:12389");
									this._profileAndUserModel.ProfileFile.ProfileXml = customerProfileFile.ProfileXml;
								}
								else
								{
									ProfileFile defaultProfileFile = await this._fileDefaultService.GetDefaultProfileFile(@"http://localhost:12389");
									this._profileAndUserModel.ProfileFile.ProfileXml = defaultProfileFile.ProfileXml;
								}
							}
							Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() profileFiles 1");
							this._profileAndUserModel.ProfileFile = await this._profileFileService.SaveOrUpdateProfileFileOnFtpAndDB(this._profileAndUserModel.ProfileFile, @"http://localhost:12389");
							Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() profileFiles 2");
							if (this._profileAndUserModel.ProfileFile != null)
							{
								if (this._profileAndUserModel.ProfileFile.Successful == SuccessfulEnum.Successful)
								{
									Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync SaveOrUpdateProfileFileOnFtpAndDB() : Successful");
								}
								else
								{
									Console.WriteLine($"Client.CustomerProfileAndUserEditBase.EditOrRegisterAsync() SaveOrUpdateProfileFileOnFtpAndDB : Errors");
									Console.WriteLine($"{this._profileAndUserModel.ProfileFile.Error}");
								}
							}
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
			IsSubmit = false;
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
						if (this._profileAndUserModel.RegisterModel.CustomerProfileCodesFromDB.CodeDictionary.ContainsKey(this.customerCode))
						{
							this._profileAndUserModel.RegisterModel.CustomerExist = true;
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
			try
			{
				//this._customerCode = customerCode;
				//this._email = email;

				
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);

				await GetRegisterModel();
				await GetProfileFiles();
				await InitCustomerProfileAndUser();
				
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


