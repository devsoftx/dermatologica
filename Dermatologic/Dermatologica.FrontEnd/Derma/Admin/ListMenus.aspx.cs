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
        var response = BussinessFactory.GetMenuService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var menus = response.Results;
            if (menus.Count > 0)
            {
                var ordered = menus.OrderBy(p => p.ParentId).ToList();
                BindControl<Menu>.BindGrid(gvMenus, ordered);
            }               
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
        var responseMenu = BussinessFactory.GetMenuService().Get(id);
        if (responseMenu.OperationResult == OperationResult.Success)
        {
            var menu = responseMenu.Entity;
            menu.IsActive = false;
            menu.LastModified = LastModified;
            menu.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetMenuService().Update(menu);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó el menu: {0}", menu.Name);
                return;
            }
        }
    }
    protected void gvMenus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            var response = BussinessFactory.GetMenuService().GetAll(p => p.IsActive);
            if (response.OperationResult == OperationResult.Success)
            {
                var persons = response.Results;
                gvMenus.DataSource = persons;
                gvMenus.PageIndex = e.NewPageIndex;
                gvMenus.DataBind();
            }
        }
        catch (Exception ex)
        {
            litMensaje.Text = string.Format("Error: {0}", ex.Message);
        }
    }
}