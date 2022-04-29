using System;
using System.Net.Http;
using System.Threading.Tasks;
using Count4U.Admin.Client.Blazor.I18nText;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Monitor.Service.Model;

namespace Count4U.Admin.Client.Page
{
	public class UserAddBase : ComponentBase
	{
		//[Parameter]
		//public string userID { get; set; }

		[Parameter]
		public string userCustomerCode { get; set; }

		protected RegisterModel _registerModel { get; set; }
 	

		//protected bool? _showErrors;

		protected RegisterResult _registerResult { get; set; }

		//protected bool? _showSuccessful;
		//protected List<string> _errors { get; set; }

		protected GetResources LocalizationResources { get; set; }

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		[Inject]
		protected IAuthService _authService { get; set; }

		[Inject]
		protected IAdminService _adminService { get; set; }

		[Inject]
		protected HttpClient Http { get; set; }

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

	

		public UserAddBase()
		{
			this._registerModel = new RegisterModel();

			//this._errors = new List<string>();
		}


	
		protected async Task RegistrationAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.UserAddBase.RegistrationAsync() : start");

			//this._showErrors = null;
			//this._showSuccessful = null;
			this._registerResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.UserAddBase.RegistrationAsync() : _authService is null");
			}
			else
			{
				try
				{
					Console.WriteLine($"this._registerModel before _authService.RegisterAsync {this._registerModel.Email} {this._registerModel.Password}");
					this._registerResult = await this._authService.RegisterAsync(this._registerModel);
					Console.WriteLine($"this._registerModel after _authService.RegisterAsync {this._registerModel.Email} {this._registerModel.Password}");
					if (this._registerResult != null)
					{
						if (this._registerResult.Successful == SuccessfulEnum.Successful)
						{
							Console.WriteLine($"Client.UserAddBase.RegistrationAsync() : Successful");
							//this._showSuccessful = true;
							this._navigationManager.NavigateTo("/usergrid");
						}
						else
						{
							Console.WriteLine($"Client.UserAddBase.RegistrationAsync() : Errors");
							Console.WriteLine($"{this._registerResult.Error}");
							//this._errors.Add(result.Error);
							//this._showErrors = true;
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.UserAddBase.RegistrationAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.UserAddBase.RegistrationAsync() : end");
			}
		}


		public async Task GetRegisterModel()
		{
  			this._registerModel = new RegisterModel();
			Console.WriteLine($"this._registerModel before {this._registerModel.Email} {this._registerModel.Password}");
			if (string.IsNullOrWhiteSpace(userCustomerCode) == false)	this._registerModel.CustomerCode = userCustomerCode;
			Console.WriteLine($"this._registerModel after {this._registerModel.Email} {this._registerModel.Password}");
		}

	
		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.UserAddBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
				if (this.LocalizationResources == null)
				{
					Console.WriteLine($"Client.UserAddBase.OnInitializedAsync() : LocalizationResources is null");
				}

				await GetRegisterModel();
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.UserAddBase.OnInitializedAsync() Exception : ");
				Console.WriteLine(ecx.Message);
			}
			Console.WriteLine($"Client.UserAddBase.OnInitializedAsync() : end");
		}
	}
}


