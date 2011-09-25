using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Menu = Dermatologic.Domain.Menu;
using Dermatologic.Services;

public partial class Derma_Admin_EditMenu : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadMenuFathers();
            SetMenu();
        }
    }

    private void LoadMenuFathers()
    {
        var faths = BussinessFactory.GetMenuService().GetAll(x => x.ParentId == null).OrderBy(p => p.Orden).ToList();
        BindControl<Menu>.BindDropDownList(ddlMenuPadre,faths);
    }

    private void SetMenu()
    {
        var action = Request.QueryString.Get("action");
        var MenuId = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadMenu(new Guid(MenuId));
                break;
        }
    }

    private void Save()
    {
        var Menu = new Menu
                       {
                           Id = Guid.NewGuid(),
                           Name = txtNombre.Text.Trim(),
                           Url = !string.IsNullOrEmpty(txtUrl.Text) ? txtUrl.Text : null,
                           Orden = !string.IsNullOrEmpty(txtOrder.Text) ? Convert.ToInt32(txtOrder.Text) : 0,
                           IsActive = true,
                           LastModified = LastModified,
                           CreationDate = CreationDate,
                           ModifiedBy = ModifiedBy,
                           CreatedBy = CreatedBy,
                           Description = txtDescription.Text.Trim()
                           
                       };
        Menu.ParentId = !CheckBox1.Checked ? new Guid(ddlMenuPadre.SelectedValue) : (Guid?) null;
        var response = BussinessFactory.GetMenuService().Save(Menu);
      
        if (response.OperationResult == OperationResult.Success)
        {
            Response.Redirect("~/Derma/Admin/ListMenus.aspx", true);
        }
        else
        {
            litMensaje.Text = string.Format("No se puedo crear el menu: {0} , se presento un error: {1}", Menu.Name, response.Message);
        }
    }

    private void Update()
    {
        var id = Request.QueryString.Get("id");
        var menu = BussinessFactory.GetMenuService().Get(new Guid(id));
        if (menu != null)
        {
            menu.Name = txtNombre.Text.Trim();
            menu.Url = txtUrl.Text.Trim();
            menu.Orden = !string.IsNullOrEmpty(txtOrder.Text) ? Convert.ToInt32(txtOrder.Text) : 0;
            menu.Description = txtDescription.Text.Trim();
            menu.ParentId = new Guid(ddlMenuPadre.SelectedValue);
            menu.IsActive = true;
            menu.LastModified = LastModified;
            menu.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetMenuService().Update(menu);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListMenus.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el menu: {0}", menu.Name);
            }
        }
    }

    private void LoadMenu(Guid id)
    {
        var menu = BussinessFactory.GetMenuService().Get(id);
        txtNombre.Text = menu.Name;
        txtUrl.Text = menu.Url;
        txtOrder.Text = menu.Orden.HasValue ? menu.Orden.Value.ToString(): string.Empty;
        txtDescription.Text = menu.Description;
        if (menu.ParentId.HasValue) ddlMenuPadre.SelectedValue = menu.ParentId.Value.ToString();
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var action = Request.QueryString.Get("action");
        switch (action)
        {
            case "new":
                Save();
                break;
            case "edit":
                Update();
                break;

        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/ListMenus.aspx", true);
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        ddlMenuPadre.Enabled = !CheckBox1.Checked;
    }
}