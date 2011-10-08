using System;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class UsersRepository : Repository<Users> , IUsersRepository
    {
        public void UpdatePassword(Users user)
        {

        }
    }
}