using System;
using Dermatologic.Data.Persistence;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class RoleService : ServiceController<Role> , IRoleService
    {
        public RoleService()
        {
            Repository = RepositoryFactory.GetRoleRepository();
        }

        public RoleResponse DeleteRole(Guid roleId, Guid appId)
        {
            var roleResponse = new RoleResponse();
            var usersInRoles = RepositoryFactory.GetUsersInRolesRepository();
            object[] values = { roleId, appId };
            string[] pars = { "roleId", "appId" };
            object[] objects = { roleId };
            string[] parameters = { "roleId" };
            try
            {   
                const string query = "delete from Role r where r.RoleId =: roleId and r.ApplicationId =: appId ";
                NhibernateHelper.BeginTransaction();
                usersInRoles.ExecuteNonQuery("delete from UsersInRoles u where u.RoleId =: roleId", parameters, objects);
                ExecuteNonQuery(query, pars, values);
                NhibernateHelper.EndTransaction();
                roleResponse.OperationResult = OperationResult.Success;
                return roleResponse;

            }
            catch (Exception)
            {
                roleResponse.OperationResult = OperationResult.Failed;
                throw;
            }
        }

        public RoleResponse GetRoleByUser(Guid userid)
        {
            var roleResponse = new RoleResponse();
            try
            {
                object[] objects = { userid };
                string[] parameters = { "userid" };
                const string query = "select r.* from [aspnet_Roles] r join [aspnet_UsersInRoles] uir on r.RoleId = uir.RoleId where uir.UserId = :userid";
                var roles = Repository.SqlQuery(query, parameters, objects);
                foreach (object[] arrays in roles)
                {
                    var role = new Role
                                   {
                                       ApplicationId = new Guid(arrays[0].ToString()),
                                       RoleId = new Guid(arrays[1].ToString()),
                                       RoleName = arrays[2].ToString(),
                                       LoweredRoleName = arrays[3] != null ? arrays[3].ToString() : null,
                                       Description = arrays[4] != null ? arrays[4].ToString() : null,
                                   };
                    roleResponse.Role = role;
                }
                roleResponse.OperationResult = OperationResult.Success;
                return roleResponse;
            }
            catch (Exception e)
            {
                roleResponse.OperationResult = OperationResult.Failed;
                roleResponse.Message = e.Message;
                throw;
            }
        }
    }
}