using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class CashMovementService : ServiceController<CashMovement>, ICashMovementService
    {
        public CashMovementService()
        {
            Repository = RepositoryFactory.GetCashMovementRepository();
        }
    }
}