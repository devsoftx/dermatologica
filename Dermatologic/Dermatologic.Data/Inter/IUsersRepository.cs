using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IUsersRepository : IRepository<Users>
    {
        void UpdatePassword(Users user);
    }
}