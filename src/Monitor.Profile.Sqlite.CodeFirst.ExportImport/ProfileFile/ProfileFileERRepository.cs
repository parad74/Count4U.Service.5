using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Count4U.Model.SelectionParams;
using System.Data.Entity.Validation;
using Monitor.Model.ServiceContract.Interface;
using Monitor.Sqlite.CodeFirst.MappingEF;
using System.Threading.Tasks;
using Monitor.Service.Model;
using System.Collections.Generic;
using Count4U.Model.Common;

namespace Monitor.Sqlite.CodeFirst
{
	public class ProfileFileERRepository : BaseEFDbSetRepository, IProfileFileRepository
	{
		private readonly ILogger _logger;
		//protected IConnectionSqliteMonitorDB _connection;
	    private readonly MonitorSqliteDBContext _context;
		private readonly ISettingsFtpRepository _settingsFtpRepository;

		public ProfileFileERRepository(MonitorSqliteDBContext context, ISettingsFtpRepository settingsFtpRepository,
			ILoggerFactory loggerFactory)
			: base()
		{
			_logger = loggerFactory.CreateLogger<ProfileFileERRepository>();
			this._context = context ??
				throw new ArgumentNullException(nameof(context));
			this._settingsFtpRepository = settingsFtpRepository ??
			throw new ArgumentNullException(nameof(settingsFtpRepository));
		}
	

		#region IMaskRepository Members
 		public Monitor.Service.Model.ProfileFiles GetProfileFiles()
		{
				var entertiList =  this._context.ProfileFileDatas.ToList();
				var domainObjects = entertiList.Select(e => e.ToDomainObject());
				//var domainObjects = dc.Process.ToList().Select(e => e.ToDomainObject());
				return Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
		}

		public Monitor.Service.Model.ProfileFiles GetProfileFiles(SelectParams selectParams)
		{
			if (selectParams == null)
				return GetProfileFiles();

			long totalCount = 0;

			var entities = GetEntities(_context, _context.ProfileFileDatas.AsQueryable(), _context.ProfileFileDatas.AsQueryable(), selectParams, out totalCount);

			//Преобразование сущностей в объекты предметной области.
			//Converting entites to domain objects.
			var domainObjects = entities.Select(e => e.ToDomainObject());

			//Возврат результата.
			//Returning result.
			Monitor.Service.Model.ProfileFiles result = Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
			result.TotalCount = totalCount;
			return result;

		}

		public Monitor.Service.Model.ProfileFiles GetCustomersProfileFiles()
		{
			var entertiList = this.GetEntitiesCustomer(_context);
			var domainObjects = entertiList.Select(e => e.ToSimpleDomainObject());
			return Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
		}

		public List<string> GetCustomerCodeList()
		{
			List<string> ret = new List<string>();
			var entertiList = this.GetEntitiesCustomer(_context);
			ret = entertiList.Select(e => e.CustomerCode).Distinct().ToList();
			return ret;
		}
		
		public Monitor.Service.Model.ProfileFiles GetBranchesProfileFiles()
		{
			var entertiList = this.GetEntitiesBranch(_context);
			var domainObjects = entertiList.Select(e => e.ToSimpleDomainObject());
			return Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
		}

		public List<string> GetBranchCodeList()
		{
			List<string> ret = new List<string>();
			var entertiList = this.GetEntitiesBranch(_context);
			ret = entertiList.Select(e => e.BranchCode).Distinct().ToList();
			return ret;
		}
		public Monitor.Service.Model.ProfileFiles GetBranchesProfileFiles(string customerCode)
		{
			var entertiList = this.GetEntitiesBranch(_context, customerCode);
			var domainObjects = entertiList.Select(e => e.ToSimpleDomainObject());
			return Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
		}

		public List<string> GetBranchCodeListForCustomer(string customerCode)
		{
			List<string> ret = new List<string>();
			var entertiList = this.GetEntitiesBranch(_context, customerCode);
			ret = entertiList.Select(e => e.BranchCode).Distinct().ToList();
			return ret;
		}

		public Monitor.Service.Model.ProfileFiles GetInventoriesProfileFiles()
		{
			var entertiList = this.GetEntitiesInventor(_context);
			var domainObjects = entertiList.Select(e => e.ToSimpleDomainObject());
			return Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
		}

