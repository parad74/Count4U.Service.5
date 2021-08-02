using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Count4U.Service.Common
{
	public static class SessionExtensions
	{
		public static void Set<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		public static T Get<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}
	}
}

//how use
// if (context.Session.Keys.Contains("person"))
//            {
//                Person person = context.Session.Get<Person>("person");
//await context.Response.WriteAsync($"Hello {person.Name}!");
//            }
//            else
//            {
//                Person person = new Person { Name = "Tom", Age = 22 };
//context.Session.Set<Person>("person", person);
//                await context.Response.WriteAsync("Hello World!");
//            }


//Объект Session определяет ряд свойств и методов, которые мы можем использовать:

//Keys: свойство, представляющее список строк, который хранит все доступные ключи

//Clear(): очищает сессию

//Get(string key) : получает по ключу key значение, которое представляет массив байтов

//GetInt32(string key) : получает по ключу key значение, которое представляет целочисленное значение

//GetString(string key) : получает по ключу key значение, которое представляет строку

// Set(string key, byte[] value): устанавливает по ключу key значение, которое представляет массив байтов

//SetInt32(string key, int value) : устанавливает по ключу key значение, которое представляет целочисленное значение value

// SetString(string key, string value): устанавливает по ключу key значение, которое представляет строку value

//Remove(string key) : удаляет значение по ключу