using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IMenuService : IServiceController<Menu>
    {
        MenuResponse GetMenuByUser(string userName);
    }
}