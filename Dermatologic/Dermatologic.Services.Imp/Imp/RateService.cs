using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class RateService : ServiceController<Rate> , IRateService
    {
        public RateService()
        {
            Repository = RepositoryFactory.GetRateRepository();
        }
    }
}