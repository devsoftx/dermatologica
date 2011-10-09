using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Menu = Dermatologic.Domain.Menu;
public partial class Derma_Derma : MasterPageBase
{

    protected void Page_PreRender(object sender, EventArgs e)
    {
        var userName = Session["userName"];
        if (!Page.IsPostBack)
        {
            if (userName != null)
            {
                GetMenu(userName.ToString());
            }
        }
        if (userName == null)
        {
            Session["userName"] = null;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage(Request.RawUrl);
        }   
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //var userName = Session["userName"];
        //if (!Page.IsPostBack)
        //{
        //    if (userName != null)
        //    {
        //        GetMenu(userName.ToString());
        //    }
        //}
        //if (userName == null)
        //{
        //    Session["userName"] = null;
        //    FormsAuthentication.SignOut();
        //    FormsAuthentication.RedirectToLoginPage(Request.RawUrl);
        //}   
    }

    private void GetMenu(string userName)
    {
        var listmenus = BussinessFactory.GetMenuService().GetMenuByUser(userName).Results.Where(p => p.ParentId == null).ToList();
        var listmenuchilds = BussinessFactory.GetMenuService().GetMenuByUser(userName).Results.Where(p => p.ParentId != null).ToList();
        foreach (Menu item in listmenus)
        {
            var mnuItem = new MenuItem(item.Name, item.Id.ToString(), "", item.Url);
            NavigationMenu.Items.Add(mnuItem);
            var childs = listmenuchilds.Where(p => p.ParentId.Value.Equals(item.Id.Value)).ToList();
            AddChilds(mnuItem, childs);
        }
    }

    private void AddChilds(MenuItem item, IEnumerable<Menu> childs)
    {
        foreach (var menu in childs)
        {
            var mnuItemChild = new MenuItem { Value = menu.Id.ToString(), Text = menu.Name, NavigateUrl = menu.Url };
            item.ChildItems.Add(mnuItemChild);
        }
    }
}
