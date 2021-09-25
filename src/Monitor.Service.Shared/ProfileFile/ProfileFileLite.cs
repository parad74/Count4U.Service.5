using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{


	public class ProfileFileLite
	{
		public string DomainObject { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Error { get; set; }
   		public SuccessfulEnum Successful { get; set; }


		public ProfileFileLite()
		{
			this.Code = "";
			this.DomainObject = "";
			this.Error = "";
			this.Successful = SuccessfulEnum.NotStart;
			this.Email = "";
		}

		

		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ProfileFileLite))
				return false;
			return this.Equals((ProfileFileLite)obj);
		}

		public bool Equals(ProfileFile other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return Equals(other.Code, this.Code);
		}

		public override int GetHashCode()
		{
			return (this.Code.ToString() != null ? this.Code.ToString().GetHashCode() : 0);
		}

	}
}
