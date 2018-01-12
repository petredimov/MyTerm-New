using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataContextNamespace.DbRepository
{
    public interface IRepo : IDisposable
    {
        T Insert<T>(T item, bool save)
                where T : class;
        T Update<T>(T item, bool save)
        where T : class;
        Int32 Delete<T>(T item, bool save)
        where T : class;
        List<T> Delete<T>(List<T> items, bool save)
        where T : class;
        int Save();
        void Detach<T>(T item) where T : class;
        IEnumerable<T> Select<T>()
            where T : class;
		IEnumerable<T> QuerySelect<T>(string query, object[] cmdParams)
			where T : class;
        int ExecuteSqlCommand(string query, params object[] parameters);
        
        IEnumerable<T> ExecSqlQuery<T>(string query, object[] cmdParams) where T : struct;

        IEnumerable<T> All<T>(string[] includes = null) where T : class;
    }
}
