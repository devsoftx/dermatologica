using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dermatologic.Data;
using Dermatologic.Domain;
namespace Dermatologic.Services
{
    public class RateService : ServiceController<Rate> , IRateService
    {
        public RateService()
        {
            Repository = RepositoryFactory.GetRateRepository();
        }
        public RateResponse GetRatesByPerson(Person example)
        {
            var response = new RateResponse();
            try
            {
                IRateRepository repository = new RateRepository();
                response.Rates = repository.GetRatesByPerson(example);
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
        public RateResponse GetRatesByPersonService(Person example1,Service example2)
        {
            var response = new RateResponse();
            try
            {
                IRateRepository repository = new RateRepository();
                response.Rates = repository.GetRatesByPersonService(example1,example2);
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