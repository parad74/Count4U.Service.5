////using System;
////using System.IO;
////using System.Text;
////using System.Text.RegularExpressions;
////using System.Threading;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Mvc.Filters;

////namespace Count4U.Service.Common.Filter.ActionFilterFactory
////{
////	//фильтр пробелов, который удаляет пробелы из выходного кода html
////	public class WhitespaceAttribute : Attribute, IActionFilter
////	{
////		//объект ActionExecutingContext, который имеет ряд свойств. Посредством 
////		//изменения значения ActionExecutingContext.ActionArguments можно манипулировать параметрами метода. 
////		//Либо через значение ActionExecutingContext.Controller можно управлять контроллером
////		//метод OnActionExecuting() может завершить обработку запроса путем установки свойства ActionExecutingContext.Result.
////		public void OnActionExecuting(ActionExecutingContext context)
////		{

////		}

////		//На этом этапе мы можем увидеть результат выполнения и как-то его изменить через свойство ActionExecutedContext.Result.
////		public void OnActionExecuted(ActionExecutedContext context)
////		{
////			var response = context.HttpContext.Response;
////			// Если sitemap, то ничего не делаем
////			if (context.HttpContext.Request.Path.ToString() == "/sitemap.xml")
////				return;
////			if (response.Body == null)
////				return;
////			response.Body = new SpaceCleaner(response.Body);
////		}

////		// вспомогательный класс для удаления пробелов
////		private class SpaceCleaner : Stream
////		{
////			private readonly Stream outputStream;
////			StringBuilder _s = new StringBuilder();

////			public SpaceCleaner(Stream filterStream)
////			{
////				if (filterStream == null)
////					throw new ArgumentNullException("filterStream is not determined");
////				this.outputStream = filterStream;
////			}

////			public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
////			{
////				var html = Encoding.UTF8.GetString(buffer, offset, count);
////				//регулярное выражение для поиска пробелов между тегами
////				var reg = new Regex(@"(?<=\s)\s+(?![^<>]*</pre>)");
////				html = reg.Replace(html, string.Empty);
////				buffer = Encoding.UTF8.GetBytes(html);
////				await this.outputStream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
////			}

////			public override void Write(byte[] buffer, int offset, int count)
////			{
////				throw new NotSupportedException();
////			}
////			// нереализованные методы Stream
////			public override int Read(byte[] buffer, int offset, int count)
////			{
////				throw new NotSupportedException();
////			}
////			public override bool CanRead { get { return false; } }
////			public override bool CanSeek { get { return false; } }
////			public override bool CanWrite { get { return true; } }
////			public override long Length { get { throw new NotSupportedException(); } }
////			public override long Position
////			{
////				get { throw new NotSupportedException(); }
////				set { throw new NotSupportedException(); }
////			}
////			public override void Flush()
////			{
////				this.outputStream.Flush();
////			}
////			public override long Seek(long offset, SeekOrigin origin)
////			{
////				throw new NotSupportedException();
////			}
////			public override void SetLength(long value)
////			{
////				throw new NotSupportedException();
////			}
////		}
////	}

////	//how use
////	//public class HomeController : Controller
////	//{
////	//	[Whitespace]
////	//	public IActionResult Index()
////	//	{
////	//		return View();
////	//	}
////	//}
////}
