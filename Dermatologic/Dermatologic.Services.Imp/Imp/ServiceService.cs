using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dermatologic.Data;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class ServiceService : ServiceController<Service>, IServiceService
    {
        public ServiceService()
        {
            Repository = RepositoryFactory.GetServiceRepository();
        }

        public ServiceResponse GetServicesByCostCenter(CostCenter example)
        {
            var response = new ServiceResponse();
            try
            {
                IServiceRepository repository = new ServiceRepository();
                response.Services = repository.GetServicesByCostCenter(example);
                response.OperationResult = OperationResult.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.OperationResult = OperationResult.Failed;
                return response;
            }
        }
        
    }
}