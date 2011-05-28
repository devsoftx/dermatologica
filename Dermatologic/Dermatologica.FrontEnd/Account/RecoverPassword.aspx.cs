using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain.Contracts;
using Dermatologic.Services;

public partial class Account_RecoverPassword : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var login = txtLogin.Text.Trim();
        var path = ConfigurationManager.AppSettings["path"];
        if (!string.IsNullOrEmpty(login))
        {
            var membershipUser = Membership.GetUser(login);
            if (membershipUser != null)
            {
                var mailRequest = new MailRequest
                {
                    To = new List<string> { membershipUser.Email },
                    Subject = "Clinica Dermatologica - Recordario de Contraseña",
                    Body = string.Format("<div><br>Ud. ha solicitatado recuperar su contraseña<br>para recuperar su contraseña haga <a href='http://{0}/Account/ChangePassword.aspx?key={1}'>Click Aquí</a><br><b>Dpto de Sistemas</b></div>", path,membershipUser.ProviderUserKey),
                    IsHtmlBody = true,
                    Host = ConfigurationManager.AppSettings["smtpServer"],
                    EnableSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["conSSL"]),
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"])
                };
                var mailresponse = BussinessFactory.GetMailerService().SendEmail(mailRequest);
                if (mailresponse.OperationResult == OperationResult.Success)
                {
                    litMensaje.Text = string.Format("Se envio un correo a {0} para recuperar contraseña", membershipUser.Email);
                    return;
                }
                litMensaje.Text = string.Format("No se pudo enviar un correo a {0} para recuperar contraseña", login);
            }
            else
            {
                litMensaje.Text = "No Existe el Usuario";
                return;
            }
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        FormsAuthentication.RedirectToLoginPage();
    }
}