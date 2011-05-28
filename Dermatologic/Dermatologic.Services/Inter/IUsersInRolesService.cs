using System;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IUsersInRolesService : IServiceController<UsersInRoles>
    {
        void Insert(Guid userid, Guid roleid);
    }
}