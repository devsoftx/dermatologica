using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
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
            LoadPersonType();
        }
        ucSearchPersonsMedical.PersonTypeControlName = ddlPersonType.ClientID;
    }

    private void SetPayment()
    {
        var IdSession = Request.QueryString.Get("idSession");
        var currentSession = BussinessFactory.GetSessionService().Get(new Guid(IdSession));
        var IdMedication = currentSession.Medication.Id;
        var medication = BussinessFactory.GetMedicationService().Get(IdMedication);
        txtPatient.Text = string.Format("{0} {1} {2}", medication.Patient.FirstName,medication.Patient.LastNameP,medication.Patient.LastNameM);
        txtSession.Text = currentSession.Medication.Service.Name;
    }

    private void Save()
    {
        var IdSession = Request.QueryString.Get("idSession");
        var session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));
        var IdMedication = session.Medication.Id;
        var medication = BussinessFactory.GetMedicationService().Get(IdMedication);
        var medical = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
        

        var example1 = medical;
        var example2=medication.Service;

        var response1 = BussinessFactory.GetRateService().GetRatesByPersonService(example1,example2);
        var rate= new Rate();
        if (response1.OperationResult == OperationResult.Success)
        {
           var List = response1.Rates;

           if (List != null)
           {
               rate = List.FirstOrDefault();
           }
           else
           {
            litMensaje.Text = string.Format("Falta Agregar la Tarifa de este Servicio para este Medico");
            return;
           }
        }

       


        var medicalCare = new MedicalCare
                              {
                                  Id = Guid.NewGuid(),
                                  Description = txtDescription.Text.Trim(),
                                  DateAttention = Convert.ToDateTime(CreationDate),
                                  IsActive = true,
                                  LastModified = LastModified,
                                  CreationDate = CreationDate,
                                  ModifiedBy = ModifiedBy,
                                  CreatedBy = CreatedBy,
                                  Pacient = medication.Patient,
                                  Session = session,
                                  Medical = medical,
                                  Rate=rate,                                                                           
                              };

        session.IsCompleted = true;
        try
        {
            var response = BussinessFactory.GetMedicalCareService().Save(medicalCare);
            if (response.OperationResult == OperationResult.Success)
            {
                BussinessFactory.GetSessionService().Update(session);
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

    private void LoadPersonType()
    {
        var types = BussinessFactory.GetPersonTypeService().GetAll(p => p.IsActive);
        BindControl<PersonType>.BindDropDownList(ddlPersonType, types);
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Save();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        var IdSession = Request.QueryString.Get("idSession");
        var session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));
        var IdMedication = session.Medication.Id;
        Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", IdMedication), true);
    }

    protected void ddlPersonType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucSearchPersonsMedical.SelectedValue = string.Empty;
        ucSearchPersonsMedical.Text = string.Empty;
    }
}