using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;

public partial class Derma_Appointment : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var Id = Request.QueryString.Get("Id");
            GetOffices();
            GetOpMedical();
            if (!string.IsNullOrEmpty(Id))
            {
                var appointment = BussinessFactory.GetAppointmentService().Get(new Guid(Id));
                txtPatient.Text = appointment.Patient;
                if (appointment.StartDate != null) txtDateStart.Text = appointment.StartDate.Value.ToShortTimeString();
                if (appointment.EndDate != null) txtDateEnd.Text = appointment.EndDate.Value.ToShortTimeString();
                if (appointment.Medical != null) ddlMedical.SelectedValue = appointment.Medical.Id.Value.ToString();
                if (appointment.Office != null) txtDateEnd.Text = appointment.Office.Id.Value.ToString();
                txtDescription.Text = appointment.Description;
            }
        }
    }
    protected void LinkReturn_Click(object sender, EventArgs e)
    {
        var returnUrl = Request.Params.Get("returnUrl");
        if(!string.IsNullOrEmpty(returnUrl))
            Response.Redirect(returnUrl);
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
}