using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class ItemTableService : ServiceController<ItemTable>, IItemTableService
    {
        public  ItemTableService()
        {
            Repository = RepositoryFactory.GetItemTableRepository();
        }
    }
}