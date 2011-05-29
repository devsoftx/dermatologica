using System;
using System.Linq;
using System.Linq.Expressions;
using ASP.App_Code;
using Medication = Dermatologic.Domain.Medication;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_EditMedication : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetServices();
            SetMedication();
        }
    }
    private void SetMedication()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadMedication(new Guid(id));
                break;
        }
    }
    private void GetServices()
    {
        var Services = BussinessFactory.GetServiceService().GetAll();
        BindControl<Service>.BindDropDownList(dwService, Services);
    }
    void LoadMedication(Guid id)
    {
        var Medication = BussinessFactory.GetMedicationService().Get(id);
        txtDescription.Text = Medication.Description;
        txtNumberSessions.Text = Convert.ToString(Medication.NumberSessions);
    }

    private void Save()
    {
        var Medication = new Medication
                             {
                                 Id = Guid.NewGuid(),
                                 Description = txtDescription.Text.Trim(),
                                 NumberSessions = Convert.ToInt32(txtNumberSessions.Text.Trim()),
                                 IsCompleted = false,
                                 IsActive = true,
                                 LastModified = LastModified,
                                 CreationDate = CreationDate,
                                 ModifiedBy = ModifiedBy,
                                 CreatedBy = CreatedBy,
                                 Patient = new Person() {Id = new Guid("10211cfb-1ffd-401c-bdff-d2181c50c001")},
                                 Service = new Service() {Id = new Guid(dwService.SelectedValue)}
                             };
        try
        {
            var response = BussinessFactory.GetMedicationService().Save(Medication);

            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListMedications.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo crear El tratamiento");
            }
        }
        catch (Exception e)
        {
            throw e;
        }

    }

    private void Update()
    {
        var Id = Request.QueryString.Get("id");
        var Medication = BussinessFactory.GetMedicationService().Get(new Guid(Id));
        if (Medication != null)
        {
            Medication.Description = txtDescription.Text.Trim();
            Medication.NumberSessions = Convert.ToInt32(txtNumberSessions.Text.Trim());
            Medication.IsActive = true;
            Medication.LastModified = LastModified;
            Medication.ModifiedBy = ModifiedBy;

            var response = BussinessFactory.GetMedicationService().Update(Medication);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListMedications.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el tratamiento");
            }
        }
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
        Response.Redirect("~/Derma/Admin/ListMedications.aspx", true);
    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        string javascript;
        var dni = txtDni.Text.Trim();
        if (!string.IsNullOrEmpty(dni))
        {
            var example = new Person
                              {
                                  DocumentNumber = txtDni.Text.Trim(),
                                  DocumentType = ddlDocumentType.SelectedValue
                              };
            var examples = BussinessFactory.GetPersonService().GetByExample(example);
            if (examples.Count > 0)
            {
                var pacient = examples.FirstOrDefault();
                txtPacient.Text = string.Format("{0} {1}", pacient.FirstName, pacient.LastName);
            }
            else
            {
                javascript =
                    string.Format(
                        "openRadWindow('SearchPersons.aspx?personType=C78CA3D8-F0C5-450E-AA64-5AFA0A5E2C54&documentType={0}&documentNumber={1}','rw1'));",
                        ddlDocumentType.SelectedValue, txtDni.Text.Trim());
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "OpenSearchPersons1", javascript, true);
            }
        }
        else
        {
            javascript = string.Format("openRadWindow('SearchPersons.aspx?personType=C78CA3D8-F0C5-450E-AA64-5AFA0A5E2C54&documentType={0}','rw1');",ddlDocumentType.SelectedValue);
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "OpenSearchPersons2", javascript, true);
        }
    }
    protected void btnDoPostBack_Click(object sender, EventArgs e)
    {

    }
}