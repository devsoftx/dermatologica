using System;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_ListOffices : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetOffices();
    }

    protected void gvOffices_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditOffice.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeleteOffice(new Guid(e.CommandArgument.ToString()));
                GetOffices();
                break;
        }
    }

    private void GetOffices()
    {
        var offices = BussinessFactory.GetOfficeService().GetAll(u => u.IsActive).OrderBy(p => p.Name).ToList();
        BindControl<Office>.BindGrid(gvOffices, offices);
    }

    private void DeleteOffice(Guid id)
    {
        var office = BussinessFactory.GetPersonTypeService().Get(id);
        if (office != null)
        {
            office.IsActive = false;
            office.LastModified = LastModified;
            office.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetPersonTypeService().Update(office);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó la oficina");
                return;
            }
        }
    }

    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditOffice.aspx?action=new");
    }

    protected void gvOffices_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var entity = e.Row.DataItem as Office;
            if (entity != null)
            {
                var input = ((TextBox) e.Row.FindControl("lblColor"));
                input.BackColor = Color.FromName(entity.ColorId);
            }
        }
    }
}