using System;
using System.Web.Security;
using Dermatologica.Web;

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
                user.ChangePassword(user.ResetPassword(), ChangeUserPassword.NewPassword.Trim());
                BussinessFactory.EngineService.Navigate(Dermatologic.Services.Page.ChangePasswordSuccess);
            }
            else
            {
                ChangeUserPassword.ChangePasswordFailureText = string.Format("No se pudo actualizar contraseña");
            }
        }
    }
}
