using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;

public partial class Derma_Appointment : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var Id = Request.QueryString.Get("Id");
            if (!string.IsNullOrEmpty(Id))
            {
                var appointment = BussinessFactory.GetAppointmentService().Get(new Guid(Id));
                txtPatient.Text = appointment.Patient;
                txtMedical.Text = appointment.Medical != null? appointment.Medical.CompleteName : string.Empty;
                txtConsultorio.Text = appointment.Office.Name;
                txtConsultorio.BackColor = Color.FromName(appointment.Office.ColorId);
                if (appointment.StartDate != null) txtDateStart.Text = appointment.StartDate.Value.ToShortTimeString();
                if (appointment.EndDate != null) txtDateEnd.Text = appointment.EndDate.Value.ToShortTimeString();
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
}