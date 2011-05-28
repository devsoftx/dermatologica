using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class TableService : ServiceController<Table>, ITableService
    {
        public TableService()
        {
            Repository = RepositoryFactory.GetTableRepository();
        }
    }
}