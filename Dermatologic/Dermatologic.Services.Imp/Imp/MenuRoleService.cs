using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class MenuRoleService : ServiceController<MenuRole>, IMenuRoleService
    {
        public MenuRoleService()
        {
            Repository = RepositoryFactory.GetMenuRoleRepository();
        }
    }
}
