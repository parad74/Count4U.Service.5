//using Unity;
using Microsoft.Extensions.Logging;

namespace Count4U.Model.Common
{
	public interface IModule
	{
		void Initialize();
	}
	public class ModelCommonModuleInit : IModule
    {
		//private readonly IUnityContainer _container;
		private readonly ILogger _logger;

		public ModelCommonModuleInit(/*IUnityContainer container,*/ ILoggerFactory loggerFactory)
        {
           // _container = container;
			_logger = loggerFactory.CreateLogger<ModelCommonModuleInit>();
		}

        #region Implementation of IModule

        public void Initialize()
        {
		
        }

        #endregion
    }
}