using Newtonsoft.Json;

namespace Count4U.Service.Common.Filter
{
	//https://www.jerriepelser.com/blog/validation-response-aspnet-core-webapi/
	// класс для ответа, который вернуть
	public class ValidationError
	{
		//Это должно гарантировать, что поле не будет сериализовано в случае нулевого значения - то есть для ошибок проверки всей модели.
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Field { get; }

		public string Message { get; }

		//Обратите внимание на[JsonProperty(NullValueHandling = NullValueHandling.Ignore)] атрибут в Field свойстве.
		//	Это должно гарантировать, что поле не будет сериализовано в случае нулевого значения -
		//	то есть для ошибок проверки всей модели.

		//Объект, ModelStateDictionary из которого я получаю ошибки, не допускает нулевые значения для Key,
		//	но он допускает пустые строки.Я хочу преобразовать это в a null в случае пустой строки, 
		//	чтобы Field свойство не сериализовалось для пустых имен полей. 
		//	Это проверка, которую я делаю в конструкторе ValidationError.

		public ValidationError(string field, string message)
		{
			this.Field = field != string.Empty ? field : null;
			this.Message = message;
		}
	}
}
