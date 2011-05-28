using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        //txtName.Text = Medication.Name;
        txtDescription.Text = Medication.Description;
        txtNumberSessions.Text = Convert.ToString(Medication.NumberSessions);
        //txtTotalPrice.Text = Convert.ToString(Medication.TotalPrice);
    }

    private void Save()
    {
        var Medication = new Medication
        {
            Id = Guid.NewGuid(),
            //Name = txtName.Text.Trim(),
            //IdPatient=,
            //IdService=CdwService.SelectedValue,

            Description = txtDescription.Text.Trim(),
            NumberSessions = Convert.ToInt32(txtNumberSessions.Text.Trim()),
            //TotalPrice=Convert.ToDecimal( txtTotalPrice.Text.Trim()),
            IsCompleted = false,
            IsActive = true,
            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy
        };
        Medication.Patient = new Person() { Id = new Guid("10211cfb-1ffd-401c-bdff-d2181c50c001") };
        Medication.Service = new Service() { Id = new Guid(dwService.SelectedValue) };
        // Person.PersonType = new PersonType() { Id = new Guid(dwTipoPersona.SelectedValue) };
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
            //Medication.Name = txtName.Text.Trim();
            Medication.Description = txtDescription.Text.Trim();
            Medication.NumberSessions = Convert.ToInt32(txtNumberSessions.Text.Trim());
            //Medication.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text.Trim());
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
}