using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dermatologic.Data.Persistence;
using NHibernate;
using NHibernate.Criterion;

namespace Dermatologic.Data
{
    public class Repository<T> : IRepository<T>{
        
        public void Save(T entity)
        {
            NhibernateHelper.GetCurrentSession().Save(entity);
        }

        public void Update(T entity)
        {
            NhibernateHelper.GetCurrentSession().Update(entity);
        }

        public void Delete(T entity)
        {
            NhibernateHelper.GetCurrentSession().Delete(entity);
        }

        public long Count()
        {
            return NhibernateHelper.Linq<T>().Count();
        }

        public long Count(Expression<Func<T, bool>> criterion)
        {
            return NhibernateHelper.Linq<T>().Count(criterion);
        }

        public IList SqlQuery(string myQuery, string[] parameters, object[] values)
        {
            ISQLQuery query = NhibernateHelper.GetCurrentSession().CreateSQLQuery(myQuery);
            for (var i = 0; i <= parameters.Length - 1; i++)
            {
                query.SetParameter(parameters[i], values[i]);
            }
            return query.List();
        }

        public void ExecuteNonQuery(string myQuery, string[] parameters, object[] values)
        {
            var query = NhibernateHelper.GetCurrentSession().CreateQuery(myQuery);
            for (var i = 0; i <= parameters.Length - 1; i++)
            {
                query.SetParameter(parameters[i], values[i]);
            }
            query.ExecuteUpdate();
        }

        public void ExecuteNonSQLQuery(string myQuery, string[] parameters, object[] values)
        {
            var query = NhibernateHelper.GetCurrentSession().CreateSQLQuery(myQuery);
            for (var i = 0; i <= parameters.Length - 1; i++)
            {
                query.SetParameter(parameters[i], values[i]);
            }
            query.ExecuteUpdate();
        }

        public IList<T> Query(string myQuery, string[] parameters, object[] values)
        {
            var result = new List<T>();
            var query = NhibernateHelper.GetCurrentSession().CreateQuery(myQuery);
            for (var i = 0; i <= parameters.Length - 1; i++)
            {
                query.SetParameter(parameters[i], values[i]);
            }
            query.List(result);
            return result;
        }

        public IList<T> GetAll()
        {
            return NhibernateHelper.GetCurrentSession().CreateCriteria(typeof(T)).List<T>();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> criterion)
        {
            return NhibernateHelper.Linq<T>().Where(criterion).ToList();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> criterion, int pageIndex, int pageSize, out int count)
        {
            IQueryable<T> query = NhibernateHelper.Linq<T>();
            count = query.Count();
            return query.Where(criterion).Paged<T>(pageIndex, pageSize).ToList();
        }

        public T Get(object id)
        {
            return NhibernateHelper.GetCurrentSession().Get<T>(id);
        }

        public T Get(Expression<Func<T, bool>> criterion)
        {
            return NhibernateHelper.Linq<T>().Where(criterion).First();
        }

        public IList<T> GetByExample(T entity)
        {
            return NhibernateHelper.GetCurrentSession().CreateCriteria(typeof(T)).Add(Example.Create(entity)).List<T>();
        }

    }
}