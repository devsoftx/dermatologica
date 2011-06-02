using System;
using Dermatologic.Data;
using Dermatologic.Data.Imp;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class ExchangeRateService: ServiceController<ExchangeRate> ,IExchangeRateService
    {
        public ExchangeRateService()
        {
            Repository = RepositoryFactory.GetExchangeRateRepository();
        }

        public ExchangeRateResponse GetExchangeRateByDates(DateTime stardate, DateTime enddate)
        {
            var response = new ExchangeRateResponse();
            try
            {
                IExchangeRateRepository repository = new ExchangeRateRepository();
                response.OperationResult = OperationResult.Success;
                response.Results = repository.GetExchangeRateByDates(stardate, enddate);
                return response;
            }
            catch (Exception e)
            {
                response.OperationResult = OperationResult.Failed;
                response.Message = e.Message;
                return response;
            }
        }
    }
}
