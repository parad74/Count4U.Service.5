using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Microsoft.Extensions.Logging;
using Count4U.Model.SelectionParams;
using Monitor.Model.ServiceContract.Interface;
//using System.Data.Entity;

namespace Monitor.Sqlite.CodeFirst
{
	//NOT USE
	public abstract class BaseEFRepository
	{
		public readonly ILogger _logger;
		private string _monitorDBConnectionString;

		protected IConnectionSqliteMonitorDB _connection;


		public BaseEFRepository(IConnectionSqliteMonitorDB connection,
			ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<BaseEFRepository>();
			this._connection = connection;
			this._monitorDBConnectionString = connection.MonitorSqliteDBConnectionString;

		}
		public string MonitorDBConnectionString()
		{
			return this._monitorDBConnectionString;
		}



		public abstract IQueryable<TEntity> AsQueryable<TEntity>(ObjectSet<TEntity> objectSet) where TEntity : class;

		//	public abstract IQueryable<TEntity> AsQueryable<TEntity>(DbSet<TEntity> objectSet) where TEntity : class; 


		public List<TEntity> GetEntities<TEntity>(ObjectContext db, IQueryable<TEntity> query,
			IQueryable<TEntity> counterQuery, SelectParams selectParams, out long totalCount)
		{
			//db.Configuration.AutoDetectChangesEnabled = false;
			//db.Configuration.ValidateOnSaveEnabled = false; 

			totalCount = 0;
			counterQuery = selectParams.ApplyFilterToQuery(counterQuery);
			totalCount = counterQuery.LongCount();

			//			query.AsNoTracking()
			query = selectParams.ApplyFilterToQuery(query);
			query = selectParams.ApplySortAndPagingToQuery(query);

			//_logger.Trace(((System.Data.Entity.Core.Objects.ObjectQuery)query).ToTraceString());

			if (query == null) return new List<TEntity>();
			var entities = query.ToList();
			return entities;
		}


		//		public List<TEntity> GetEntities<TEntity>(DbContext db, IQueryable<TEntity> query, 
		//			IQueryable<TEntity> counterQuery, SelectParams selectParams, out long totalCount)
		//		{
		//			//db.Configuration.AutoDetectChangesEnabled = false;
		//			//db.Configuration.ValidateOnSaveEnabled = false; 

		//			totalCount = 0;
		//			counterQuery = selectParams.ApplyFilterToQuery(counterQuery);
		//			totalCount = counterQuery.LongCount();

		////			query.AsNoTracking()
		//			query = selectParams.ApplyFilterToQuery(query);
		//			query = selectParams.ApplySortAndPagingToQuery(query);

		//			_logger.Trace(((System.Data.Objects.ObjectQuery)query).ToTraceString());

		//			if (query == null) return new List<TEntity>();
		//			var entities = query.ToList();
		//			return entities;
		//		}

	}
}
