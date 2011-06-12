using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;

public partial class SiteMaster : MasterPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void HeadLoginView_ViewChanged(object sender, EventArgs e)
    {
        var returnUrl = Request.QueryString.Get("ReturnUrl");
        if (!string.IsNullOrEmpty(returnUrl))
        {
            Session["userName"] = null;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage(returnUrl);
        }
        
    }
}
