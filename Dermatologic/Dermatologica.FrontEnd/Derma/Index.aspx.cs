using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;

public partial class Derma_Index : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            LoadUserInfo();
        }
    }

    private void LoadUserInfo()
    {
        var userId = Session["UserId"];
        if (userId != null)
        {
            var user = Membership.GetUser(new Guid(userId.ToString()), false);
            litUserName.Text = user.UserName;
            lnkUser.PostBackUrl = string.Format("~/Derma/Admin/EditUser.aspx?id={0}&action=edit&returnUrl={1}", user.ProviderUserKey, Request.RawUrl);
        }
    }
}