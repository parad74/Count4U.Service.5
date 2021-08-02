using System;
using System.Collections.Generic;
using System.Linq;
using Monitor.Service.Model;
using Service.Model;

namespace Count4U.Service.Shared
{
	public interface IClaimConvertRepository
	{
		//Dictionary<string, ClaimConvertItem> GetClaimConvertItemDictionary(List<ClaimConvertItem> claims);
		ProfileModel FillUserProfileModel(List<ClaimConvertItem> claims);
		//public ProfileModel GetUserProfileModel(IEnumerable<Claim> claims);

	}

	public class ClaimConvertRepository : IClaimConvertRepository
	{

		public ClaimConvertRepository() { }

		public ProfileModel FillUserProfileModel(List<ClaimConvertItem> claims)
		{

			ProfileModel userProfileModel = new ProfileModel();
			if (claims == null)
				return userProfileModel;
			try
			{
				var dics = claims.Select(e => e).Distinct().ToDictionary(k => k.ClaimType);

				if (dics.ContainsKey(ClaimEnum.DataServerAddress.ToString()) == true)
				{
					userProfileModel.DataServerAddress = dics[ClaimEnum.DataServerAddress.ToString()].Value;
				}
				if (dics.ContainsKey(ClaimEnum.ApplicationUserId.ToString()) == true)
				{
					userProfileModel.ID = dics[ClaimEnum.ApplicationUserId.ToString()].Value;
				}
				//if (dics.ContainsKey(ClaimEnum.DataServerPort.ToString()) == true)
				//{
				//	userProfileModel.DataServerPort = dics[ClaimEnum.DataServerPort.ToString()].Value;
				//}
				if (dics.ContainsKey(ClaimEnum.AccessKey.ToString()) == true)
				{
					userProfileModel.AccessKey = dics[ClaimEnum.AccessKey.ToString()].Value;
				}
				if (dics.ContainsKey(ClaimEnum.CustomerCode.ToString()) == true)
				{
					userProfileModel.CustomerCode = dics[ClaimEnum.CustomerCode.ToString()].Value;
				}
				if (dics.ContainsKey(ClaimEnum.BranchCode.ToString()) == true)
				{
					userProfileModel.BranchCode = dics[ClaimEnum.BranchCode.ToString()].Value;
				}
				if (dics.ContainsKey(ClaimEnum.InventorCode.ToString()) == true)
				{
					userProfileModel.InventorCode = dics[ClaimEnum.InventorCode.ToString()].Value;
				}
				if (dics.ContainsKey(ClaimEnum.DBPath.ToString()) == true)
				{
					userProfileModel.DBPath = dics[ClaimEnum.DBPath.ToString()].Value;
				}

			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
			return userProfileModel;
		}


		//public Dictionary<string, ClaimConvertItem> GetClaimConvertItemDictionary(List<ClaimConvertItem> claims)
		//{
		//	if (claims == null) return new Dictionary<string, ClaimConvertItem>();
		//	//Dictionary<string, ClaimConvertItem>
		//	var dics	= claims.Select(e => e).Distinct().ToDictionary(k => k.ClaimType);
		//	return dics;
		//}

		//public ProfileModel GetUserProfileModel(IEnumerable<Claim> claims)
		//{
		//	ProfileModel userProfileModel = new ProfileModel();
		//	if (claims == null)
		//	{
		//		Console.WriteLine($"GetUserProfileModel : userProfileModel is null");
		//		return userProfileModel;
		//	}
		//	try
		//	{
		//		Console.WriteLine($"GetUserProfileModel 1");

		//		foreach (var claim in claims)
		//		{
		//			if (claim.Type == ClaimEnum.DataServerAddress.ToString())
		//			{
		//				userProfileModel.DataServerAddress = claim.Value;
		//				Console.WriteLine($"userProfileModel.DataServerAddress : {userProfileModel.DataServerAddress}");
		//			}
		//			else if (claim.Type == ClaimEnum.AccessKey.ToString()) 
		//			{
		//				userProfileModel.AccessKey = claim.Value;
		//			}
		//			else if (claim.Type == ClaimEnum.CustomerCode.ToString()) 
		//			{
		//				userProfileModel.CustomerCode = claim.Value;
		//			}
		//			else if (claim.Type == ClaimEnum.BranchCode.ToString())
		//			{
		//				userProfileModel.BranchCode = claim.Value;
		//			}
		//			else if (claim.Type == ClaimEnum.InventorCode.ToString())
		//			{
		//				userProfileModel.InventorCode = claim.Value;
		//			}
		//			else if (claim.Type == ClaimEnum.DBPath.ToString())
		//			{
		//				userProfileModel.DBPath = claim.Value;
		//			}
		//		}

		//	}
		//	catch (Exception exc)
		//	{
		//		Console.WriteLine(exc.Message);
		//	}

		//	return userProfileModel;
		//}



	}

}
