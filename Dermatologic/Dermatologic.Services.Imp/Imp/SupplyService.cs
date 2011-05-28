using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class SupplyService : ServiceController<Supply> , ISupplyService
    {
        public SupplyService()
        {
            Repository = RepositoryFactory.GetSupplyRepository();
        }
    }
}