		public List<string> GetInventorCodeList()
		{
			List<string> ret = new List<string>();
			var entertiList = this.GetEntitiesInventor(_context);
			ret = entertiList.Select(e => e.InventorCode).Distinct().ToList();
			return ret;
		}

		public Monitor.Service.Model.ProfileFiles GetInventoriesProfileFilesByCustomerCode(string customerCode)
		{
			var entertiList = this.GetEntitiesInventor(_context, customerCode);
			var domainObjects = entertiList.Select(e => e.ToSimpleDomainObject());
			return Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
		}

		public List<string> GetInventorCodeListForCustomer(string customerCode)
		{
			List<string> ret = new List<string>();
			var entertiList = this.GetEntitiesInventor(_context, customerCode);
			ret = entertiList.Select(e => e.InventorCode).Distinct().ToList();
			return ret;
		}

		public Monitor.Service.Model.ProfileFiles GetInventoriesProfileFilesByBranchCode(string branchCode)
		{
			var entertiList = this.GetEntitiesInventorByBranchCode(_context, branchCode);
			var domainObjects = entertiList.Select(e => e.ToSimpleDomainObject());
			return Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
		}

		public List<string> GetInventorCodeListForBranch(string branchCode)
		{
			List<string> ret = new List<string>();
			var entertiList = this.GetEntitiesInventorByBranchCode(_context, branchCode);
			ret = entertiList.Select(e => e.InventorCode).Distinct().ToList();
			return ret;
		}


		public Monitor.Service.Model.ProfileFiles GetTestDataProfileFiles()
		{
			try
			{
				Monitor.Service.Model.ProfileFile profileFile = new Monitor.Service.Model.ProfileFile();
				profileFile.Code = "CustomerCode5";
				profileFile.CustomerCode = "CustomerCode5";
				profileFile.DomainObject = "Customer";

				Monitor.Service.Model.ProfileFile profileFile1 = new Monitor.Service.Model.ProfileFile();
				profileFile1.Code = "BranchCode5";
				profileFile1.CustomerCode = "CustomerCode5";
				profileFile1.BranchCode = "BranchCode5";
				profileFile1.ParentCode = "CustomerCode5";
				profileFile1.DomainObject = "Branch";

				Monitor.Service.Model.ProfileFile profileFile2 = new Monitor.Service.Model.ProfileFile();
				profileFile2.Code = "InventorBranch5";
				profileFile2.CustomerCode = "CustomerCode5";
				profileFile2.BranchCode = "BranchCode5";
				profileFile2.ParentCode = "BranchCode5";
				profileFile2.DomainObject = "Inventor";
				profileFile2.InventorCode = "InventorCode5";

				Monitor.Service.Model.ProfileFiles profileFiles  = new Monitor.Service.Model.ProfileFiles();
				profileFiles.Add(profileFile);
				profileFiles.Add(profileFile1);
				profileFiles.Add(profileFile2);

				InsertList(profileFiles);
			}
			catch (Exception ext)
			{
				string message = ext.Message;
				return new Monitor.Service.Model.ProfileFiles();
			}

					//dc.TryCreateDB();
				try
				{
					var entertis = _context.ProfileFileDatas;
					var entertiList = entertis.ToList();
					var domainObjects = entertiList.Select(e => e.ToDomainObject());
					//var domainObjects = dc.Process.ToList().Select(e => e.ToDomainObject());
					return Monitor.Service.Model.ProfileFiles.FromEnumerable(domainObjects);
				}
				catch (Exception ext)
				{
					string message = ext.Message;
					return new Monitor.Service.Model.ProfileFiles();
				}
		

		}

		public Task DeleteAll()
        {
			_context.ProfileFileDatas.ToList().ForEach(e => _context.ProfileFileDatas.Remove(e));
			_context.SaveChanges();
  			return Task.FromResult(true);
        }

		public Monitor.Service.Model.ProfileFile GetProfileFile(long id)
		{
				var entity = this.GetEntitiesById(_context, id);
				if (entity == null)
					return null;
				return entity.ToDomainObject();
		}

