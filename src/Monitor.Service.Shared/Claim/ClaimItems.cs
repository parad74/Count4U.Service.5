using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Monitor.Service.Model;

namespace Service.Model
{
	public static class ClaimItems
	{
		public static List<ClaimItem> ClaimItemsToDisplay(Type enumType)
		{
			var result = new List<ClaimItem>();
			foreach (var claimItem in Enum.GetNames(enumType))
			{
				var member = enumType.GetMember(claimItem);
				//This allows you to obsolete a permission and it won't be shown as a possible option, but is still there so you won't reuse the number
				var obsoleteAttribute = member[0].GetCustomAttribute<ObsoleteAttribute>();
				if (obsoleteAttribute != null)
					continue;
				//If there is no DisplayAttribute then the Enum is not used
				var displayAttribute = member[0].GetCustomAttribute<DisplayAttribute>();
				if (displayAttribute == null)
					continue;

				var claim = (ClaimEnum)Enum.Parse(enumType, claimItem, false);

				result.Add(new ClaimItem(displayAttribute.GroupName, displayAttribute.Name,
						displayAttribute.Description, claim));
			}

			return result;
		}

		public static ClaimEnum? FindClaimEnumViaName(this string claimName)
		{
			return Enum.TryParse(claimName, out ClaimEnum claimEnum)
				? (ClaimEnum?)claimEnum
				: null;
		}
	}
}
