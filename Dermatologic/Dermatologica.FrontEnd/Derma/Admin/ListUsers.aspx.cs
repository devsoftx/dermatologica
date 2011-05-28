using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;

public partial class Derma_Admin_ListUsers : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetUsers();
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditUser.aspx?action=new");
    }

    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                Response.Redirect(string.Format("EditUser.aspx?id={0}&action=edit", e.CommandArgument), true);
                break;
            case "cmd_eliminar":
                DeleteUser(e.CommandArgument);
                GetUsers();
                break;
        }
    }

    private void GetUsers()
    {
        var users = Membership.GetAllUsers();
        gvUsers.DataSource = users;
        gvUsers.DataBind();
    }

    private void DeleteUser(object userId)
    {
        var username = Membership.GetUser(new Guid(userId.ToString()));
        if (username != null) Membership.DeleteUser(username.UserName, true);
        GetUsers();
    }
}