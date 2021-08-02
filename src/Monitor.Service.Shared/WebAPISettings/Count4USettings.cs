using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Monitor.Service.Model.Settings
{
	//Validate() метод выдает исключение, если есть проблема с вашей конфигурацией и привязкой.
	// https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-in-asp-net-core/

	public interface ICount4uSettings
	{
		bool UseAppDataPath { get; set; }

		string AppDataPath { get; set; }             //C:\Count4U\trunk\Count4U\Count4U.Model

		bool UseProgramDataAppDataPath { get; set; }

		string ProgramDataAppDataPath { get; set; }         //C:\ProgramData\Count4U
	}

	public class Count4uSettings : IValidatable, ICount4uSettings
	{
		//	[Required]
		//	public bool UseServerAppDataPath { get; set; }

		[Required]
		public bool UseAppDataPath { get; set; }

		[Required]
		public string AppDataPath { get; set; }             //C:\Count4U\trunk\Count4U\Count4U.Model

		[Required]
		public bool UseProgramDataAppDataPath { get; set; }

		[Required]
		public string ProgramDataAppDataPath { get; set; }         //C:\ProgramData\Count4U



		//[Required]
		//public string DisplayName { get; set; }
		//public bool ShouldNotify { get; set; }

		public void Validate()
		{
			Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);

			if (this.UseAppDataPath == true && this.UseProgramDataAppDataPath == true)
			{
				throw new ArgumentException("UseAppDataPath and UseProgramDataAppDataPath cann't be both equal true in the same Count4USettings");
			}

			if (this.UseAppDataPath == true)
			{
				if (System.IO.Directory.Exists(this.AppDataPath) == false)
				{
					throw new DirectoryNotFoundException(this.AppDataPath);
				}
			}

			if (this.UseProgramDataAppDataPath == true)
			{
				if (System.IO.Directory.Exists(this.ProgramDataAppDataPath) == false)
				{
					throw new DirectoryNotFoundException(this.ProgramDataAppDataPath);
				}
			}
		}

	}
}

