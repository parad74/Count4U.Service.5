using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;


namespace Service.Model
{

	public interface IClaimsViewModel
	{
		List<ClaimConvertItem> ClaimList { get; set; }
		void RetrieveClaims();
	}

	public class ClaimsViewModel : IClaimsViewModel
	{
		public List<ClaimConvertItem> _claimList;
		private HttpClient _httpClient;
		public ClaimsViewModel(HttpClient httpClient)
		{
			this._httpClient = httpClient ??
						   throw new ArgumentNullException(nameof(httpClient));

			//this._claimList = new List<Claim>();
		}

		//[DebuggerDisplay("{Title}")]	отображать в отладчике поле   Title
		//	[DebuggerTypeProxy(typeof(ClaimListDebugView))]	 заменить аггрегированными данными отображение в отладчике
		//https://andrey.moveax.ru/post/csharp-debugger-attributes

		//RootHidden – не показывать сам элемент, но показывать содержащуюся в нем коллекцию.
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public List<ClaimConvertItem> ClaimList { get => this._claimList; set => this._claimList = value; }


		public void RetrieveClaims()
		{
			//this.ClaimList = ClaimItems.ClaimItemsToDisplay(typeof(ClaimEnum));  работает
			//ClaimConvertItem
			//	await Http.GetFromJsonAsync<WeatherForecast[]>("test/SampleDataTest/WeatherForecasts");
			//this.ClaimList = _http.GetFromJsonAsync<ClaimConvertItem[]>("Claim/GetClaimConverts");
			//this._claimList = _http.GetAsync<List<Claim>>("api/Accounts/Claims");
			//this.ClaimList = new List<ClaimItem>();
			//ClaimList.Add(new ClaimItem(ClaimTypes.Role, "Error"));
		}
	}
}

