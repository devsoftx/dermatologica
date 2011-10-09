using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_ListAppoimentsByPatient : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetAppointments();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var example = new Appointment {Patient = txtSearch.Text.Trim().ToLower()};
        DateTime? startDate = null;
        DateTime? endDate = null;
        if (!string.IsNullOrEmpty(txtDateStart.Text))
        {
            var date = Convert.ToDateTime(txtDateStart.Text.Trim());
            startDate = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
        }
        if (!string.IsNullOrEmpty(txtDateEnd.Text))
        {
            var date = Convert.ToDateTime(txtDateEnd.Text.Trim());
            endDate = new DateTime(date.Year, date.Month, date.Day, 21, 0, 0);
        }
        if(startDate == null)
        {
            var date = DateTime.Now;
            startDate = new DateTime(date.Year, date.Month, 1, 8, 0, 0);
        }
        if (endDate == null)
        {
            var date = DateTime.Now;
            endDate = AppointmentService.GetNroDaysFromMonth(date) > 30
                                       ? new DateTime(date.Year, date.Month, 31, 21, 0, 0)
                                       : new DateTime(date.Year, date.Month, 30, 21, 0, 0);
        }
        example.StartDate = startDate;
        example.EndDate = endDate;
        var response = BussinessFactory.GetAppointmentService().GetByPatient(example);
        if (response.OperationResult == OperationResult.Success)
        {
            var appointments = response.Appointments;
            BindControl<Appointment>.BindGrid(gvAppointments, appointments);
        }
    }

    protected void gvAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            switch (e.CommandName)
            {
                case "cmd_editar":
                    var id = new Guid(e.CommandArgument.ToString());
                    Response.Redirect(string.Format("~/Derma/Appointment.aspx?id={0}&action=edit&returnUrl={1}", id, Request.RawUrl), true);
                    break;
                case "cmd_eliminar":
                    DeleteAppointment(new Guid(e.CommandArgument.ToString()));
                    GetAppointments();
                    break;
            }   
        }
    }

    private void GetAppointments()
    {
        var response = BussinessFactory.GetAppointmentService().GetAll(u => u.IsActive);
        if(response.OperationResult == OperationResult.Success)
        {
            var appointments = response.Results.OrderBy(p => p.LastModified).ToList();
            BindControl<Appointment>.BindGrid(gvAppointments, appointments);   
        }
    }

    private void DeleteAppointment(Guid id)
    {
        var responsAppointment = BussinessFactory.GetAppointmentService().Get(id);
        if (responsAppointment.OperationResult == OperationResult.Success)
        {
            var appointment = responsAppointment.Entity;
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

    protected void gvAppointments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            ResponseBase<Appointment> response;
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                response = BussinessFactory.GetAppointmentService().GetAll(p => p.IsActive);
            }
            else
            {
                var example = new Appointment { Patient = txtSearch.Text.Trim().ToLower() };
                DateTime? startDate = null;
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(txtDateStart.Text))
                {
                    var date = Convert.ToDateTime(txtDateStart.Text.Trim());
                    startDate = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
                }
                if (!string.IsNullOrEmpty(txtDateEnd.Text))
                {
                    var date = Convert.ToDateTime(txtDateEnd.Text.Trim());
                    endDate = new DateTime(date.Year, date.Month, date.Day, 21, 0, 0);
                }
                if (startDate == null)
                {
                    var date = DateTime.Now;
                    startDate = new DateTime(date.Year, date.Month, 1, 8, 0, 0);
                }
                if (endDate == null)
                {
                    var date = DateTime.Now;
                    endDate = AppointmentService.GetNroDaysFromMonth(date) > 30
                                               ? new DateTime(date.Year, date.Month, 31, 21, 0, 0)
                                               : new DateTime(date.Year, date.Month, 30, 21, 0, 0);
                }
                response = BussinessFactory.GetAppointmentService().GetByPatient(example);
            }
            if (response.OperationResult == OperationResult.Success)
            {
                var persons = response.Results;
                gvAppointments.DataSource = persons;
                gvAppointments.PageIndex = e.NewPageIndex;
                gvAppointments.DataBind();
            }
        }
        catch (Exception ex)
        {
            litMensaje.Text = string.Format("Error: {0}", ex.Message);
        }
    }
}