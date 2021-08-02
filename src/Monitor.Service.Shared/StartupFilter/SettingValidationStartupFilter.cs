using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Monitor.Service.Model.Settings;

namespace Service.Filter
{
	//https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-in-asp-net-core/
	public class SettingValidationStartupFilter : IStartupFilter
	{
		readonly IEnumerable<IValidatable> _validatableObjects;
		public SettingValidationStartupFilter(IEnumerable<IValidatable> validatableObjects)
		{
			this._validatableObjects = validatableObjects;
		}

		//IStartupFilter вызов Validate() для всех IValidatable объектов, зарегистрированных в контейнере DI:
		//Это IStartupFilterне изменяет конвейер промежуточного программного обеспечения: он возвращается nextбез его модификации. 
		//Но если кто-либо IValidatableвыдает исключение, то оно всплывает и препятствует запуску приложения.
		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
		{
			foreach (var validatableObject in this._validatableObjects)
			{
				validatableObject.Validate();
			}

			//don't alter the configuration
			return next;
		}
	}
}    //Наконец, вам нужно реализовать IValidatable интерфейс в  настройках, которые надо проверять при запуске.
