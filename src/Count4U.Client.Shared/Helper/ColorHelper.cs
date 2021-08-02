using System;
using System.Collections.Generic;
using System.Drawing;
using Count4U.Model;

namespace Count4U.Service.Shared
{
	public static class ColorHelper
	{

		public static string ColorToString(Color color)
		{
			return String.Format("{0:000},{1:000},{2:000}", color.R, color.G, color.B);
		}

		public static Color StringToColor(string color)
		{
			try
			{
				string[] split = color.Split(new char[] { ',' });
				byte r = Byte.Parse(split[0]);
				byte g = Byte.Parse(split[1]);
				byte b = Byte.Parse(split[2]);
				return Color.FromArgb(r, g, b);
			}
			catch
			{
				return Color.White;
			}
		}

		public static Color StatusDefaultColorGet(IturStatusEnum status)
		{
			switch (status)
			{
				case IturStatusEnum.NoOneDoc:
				return Color.FromArgb(250, 235, 215);
				//case IturStatusEnum.None:
				//    return Color.FromRgb(176, 196, 222);
				case IturStatusEnum.OneDocIsNotApprove:
				return Color.FromArgb(212, 249, 212);
				case IturStatusEnum.OneDocIsApprove:
				return Color.FromArgb(211, 211, 211);
				case IturStatusEnum.SomeDocIsNotApprove:
				return Color.FromArgb(237, 213, 237);
				case IturStatusEnum.SomeDocIsApprove:
				return Color.FromArgb(255, 218, 185);
				case IturStatusEnum.DisableAndNoOneDoc:
				return Color.LightSeaGreen;
				case IturStatusEnum.DisableAndOneDocIsNotApprove:
				return Color.LightSlateGray;
				case IturStatusEnum.DisableAndOneDocIsApprove:
				return Color.LightSteelBlue;
				case IturStatusEnum.DisableAndSomeDocIsNotApprove:
				return Color.LightYellow;
				case IturStatusEnum.DisableAndSomeDocIsApprove:
				return Color.Salmon;
				case IturStatusEnum.WarningConvert:
				return Color.Orange;
				default:
				throw new ArgumentOutOfRangeException("status");
			}
		}


		public static string StatusIturBitDefaultColorGet(int statusIturBit)
		{
			try
			{
				IturStatusEnum status = (IturStatusEnum)statusIturBit;
				switch (status)
				{
					case IturStatusEnum.NoOneDoc:
					return "cornflowerblue";
					//case IturStatusEnum.None:
					//    return Color.FromRgb(176, 196, 222);
					case IturStatusEnum.OneDocIsNotApprove:
					return "coral";
					case IturStatusEnum.OneDocIsApprove:
					return "aquamarine";
					case IturStatusEnum.SomeDocIsNotApprove:
					return "lightpink";
					case IturStatusEnum.SomeDocIsApprove:
					return "lightgreen";
					case IturStatusEnum.DisableAndNoOneDoc:
					return "lightseagreen";
					case IturStatusEnum.DisableAndOneDocIsNotApprove:
					return "lightslategray";
					case IturStatusEnum.DisableAndOneDocIsApprove:
					return "lightsteelblue";
					case IturStatusEnum.DisableAndSomeDocIsNotApprove:
					return "lightyellow";
					case IturStatusEnum.DisableAndSomeDocIsApprove:
					return "salmon";
					case IturStatusEnum.WarningConvert:
					return "orange";
					default:
					return "white";
				}
			}
			catch { return "white"; }
		}

		public static string StatusIturBitDefaultTitleGet(int statusIturBit)
		{
			try
			{
				IturStatusEnum status = (IturStatusEnum)statusIturBit;
				switch (status)
				{
					case IturStatusEnum.NoOneDoc:
					return "NoOneDoc";
					//case IturStatusEnum.None:
					//    return Color.FromRgb(176, 196, 222);
					case IturStatusEnum.OneDocIsNotApprove:
					return "OneDocIsNotApprove";
					case IturStatusEnum.OneDocIsApprove:
					return "OneDocIsApprove";
					case IturStatusEnum.SomeDocIsNotApprove:
					return "SomeDocIsNotApprove";
					case IturStatusEnum.SomeDocIsApprove:
					return "SomeDocIsApprove";
					case IturStatusEnum.DisableAndNoOneDoc:
					return "DisableAndNoOneDoc";
					case IturStatusEnum.DisableAndOneDocIsNotApprove:
					return "DisableAndOneDocIsNotApprove";
					case IturStatusEnum.DisableAndOneDocIsApprove:
					return "DisableAndOneDocIsApprove";
					case IturStatusEnum.DisableAndSomeDocIsNotApprove:
					return "DisableAndSomeDocIsNotApprove";
					case IturStatusEnum.DisableAndSomeDocIsApprove:
					return "DisableAndSomeDocIsApprove";
					case IturStatusEnum.WarningConvert:
					return "WarningConvert";
					default:
					return "none";
				}
			}
			catch { return "none"; }
		}


