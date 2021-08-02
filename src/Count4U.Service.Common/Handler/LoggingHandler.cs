using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace Count4U.Service.Common.Handler
{
	//OLD
	public class LoggingHandler : DelegatingHandler
	{
		public LoggingHandler(HttpMessageHandler innerHandler)
			: base(innerHandler)
		{
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			Console.WriteLine("Request:");
			Console.WriteLine(request.ToString());
			if (request.Content != null)
			{
				Console.WriteLine(await request.Content.ReadAsStringAsync());
			}
			Console.WriteLine();

			HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

			Console.WriteLine("Response:");
			Console.WriteLine(response.ToString());
			if (response.Content != null)
			{
				Console.WriteLine(await response.Content.ReadAsStringAsync());
			}
			Console.WriteLine();

			return response;
		}
	}
}

//https://stackoverflow.com/questions/18924996/logging-request-response-messages-when-using-httpclient/18925296#18925296

//LoggingHandler with HttpClient hpw to use:

//HttpClient client = new HttpClient(new LoggingHandler(new HttpClientHandler()));
//HttpResponseMessage response = client.PostJsonAsync(baseAddress + "/api/values", "Hello, World!").Result;


//Output:

//Request:
//Method: POST, RequestUri: 'http://kirandesktop:9095/api/values', Version: 1.1, Content: System.Net.Http.ObjectContent`1[
//[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], Headers:
//{
//  Content-Type: application/json; charset=utf-8
//}
//"Hello, World!"

//Response:
//StatusCode: 200, ReasonPhrase: 'OK', Version: 1.1, Content: System.Net.Http.StreamContent, Headers:
//{
//  Date: Fri, 20 Sep 2013 20:21:26 GMT
//  Server: Microsoft-HTTPAPI/2.0
//  Content-Length: 15
//  Content-Type: application/json; charset=utf-8
//}
//"Hello, World!"