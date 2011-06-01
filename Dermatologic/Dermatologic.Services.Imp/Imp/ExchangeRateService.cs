using Dermatologic.Domain;

namespace Dermatologic.Services
{
    class ExchangeRateService: ServiceController<ExchangeRate> ,IExchangeRateService
    {
        public ExchangeRateService()
        {
            Repository = RepositoryFactory.GetExchangeRateRepository();
        }
    }

    }
