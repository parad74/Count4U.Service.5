
//namespace Count4U.Service.Common.Filter
//{
////https://www.devtrends.co.uk/blog/dependency-injection-in-action-filters-in-asp.net-core
//	public class ThrottleFilterFactory : Attribute, IFilterFactory
//	{
//		public int MaxRequestPerSecond { get; set; }

//		public bool IsReusable => false;

//		public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
//		{
//			var filter = serviceProvider.GetService<ThrottleFilter>();

//			if (MaxRequestPerSecond > 0)
//			{
//				filter.MaxRequestPerSecond = MaxRequestPerSecond.Value;
//			}

//			return filter;
//		}
//	}


//	public class ThrottleFilter : IActionFilter
//	{
//		private const int DefaultMaxRequestPerSecond = 3;

//		private readonly IDistributedCache _cache;

//		public int MaxRequestPerSecond { get; set; } = DefaultMaxRequestPerSecond;

//		public ThrottleFilter(IDistributedCache cache)
//		{
//			_cache = cache ?? throw new ArgumentNullException(nameof(cache));
//		}

//		public void OnActionExecuting(ActionExecutingContext context)
//		{
//			throw new NotImplementedException();
//		}

//		public void OnActionExecuted(ActionExecutedContext context)
//		{
//			throw new NotImplementedException();
//		}
//		// ...
//	}
//}
//how use
//[ThrottleFilterFactory(MaxRequestPerSecond = 10)]
//public IActionResult Example()