using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_ListOffices : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetPersonTypes();
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
                DeletePersonType(new Guid(e.CommandArgument.ToString()));
                GetPersonTypes();
                break;
        }
    }

    private void GetPersonTypes()
    {
        var offices = BussinessFactory.GetOfficeService().GetAll(u => u.IsActive == true).OrderBy(p => p.Name).ToList();
        BindControl<Office>.BindGrid(gvOffices, offices);
    }

    private void DeletePersonType(Guid id)
    {
        var PersonType = BussinessFactory.GetPersonTypeService().Get(id);
        if (PersonType != null)
        {
            PersonType.IsActive = false;
            PersonType.LastModified = LastModified;
            PersonType.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetPersonTypeService().Update(PersonType);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó El Tipo de Persona");
                return;
            }
        }
    }

    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditOffice.aspx?action=new");
    }
}