		public Monitor.Service.Model.ProfileFiles GetProfileFilesByParentCode(string parentCode)
		{
				var entitys = _context.ProfileFileDatas.Where(e => (e.ParentCode == parentCode)).Select(e => e.ToDomainObject()).ToList();
				if (entitys == null)
					return null;
			ProfileFiles result = ProfileFiles.FromEnumerable(entitys);
				return result;
		}


		public Monitor.Service.Model.ProfileFile GetProfileFileByObjectCode(string objectCode)
		{
			var entity = this.GetEntitiesByCode(_context, objectCode);
			if (entity == null)
				return null;
			return entity.ToDomainObject();

		}

		
		public Monitor.Service.Model.ProfileFile GetProfileFileByInventorCode(string objectCode)
		{
			var entity = this.GetEntitiesByInventorCode(_context, objectCode);
			if (entity == null)
				return null;
			return entity.ToDomainObject();

		}

		public Monitor.Service.Model.ProfileFile GetProfileFileInventor(Monitor.Service.Model.ProfileFile profileFileModel)
		{
			if (profileFileModel == null)
			{
				return new Monitor.Service.Model.ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.ProfileFileIsNull) { Error = $"ERROR GetProfileFileInventor : ProfileFile is null" };
			}

			string customerCode = profileFileModel.CustomerCode;
			if (string.IsNullOrWhiteSpace(customerCode) == true)
			{
				profileFileModel.Successful = SuccessfulEnum.NotSuccessful;
				profileFileModel.ResultCode = CommandResultCodeEnum.ValidateError;
				profileFileModel.Error = "CustomerCode  Is Empty";
				return profileFileModel;
			}

			string branchCode = profileFileModel.BranchCode;
			if (string.IsNullOrWhiteSpace(branchCode) == true)
			{
				profileFileModel.Successful = SuccessfulEnum.NotSuccessful;
				profileFileModel.ResultCode = CommandResultCodeEnum.ValidateError;
				profileFileModel.Error = "BranchCode  Is Empty";
				return profileFileModel;
			}
			string inventorSubfolder = profileFileModel.InventorDBPath;
			if (string.IsNullOrWhiteSpace(inventorSubfolder) == true)
			{
				profileFileModel.Successful = SuccessfulEnum.NotSuccessful;
				profileFileModel.ResultCode = CommandResultCodeEnum.ValidateError;
				profileFileModel.Error = "InventorDBPath  Is Empty";
				return profileFileModel;
			}

			var entity = this.GetEntitiesByInventorCode(_context, profileFileModel.InventorCode);
			if (entity == null)
			{
				profileFileModel.Successful = SuccessfulEnum.NotSuccessful;
				profileFileModel.ResultCode = CommandResultCodeEnum.Warning;
				profileFileModel.Error = $"No Inventor in Db with  {inventorSubfolder}";
				return profileFileModel;
			}
			return entity.ToDomainObject();

		}

	public Task Delete(long id)
		{
			var entity = this.GetEntitiesById(_context, id);
			if (entity != null)
			{
				_context.ProfileFileDatas.Remove(entity);
				_context.SaveChanges();
			}
			return Task.FromResult(true);
		}


		public Task Delete(string objectCode)
		{

			var entity = this.GetEntitiesByCode(_context, objectCode);
			if (entity != null)
			{
				_context.ProfileFileDatas.Remove(entity);
				_context.SaveChanges();
			}

			return Task.FromResult(true);
		}



