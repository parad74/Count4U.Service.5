using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace Count4U.Admin.Client.Page
{
	public class AppBase : ComponentBase
	{

		[Inject]
		public HttpClient Http { get; set; }

		//[Inject]
		//protected IWebAPISettingsService _webAPISettingsService { get; set; }

		//[Inject]
		//protected IWebAPISettings _webAPISettings { get; set; }

		public AppBase()
		{
		}

	
	}



}


