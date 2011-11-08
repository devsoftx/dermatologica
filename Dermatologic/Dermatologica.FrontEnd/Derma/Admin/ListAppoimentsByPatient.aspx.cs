using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Dermatologica.Web;
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
            var date = Convert.ToDateTime(txtDateStart.Text.Trim(), CurrentCulture);
            startDate = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
        }
        if (!string.IsNullOrEmpty(txtDateEnd.Text))
        {
            var date = Convert.ToDateTime(txtDateEnd.Text.Trim(), CurrentCulture);
            endDate = new DateTime(date.Year, date.Month, date.Day, 21, 0, 0);
        }
        if(startDate == null)
        {
            var date = Convert.ToDateTime(DateTime.Now, CurrentCulture);
            startDate = new DateTime(date.Year, date.Month, 1, 8, 0, 0);
        }
        if (endDate == null)
        {
            var date = Convert.ToDateTime(DateTime.Now, CurrentCulture);
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
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                var response = BussinessFactory.GetAppointmentService().GetAll(p => p.IsActive);
                if (response.OperationResult == OperationResult.Success)
                {
                    var persons = response.Results;
                    gvAppointments.DataSource = persons;
                    gvAppointments.PageIndex = e.NewPageIndex;
                    gvAppointments.DataBind();
                }
            }
            else
            {
                var example = new Appointment { Patient = txtSearch.Text.Trim().ToLower() };
                DateTime? startDate = null;
                DateTime? endDate = null;
                if (!string.IsNullOrEmpty(txtDateStart.Text))
                {
                    var date = Convert.ToDateTime(txtDateStart.Text.Trim(), CurrentCulture);
                    startDate = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
                }
                if (!string.IsNullOrEmpty(txtDateEnd.Text))
                {
                    var date = Convert.ToDateTime(txtDateEnd.Text.Trim(), CurrentCulture);
                    endDate = new DateTime(date.Year, date.Month, date.Day, 21, 0, 0);
                }
                if (startDate == null)
                {
                    var date = Convert.ToDateTime(DateTime.Now, CurrentCulture);
                    startDate = new DateTime(date.Year, date.Month, 1, 8, 0, 0);
                }
                if (endDate == null)
                {
                    var date = Convert.ToDateTime(DateTime.Now, CurrentCulture);
                    endDate = AppointmentService.GetNroDaysFromMonth(date) > 30
                                               ? new DateTime(date.Year, date.Month, 31, 21, 0, 0)
                                               : new DateTime(date.Year, date.Month, 30, 21, 0, 0);
                }
                example.StartDate = startDate;
                example.EndDate = endDate;
                var responseAppoinment = BussinessFactory.GetAppointmentService().GetByPatient(example);
                if (responseAppoinment.OperationResult == OperationResult.Success)
                {
                    var persons = responseAppoinment.Appointments;
                    gvAppointments.DataSource = persons;
                    gvAppointments.PageIndex = e.NewPageIndex;
                    gvAppointments.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            litMensaje.Text = string.Format("Error: {0}", ex.Message);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        var example = new Appointment { Patient = txtSearch.Text.Trim().ToLower() };
        DateTime? startDate = null;
        DateTime? endDate = null;
        if (!string.IsNullOrEmpty(txtDateStart.Text))
        {
            var date = Convert.ToDateTime(txtDateStart.Text.Trim(), CurrentCulture);
            startDate = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
        }
        if (!string.IsNullOrEmpty(txtDateEnd.Text))
        {
            var date = Convert.ToDateTime(txtDateEnd.Text.Trim(), CurrentCulture);
            endDate = new DateTime(date.Year, date.Month, date.Day, 21, 0, 0);
        }
        if (startDate == null)
        {
            var date = Convert.ToDateTime(DateTime.Now, CurrentCulture);
            startDate = new DateTime(date.Year, date.Month, 1, 8, 0, 0);
        }
        if (endDate == null)
        {
            var date = Convert.ToDateTime(DateTime.Now, CurrentCulture);
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
            var dt = new DataTable();
            dt.Columns.Add("<b>Fecha</b>");
            dt.Columns.Add("<b>Hora Inicial</b>");
            dt.Columns.Add("<b>Hora Final</b>");
            dt.Columns.Add("<b>Paciente</b>");
            dt.Columns.Add("<b>Descripcion</b>");
            dt.Columns.Add("<b>Tratamiento</b>");
            dt.Columns.Add("<b>Oficina</b>");
            dt.Columns.Add("<b>Operador Medico</b>"); 
            foreach (var appointment in appointments)
            {
                var row = dt.NewRow();
                row[0] = appointment.StartDate != null ? appointment.StartDate.Value.ToShortDateString() : string.Empty;
                row[1] = appointment.StartDate != null ? appointment.StartDate.Value.ToShortTimeString() : string.Empty;
                row[2] = appointment.EndDate != null ? appointment.EndDate.Value.ToShortTimeString() : string.Empty;
                row[3] = HttpUtility.HtmlEncode(appointment.Patient);
                row[4] = HttpUtility.HtmlEncode(appointment.Description);
                row[5] = HttpUtility.HtmlEncode(appointment.Subject);
                row[6] = appointment.Office != null ? appointment.Office.Name : string.Empty;
                row[7] = appointment.Medical != null ? HttpUtility.HtmlEncode(appointment.Medical.CompleteName) : string.Empty;
                dt.Rows.Add(row);
            }
            var dg = new DataGrid {DataSource = dt};
            dg.DataBind();
            ExportToExcel(
                string.Format("Citas_{0}-{1}.xls", startDate.Value.ToShortDateString(),
                              endDate.Value.ToShortDateString()), dg);
        }
    }
}