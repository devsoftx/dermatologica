using System;
using System.Linq;
using System.Web.UI.WebControls;
using Dermatologica.Web;
using Dermatologic.Services;
using PersonType = Dermatologic.Domain.PersonType;

public partial class Derma_Admin_ListPersonTypes : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetPersonTypes();
    }

    protected void gvPersonTypes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditPersonType.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeletePersonType(new Guid(e.CommandArgument.ToString()));
                GetPersonTypes();
                break;
        }
    }

    private void GetPersonTypes()
    {
        var response = BussinessFactory.GetPersonTypeService().GetAll(u => u.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var personTypes = response.Results.OrderBy(p => p.Name).ToList();
            BindControl<PersonType>.BindGrid(gvPersonTypes, personTypes);   
        }
    }

    private void DeletePersonType(Guid id)
    {
        var responsePersonType = BussinessFactory.GetPersonTypeService().Get(id);
        if (responsePersonType.OperationResult == OperationResult.Success)
        {
            var PersonType = responsePersonType.Entity; 
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
        Response.Redirect("~/Derma/Admin/EditPersonType.aspx?action=new");
    }
  
}