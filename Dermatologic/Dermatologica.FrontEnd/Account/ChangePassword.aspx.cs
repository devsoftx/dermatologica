using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;

public partial class Account_ChangePassword : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ChangeUserPassword_ChangedPassword(object sender, EventArgs e)
    {
        var userId = Request.QueryString.Get("key");
        if (!string.IsNullOrEmpty(userId))
        {
            var user = Membership.GetUser(userId);
            if (user != null)
            {
                var currentPassword = user.GetPassword();
                Response.Write(currentPassword);
                user.ChangePassword(ChangeUserPassword.CurrentPassword, ChangeUserPassword.NewPassword);
                Response.Redirect("~/ChangePasswordSuccess.aspx", true);
            }
            else
            {
                ChangeUserPassword.ChangePasswordFailureText = string.Format("No se pudo actualizar contraseña");
            }
        }
    }
}
