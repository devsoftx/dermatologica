using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Menu = Dermatologic.Domain.Menu;

public partial class Derma_Admin_ListMenus : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetMenus();
    }

    private void GetMenus()
    {
        var menus = BussinessFactory.GetMenuService().GetAll();
        if (menus.Count > 0)
        {
            var ordered = menus.Where(u => u.IsActive == true).OrderBy(p => p.ParentId).ToList();
            BindControl<Menu>.BindGrid(gvMenus, ordered);
        }            
    }

    protected void gvMenus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditMenu.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                Delete(new Guid(e.CommandArgument.ToString()));
                GetMenus();
                break;
        }
    }

    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditMenu.aspx?action=new");
    }

    private void Delete(Guid id)
    {
        var Menu = BussinessFactory.GetMenuService().Get(id);
        if (Menu != null)
        {
            Menu.IsActive = false;
            Menu.LastModified = LastModified;
            Menu.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetMenuService().Update(Menu);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó el menu: {0}", Menu.Name);
                return;
            }
        }
    }
}