		public static Color StatusColorGet(string status)
		{
			IturStatusEnum en = (IturStatusEnum)Enum.Parse(typeof(IturStatusEnum), status);
			return StatusDefaultColorGet(en);
		}

		public static string StatusColorGetString(string status)
		{
			IturStatusEnum en = (IturStatusEnum)Enum.Parse(typeof(IturStatusEnum), status);
			return ColorToString(StatusDefaultColorGet(en));
		}

		public static string StatusGroupBitDefaultColorGet(int statusGroupBit)
		{
			try
			{
				IturStatusGroupEnum statusGroup = (IturStatusGroupEnum)statusGroupBit;
				switch (statusGroup)
				{
					case IturStatusGroupEnum.Empty:
					return "white";
					case IturStatusGroupEnum.OneDocIsApprove:
					return "lightgreen";
					case IturStatusGroupEnum.AllDocsIsApprove:
					return "lightblue";
					case IturStatusGroupEnum.NotApprove:
					return "tomato";
					case IturStatusGroupEnum.DisableAndNoOneDoc:
					return "gray";
					case IturStatusGroupEnum.DisableWithDocs:
					return "brown";
					case IturStatusGroupEnum.Error:
					return "orange";
					case IturStatusGroupEnum.None:
					return "lightgray";
					default:
					return "white";
				}
			}
			catch { return "white"; }
		}

		public static string StatusGroupBitDefaultTitleGet(int statusGroupBit)
		{
			try
			{
				IturStatusGroupEnum statusGroup = (IturStatusGroupEnum)statusGroupBit;
				switch (statusGroup)
				{
					case IturStatusGroupEnum.Empty:
					return "Empty";
					case IturStatusGroupEnum.OneDocIsApprove:
					return "OneDocIsApprove";
					case IturStatusGroupEnum.AllDocsIsApprove:
					return "AllDocsIsApprove";
					case IturStatusGroupEnum.NotApprove:
					return "NotApprove";
					case IturStatusGroupEnum.DisableAndNoOneDoc:
					return "DisableAndNoOneDoc";
					case IturStatusGroupEnum.DisableWithDocs:
					return "DisableWithDocs";
					case IturStatusGroupEnum.Error:
					return "Error";
					case IturStatusGroupEnum.None:
					return "None";
					default:
					return "None";
				}
			}
			catch { return "None"; }
		}
		public static Color StatusGroupDefaultColorGet(IturStatusGroupEnum statusGroup)
		{
			switch (statusGroup)
			{
				case IturStatusGroupEnum.Empty:
				return Color.White;
				case IturStatusGroupEnum.OneDocIsApprove:
				return Color.LightGreen;
				case IturStatusGroupEnum.AllDocsIsApprove:
				return Color.LightBlue;
				case IturStatusGroupEnum.NotApprove:
				return Color.Tomato;
				case IturStatusGroupEnum.DisableAndNoOneDoc:
				return Color.Gray;
				case IturStatusGroupEnum.DisableWithDocs:
				return Color.Brown;
				case IturStatusGroupEnum.Error:
				return Color.Orange;
				case IturStatusGroupEnum.None:
				return Color.LightGray;
				default:
				return Color.White;
			}
		}

		public static Color StatusGroupColorGet(string statusGroup)
		{
			IturStatusGroupEnum en = (IturStatusGroupEnum)Enum.Parse(typeof(IturStatusGroupEnum), statusGroup);
			return StatusGroupDefaultColorGet(en);
		}

		public static string StatusGroupColorGetString(string statusGroup)
		{
			IturStatusGroupEnum en = (IturStatusGroupEnum)Enum.Parse(typeof(IturStatusGroupEnum), statusGroup);
			return ColorToString(StatusGroupDefaultColorGet(en));
		}

		public static Dictionary<MessageTypeEnum, bool> LogTypeListGet()
		{
			Dictionary<MessageTypeEnum, bool> result = new Dictionary<MessageTypeEnum, bool>();

			foreach (MessageTypeEnum en in Enum.GetValues(typeof(MessageTypeEnum)))
			{
				result.Add(en, false);
			}
			return result;
		}


	}
}