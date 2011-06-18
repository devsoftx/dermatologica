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
        var userName = Session["userName"];
        if (userName != null)
        {
            litUser.Text = string.Format("{0} {1} {2}", "Jose","Rojas","Quiroz");
        }
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
        radCalendar.DataDescriptionField = "Description";
        radCalendar.DataEndField = "EndDate";
        radCalendar.DataSubjectField = "Subject";
        radCalendar.DataRecurrenceField = "RecurrenceRule";
        radCalendar.DataRecurrenceParentKeyField = "RecurrenceParentID";
        radCalendar.Culture = new CultureInfo("es-PE");
        radCalendar.CustomAttributeNames = new[] { "Paciente", "NotifyEach" };

        var frecuencias = EnumHelper.ToList(typeof(Frecuence));
        var rtFrecuencias = new ResourceType
        {
            Name = "Frecuencia",
            DataSource = frecuencias,
            KeyField = "Key",
            TextField = "Value",
            ForeignKeyField = "Frecuence"
        };
        radCalendar.ResourceTypes.Add(rtFrecuencias);

        IList<Person> response = GetMedicals();
        var rtTipo = new ResourceType
        {
            Name = "Medico",
            DataSource = response,
            KeyField = "Id",
            TextField = "CompleteName",
            ForeignKeyField = "Medical"
        };
        radCalendar.ResourceTypes.Add(rtTipo);
    }

    private IList<Person> GetMedicals()
    {
        var example = new Person
                          {
                              PersonType = {Id = new Guid("DA913E86-1EB8-41E1-8DA0-81ABD6195254")}
                          };
        return BussinessFactory.GetPersonService().GetPacients(example).Pacients;
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
        var idOfficce = ddlOffices.SelectedValue;
        if (!string.IsNullOrEmpty(idOfficce))
        {
            IList<Person> medicals = GetMedicals();
            var medical = e.Appointment.Resources.Count == 0
                           ? medicals.Count == 0 ? null : medicals.First().Id
                           : e.Appointment.Resources[1].Key == null
                                 ? medicals.Count == 0 ? null : medicals.First().Id
                                 : new Guid(e.Appointment.Resources[1].Key.ToString());

            int frecuence = e.Appointment.Resources.Count == 0
                                 ? 0
                                 : e.Appointment.Resources[0].Key == null
                                       ? 0
                                       : Convert.ToInt32(e.Appointment.Resources[0].Key);

            var notificarCada = string.IsNullOrEmpty(e.Appointment.Attributes["NotifyEach"])
                                    ? 0 : Convert.ToInt32(e.Appointment.Attributes["NotifyEach"]);
            
                var appointment = new Appointment
                                      {
                                          Id = Guid.NewGuid(),
                                          Subject = e.Appointment.Subject,
                                          StartDate = e.Appointment.Start,
                                          EndDate = e.Appointment.End,
                                          CreationDate = CreationDate,
                                          CreatedBy = CreatedBy,
                                          RecurrenceParentID = (Guid?) e.Appointment.RecurrenceParentID,
                                          RecurrenceRule = e.Appointment.RecurrenceRule,
                                          Description = e.Appointment.Description,
                                          Frecuence = frecuence,
                                          Patient = e.Appointment.Attributes["Paciente"],
                                          NotifyEach = notificarCada,
                                          Medical = BussinessFactory.GetPersonService().Get(medical),
                                          Office = BussinessFactory.GetOfficeService().Get(new Guid(idOfficce))
                                      };
            var response = BussinessFactory.GetAppointmentService().Save(appointment);
            if (response.OperationResult == OperationResult.Success)
            {
                litMessage.Text = string.Format("Se realizó la cita para el día: {0}",e.Appointment.Start.ToShortDateString());
            }
            else
            {
                litMessage.Text = string.Format("No se puedo guardar - Error: {0}", response.Message);
            }
        }
    }

    protected void radCalendar_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {

    }

    protected void radCalendar_FormCreated(object sender, SchedulerFormCreatedEventArgs e)
    {
        if (e.Container.Mode == SchedulerFormMode.AdvancedEdit || e.Container.Mode == SchedulerFormMode.AdvancedInsert)
        {
            var notificarCadaText = (RadTextBox)e.Container.FindControl("AttrNotifyEach");
            notificarCadaText.ToolTip = @"Ingresar número de veces.";
            notificarCadaText.Width = 150;

            //var recurrentAppointment = (CheckBox)e.Container.FindControl("RecurrentAppointment");
            //recurrentAppointment.Enabled = false;
            //recurrentAppointment.Text = string.Empty;
            //recurrentAppointment.Width = 0;
        }
    }

    protected void radCalendar_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        if (e.Command == SchedulerNavigationCommand.NavigateToNextPeriod ||
                e.Command == SchedulerNavigationCommand.NavigateToPreviousPeriod ||
                e.Command == SchedulerNavigationCommand.NavigateToSelectedDate)
        {
            var idOffice = ddlOffices.SelectedValue;
            LoadAppointments(new Guid(idOffice));
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

    protected void ddlOffices_SelectedIndexChanged(object sender, EventArgs e)
    {
        var idOfficce = ddlOffices.SelectedValue;
        if (!string.IsNullOrEmpty(idOfficce))
        {
           
        }
    }

    private void LoadAppointments(Guid idOffice)
    {
        var fecha = new DateTime(radCalendar.SelectedDate.Year, radCalendar.SelectedDate.Month, 1);
        var appointments = BussinessFactory.GetAppointmentService().GetByOffices(idOffice, fecha.AddMonths(-1), fecha.AddMonths(1));
        radCalendar.DataSource = appointments;
        radCalendar.DataBind();
    }

}