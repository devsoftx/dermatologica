using System;
using System.Web.Security;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class MenuService : ServiceController<Menu>, IMenuService
    {
        public MenuService()
        {
            Repository = RepositoryFactory.GetMenuRepository();
        }

        public MenuResponse GetMenuByUser(string userName)
        {
            var response = new MenuResponse();
            var user = Membership.GetUser(userName);
            if (user != null && user.ProviderUserKey != null)
            {
                var userId = new Guid(user.ProviderUserKey.ToString());
                string[] parameters = { "userId" };
                object[] values = { userId };
                const string query = "select distinct m.Id, m.Name, m.Url, m.ParentId, m.[Order] from Menu as m join MenuRole mr on mr.MenuId = m.Id join [aspnet_Roles] r on r.RoleId = mr.RoleId join [aspnet_UsersInRoles] uir on uir.RoleId = r.RoleId where uir.UserId = :userId order by m.[Order]";
                try
                {
                    var objects = Repository.SqlQuery(query, parameters, values);
                    foreach (object[] arrays in objects)
                    {
                        var menu = new Menu
                                       {
                                           Id = new Guid(arrays[0].ToString()),
                                           ParentId = arrays[3] != null ? new Guid(arrays[3].ToString()) : (Guid?) null,
                                           Name = arrays[1].ToString(),
                                           Url = arrays[2] != null ? arrays[2].ToString() : null,
                                           Orden = arrays[4] != null ? Int32.Parse(arrays[4].ToString()) : (int?) null
                                       };
                        response.Results.Add(menu);
                    }
                    response.OperationResult = OperationResult.Success;
                    return response;
                }
                catch (Exception e)
                {
                    response.OperationResult = OperationResult.Failed;
                    response.Message = e.Message;
                    return response;
                }
            }
            response.OperationResult = OperationResult.Failed;
            return response;
        }
    }
}