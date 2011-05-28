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
            SetMenu();
            LoadMenuFathers();
        }
    }

    private void LoadMenuFathers()
    {
        var faths = BussinessFactory.GetMenuService().GetAll(x => x.ParentId == null);
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
                           CreatedBy = CreatedBy
                           
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
        var MenuId = Request.QueryString.Get("id");
        var Menu = BussinessFactory.GetMenuService().Get(new Guid(MenuId));
        if (Menu != null)
        {
            Menu.Name = txtNombre.Text.Trim();
            Menu.Url = txtUrl.Text.Trim();
            Menu.Orden = !string.IsNullOrEmpty(txtOrder.Text) ? Convert.ToInt32(txtOrder.Text) : 0;
            Menu.IsActive = true;
            Menu.LastModified = LastModified;
            Menu.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetMenuService().Update(Menu);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListMenus.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el menu: {0}", Menu.Name);
            }
        }
    }

    private void LoadMenu(Guid id)
    {
        var Menu = BussinessFactory.GetMenuService().Get(id);
        txtNombre.Text = Menu.Name;
        txtUrl.Text = Menu.Url;
        txtOrder.Text = Menu.Orden.HasValue ? Menu.Orden.Value.ToString(): string.Empty;
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