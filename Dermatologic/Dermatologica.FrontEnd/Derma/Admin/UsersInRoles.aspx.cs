using System;
using ASP.App_Code;
using Dermatologic.Services;

public partial class Derma_Admin_UsersInRoles : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var userId = Request.Params.Get("userId");
            GetRoles();
            GetRole(userId);
        }
    }

    private void GetRole(string userId)
    {
        if (!string.IsNullOrEmpty(userId))
        {
            var response = BussinessFactory.GetRoleService().GetRoleByUser(new Guid(userId));
            if(response.OperationResult == OperationResult.Success)
            {
                var role = response.Role;
                if (role != null)
                {
                    if (role.RoleId != null) ddlRole.SelectedValue = role.RoleId.Value.ToString();
                    txtNombre.Text = role.RoleName;
                    txtDescription.Text = role.Description;
                    ddlRole.Enabled = false;
                }
            }
        }
    }

    private void GetRoles()
    {
        var response = BussinessFactory.GetRoleService().GetAll();
        if (response.OperationResult == OperationResult.Success)
        {
            ddlRole.DataSource = response.Results;
            ddlRole.DataValueField = "RoleId";
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataBind();
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var userid = new Guid(Request.Params.Get("userId"));
        var roleid = new Guid(ddlRole.SelectedValue);
        var response = BussinessFactory.GetRoleService().GetRoleByUser(userid);
        if (response.Role == null)
        {
            BussinessFactory.GetUsersInRolesService().Insert(userid, roleid);
            Response.Redirect("~/Derma/Admin/ListUsers.aspx", true);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/ListUsers.aspx", true);
    }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        var response = BussinessFactory.GetRoleService().Get(new Guid(ddlRole.SelectedValue));
        if (response.OperationResult == OperationResult.Success)
        {
            var role = response.Entity;
            txtNombre.Text = role.RoleName;
            txtDescription.Text = role.Description;   
        }
    }
}