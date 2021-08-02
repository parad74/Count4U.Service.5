using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace Count4U.Admin.Client.Page
{
	public class WelcomeBase : ComponentBase
	{

		[Inject]
		public HttpClient Http { get; set; }

		public string Title1 { get; set; }


		public WelcomeBase()
		{
		}

		protected override void OnInitialized()
		{
			Console.WriteLine();
			Console.WriteLine("Client.WelcomeBase.OnInitialized : start ");
			this.Title1 = "How is COUNT4U.SERVICE working for you?";
			Console.WriteLine("Client.WelcomeBase.OnInitialized : end ");
		}



	}

}
