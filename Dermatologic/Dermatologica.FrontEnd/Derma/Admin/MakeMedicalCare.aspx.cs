using System;
using System.Linq;
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
        var currentSession = BussinessFactory.GetSessionService().Get(new Guid(IdSession)).Entity;
        var IdMedication = currentSession.Medication.Id;
        var medication = BussinessFactory.GetMedicationService().Get(IdMedication).Entity;
        txtPatient.Text = string.Format("{0} {1} {2}", medication.Patient.FirstName, medication.Patient.LastNameP, medication.Patient.LastNameM);
        txtSession.Text = currentSession.Medication.Service.Name;
    }

    private void Save()
    {
        var IdSession = Request.QueryString.Get("idSession");
        var session = BussinessFactory.GetSessionService().Get(new Guid(IdSession)).Entity;
        var IdMedication = session.Medication.Id;
        var medication = BussinessFactory.GetMedicationService().Get(IdMedication).Entity;
        var medical = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue)).Entity;
        var example1 = medical;
        var example2 = medication.Service;
        var response1 = BussinessFactory.GetRateService().GetRatesByPersonService(example1, example2);
        var rate = new Rate();
        if (response1.OperationResult == OperationResult.Success)
        {
            var List = response1.Rates;
            if (List.Count != 0)
            {
                rate = List.FirstOrDefault();
            }
            else
            {
                litMensaje.Text = string.Format("Falta Agregar la Tarifa de este Tratamiento para este Medico");
                return;
            }
        }

        Person partner = rate.UnitCostPartner != 0 ? BussinessFactory.GetPersonService().Get(new Guid(DermaConstants.PERSON_URSULA)).Entity : null;
        var medicalCare = new MedicalCare
                              {
                                  Id = Guid.NewGuid(),
                                  Description = txtDescription.Text.Trim(),
                                  DateAttention = Convert.ToDateTime(CreationDate),
                                  IsReplacement = chkIsReplacement.Checked,
                                  IsActive = true,
                                  LastModified = LastModified,
                                  CreationDate = CreationDate,
                                  ModifiedBy = ModifiedBy,
                                  CreatedBy = CreatedBy,
                                  Pacient = medication.Patient,
                                  Session = session,
                                  Medical = medical,
                                  Partner = partner,
                                  Rate = rate,
                              };

        session.IsCompleted = true;
        medicalCare.CostCenter = chkIsReplacement.Checked ? BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenterR.SelectedValue)).Entity : null;
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
            litMensaje.Text = string.Format("No se pudo guardar la atencion -> Error: {0}", e.Message);
        }
    }

    private void LoadPersonType()
    {
        var response = BussinessFactory.GetPersonTypeService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var types = response.Results;
            BindControl<PersonType>.BindDropDownList(ddlPersonType, types);   
        }
    }

    private void LoadCostCenterR()
    {

        var response = BussinessFactory.GetStaffInformationService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
        if (response.OperationResult == OperationResult.Success)
        {
            var staffInformation = response.Entity;
            if (staffInformation.CostCenter.Id.HasValue)
            {
                var CostCenterId = staffInformation.CostCenter.Id.Value.ToString();
                var costCenters = BussinessFactory.GetCostCenterService().GetAll(p => p.Id != null && !p.Id.Value.Equals(CostCenterId));
                BindControl<CostCenter>.BindDropDownList(ddlCostCenterR, costCenters.Results);
            }
        }
        //devuelve los centros de costo en los cuales el no trabaja
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Save();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        var idSession = Request.QueryString.Get("idSession");
        var session = BussinessFactory.GetSessionService().Get(new Guid(idSession)).Entity;
        var idMedication = session.Medication.Id;
        Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", idMedication), true);
    }

    protected void ddlPersonType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucSearchPersonsMedical.SelectedValue = string.Empty;
        ucSearchPersonsMedical.Text = string.Empty;
    }

    protected void chkIsReplacement_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsReplacement.Checked == true)
        {
            if (ucSearchPersonsMedical.Text == "")
            {
                litMensaje.Text = ("Falta Ingresar el Operador Medico");
                chkIsReplacement.Checked = false;
            }
            else
            {
                LoadCostCenterR();
            }
        }
        else
        {
            ddlCostCenterR.DataSource = null;
        }
    }
}