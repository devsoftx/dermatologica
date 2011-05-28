using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
        IList<T> Query(string myQuery, string[] parameters, object[] values);
        IList SqlQuery(string myQuery, string[] parameters, object[] values);
        void Delete(string myQuery, string[] parameters, object[] values);
        void ExecuteNonQuery(string myQuery, string[] parameters, object[] values);
        IList<T> GetAll(Expression<Func<T, bool>> criterion);
        T Get(object id);
        T Get(Expression<Func<T, bool>> criterion);
        IList<T> GetByExample(T entity);
    }
}
