using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_ListRoles : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetRoles();
    }

    private void GetRoles()
    {
        var roles = BussinessFactory.GetRoleService().GetAll();
        BindControl<Role>.BindGrid(gvRoles, roles);
    }

    protected void gvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditRole.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                Delete(new Guid(e.CommandArgument.ToString()));
                GetRoles();
                break;
        }
    }

    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditRole.aspx?action=new");
    }

    private void Delete(Guid id)
    {
        var role = BussinessFactory.GetRoleService().Get(id);
        var appId = new Guid("2D6C5D1C-8913-4803-85B7-4499A413062E");
        if (role != null)
        {
            var response = BussinessFactory.GetRoleService().DeleteRole(role.RoleId.Value, appId);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó el rol: {0}", role.RoleName);
                return;
            }
        }
    }
}