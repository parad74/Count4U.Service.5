using System;
using System.Diagnostics;

namespace Service.Model
{
	[Serializable]
	[DebuggerDisplay("{ClaimType} => {Value}")]
	public class ClaimConvertItem
	{
		public string Name { get; set; }
		public string Issuer { get; set; }
		public string ClaimType { get; set; }
		public string Value { get; set; }

		public string HeaderValue { get; set; }         //[WebApi]

		public string DBSettingsValue { get; set; }       //[WebApi]


		public ClaimConvertItem(string name, string issuer, string claimType, string value)
		{
			this.Name = name;
			this.Issuer = issuer;
			this.ClaimType = claimType;
			this.Value = value;
			this.HeaderValue = "";
			this.DBSettingsValue = "";
		}

		public ClaimConvertItem() { }

		public override string ToString() => $"{this.ClaimType}, {this.Value}";

		public string FullName => $"{this.ClaimType} : {this.Value}";

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ClaimConvertItem))
				return false;
			return this.Equals((ClaimConvertItem)obj);
		}

		public bool Equals(ClaimConvertItem other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return Equals(other.ClaimType, this.ClaimType);
		}

		public override int GetHashCode()
		{
			return (this.ClaimType != null ? this.ClaimType.GetHashCode() : 0);
		}
	}

}
