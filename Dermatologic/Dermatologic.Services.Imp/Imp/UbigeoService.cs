using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class UbigeoService : ServiceController<Ubigeo>, IUbigeoService
    {
        public UbigeoService()
        {
            Repository = RepositoryFactory.GetUbigeoRepository();
        }
    }
}
