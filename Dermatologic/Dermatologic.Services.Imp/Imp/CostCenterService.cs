using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class CostCenterService : ServiceController<CostCenter> , ICostCenterService
    {

        public CostCenterService()
        {
            Repository=RepositoryFactory.GetCostCenterRepository();
        }
        
    }
}