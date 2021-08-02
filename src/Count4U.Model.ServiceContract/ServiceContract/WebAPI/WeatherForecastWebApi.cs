using System;

namespace Count4U.Service.WebAPI.Model
{

	public interface IWeatherForecastWebApi
	{
		DateTime Date { get; set; }

		int TemperatureC { get; set; }

		int TemperatureF { get; }

		string Summary { get; set; }
	}

	public class WeatherForecastWebApi : IWeatherForecastWebApi
	{
		public WeatherForecastWebApi()
		{ Summary = "not Test"; }
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string Summary { get; set; }
	}

	public interface IWeatherForecastTest
	{
		DateTime Date { get; set; }

		int TemperatureC { get; set; }

		int TemperatureF { get; }

		string Summary { get; set; }
	}

	public class WeatherForecastTest  : IWeatherForecastTest

	{
		public WeatherForecastTest()
		{ Summary = "Test";   }
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string Summary { get; set; }
	}

	public class WeatherForecastTest1 : IWeatherForecastTest

	{
		public WeatherForecastTest1()
		{ Summary = "Test1"; }
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string Summary { get; set; }
	}

	
}

