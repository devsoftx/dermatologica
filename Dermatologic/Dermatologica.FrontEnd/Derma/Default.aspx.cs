using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;
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
    }

    private void GetOffices()
    {
        var offices = BussinessFactory.GetOfficeService().GetAll(p => p.IsActive);
        BindControl<Office>.BindDropDownList(ddlOffices,offices);
    }

    private void ConfigureRadCalendar()
    {
        radCalendar.DataKeyField = "ID";
        radCalendar.DataStartField = "StartDate";
        radCalendar.DataDescriptionField = "Descripcion";
        radCalendar.DataEndField = "EndDate";
        radCalendar.DataSubjectField = "Subject";
        radCalendar.DataRecurrenceField = "RecurrenceRule";
        radCalendar.DataRecurrenceParentKeyField = "RecurrenceParentID";
        radCalendar.Culture = new CultureInfo("es-PE");
        radCalendar.CustomAttributeNames = new string[] { "Place", "NotifyEach" };
        
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
            Response.Redirect("Appointment.aspx?id=" + e.Appointment.ID, true);
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
            var idOffice = ddlOffices.SelectedValue;
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
    
}