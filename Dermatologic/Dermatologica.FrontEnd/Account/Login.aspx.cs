using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        HyperLink1.NavigateUrl = "RecoverPassword.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
    {
        var userName = LoginUser.UserName.Trim();
        var password = LoginUser.Password.Trim();
        if (Membership.ValidateUser(userName,password))
        {
            e.Authenticated = true;
            Session["userName"] = userName;
            Session["UserId"] = Membership.GetUser(userName).ProviderUserKey.ToString();
            if (Request.QueryString["ReturnUrl"] != null)
            {   
                FormsAuthentication.RedirectFromLoginPage(userName, LoginUser.RememberMeSet);
                return;
            }
            FormsAuthentication.SetAuthCookie(userName, LoginUser.RememberMeSet);
        }
    }
}
