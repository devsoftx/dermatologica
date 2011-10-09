using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dermatologic.Data;
using Dermatologic.Data.Persistence;

namespace Dermatologic.Services
{
    public class ServiceController<T> : IServiceController<T> where T : new()
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

        public ResponseBase<T> GetAll()
        {
            var response = new ResponseBase<T>();
            try
            {
                var results = Repository.GetAll();
                response.Results = results;
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.OperationResult = OperationResult.Failed;
            }
            return response;
        }

        public ResponseBase<T> GetAll(Expression<Func<T, bool>> criterion)
        {
            var response = new ResponseBase<T>();
            try
            {
                var results = Repository.GetAll(criterion);
                response.Results = results;
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.OperationResult = OperationResult.Failed;
            }
            return response;
        }

        public ResponseBase<T> GetAll(Expression<Func<T, bool>> criterion, PagingParameters parameters)
        {
            var response = new ResponseBase<T>();
            try
            {
                int count = 0;
                var results = Repository.GetAll(criterion, parameters.PageIndex, parameters.PageSize, out count);
                parameters.VirtualCount = count;
                response.Results = results;
                response.PagingParameters = parameters;
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.OperationResult = OperationResult.Failed;
            }
            return response;
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

        public ResponseBase<T> ExecuteNonQuery(string myQuery, string[] parameters, object[] values)
        {
            var response = new ResponseBase<T>();
            try
            {
                Repository.ExecuteNonQuery(myQuery,parameters,values);
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.OperationResult = OperationResult.Failed;
                throw ex;
            }
            return response;
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

        public ResponseBase<T> ExecuteNonSQLQuery(string myQuery, string[] parameters, object[] values)
        {
            var response = new ResponseBase<T>();
            try
            {
                response.OperationResult = OperationResult.Success;
                Repository.ExecuteNonSQLQuery(myQuery, parameters, values);
                return response;
            }
            catch (Exception ex)
            {
                response.OperationResult = OperationResult.Success;
                response.Message = ex.Message;
                throw;
            }
            
        }

        public ResponseBase<T> GetByExample(T example)
        {
            var response = new ResponseBase<T>();
            try
            {
                var results = Repository.GetByExample(example); ; 
                response.Results = results;
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.OperationResult = OperationResult.Failed;
            }
            return response;
        }

        public ResponseBase<T> Get(object id)
        {
            var response = new ResponseBase<T>();
            try
            {
                var entity = Repository.Get(id);
                response.Entity = entity;
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.OperationResult = OperationResult.Failed;
            }
            return response;
        }

        public ResponseBase<T> Get(Expression<Func<T, bool>> criterion)
        {
            var response = new ResponseBase<T>();
            try
            {
                var entity = Repository.Get(criterion);
                response.Entity = entity;
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.OperationResult = OperationResult.Failed;
            }
            return response;
        }
    }
}
