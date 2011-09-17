using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_ListAppoiments : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetAppointments();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var example = new Appointment
                          {
                              Medical =
                                  {
                                      FirstName = txtSearch.Text.Trim(),
                                      LastNameP = txtSearch.Text.Trim(),
                                      LastNameM = txtSearch.Text.Trim()
                                  }
                          };
        if (!string.IsNullOrEmpty(txtDate.Text))
        {
            example.StartDate = Convert.ToDateTime(txtDate.Text);
        }
        else
        {
            example.StartDate = null;
        }
        var response = BussinessFactory.GetAppointmentService().GetByOpMedical(example);
        if (response.OperationResult == OperationResult.Success)
        {
            var appointments = response.Appointments;
            BindControl<Appointment>.BindGrid(gvAppointments, appointments);
        }
    }

    protected void gvAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/Derma/Appointment.aspx?id={0}&action=edit&returnUrl={1}", id,Request.RawUrl), true);
                break;
            case "cmd_eliminar":
                DeleteAppointment(new Guid(e.CommandArgument.ToString()));
                GetAppointments();
                break;
        }
    }

    private void GetAppointments()
    {
        var appointments = BussinessFactory.GetAppointmentService().GetAll(u => u.IsActive == true).OrderBy(p => p.LastModified).ToList();
        BindControl<Appointment>.BindGrid(gvAppointments, appointments);
    }

    private void DeleteAppointment(Guid id)
    {
        var appointment = BussinessFactory.GetAppointmentService().Get(id);
        if (appointment != null)
        {
            appointment.IsActive = false;
            appointment.LastModified = LastModified;
            appointment.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetAppointmentService().Update(appointment);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó la cita del Sr. {0} con Dr(a).: {1}", appointment.Patient ,appointment.Medical.CompleteName);
                return;
            }
        }
    }

}