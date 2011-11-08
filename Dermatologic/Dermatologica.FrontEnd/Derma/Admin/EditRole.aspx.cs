using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dermatologica.Web;
using Dermatologic.Domain;
using Dermatologic.Services;
using System.Configuration;

public partial class Derma_Admin_EditRole : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetRole();
        }
    }

    private void SetRole()
    {
        var action = Request.QueryString.Get("action");
        var RoleId = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadRole(new Guid(RoleId));
                break;
        }
    }

    private void LoadRole(Guid id)
    {
        var response = BussinessFactory.GetRoleService().Get(id);
        if (response.OperationResult == OperationResult.Success)
        {
            var Role = response.Entity;
            txtRolName.Text = Role.RoleName;
            txtDescripción.Text = Role.Description;   
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var action = Request.QueryString.Get("action");
        switch (action)
        {
            case "new":
                Save();
                break;
            case "edit":
                Update();
                break;

        }
    }

    private void Save()
    {
        var Role = new Role
        {
            ApplicationId = new Guid(ConfigurationManager.AppSettings["ApplicationId"]),
            RoleId = Guid.NewGuid(),
            RoleName = txtRolName.Text.Trim(),
            Description = txtDescripción.Text.Trim(),
            LoweredRoleName = txtRolName.Text.Trim().ToLower()
        };
        var response = BussinessFactory.GetRoleService().Save(Role);
        if (response.OperationResult == OperationResult.Success)
        {
            Response.Redirect("~/Derma/Admin/ListRoles.aspx", true);
        }
        else
        {
            litMensaje.Text = string.Format("No se puedo crear el rol: {0}", Role.RoleName);
        }
    }

    private void Update()
    {
        var id = Request.QueryString.Get("id");
        var responseRole = BussinessFactory.GetRoleService().Get(new Guid(id));
        if (responseRole.OperationResult == OperationResult.Success)
        {
            var role = responseRole.Entity;
            role.RoleName = txtRolName.Text.Trim();
            role.LoweredRoleName = txtRolName.Text.Trim().ToLower();
            role.Description = txtDescripción.Text;
            var response = BussinessFactory.GetRoleService().Update(role);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListRoles.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo crear el usuario: {0}", role.RoleName);
            }
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/ListRoles.aspx", true);
    }
}