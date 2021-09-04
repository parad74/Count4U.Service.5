using System;
using System.Net.Http;
using System.Threading.Tasks;
using Count4U.Admin.Client.Blazor.I18nText;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Monitor.Service.Model;

namespace Count4U.Admin.Client.Page
{
	public class UserEditBase : ComponentBase
	{
		[Parameter]
		public string email { get; set; }
		protected UserViewModel _userViewModel { get; set; }


		//protected bool? _showErrors;

		protected UserResult _registerResult { get; set; }

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



		public UserEditBase()
		{
			this._userViewModel = new UserViewModel();
			//this._errors = new List<string>();
		}


		public bool IsEdit
		{
			get
			{
				return (string.IsNullOrWhiteSpace(email) == false);
			}
		}

		public bool IsRegister
		{
			get
			{
				return (string.IsNullOrWhiteSpace(email) == true);
			}
		}

		protected async Task UpdateAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.UserEditBase.RegistrationAsync() : start");

			//this._showErrors = null;
			//this._showSuccessful = null;
			this._registerResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.UserEditBase.RegistrationAsync() : _authService is null");
			}
			else
			{
				try
				{
					this._registerResult = await this._authService.UpdateUserAsync(this._userViewModel);           //Task<UserResult> UpdateUserAsync(UserViewModel userViewModel);

					if (this._registerResult != null)
					{
						if (this._registerResult.Successful == SuccessfulEnum.Successful)
						{
							Console.WriteLine($"Client.UserEditBase.RegistrationAsync() : Successful");
							//this._showSuccessful = true;
							this._navigationManager.NavigateTo("/usergrid");
						}
						else
						{
							Console.WriteLine($"Client.UserEditBase.RegistrationAsync() : Errors");
							Console.WriteLine($"{this._registerResult.Error}");
							//this._errors.Add(result.Error);
							//this._showErrors = true;
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.UserEditBase.RegistrationAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.UserEditBase.RegistrationAsync() : end");
			}
		}


		public async Task GetUserModel()
		{

			if (string.IsNullOrWhiteSpace(email) == false)
			{
				Console.WriteLine($"Client.UserEditBase.GetRegisterModel() email = {email}");
				if (this._authService == null)
				{
					Console.WriteLine($"Client.UserEditBase.UserDelete() : _authService is null");
				}
				else
				{
					try
					{
						UserViewModel user = await this._authService.GetUser(new UserViewModel() { Email = email });
						if (user.Successful == SuccessfulEnum.Successful)
						{
							this._userViewModel = user;
						}
						else
						{
							this._userViewModel = new UserViewModel();
						}
					}
					catch (Exception ecx)
					{
						Console.WriteLine("Client.UserEditBase.UserDelete() Exception : ");
						Console.WriteLine(ecx.Message);
					}
					Console.WriteLine($"Client.UserEditBase.UserDelete() : end");
					//this.StateHasChanged();
				}

			}
			else
			{
				this._userViewModel = new UserViewModel();
				this._userViewModel.Successful = SuccessfulEnum.NotSuccessful;
				this._userViewModel.Message = "email is null";
			}

		}


		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.UserEditBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
				if (this.LocalizationResources == null)
				{
					Console.WriteLine($"Client.UserEditBase.OnInitializedAsync() : LocalizationResources is null");
				}

				await GetUserModel();
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.UserEditBase.OnInitializedAsync() Exception : ");
				Console.WriteLine(ecx.Message);
			}
			Console.WriteLine($"Client.UserEditBase.OnInitializedAsync() : end");
		}
	}
}


