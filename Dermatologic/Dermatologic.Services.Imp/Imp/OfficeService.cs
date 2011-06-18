using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class OfficeService : ServiceController<Office> , IOfficeService
    {
        public OfficeService()
        {
            Repository = RepositoryFactory.GetOfficeRepository();
        }
    }
}