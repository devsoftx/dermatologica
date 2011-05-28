using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Menu = Dermatologic.Domain.Menu;
public partial class Derma_Derma : MasterPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var userName = Session["userName"];
        if (userName != null)
        {
            GetMenu(userName.ToString());
        }
    }

    private void GetMenu(string userName)
    {
        var padres = BussinessFactory.GetMenuService().GetMenuByUser(userName).Results.Where(p => p.ParentId == null).ToList();
        var childs = BussinessFactory.GetMenuService().GetMenuByUser(userName).Results.Where(p => p.ParentId != null).ToList();
        foreach (Menu item in padres)
        {
            var child = new MenuItem(item.Name, item.Id.ToString(), "", item.Url);
            NavigationMenu.Items.Add(child);
        }
        for (int i = 0; i <= NavigationMenu.Items.Count - 1; i++)
        {
            foreach (var menu in childs)
            {
                var mnuItemChild = new MenuItem { Value = menu.Id.ToString(), Text = menu.Name, NavigateUrl = menu.Url };
                NavigationMenu.Items[i].ChildItems.Add(mnuItemChild);
            }
        }
    }
}
