using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataContextNamespace.DbRepository
{
	public class Repository : IRepo
	{
		public Repository()
		{
			Context = new DataContext();
		}

		public DataContext Context { get; set; }

		public Int32 Delete<T>(T item, bool save) where T : class
		{
			Context.Entry(item).State = EntityState.Deleted;
			if (save)
				return Context.SaveChanges();
			return 0;
		}

		public List<T> Delete<T>(List<T> items, bool save) where T : class
		{
			Context.Entry(items).State = EntityState.Deleted;

			if (save)
				Context.SaveChanges();
			return items;
		}

		public void Dispose()
		{
			Context.Dispose();
		}

		public T Insert<T>(T item, bool save) where T : class
		{
			Context.Entry(item).State = EntityState.Added;

			if (save)
				Context.SaveChanges();
			return item;
		}

		public int Save()
		{
			return Context.SaveChanges();
		}

		public IEnumerable<T> Select<T>()
			where T : class
		{
			return Context.Set<T>();
		}

		public IEnumerable<T> All<T>(string[] includes = null) where T : class
		{
			if (includes != null && includes.Count() > 0)
			{
				var query = Context.Set<T>().Include(includes.First());
				foreach (var include in includes.Skip(1))
					query = query.Include(include);
				return query.AsQueryable();
			}

			return Context.Set<T>();
		}

		public IEnumerable<T> QuerySelect<T>(string query, object[] cmdParams)
		   where T : class
		{
			return Context.Database.SqlQuery<T>(query, cmdParams);
		}

		public T Update<T>(T item, bool save) where T : class
		{
			Context.Entry(item).State = EntityState.Modified;
			if (save)
				Context.SaveChanges();
			return item;
		}

		public void Detach<T>(T item) where T : class
		{
			Context.Entry(item).State = EntityState.Detached;
		}

		public int ExecuteSqlCommand(string query, params object[] parameters)
		{
			return Context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query, parameters);
		}

		public IEnumerable<T> ExecSqlQuery<T>(string query, object[] cmdParams) where T : struct
		{
			return Context.Database.SqlQuery<T>(query, cmdParams);
		}
	}
}
	