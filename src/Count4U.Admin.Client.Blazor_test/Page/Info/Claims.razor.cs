using System;
using System.Net.Http;
using System.Threading.Tasks;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Service.Model;

namespace Count4U.Admin.Client.Page
{
	public class ClaimsBase : ComponentBase
	{
		[Inject]
		public IClaimsViewModel _viewModel { get; set; }

		[Inject]
		public IClaimService _claimService { get; set; }


		[Inject]
		public HttpClient Http { get; set; }
		public string Title = "Claims";

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.ClaimsBase.OnInitializedAsync() : start");
			try
			{
				this.Title = "Claims from Web API";
				//var claimList = await ClaimService.GetClaimConvertItemsAsync();	   //работает
				var claimList = await this._claimService.GetClaimsFromWebApiAsync();    //тест 
				Console.WriteLine($"Client.ClaimsBase.OnInitializedAsync() : count processes {claimList.Count}");
				this._viewModel.ClaimList = claimList;
			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.ClaimsBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.ClaimsBase.OnInitializedAsync() : end");
		}


		//protected override void OnInitialized()
		//{
		//	//Title = "Hello World";
		//	//ViewModel.ClaimList = ClaimItems.ClaimItemsToDisplay(typeof(ClaimEnum));		   //работает
		//	ViewModel.RetrieveClaims();        //работает
		//}

		//protected override async Task OnInitializedAsync()	   //TEST работает
		//{
		//	var claimList = await ClaimService.GetClaimConvertItemAsync();
		//	ViewModel.ClaimList = new List<ClaimConvertItem>();
		//	ViewModel.ClaimList.Add(claimList);
		//}
		//protected override void OnInitialized()
		//{
		//ViewModel.RetrieveClaims();
		//}
	}

}


//<p>Current logged in user claims.</p>

//@if (Model?.Identity.IsAuthenticated == true)
//{

//	< h4 > User '@User.Identity.Name' </ h4 >

//	   < ul >

//		   @foreach(var claim in @Model.Claims)

//		{

//			< li > @claim.ToString() </ li >

//		}

//	</ ul >
//}
//else
//{
//    <h4>No user is logged in.</h4>
//}
