using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class AccountService : ServiceController<Account>, IAccountService
    {
        public AccountService()
        {
            Repository = RepositoryFactory.GetAccountRepository();
        }
    }
}