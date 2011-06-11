using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Medication = Dermatologic.Domain.Medication;
using Person = Dermatologic.Domain.Person;

public partial class Derma_Admin_ListMedications : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetMedications();
        //SearchPersons();
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
        var Medications = BussinessFactory.GetMedicationService().GetAll(u => u.IsActive == true).OrderBy(p => p.LastModified).ToList();
        BindControl<Medication>.BindGrid(gvMedications, Medications);
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
                litMensaje.Text = string.Format("Se eliminó El Tratamiento");
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

        if (Page.IsPostBack)
        {
            SearchPersons();
        }
    }
    private void SearchPersons()
    {
       // var personType = Request.QueryString.Get("personType");
        var example = new Person
        {
            FirstName = txtSearch.Text.Trim().ToLower(),
            LastNameP = txtSearch.Text.Trim().ToLower(),
            LastNameM = txtSearch.Text.Trim().ToLower(),
        };
        var response = BussinessFactory .GetMedicationService().GetMedicationsByPatient(example);
        if (response.OperationResult == OperationResult.Success)
        
            gvMedications.DataSource = response.Medications;
            gvMedications.DataBind(); 
    }
}