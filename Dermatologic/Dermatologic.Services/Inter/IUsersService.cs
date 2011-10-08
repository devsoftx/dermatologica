using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IUsersService : IServiceController<Users>
    {
        void UpdatePassword(Users user);
    }
}