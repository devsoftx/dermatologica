using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dermatologic.Services
{
    public interface IServiceController<T> where T : new()
    {
        ResponseBase<T> Save(T entity);
        ResponseBase<T> Update(T entity);
        ResponseBase<T> Delete(T entity);
        long Count();
        long Count(Expression<Func<T, bool>> criterion);
        ResponseBase<T> GetAll();
        ResponseBase<T> GetAll(Expression<Func<T, bool>> criterion);
        ResponseBase<T> GetAll(Expression<Func<T, bool>> criterion, PagingParameters parameters);
        ResponseBase<T> Query(string myQuery, string[] parameters, object[] values);
        ResponseBase<T> ExecuteNonSQLQuery(string myQuery, string[] parameters, object[] values);
        IList SqlQuery(string myQuery, string[] parameters, object[] value);
        ResponseBase<T> ExecuteNonQuery(string myQuery, string[] parameters, object[] values);
        ResponseBase<T> GetByExample(T example);
        ResponseBase<T> Get(object id);
        ResponseBase<T> Get(Expression<Func<T, bool>> criterion);
    }
}