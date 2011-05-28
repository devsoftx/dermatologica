using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dermatologic.Services
{
    public interface IServiceController<T>
    {
        ResponseBase<T> Save(T entity);
        ResponseBase<T> Update(T entity);
        ResponseBase<T> Delete(T entity);
        long Count();
        long Count(Expression<Func<T, bool>> criterion);
        IList<T> GetAll();
        ResponseBase<T> Query(string myQuery, string[] parameters, object[] values);
        void ExecuteNonQuery(string myQuery, string[] parameters, object[] values);
        IList SqlQuery(string myQuery, string[] parameters, object[] value);
        ResponseBase<T> Delete(string myQuery, string[] parameters, object[] values);
        IList<T> GetAll(Expression<Func<T, bool>> criterion);
        IList<T> GetByExample(T example);
        T Get(object id);
        T Get(Expression<Func<T, bool>> criterion);
    }
}