		public long Insert(Monitor.Service.Model.ProfileFile profileFile)
		{
			if (profileFile == null)
				return -1;
			try
			{
				var entity = profileFile.ToEntity();
				_context.ProfileFileDatas.Add(entity);
				_context.SaveChanges();

				//var entity1 = GetEntitiesByCommandResultCode(dc, commandResult.CommandResultCode);
				var entity1 = GetEntitiesByProfileFileUID(_context, profileFile.ProfileFileUID);
				if (entity1 == null)
					return -1;
				else
					return entity1.ID;
			}

			catch (DbEntityValidationException e)
			{
				string error1 = "";
				foreach (var eve in e.EntityValidationErrors)
				{
					error1 += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						error1 += string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			catch (System.Data.Entity.Infrastructure.DbUpdateException e)
			{
				string error2 = "";
				foreach (var eve in e.Entries)
				{
					error2 += $"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated";
				}
				throw;
			}
		}

		public Task InsertArray(Monitor.Service.Model.ProfileFile[] profileFileArray)
		{
			if (profileFileArray == null)
				return Task.FromResult(true);

			try
			{
				foreach (Monitor.Service.Model.ProfileFile profileFile in profileFileArray)
				{
					var entity = profileFile.ToEntity();
					_context.ProfileFileDatas.Add(entity);
				}
				_context.SaveChanges();
			}

			catch (DbEntityValidationException e)
			{
				string error1 = "";
				foreach (var eve in e.EntityValidationErrors)
				{
					error1 += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						error1 += string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			catch (System.Data.Entity.Infrastructure.DbUpdateException e)
			{
				string error2 = "";
				foreach (var eve in e.Entries)
				{
					error2 += $"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated";
				}
				throw;
			}

			return Task.FromResult(true);
		}


		public Task InsertList(Monitor.Service.Model.ProfileFiles profileFileList)
		{
			if (profileFileList == null)
				return Task.FromResult(true);

			try
			{
				foreach (Monitor.Service.Model.ProfileFile profileFile in profileFileList)
				{
					var entity = profileFile.ToEntity();
					_context.ProfileFileDatas.Add(entity);
				}
				_context.SaveChanges();
			}

			catch (DbEntityValidationException e)
			{
				string error1 = "";
				foreach (var eve in e.EntityValidationErrors)
				{
					error1 += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						error1 += string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			catch (System.Data.Entity.Infrastructure.DbUpdateException e)
			{
				string error2 = "";
				foreach (var eve in e.Entries)
				{
					error2 += $"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated";
				}
				throw;
			}

			return Task.FromResult(true);
		}


		public Task InsertCustomersBySubFolderList(List<string> customerCodes)
		{
			if (customerCodes == null)
				return Task.FromResult(true);
			if (customerCodes.Count == 0)
				return Task.FromResult(true);
			Monitor.Service.Model.ProfileFiles profileFileList = new Service.Model.ProfileFiles();
			try
			{
				 
					foreach (string code in customerCodes)
					{
						if (string.IsNullOrWhiteSpace(code) == true) continue;
						Monitor.Service.Model.ProfileFile profileFile = new Monitor.Service.Model.ProfileFile();
						profileFile.Code = code;
						profileFile.CustomerCode = code;
						profileFile.SubFolder = code;
						profileFile.CurrentPath = @"Customer\" + profileFile.CustomerCode;
						profileFile.DomainObject = "Customer";

					//this._settingsFtpRepository.InitProperty(profileFile);
					//string profileTest = "";
					//string messageCreateFolder = "";
					//this._settingsFtpRepository.CopyProfileFileFromFtpToMemoryStream(profileFile.CurrentPath, ref profileTest, ref messageCreateFolder);
					//profileFile.ProfileXml = profileTest;


					profileFileList.Add(profileFile);
					}

				foreach (Monitor.Service.Model.ProfileFile profileFile in profileFileList)
				{
					Delete(profileFile.Code);
				}

				foreach (Monitor.Service.Model.ProfileFile profileFile in profileFileList)
				{
					var entity = profileFile.ToEntity();
					_context.ProfileFileDatas.Add(entity);
				}
				_context.SaveChanges();
			}

			catch (DbEntityValidationException e)
			{
				string error1 = "";
				foreach (var eve in e.EntityValidationErrors)
				{
					error1 += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						error1 += string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			catch (System.Data.Entity.Infrastructure.DbUpdateException e)
			{
				string error2 = "";
				foreach (var eve in e.Entries)
				{
					error2 += $"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated";
				}
				throw;
			}

			return Task.FromResult(true);
		}


		public Task InsertBranchsBySubFolderList(string customerCode, List<string> branchCodes)
		{
			if (branchCodes == null)
				return Task.FromResult(true);
			if (branchCodes.Count == 0)
				return Task.FromResult(true);
			if (string.IsNullOrWhiteSpace(customerCode) == true)
				return Task.FromResult(true);

			Monitor.Service.Model.ProfileFiles profileFileList = new Service.Model.ProfileFiles();
			try
			{

				foreach (string code in branchCodes)
				{
					if (string.IsNullOrWhiteSpace(code) == true) continue;
					Monitor.Service.Model.ProfileFile profileFile = new Monitor.Service.Model.ProfileFile();
					profileFile.Code = code;
					profileFile.ParentCode = customerCode;
					profileFile.CustomerCode = customerCode;
					profileFile.BranchCode = code;
					profileFile.SubFolder = code;
					profileFile.CurrentPath = @"Customer\" + profileFile.CustomerCode + @"\Branch\" + profileFile.BranchCode;
					profileFile.DomainObject = "Branch";

					profileFileList.Add(profileFile);
				}

				foreach (Monitor.Service.Model.ProfileFile profileFile in profileFileList)
				{
					Delete(profileFile.Code);

				}
				foreach (Monitor.Service.Model.ProfileFile profileFile in profileFileList)
				{
					var entity = profileFile.ToEntity();
					_context.ProfileFileDatas.Add(entity);
				}
				_context.SaveChanges();
			}

			catch (DbEntityValidationException e)
			{
				string error1 = "";
				foreach (var eve in e.EntityValidationErrors)
				{
					error1 += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						error1 += string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			catch (System.Data.Entity.Infrastructure.DbUpdateException e)
			{
				string error2 = "";
				foreach (var eve in e.Entries)
				{
					error2 += $"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated";
				}
				throw;
			}

			return Task.FromResult(true);
		}


		public Task InsertInventoriesBySubFolderList(string customerCode, string branchCode, List<string> inventorSubFolderList)
		{
			if (inventorSubFolderList == null)
				return Task.FromResult(true);
			if (inventorSubFolderList.Count == 0)
				return Task.FromResult(true);
			if (string.IsNullOrWhiteSpace(customerCode) == true)
				return Task.FromResult(true);
			if (string.IsNullOrWhiteSpace(branchCode) == true)
				return Task.FromResult(true);

			Monitor.Service.Model.ProfileFiles profileFileList = new Service.Model.ProfileFiles();
			try
			{

				foreach (string subfolder in inventorSubFolderList)
				{
					if (string.IsNullOrWhiteSpace(subfolder) == true) continue;
					string inventorCode = subfolder;
					string subFolderWithoutCode = subfolder;
					string inventorName = subfolder;
					try
					{
						string[] codes = subfolder.Split('\\');
						subFolderWithoutCode = $"{codes[0]}\\{codes[1]}\\{codes[2]}";
						inventorName = $"{codes[2]}\\{codes[1]}\\{codes[0]}";
						inventorCode = codes[3];
					}
					catch { }
					Monitor.Service.Model.ProfileFile profileFile = new Monitor.Service.Model.ProfileFile();
					profileFile.Code = inventorCode;
					profileFile.ParentCode = branchCode;
					profileFile.CustomerCode = customerCode;
					profileFile.BranchCode = branchCode;
					profileFile.InventorCode = inventorCode;
					profileFile.InventorName = inventorName;
					profileFile.SubFolder = subFolderWithoutCode;
					profileFile.InventorDBPath = subfolder;
					profileFile.CurrentPath = @"Customer\" + profileFile.CustomerCode + @"\Branch\" + profileFile.BranchCode + @"\Inventor\" + profileFile.InventorDBPath;
					profileFile.DomainObject = "Inventor";


					this._settingsFtpRepository.InitProperty(profileFile);
					string profileTest = "";
					string messageCreateFolder = "";
					this._settingsFtpRepository.CopyProfileFileFromFtpToMemoryStream(profileFile.CurrentPath, ref profileTest, ref messageCreateFolder);
					profileFile.ProfileXml = profileTest;

					profileFileList.Add(profileFile);
				}

				foreach (Monitor.Service.Model.ProfileFile profileFile in profileFileList)
				{
					Delete(profileFile.Code);
  				}

				foreach (Monitor.Service.Model.ProfileFile profileFile in profileFileList)
				{
					var entity = profileFile.ToEntity();
					_context.ProfileFileDatas.Add(entity);
				}
				_context.SaveChanges();
			}

			catch (DbEntityValidationException e)
			{
				string error1 = "";
				foreach (var eve in e.EntityValidationErrors)
				{
					error1 += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						error1 += string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			catch (System.Data.Entity.Infrastructure.DbUpdateException e)
			{
				string error2 = "";
				foreach (var eve in e.Entries)
				{
					error2 += $"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated";
				}
				throw;
			}

			return Task.FromResult(true);
		}


		public Monitor.Service.Model.ProfileFile InsertInventoriesByCBI(Monitor.Service.Model.ProfileFile profileFileModel)
		{		
			if (profileFileModel == null)
			{
				return new Monitor.Service.Model.ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.ProfileFileIsNull) { Error = $"ERROR InsertInventoriesByCBI : ProfileFile is null" };
			}

			string customerCode = profileFileModel.CustomerCode;
			if (string.IsNullOrWhiteSpace(customerCode) == true)
				{
					profileFileModel.Successful = SuccessfulEnum.NotSuccessful;
					profileFileModel.ResultCode = CommandResultCodeEnum.ValidateError;
				profileFileModel.Error = "CustomerCode  Is Empty";
					return profileFileModel;
				}
		
			string branchCode = profileFileModel.BranchCode;
			if (string.IsNullOrWhiteSpace(branchCode) == true)
				{
					profileFileModel.Successful = SuccessfulEnum.NotSuccessful;
					profileFileModel.ResultCode = CommandResultCodeEnum.ValidateError;
				profileFileModel.Error = "BranchCode  Is Empty";
					return profileFileModel;
				}
			string inventorSubfolder = profileFileModel.InventorDBPath;
			if (string.IsNullOrWhiteSpace(inventorSubfolder) == true)
			{
				profileFileModel.Successful = SuccessfulEnum.NotSuccessful;
				profileFileModel.ResultCode = CommandResultCodeEnum.ValidateError;
				profileFileModel.Error = "InventorDBPath  Is Empty";
					return profileFileModel;
			}

			//Monitor.Service.Model.ProfileFiles profileFileList = new Service.Model.ProfileFiles();
			try
			{
					string inventorCode = inventorSubfolder;
					string subFolderWithoutCode = inventorSubfolder;
					string inventorName = inventorSubfolder;
					try
					{
						string[] codes = inventorSubfolder.Split('\\');
						subFolderWithoutCode = $"{codes[0]}\\{codes[1]}\\{codes[2]}";
						inventorName = $"{codes[2]}\\{codes[1]}\\{codes[0]}";
						inventorCode = codes[3];
					}
					catch { }
					Monitor.Service.Model.ProfileFile profileFile = new Monitor.Service.Model.ProfileFile();
					profileFile.Code = inventorCode;
					profileFile.ParentCode = branchCode;
					profileFile.CustomerCode = customerCode;
					profileFile.BranchCode = branchCode;
					profileFile.InventorCode = inventorCode;
					profileFile.InventorName = inventorName;
					profileFile.SubFolder = subFolderWithoutCode;
					profileFile.InventorDBPath = inventorSubfolder;
					profileFile.CurrentPath = @"Customer\" + profileFile.CustomerCode + @"\Branch\" + profileFile.BranchCode + @"\Inventor\" + profileFile.InventorDBPath;
					profileFile.DomainObject = "Inventor";


					this._settingsFtpRepository.InitProperty(profileFile);
					string profileTest = "";
					string messageCreateFolder = "";
					this._settingsFtpRepository.CopyProfileFileFromFtpToMemoryStream(profileFile.CurrentPath, ref profileTest, ref messageCreateFolder);
					profileFile.ProfileXml = profileTest;

					this.Delete(profileFile.Code);
					long id = this.Insert(profileFile);
					Monitor.Service.Model.ProfileFile ret = GetProfileFile(id);
			}

			catch (DbEntityValidationException e)
			{
				string error1 = "";
				foreach (var eve in e.EntityValidationErrors)
				{
					error1 += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						error1 += string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			catch (System.Data.Entity.Infrastructure.DbUpdateException e)
			{
				string error2 = "";
				foreach (var eve in e.Entries)
				{
					error2 += $"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated";
				}
				throw;
			}

			return profileFileModel;
		}
		public Task Update(Monitor.Service.Model.ProfileFile profileFile)
		{
			if (profileFile == null)
				return Task.FromResult(true);

			var entity = GetEntitiesByProfileFileUID(_context, profileFile.ProfileFileUID);
			if (entity != null)
			{
				entity.ApplyChanges(profileFile);
				_context.SaveChanges();
			}

			return Task.FromResult(true);
		}
		#endregion

		#region private

		private Monitor.Sqlite.CodeFirst.ProfileFile GetEntitiesById(MonitorSqliteDBContext db, long id)
		{
			var entity = db.ProfileFileDatas.Where(e => (e.ID == id)).FirstOrDefault();
			return entity;
		}

		private Monitor.Sqlite.CodeFirst.ProfileFile GetEntitiesByCode(MonitorSqliteDBContext db, string code)
		{
			var entity = db.ProfileFileDatas.Where(e => (e.Code == code)).FirstOrDefault();
			return entity;
		}

		private Monitor.Sqlite.CodeFirst.ProfileFile GetEntitiesByInventorCode(MonitorSqliteDBContext db, string inventorCode)
		{
			var entity = db.ProfileFileDatas.Where(e => (e.InventorCode == inventorCode)).FirstOrDefault();
			return entity;
		}

		private List<Monitor.Sqlite.CodeFirst.ProfileFile> GetEntitiesByParentCode(MonitorSqliteDBContext db, string parentCode)
		{
			var entitys = db.ProfileFileDatas.Where(e => (e.ParentCode == parentCode)).Select(x => x).ToList();
			return entitys;
		}

		private List<Monitor.Sqlite.CodeFirst.ProfileFile> GetEntitiesCustomer(MonitorSqliteDBContext db)
		{
			var entitys = db.ProfileFileDatas.Where(e => (e.DomainObject == "Customer")).Select(x => x).ToList();
			return entitys;
		}

		private List<Monitor.Sqlite.CodeFirst.ProfileFile> GetEntitiesBranch(MonitorSqliteDBContext db)
		{
			var entitys = db.ProfileFileDatas.Where(e => (e.DomainObject == "Branch")).Select(x => x).ToList();
			return entitys;
		}

		private List<Monitor.Sqlite.CodeFirst.ProfileFile> GetEntitiesBranch(MonitorSqliteDBContext db, string customerCode)
		{
			var entitys = db.ProfileFileDatas.Where(e => (e.DomainObject == "Branch" && e.CustomerCode == customerCode)).Select(x => x).ToList();
			return entitys;
		}

		private List<Monitor.Sqlite.CodeFirst.ProfileFile> GetEntitiesInventor(MonitorSqliteDBContext db)
		{
			var entitys = db.ProfileFileDatas.Where(e => (e.DomainObject == "Inventor")).Select(x => x).ToList();
			return entitys;
		}

		private List<Monitor.Sqlite.CodeFirst.ProfileFile> GetEntitiesInventor(MonitorSqliteDBContext db, string customerCode)
		{
			var entitys = db.ProfileFileDatas.Where(e => (e.DomainObject == "Inventor" && e.CustomerCode == customerCode)).Select(x => x).ToList();
			return entitys;
		}

		private List<Monitor.Sqlite.CodeFirst.ProfileFile> GetEntitiesInventorByBranchCode(MonitorSqliteDBContext db, string branchCode)
		{
			var entitys = db.ProfileFileDatas.Where(e => (e.DomainObject == "Inventor" && e.BranchCode == branchCode)).Select(x => x).ToList();
			return entitys;
		}


		private Monitor.Sqlite.CodeFirst.ProfileFile GetEntitiesByProfileFileUID(MonitorSqliteDBContext db, string profileFileUID)
		{
			var entity = db.ProfileFileDatas.Where(e => (e.ProfileFileUID == profileFileUID)).FirstOrDefault();
			return entity;
		}
		#endregion



	}

}
