//using CommonServiceLocator;
//using Count4U.Model;
//using Count4U.Model.Audit;
//using Count4U.Model.Common;
//using Count4U.Model.Interface;
//using Count4U.Model.Interface.Audit;
//using Count4U.Model.Interface.ProcessC4U;
//using Count4U.Model.ProcessC4U;
//using Count4U.Model.Transfer;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace VerfiyUnityResolving.App_Start
{
	//[TestClass]
	//public class VerifyContainerResolving
	//{
	//	[TestMethod]
	//	public void TestMethod1()
	//	{
	//		IUnityContainer container = new UnityContainer();


	//		//container.RegisterType<ICustomerManager, CustomerManager>(new HierarchicalLifetimeManager());
	//		//container.RegisterType<ICustomerData, CustomerData>(new HierarchicalLifetimeManager());
	//		//container.RegisterType<IUserSettingsManager, UserSettingsManager>( new ContainerControlledLifetimeManager());
	//		container.RegisterType<ISettingsRepository, SettingsRepository>( new ContainerControlledLifetimeManager());
	//		container.RegisterType<IDBSettings, DBSettings>( new ContainerControlledLifetimeManager());
	//		container.RegisterType<IConnectionDB, ConnectionDB>( new ContainerControlledLifetimeManager());
	//		container.RegisterType<IZip, Zip>( new ContainerControlledLifetimeManager());
	//		//	container.RegisterType<IApplicationVersion, ApplicationVersion>( new ContainerControlledLifetimeManager());
	//		container.RegisterType<IAuditConfigRepository, AuditConfigEFRepository>( new ContainerControlledLifetimeManager());
	//		container.RegisterType<IProcessRepository, ProcessEFRepository>( new ContainerControlledLifetimeManager());


	//		container.Resolve<ISettingsRepository>().LogPath = "";//App.LogPath;  TO DO
	//		container.Resolve<ISettingsRepository>().StartupArgumentDictionary = new Dictionary<string, string>(); // TO DO//App.StartupArgumentDictionary;
	//		string ProcessCode = "";


	//		try
	//		{
	//			IServiceLocator serviceLocator = container.Resolve<IServiceLocator>();
	//			IProcessRepository processRepository = serviceLocator.GetInstance<IProcessRepository>();
	//			ProcessCode = processRepository.GetProcessCode_InProcess();
	//		}
	//		catch { }
	//		container.Resolve<ISettingsRepository>().ProcessCode = ProcessCode;

	//		DBModuleInit.InitializeStatic(container);
	//		ExportImportModuleInit.InitializeStatic(container);

	//		/* Verification for container resolving*/
	//		container.AddExtension(new Diagnostic());
	//		foreach (var registration in container.Registrations)
	//		{
	//			try
	//			{
	//				container.Resolve(registration.RegisteredType, registration.Name);
	//			}
	//			catch (ResolutionFailedException ex)
	//			{
	//				Assert.Fail(string.Concat(ex.Message, "\n", ex.StackTrace.ToString()));
	//			}
	//		}
	//		/* Verification for container resolving*/
	//	}
	//}
}