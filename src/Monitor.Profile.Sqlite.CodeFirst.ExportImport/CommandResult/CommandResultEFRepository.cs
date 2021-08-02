using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Data.Entity;
using Count4U.Model.SelectionParams;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Monitor.Model.ServiceContract.Interface;
using System.Data.Common;
using System.IO;
using Monitor.Sqlite.CodeFirst.MappingEF;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Monitor.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace Monitor.Sqlite.CodeFirst
{
	public class CommandResultEFRepository : BaseEFDbSetRepository, ICommandResultRepository
	{

		private readonly ILogger _logger;
		//protected IConnectionSqliteMonitorDB _connection;
	    private readonly MonitorSqliteDBContext _context;

		public CommandResultEFRepository(MonitorSqliteDBContext context, ILoggerFactory loggerFactory)
			: base()
		{
			_logger = loggerFactory.CreateLogger<CommandResultEFRepository>();
			this._context = context ??
				throw new ArgumentNullException(nameof(context));
		}
	

		#region IMaskRepository Members


		public Monitor.Service.Model.CommandResults GetCommandResults()
		{
				var entertiList =  this._context.CommandResultDatas.ToList();
				var domainObjects = entertiList.Select(e => e.ToDomainObject());
				//var domainObjects = dc.Process.ToList().Select(e => e.ToDomainObject());
				return Monitor.Service.Model.CommandResults.FromEnumerable(domainObjects);
		}

		public Monitor.Service.Model.CommandResults GetCommandResults(SelectParams selectParams)
		{
			if (selectParams == null)
				return GetCommandResults();

			long totalCount = 0;

			var entities = GetEntities(_context, _context.CommandResultDatas.AsQueryable(), _context.CommandResultDatas.AsQueryable(), selectParams, out totalCount);

			//Преобразование сущностей в объекты предметной области.
			//Converting entites to domain objects.
			var domainObjects = entities.Select(e => e.ToDomainObject());

			//Возврат результата.
			//Returning result.
			Monitor.Service.Model.CommandResults result = Monitor.Service.Model.CommandResults.FromEnumerable(domainObjects);
			result.TotalCount = totalCount;
			return result;

		}

		public Monitor.Service.Model.CommandResults GetTestDataCommandResults()
		{
			try
			{
				Monitor.Service.Model.CommandResult command1 = new Monitor.Service.Model.CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.none);
				command1.AdapterName = "adapterName";
				command1.IsSingleFileOrDirectory = IsSingleFileOrDirectoryEnum.IsDirectory;
				command1.MonitorAddress = "http://localhost:12389/";
				Monitor.Service.Model.CommandResult[] commandResults = new Monitor.Service.Model.CommandResult[]
				{
				new Monitor.Service.Model.CommandResult(OperationIndexEnum.i_11, AdapterCommandStepEnum.AddInQueue, "testSessionCode1", command1, null, command1.AdapterName),
				new Monitor.Service.Model.CommandResult(OperationIndexEnum.i_12, AdapterCommandStepEnum.Import, "testSessionCode2", command1, null, command1.AdapterName),
				new Monitor.Service.Model.CommandResult(OperationIndexEnum.i_13, AdapterCommandStepEnum.RefreshIturStatus, "testSessionCode3", command1, null, command1.AdapterName),
				new Monitor.Service.Model.CommandResult(OperationIndexEnum.i_14, AdapterCommandStepEnum.MoveFileAfter, "testSessionCode4", command1, null, command1.AdapterName)   ,
				new Monitor.Service.Model.CommandResult(OperationIndexEnum.c_01,  AdapterCommandStepEnum.AddInQueue, "testSessionCode5", command1, null, command1.AdapterName),
				new Monitor.Service.Model.CommandResult(OperationIndexEnum.c_02, AdapterCommandStepEnum.Clear, "testSessionCode6", command1, null, command1.AdapterName),
				new Monitor.Service.Model.CommandResult(OperationIndexEnum.c_03, AdapterCommandStepEnum.ClearStatusBit, "testSessionCode7", command1, null, command1.AdapterName)
				};
				Insert(commandResults);
			}
			catch (Exception ext)
			{
				string message = ext.Message;
				return new CommandResults();
			}

					//dc.TryCreateDB();
				try
				{
					var entertis = _context.CommandResultDatas;
					var entertiList = entertis.ToList();
					var domainObjects = entertiList.Select(e => e.ToDomainObject());
					//var domainObjects = dc.Process.ToList().Select(e => e.ToDomainObject());
					return Monitor.Service.Model.CommandResults.FromEnumerable(domainObjects);
				}
				catch (Exception ext)
				{
					string message = ext.Message;
					return new Monitor.Service.Model.CommandResults();
				}
		

		}

		public Task DeleteAll()
        {
			_context.CommandResultDatas.ToList().ForEach(e => _context.CommandResultDatas.Remove(e));
			_context.SaveChanges();
  			return Task.FromResult(true);
        }

		public Monitor.Service.Model.CommandResult GetCommandResult(long id)
		{
				var entity = this.GetEntitiesById(_context, id);
				if (entity == null)
					return null;
				return entity.ToDomainObject();
		}

		public Monitor.Service.Model.CommandResults GetCommandResultsByParentCode(string parentCommandResultCode)
		{
				var entitys = _context.CommandResultDatas.Where(e => (e.ParentCommandResultCode == parentCommandResultCode)).Select(e => e.ToDomainObject()).ToList();
				if (entitys == null)
					return null;
				CommandResults result = CommandResults.FromEnumerable(entitys);
				return result;
		}


		public Monitor.Service.Model.CommandResult GetCommandResultByCommandResultCode(string commandResultCode)
		{
			var entity = this.GetEntitiesByCommandResultCode(_context, commandResultCode);
			if (entity == null)
				return null;
			return entity.ToDomainObject();

		}

		public Task Delete(long id)
		{
			var entity = this.GetEntitiesById(_context, id);
			if (entity != null)
			{
				_context.CommandResultDatas.Remove(entity);
				_context.SaveChanges();
			}
			return Task.FromResult(true);
		}


		public Task Delete(string commandResultCode)
		{

			var entity = this.GetEntitiesByCommandResultCode(_context, commandResultCode);
			if (entity != null)
			{
				_context.CommandResultDatas.Remove(entity);
				_context.SaveChanges();
			}

			return Task.FromResult(true);
		}



		public long Insert(Monitor.Service.Model.CommandResult commandResult)
		{
			if (commandResult == null)
				return -1;
			try
			{
				var entity = commandResult.ToEntity();
				_context.CommandResultDatas.Add(entity);
				_context.SaveChanges();

				//var entity1 = GetEntitiesByCommandResultCode(dc, commandResult.CommandResultCode);
				var entity1 = GetEntitiesByCommandUID(_context, commandResult.CommandUID);
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

		public Task Insert(Monitor.Service.Model.CommandResult[] commandResultArray)
		{
			if (commandResultArray == null)
				return Task.FromResult(true);

			try
			{
				foreach (Monitor.Service.Model.CommandResult commandResult in commandResultArray)
				{
					var entity = commandResult.ToEntity();
					_context.CommandResultDatas.Add(entity);
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

		public Task Update(Monitor.Service.Model.CommandResult commandResult)
		{
			if (commandResult == null)
				return Task.FromResult(true);

			var entity = GetEntitiesByCommandUID(_context, commandResult.CommandUID);
			if (entity != null)
			{
				entity.ApplyChanges(commandResult);
				_context.SaveChanges();
			}

			return Task.FromResult(true);
		}
		#endregion

		#region private

		private Monitor.Sqlite.CodeFirst.CommandResult GetEntitiesById(MonitorSqliteDBContext db, long id)
		{
			var entity = db.CommandResultDatas.Where(e => (e.ID == id)).FirstOrDefault();
			return entity;
		}

		private Monitor.Sqlite.CodeFirst.CommandResult GetEntitiesByCommandResultCode(MonitorSqliteDBContext db, string commandResultCode)
		{
			var entity = db.CommandResultDatas.Where(e => (e.CommandResultCode == commandResultCode)).FirstOrDefault();
			return entity;
		}

		private Monitor.Sqlite.CodeFirst.CommandResult GetEntitiesByCommandUID(MonitorSqliteDBContext db, string commandUID)
		{
			var entity = db.CommandResultDatas.Where(e => (e.CommandUID == commandUID)).FirstOrDefault();
			return entity;
		}
		#endregion



	}

}
