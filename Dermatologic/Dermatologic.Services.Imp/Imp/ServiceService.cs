using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class ServiceService : ServiceController<Service>, IServiceService
    {
        public ServiceService()
        {
            Repository = RepositoryFactory.GetServiceRepository();
        }
    }
}