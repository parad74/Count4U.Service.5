using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Monitor.Service.Model
{
	public interface IJwtService
	{
		ClaimsPrincipal GetClaimsPrincipalFromToken(HttpRequest request);
		IEnumerable<Claim> ParseClaimsFromJwt(string jwt);
		ProfileModel GetUserProfileModel(IEnumerable<Claim> claims);
		ProfileModel GetProfileModelFromHttpRequest(HttpRequest request);
		ProfileModel GetProfileModelFromStoragedToken(string savedToken);
	}

	public class JwtService : IJwtService
	{
		public JwtService()
		{
		}

		public ClaimsPrincipal GetClaimsPrincipalFromToken(HttpRequest request)
		{
			Console.WriteLine($"JwtService.GetClaimsPrincipalFromToken() : start");
			if (request == null)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : HttpRequest is null");
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end");
				return new ClaimsPrincipal();
			}
			if (request.Headers == null)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : HttpRequest.Headers is null");
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end");
				return new ClaimsPrincipal();
			}

			StringValues savedTokens = new StringValues();
			request.Headers.TryGetValue(HeaderNames.Authorization, out savedTokens);

			if (savedTokens.Count < 1)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : Not get Authorization from Header");
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end");
				return new ClaimsPrincipal();
			}

			try
			{
				string savedToken = savedTokens[0];
				ClaimsPrincipal authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(this.ParseClaimsFromJwt(savedToken), "jwt"));
				return authenticatedUser;
			}
			catch (Exception exc)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() Exception :");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end with Exception");
				return new ClaimsPrincipal();
			}
		}

		public ProfileModel GetProfileModelFromHttpRequest(HttpRequest request)
		{
			Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : start");
			if (request == null)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : HttpRequest is null");
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end");
				return new ProfileModel();
			}
			if (request.Headers == null)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : HttpRequest.Headers is null");
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end");
				return new ProfileModel();
			}

			StringValues savedTokens = new StringValues();
			request.Headers.TryGetValue(HeaderNames.Authorization, out savedTokens);
			if (savedTokens.Count < 1)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : Not get Authorization from Header");
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end");
				return new ProfileModel();
			}

			try
			{
				string savedToken = savedTokens[0];
				ProfileModel userProfileModel = this.GetProfileModelFromStoragedToken(savedToken);
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end");
				return userProfileModel;
			}
			catch (Exception exc)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() Exception :");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"JwtService.GetProfileModelFromHttpRequest() : end with Exception");
				return new ProfileModel();
			}
		}

		public ProfileModel GetProfileModelFromStoragedToken(string savedToken)
		{
			Console.WriteLine($"JwtService.GetProfileModelFromStoragedToken() : start");
			if (string.IsNullOrWhiteSpace(savedToken) == true)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromStoragedToken() : Token is Empty");
				Console.WriteLine($"JwtService.GetProfileModelFromStoragedToken() : end");
				return new ProfileModel();
			}
			try
			{
				ClaimsPrincipal authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(this.ParseClaimsFromJwt(savedToken), "jwt"));
				if (authenticatedUser == null)
				{
					Console.WriteLine("JwtService.GetProfileModelFromStoragedToken() : authenticatedUser is null");
					Console.WriteLine($"JwtService.GetProfileModelFromStoragedToken() : end");
					return new ProfileModel();
				}
				ProfileModel userProfileModel = this.GetUserProfileModel(authenticatedUser.Claims);
				Console.WriteLine($"JwtService.GetProfileModelFromStoragedToken() : end");
				return userProfileModel;
			}
			catch (Exception exc)
			{
				Console.WriteLine($"JwtService.GetProfileModelFromStoragedToken() Exception :");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"JwtService.GetProfileModelFromStoragedToken() : end with Exception");
				return new ProfileModel();
			}
		}


		public ProfileModel GetUserProfileModel(IEnumerable<Claim> claims)
		{
			Console.WriteLine($"JwtService.GetUserProfileModel() : start");
			ProfileModel userProfileModel = new ProfileModel();
			if (claims == null)
			{
				Console.WriteLine($"JwtService.GetUserProfileModel() : in claims is null");
				Console.WriteLine($"JwtService.GetUserProfileModel() : end");
				return userProfileModel;
			}
			try
			{
				foreach (var claim in claims)
				{
					if (claim.Type == ClaimEnum.ApplicationUserId.ToString())
					{
						userProfileModel.ID = claim.Value;
						Console.WriteLine($"JwtService.GetUserProfileModel() : ApplicationUserId : {userProfileModel.ID}");
					}
					else  if (claim.Type == ClaimEnum.DataServerAddress.ToString())
					{
						userProfileModel.DataServerAddress = claim.Value;
						Console.WriteLine($"JwtService.GetUserProfileModel() : DataServerAddress : {userProfileModel.DataServerAddress}");
					}
					else if (claim.Type == ClaimEnum.AccessKey.ToString())
					{
						userProfileModel.AccessKey = claim.Value;
					}
					else if (claim.Type == ClaimEnum.CustomerCode.ToString())
					{
						userProfileModel.CustomerCode = claim.Value;
					}
					else if (claim.Type == ClaimEnum.BranchCode.ToString())
					{
						userProfileModel.BranchCode = claim.Value;
					}
					else if (claim.Type == ClaimEnum.InventorCode.ToString())
					{
						userProfileModel.InventorCode = claim.Value;
					}
					else if (claim.Type == ClaimEnum.DBPath.ToString())
					{
						userProfileModel.DBPath = claim.Value;
					}
				}
			}
			catch (Exception exc)
			{
				Console.WriteLine($"JwtService.GetUserProfileModel() Exception :");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"JwtService.GetUserProfileModel() : end with Exception");
				return userProfileModel;
			}
			Console.WriteLine($"JwtService.GetUserProfileModel() : end");
			return userProfileModel;
		}

		public IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
		{
			var claims = new List<Claim>();
			if (string.IsNullOrWhiteSpace(jwt) == true)
				return claims;
			var payload = jwt.Split('.')[1];
			var jsonBytes = this.ParseBase64WithoutPadding(payload);
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
