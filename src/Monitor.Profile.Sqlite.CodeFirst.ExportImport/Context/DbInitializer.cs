using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Monitor.Service.Model;
using Monitor.Sqlite.CodeFirst.MappingEF;

namespace Monitor.Sqlite.CodeFirst
{
    public static class DbInitializer
    {
        public static void Initialize(MonitorSqliteDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.ProfileFileDatas.Any())
            {
                return;   // DB has been seeded
            }

			//Monitor.Service.Model.ProfileFile profileFile = new Monitor.Service.Model.ProfileFile();
			//profileFile.Code = "CustomerCode1";
			//profileFile.CustomerCode = "CustomerCode1";
			//profileFile.DomainObject = "Customer";

			//Monitor.Service.Model.ProfileFile profileFile1 = new Monitor.Service.Model.ProfileFile();
			//profileFile1.Code = "CustomerBranch1";
			//profileFile1.CustomerCode = "CustomerCode1";
			//profileFile1.BranchCode = "BranchCode1";
			//profileFile1.ParentCode = "CustomerCode1";
			//profileFile1.DomainObject = "Branch";

			//Monitor.Service.Model.ProfileFile[] profileFiles = new Monitor.Service.Model.ProfileFile[]
			//{
			//		profileFile,
			//		profileFile1
			//};
			//foreach (Monitor.Service.Model.ProfileFile pf in profileFiles)
			//{
			//	var entity = pf.ToEntity();
			//	context.ProfileFileDatas.Add(entity);
			//}
			//context.SaveChanges();
    
        }
    }
}