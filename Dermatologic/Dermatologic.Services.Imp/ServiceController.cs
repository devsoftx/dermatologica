using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dermatologic.Data;
using Dermatologic.Data.Persistence;

namespace Dermatologic.Services
{
    public class ServiceController<T> : IServiceController<T>
    {
        private AbstractRepositoryFactory repositoryFactory = AbstractRepositoryFactory.Instance(AbstractRepositoryFactory.REPOSITORY_FACTORY);

        protected AbstractRepositoryFactory RepositoryFactory
        {
            set
            {
                repositoryFactory = value;
            }
            get
            {
                return repositoryFactory;
            }
        }


        protected IRepository<T> Repository { get; set; }

        public ResponseBase<T> Save(T entity)
        {
            var response = new ResponseBase<T>();
            try
            {
                NhibernateHelper.BeginTransaction();
                Repository.Save(entity);
                NhibernateHelper.EndTransaction();
            }
            catch(Exception ex)
            {
                NhibernateHelper.RollBackTransaction();
				response.OperationResult = OperationResult.Failed;
                response.Message = ex.Message;
            }
            finally
            {
                NhibernateHelper.CloseSession();
            }
            return response;
        }

        public ResponseBase<T> Update(T entity)
        {
            var response = new ResponseBase<T>();
            try
            {
                NhibernateHelper.BeginTransaction();
                Repository.Update(entity);
                NhibernateHelper.EndTransaction();
            }
            catch(Exception ex)
            {
                NhibernateHelper.RollBackTransaction();
				response.OperationResult = OperationResult.Failed;
                response.Message = ex.Message;
            }
            finally
            {
                NhibernateHelper.CloseSession();
            }
            return response;
        }

        public ResponseBase<T> Delete(T entity)
        {
            var response = new ResponseBase<T>();
            try
            {
                NhibernateHelper.BeginTransaction();
                Repository.Delete(entity);
                NhibernateHelper.EndTransaction();
            }
            catch(Exception ex)
            {
                NhibernateHelper.RollBackTransaction();
				response.OperationResult = OperationResult.Failed;
                response.Message = ex.Message;
            }
            finally
            {
                NhibernateHelper.CloseSession();
            }
            return response;
        }

        public long Count()
        {
            return Repository.Count();
        }

        public long Count(Expression<Func<T, bool>> criterion)
        {
            return Repository.Count(criterion);
        }

        public IList<T> GetAll()
        {
            return Repository.GetAll();
        }

        public ResponseBase<T> Query(string myQuery, string[] parameters, object[] values)
        {
            var response = new ResponseBase<T>();
            try
            {
                response.OperationResult = OperationResult.Success;
                response.Results = Repository.Query(myQuery, parameters, values);
                return response;
            }
            catch (Exception ex)
            {
                response.OperationResult = OperationResult.Failed;
                response.Message = ex.Message;
				return response;                
            }
        }

        public void ExecuteNonQuery(string myQuery, string[] parameters, object[] values)
        {
            try
            {
                Repository.ExecuteNonQuery(myQuery,parameters,values);
            }
            catch (Exception ex)
            {
                throw ex;            
            }
        }

        public IList SqlQuery(string myQuery, string[] parameters, object[] values)
        {
            try
            {
                return Repository.SqlQuery(myQuery, parameters, values);
            }
            catch (Exception ex)
            {
                throw ex;             
            }
        }

        public ResponseBase<T> Delete(string myQuery, string[] parameters, object[] values)
        {
            var response = new ResponseBase<T>();
            try
            {
                response.OperationResult = OperationResult.Success;
                Repository.Delete(myQuery, parameters, values);
                return response;
            }
            catch (Exception ex)
            {
                response.OperationResult = OperationResult.Success;
                response.Message = ex.Message;
                throw;
            }
            
        }

        public IList<T> GetAll(Expression<Func<T, bool>> criterion)
        {
            return Repository.GetAll(criterion);
        }

        public IList<T> GetByExample(T example)
        {
            return Repository.GetByExample(example);
        }

        public T Get(object id)
        {
            return Repository.Get(id);
        }

        public T Get(Expression<Func<T, bool>> criterion)
        {
            return Repository.Get(criterion);
        }
    }
}
