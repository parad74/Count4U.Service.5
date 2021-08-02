using System;
using System.Net.Http;
using System.Threading.Tasks;
using Count4U.Admin.Client.Blazor.I18nText;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Monitor.Service.Model;

namespace Count4U.Admin.Client.Page
{
	public class ResetPasswordBase : ComponentBase
	{
		[Parameter]
        public string userID { get; set; }
		protected ForgotPasswordModel _forgotPasswordModel { get; set; }

		//protected bool? _showErrors;

		protected ForgotPasswordResult _forgotPasswordResult { get; set; }

		//protected bool? _showSuccessful;
		//protected List<string> _errors { get; set; }

		protected GetResources LocalizationResources;

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		[Inject]
		protected IAuthService _authService { get; set; }

		[Inject]
		protected HttpClient Http { get; set; }

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		public ResetPasswordBase()
		{
			this._forgotPasswordModel = new ForgotPasswordModel();
			//this._errors = new List<string>();
		}

		protected async Task ResetPasswordAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ForgotPasswordBase.ForgotPasswordAsync() : start");

			this._forgotPasswordResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.ForgotPasswordBase.ForgotPasswordAsync() : _authService is null");
			}
			else
			{
				try
				{
					this._forgotPasswordResult = await this._authService.ForgotPassword(this._forgotPasswordModel);

					if (this._forgotPasswordResult != null)
					{
						if (this._forgotPasswordResult.Successful == SuccessfulEnum.Successful)
						{
							Console.WriteLine($"Client.ForgotPasswordBase.ForgotPasswordAsync() : Successful");
							_navigationManager.NavigateTo("/forgotpassword");
						}
						else
						{
							Console.WriteLine($"Client.ForgotPasswordBase.ForgotPasswordAsync() : Errors");
							Console.WriteLine($"{this._forgotPasswordResult.Error}");
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.ForgotPasswordBase.RegistrationAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.ForgotPasswordBase.RegistrationAsync() : end");
			}
		}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ForgotPasswordBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.ForgotPasswordBase.OnInitializedAsync() Exception : ");
				Console.WriteLine(ecx.Message);
			}
			Console.WriteLine($"Client.ForgotPasswordBase.OnInitializedAsync() : end");
		}
	}
}


