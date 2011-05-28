using System;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Medication = Dermatologic.Domain.Medication;

public partial class Derma_Admin_ListMedications : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
       // GetMedications();
    }
    protected void gvMedication_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeleteMedication(new Guid(e.CommandArgument.ToString()));
                GetMedications();
                break;
        }
    }
    private void GetMedications()
    {
        var Medications = BussinessFactory.GetMedicationService().GetAll(u => u.IsActive == true);
        //BindControl<Medication>.BindGrid(gvMedications, Medications);
    }
    private void DeleteMedication(Guid id)
    {
        var Medication = BussinessFactory.GetMedicationService().Get(id);
        if (Medication != null)
        {
            Medication.IsActive = false;
            Medication.LastModified = LastModified;
            Medication.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetMedicationService().Update(Medication);
            if (response.OperationResult == OperationResult.Success)
            {
                //litMensaje.Text = string.Format("Se eliminó El Tratamiento");
                return;
            }
        }
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditMedication.aspx?action=new");
    }
    protected void btnDoPostBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //const string javascript = "openRadWindow('SearchPersons.aspx?personType=','rw1');";
        //System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "OpenSearchPersons", javascript, true);
    }
}