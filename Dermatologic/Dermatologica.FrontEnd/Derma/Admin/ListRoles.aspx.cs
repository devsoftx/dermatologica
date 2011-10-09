using System;
using System.Collections.Generic;
using System.Configuration;
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
        var response = BussinessFactory.GetRoleService().GetAll();
        if (response.OperationResult == OperationResult.Success)
        {
            var roles = response.Results;
            BindControl<Role>.BindGrid(gvRoles, roles);    
        }
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
        var appId = new Guid(ConfigurationManager.AppSettings.Get("ApplicationId"));
        var response = BussinessFactory.GetRoleService().DeleteRole(id, appId);
        if (response.OperationResult == OperationResult.Success)
        {
            var role = response.Entity;
            litMensaje.Text = string.Format("Se eliminó el rol: {0}", role.RoleName);
            return;
        }
    }
}