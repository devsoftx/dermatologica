using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using MedicalCare = Dermatologic.Domain.MedicalCare;
using Dermatologic.Domain;
using Dermatologic.Services;
public partial class Derma_Admin_MakeMedicalCare : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetPayment();
            txtDateAttention.Text = Convert.ToString(CreationDate);
        }
    }
    private void SetPayment()
    {
        var IdSession = Request.QueryString.Get("idSession");
        var Session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));

        //  var IdMedication = Request.QueryString.Get("idMedication");
        var IdMedication = Session.Medication.Id;
        var Medication = BussinessFactory.GetMedicationService().Get(IdMedication);

        txtPatient.Text = Medication.Patient.FirstName + " " + Medication.Patient.LastName;
        txtSession.Text = Session.Description;
    }
    private void Save()
    {

        var IdSession = Request.QueryString.Get("idSession");
        var Session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));

        //  var IdMedication = Request.QueryString.Get("idMedication");
        var IdMedication = Session.Medication.Id;
        var Medication = BussinessFactory.GetMedicationService().Get(IdMedication);

        //var IdMedical=
        var Medical = BussinessFactory.GetPersonService().Get(new Guid("1df97a6d-58a2-4219-8572-68250bfd3b23"));

        var MedicalCare = new MedicalCare
        {
            Id = Guid.NewGuid(),
            Description = txtDescription.Text.Trim(),
            DateAttention = Convert.ToDateTime(CreationDate),
            IsActive = true,

            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy,
            // Patient = patient,

        };
        MedicalCare.Pacient = Medication.Patient;
        MedicalCare.Session = Session;
        MedicalCare.Medical = Medical;

        Session.IsCompleted = true;
        try
        {

            var response = BussinessFactory.GetMedicalCareService().Save(MedicalCare);

            if (response.OperationResult == OperationResult.Success)
            {
                BussinessFactory.GetSessionService().Update(Session);
                Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", IdMedication), true);
            }
            else
            {
                litMensaje.Text = string.Format("No se pudo Guardar la Atención");
            }
        }
        catch (Exception e)
        {
            throw e;
        }

    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //var action = Request.QueryString.Get("action");
        //switch (action)
        //{
        //    case "new":
        Save();
        //    break;
        //case "edit":
        //    Update();
        //    break;
        // }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        var IdSession = Request.QueryString.Get("idSession");
        var Session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));

        //  var IdMedication = Request.QueryString.Get("idMedication");
        var IdMedication = Session.Medication.Id;
        Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", IdMedication), true);
    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {

        const string javascript = "openRadWindow('SearchPersons.aspx?personType=652015c3-e389-46b0-9bab-fb016b8abd44','rw1');";
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "OpenSearchPersons", javascript, true);
    }
}