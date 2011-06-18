using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Appointment = Dermatologic.Domain.Appointment;
using Telerik.Web.UI;

public partial class Derma_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetOffices();
        ConfigureRadCalendar();
        var date = DateTime.Now.ToShortDateString();
        if (!string.IsNullOrEmpty(date))
            radCalendar.SelectedDate = DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("ES-pe"));
        GetAppointments(new Guid(ddlOffices.SelectedValue));
    }

    private void GetOffices()
    {
        var offices = BussinessFactory.GetOfficeService().GetAll(p => p.IsActive);
        BindControl<Office>.BindDropDownList(ddlOffices,offices);
    }

    private void ConfigureRadCalendar()
    {
        radCalendar.DataKeyField = "ID";
        radCalendar.DataStartField = "Start";
        radCalendar.DataDescriptionField = "Descripcion";
        radCalendar.DataEndField = "End";
        radCalendar.DataSubjectField = "Subject";
        radCalendar.DataRecurrenceField = "RecurrenceRule";
        radCalendar.DataRecurrenceParentKeyField = "RecurrenceParentID";
        radCalendar.Culture = new CultureInfo("es-PE");
        radCalendar.CustomAttributeNames = new string[] { "Lugar", "NotificarCada" };
        
        var frecuencias = BussinessFactory.GetItemTableService().GetAll();
        var rtFrecuencias = new ResourceType
        {
            Name = "Frecuencia",
            DataSource = frecuencias,
            KeyField = "Id",
            ForeignKeyField = "Frecuencia",
            TextField = "Descripcion"
        };
        radCalendar.ResourceTypes.Add(rtFrecuencias);
        var tipos = BussinessFactory.GetItemTableService().GetAll();
        var rtTipo = new ResourceType
        {
            Name = "Tipo",
            DataSource = tipos,
            KeyField = "Id",
            ForeignKeyField = "Tipo",
            TextField = "Descripcion"
        };
        radCalendar.ResourceTypes.Add(rtTipo);
    }

    protected void radCalendar_AppointmentClick(object sender, SchedulerEventArgs e)
    {
        if (e.Appointment.Description == "Cita")
            Response.Redirect("Appointment.aspx?Id=" + e.Appointment.ID, true);
    }

    protected void radCalendar_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
    {

    }

    protected void radCalendar_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
    {

    }

    protected void radCalendar_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {

    }

    protected void radCalendar_FormCreated(object sender, SchedulerFormCreatedEventArgs e)
    {
        if (e.Container.Mode == SchedulerFormMode.AdvancedEdit || e.Container.Mode == SchedulerFormMode.AdvancedInsert)
        {
            var notificarCadaText = (RadTextBox)e.Container.FindControl("AttrNotificarCada");
            notificarCadaText.ToolTip = @"Ingresar número de veces.";
            notificarCadaText.Width = 150;

            var recurrentAppointment = (CheckBox)e.Container.FindControl("RecurrentAppointment");
            recurrentAppointment.Enabled = false;
            recurrentAppointment.Text = string.Empty;
            recurrentAppointment.Width = 0;
        }
    }

    protected void radCalendar_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        if (e.Command == SchedulerNavigationCommand.NavigateToNextPeriod ||
                e.Command == SchedulerNavigationCommand.NavigateToPreviousPeriod ||
                e.Command == SchedulerNavigationCommand.NavigateToSelectedDate)
        {
            //var idSede = Convert.ToInt32(Session["idSede"]);
            GetAppointments(new Guid());
        }
    }

    protected void radCalendar_PreRender(object sender, EventArgs e)
    {
        var popupCalendar = radCalendar.FindControl("SelectedDateCalendar") as RadCalendar;
        if (popupCalendar == null) return;
        foreach (var dayWithAppointment in radCalendar.Appointments.Select(a => new RadCalendarDay
        {
            ToolTip = a.Subject,
            Date = a.Start
        }))
        {
            dayWithAppointment.ItemStyle.BackColor = Color.Red;
            popupCalendar.SpecialDays.Add(dayWithAppointment);
        }
    }

    private void GetAppointments(Guid? idOffice)
    {
        var fecha = new DateTime(radCalendar.SelectedDate.Year, radCalendar.SelectedDate.Month, 1);
        var appointments = BussinessFactory.GetAppointmentService().GetByOffices(idOffice, fecha.AddMonths(-1), fecha.AddMonths(1));
        appointments.AddRange(LoadAppointments(idOffice, fecha));
        radCalendar.DataSource = appointments;
        radCalendar.DataBind();
    }

    private IEnumerable<Appointment> LoadAppointments(Guid? idSede, DateTime? fecha)
    {
        var obligaciones = BussinessFactory.GetAppointmentService().GetByMonth(fecha, idSede);
        return obligaciones.Select(obligacionSede => new Appointment
        {
            Id = obligacionSede.Id,
            Subject = obligacionSede.Subject,
            StartDate = obligacionSede.StartDate,
            EndDate = obligacionSede.EndDate.AddDays(1),
            Description = "Cita"
        }).ToList();
    }
}