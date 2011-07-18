using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class TypeContractService : ServiceController<TypeContract>,ITypeContractService
    {
        public TypeContractService()
        {
            Repository = RepositoryFactory.GetTypeContractRepository();
        }
    }
}
