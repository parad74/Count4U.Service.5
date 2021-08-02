using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Net.Http.Headers;
using Count4U.Service.Model;
using Monitor.Service.Model;

namespace Count4U.Service.Common
{
	//Если есть JWT в заголовке запроса, то преобразует его в нескольео заголовков со значением clims
    public class Count4uHeaderFromJWTMiddleware
	{
        private readonly RequestDelegate _next;

        public Count4uHeaderFromJWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
			SplitJWT(httpContext);
			await _next.Invoke(httpContext);
        }

		public void SplitJWT(HttpContext httpContext)
		{
			if (httpContext == null) return;
			if (httpContext.Request == null) return;
			if (httpContext.Request.Headers == null) return;
			StringValues savedTokens = new StringValues();
			httpContext.Request.Headers.TryGetValue(HeaderNames.Authorization, out savedTokens);
			httpContext.Response.Headers.Add(HeaderNames.Authorization, savedTokens);
			if (savedTokens.Count < 1) return;
			string savedToken = savedTokens[0];

			ClaimsPrincipal authenticatedUser = GetClaimsPrincipalFromTokenPrivate(savedToken);
			
			if (authenticatedUser == null) return;
			if (authenticatedUser.Claims == null)  return;
			List<Claim> clims = authenticatedUser.Claims.ToList();
			if (clims.Count == 0)  return;
			try
			{
				var processCode = clims.FirstOrDefault(c => c.Type == ClaimEnum.AccessKey.ToString());
				if (processCode != null)
				{
					httpContext.Request.Headers.Add(
					ClaimEnum.AccessKey.ToString(),
					processCode.Value);
				}

				var customerCode = clims.FirstOrDefault(c => c.Type == ClaimEnum.CustomerCode.ToString());
				if (customerCode != null)
				{
					httpContext.Request.Headers.Add(
					ClaimEnum.CustomerCode.ToString(),
					customerCode.Value);
				}

				var branchCode = clims.FirstOrDefault(c => c.Type == ClaimEnum.BranchCode.ToString());
				if (branchCode != null)
				{
					httpContext.Request.Headers.Add(
				ClaimEnum.BranchCode.ToString(),
				branchCode.Value);
				}

				var inventorCode = clims.FirstOrDefault(c => c.Type == ClaimEnum.InventorCode.ToString());
				if (inventorCode != null)
				{
					httpContext.Request.Headers.Add(
				ClaimEnum.InventorCode.ToString(),
				inventorCode.Value);
				}

				
				var dbPath = clims.FirstOrDefault(c => c.Type == ClaimEnum.DBPath.ToString());
				if (dbPath != null)
				{
					httpContext.Request.Headers.Add(
				ClaimEnum.DBPath.ToString(),
				dbPath.Value);
				}

				//if (dics.ContainsKey(ClaimEnum.DataServerAddress.ToString()) == true)
				//{
				//	pcbiContext.ProcessCode = dics[ClaimEnum.DataServerAddress.ToString()].Value;
				//}
				//if (dics.ContainsKey(ClaimEnum.DataServerPort.ToString()) == true)
				//{
				//	pcbiContext.DataServerPort = dics[ClaimEnum.DataServerPort.ToString()].Value;
				//}
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
			return;
		}


		private ClaimsPrincipal GetClaimsPrincipalFromTokenPrivate(string savedToken)
		{
			ClaimsPrincipal authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwtPrivate(savedToken), "jwt"));
			return authenticatedUser;
		}


		private IEnumerable<Claim> ParseClaimsFromJwtPrivate(string jwt)
		{
			var claims = new List<Claim>();
			if (string.IsNullOrWhiteSpace(jwt) == true) return claims;
			var payload = jwt.Split('.')[1];
			var jsonBytes = ParseBase64WithoutPadding(payload);
			var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

			keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

			if (roles != null)
			{
				if (roles.ToString().Trim().StartsWith("["))
				{
					var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

					foreach (var parsedRole in parsedRoles)
					{
						claims.Add(new Claim(ClaimTypes.Role, parsedRole));
					}
				}
				else
				{
					claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
				}

				keyValuePairs.Remove(ClaimTypes.Role);
			}

			claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

			return claims;
		}

		private byte[] ParseBase64WithoutPadding(string base64)
		{
			switch (base64.Length % 4)
			{
				case 2:
					base64 += "==";
					break;
				case 3:
					base64 += "=";
					break;
			}
			return Convert.FromBase64String(base64);
		}
	}
}