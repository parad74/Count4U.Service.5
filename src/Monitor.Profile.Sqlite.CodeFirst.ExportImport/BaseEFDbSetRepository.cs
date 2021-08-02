using System.Collections.Generic;
using System.Linq;
//using System.Data.Entity;
using Count4U.Model.SelectionParams;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace Monitor.Sqlite.CodeFirst
{
	public abstract class BaseEFDbSetRepository
    {
		public BaseEFDbSetRepository()
		{
		}

		//public abstract IQueryable<TEntity> AsQueryable<TEntity>(DbSet<TEntity> objectSet) where TEntity : class; 
		
   		public List<TEntity> GetEntities<TEntity>(DbContext db, IQueryable<TEntity> query, 
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

            //_logger.Trace(((System.Data.Objects.ObjectQuery)query).ToTraceString());

			if (query == null) return new List<TEntity>();
			var entities = query.ToList();
            return entities;
        }

    }
}
