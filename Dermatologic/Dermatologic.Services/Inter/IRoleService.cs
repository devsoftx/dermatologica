using System;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IRoleService : IServiceController<Role>
    {
        RoleResponse DeleteRole(Guid roleId, Guid appId);
        RoleResponse GetRoleByUser(Guid userid);
    }
}