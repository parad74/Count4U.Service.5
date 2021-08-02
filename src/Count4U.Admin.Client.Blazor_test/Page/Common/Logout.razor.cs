using System;
using System.Net.Http;
using System.Threading.Tasks;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Count4U.Admin.Client.Page
{
	[Authorize]
	public class LogoutBase : ComponentBase
	{

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		[Inject]
		protected IAuthService _authService { get; set; }

		[Inject]
		protected HttpClient Http { get; set; }

		public LogoutBase()
		{
		}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.LogoutBase.OnInitializedAsync() : start");

			if (this._authService == null)
			{
				Console.WriteLine($"Client.LogoutBase.OnInitializedAsync() : _authService is null");
			}
			else
			{
				try
				{
					await this._authService.LogoutAaync();
					this._navigationManager.NavigateTo("/");
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.LogoutBase.OnInitializedAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.LogoutBase.OnInitializedAsync() : end");
			}

		}
	}
}



