using System;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class UsersInRolesService : ServiceController<UsersInRoles> , IUsersInRolesService
    {
        public UsersInRolesService()
        {
            Repository = RepositoryFactory.GetUsersInRolesRepository();
        }

        public void Insert(Guid userid, Guid roleid)
        {
            object[] objects = { userid, roleid };
            string[] parameters = { "userid", "roleid" };
            const string query =
                "insert into [aspnet_UsersInRoles](UserId,RoleId) values(:userid,:roleid)";
            Repository.ExecuteNonQuery(query, parameters, objects);
        }
    }
}