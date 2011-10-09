using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dermatologic.Data
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        long Count();
        long Count(Expression<Func<T, bool>> criterion);
        IList<T> GetAll();
        IList<T> GetAll(Expression<Func<T, bool>> criterion);
        IList<T> GetAll(Expression<Func<T, bool>> criterion, int pageIndex, int pageSize, out int count);
        IList<T> Query(string myQuery, string[] parameters, object[] values);
        IList SqlQuery(string myQuery, string[] parameters, object[] values);
        void ExecuteNonQuery(string myQuery, string[] parameters, object[] values);
        void ExecuteNonSQLQuery(string myQuery, string[] parameters, object[] values);
        T Get(object id);
        T Get(Expression<Func<T, bool>> criterion);
        IList<T> GetByExample(T entity);
    }
}
