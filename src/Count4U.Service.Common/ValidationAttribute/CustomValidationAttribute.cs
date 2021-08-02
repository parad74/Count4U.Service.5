using System.ComponentModel.DataAnnotations;

namespace Count4U.Service.Common
{
	public class CustomValidationAttribute : ValidationAttribute
	{
		//Как использовать в вттрибуте сервис из DI
		//protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		//{
		//	// ... validation logic
		//	var service = (IExternalService)validationContext
		//				.GetService(typeof(IExternalService));

		//	// use service
		//}
	}
}
