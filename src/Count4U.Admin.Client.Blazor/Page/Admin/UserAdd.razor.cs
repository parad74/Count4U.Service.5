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
		protected RegisterModel _registerModel { get; set; }

		//protected bool? _showErrors;

		protected RegisterResult _registerResult { get; set; }

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

		public UserAddBase()
		{
			this._registerModel = new RegisterModel();
			//this._errors = new List<string>();
		}

		protected async Task RegistrationAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.RegisterBase.RegistrationAsync() : start");

			//this._showErrors = null;
			//this._showSuccessful = null;
			this._registerResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.RegisterBase.RegistrationAsync() : _authService is null");
			}
			else
			{
				try
				{
					this._registerResult = await this._authService.RegisterAsync(this._registerModel);

					if (this._registerResult != null)
					{
						if (this._registerResult.Successful == SuccessfulEnum.Successful)
						{
							Console.WriteLine($"Client.RegisterBase.RegistrationAsync() : Successful");
							//this._showSuccessful = true;
							this._navigationManager.NavigateTo("/usergrid");
						}
						else
						{
							Console.WriteLine($"Client.RegisterBase.RegistrationAsync() : Errors");
							Console.WriteLine($"{this._registerResult.Error}");
							//this._errors.Add(result.Error);
							//this._showErrors = true;
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.RegisterBase.RegistrationAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.RegisterBase.RegistrationAsync() : end");
			}
		}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.RegisterBase.OnInitializedAsync() Exception : ");
				Console.WriteLine(ecx.Message);
			}
			Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : end");
		}
	}
}


