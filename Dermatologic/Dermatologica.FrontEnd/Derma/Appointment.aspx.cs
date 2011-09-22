using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Appointment : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetAppointment();
        }
    }
    
    private void GetOffices()
    {
        var offices = BussinessFactory.GetOfficeService().GetAll(u => u.IsActive).OrderBy(p => p.Name).ToList();
        BindControl<Office>.BindDropDownList(ddlConsultorio, offices);
    }

    private void GetOpMedical()
    {
        IEnumerable<Person> medicals = GetMedicals();
        IEnumerable<Person> cosmeatras = GetCosmeatras();
        var response = medicals.Union(cosmeatras).OrderBy(p => p.CompleteName).ToList();
        BindControl<Person>.BindDropDownList(ddlMedical, response, true);
    }

    private IEnumerable<Person> GetMedicals()
    {
        var example = new Person
        {
            PersonType = { Id = new Guid(DermaConstants.PERSON_TYPE_MEDICAL) }
        };
        return BussinessFactory.GetPersonService().GetPacients(example).Pacients.OrderBy(p => p.CompleteName).ToList();
    }

    private IEnumerable<Person> GetCosmeatras()
    {
        var example = new Person
        {
            PersonType = { Id = new Guid(DermaConstants.PERSON_TYPE_COSMEATRA) }
        };
        return BussinessFactory.GetPersonService().GetPacients(example).Pacients.OrderBy(p => p.CompleteName).ToList();
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var action = Request.QueryString.Get("action");
        switch (action)
        {
            case "new":
                
                break;
            case "edit":
                Update();
                break;
        }
    }

    private void Update()
    {
        var id = Request.QueryString.Get("id");
        var appointment = BussinessFactory.GetAppointmentService().Get(new Guid(id));
        appointment.Patient = txtPatient.Text;
        appointment.Description = txtDescription.Text;
        appointment.Medical = BussinessFactory.GetPersonService().Get(new Guid(ddlMedical.SelectedValue));
        appointment.Office = BussinessFactory.GetOfficeService().Get(new Guid(ddlConsultorio.SelectedValue));
        var response = BussinessFactory.GetAppointmentService().Update(appointment);
        if(response.OperationResult == OperationResult.Success)
        {
            var returnUrl = Request.Params.Get("returnUrl");
            if (!string.IsNullOrEmpty(returnUrl))
                Response.Redirect(string.Format("{0}?id={1}", returnUrl, id));
        }
        else
        {

        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        var returnUrl = Request.Params.Get("returnUrl");
        var id = Request.Params.Get("id");
        if (!string.IsNullOrEmpty(returnUrl))
            Response.Redirect(string.Format("{0}?id={1}", returnUrl, id));
    }

    private void SetAppointment()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadAppointment(new Guid(id));
                break;
        }
    }

    private void LoadAppointment(Guid id)
    {
        GetOffices();
        GetOpMedical();
        var appointment = BussinessFactory.GetAppointmentService().Get(id);
        txtPatient.Text = appointment.Patient;
        if (appointment.StartDate != null) txtDateStart.Text = appointment.StartDate.Value.ToShortTimeString();
        if (appointment.EndDate != null) txtDateEnd.Text = appointment.EndDate.Value.ToShortTimeString();
        if (appointment.Medical != null) ddlMedical.SelectedValue = appointment.Medical.Id.Value.ToString();
        if (appointment.Office != null) ddlConsultorio.SelectedValue = appointment.Office.Id.Value.ToString();
        txtDescription.Text = appointment.Description;
    }
}