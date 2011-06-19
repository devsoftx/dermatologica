using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;
using Appointment = Dermatologic.Domain.Appointment;
using Telerik.Web.UI;

public partial class Derma_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetOffices();
            ConfigureRadCalendar();
            var date = DateTime.Now.ToShortDateString();
            if (!string.IsNullOrEmpty(date))
                radCalendar.SelectedDate = DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("ES-pe"));
            var userName = Session["userName"];
            if (userName != null)
            {
                litUser.Text = string.Format("{0} {1} {2}", "Jose", "Rojas", "Quiroz");
                var idOffice = ddlOffices.SelectedValue;
                LoadAppointments(new Guid(idOffice));
            }   
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
        radCalendar.ShowAllDayRow = false;
        var frecuencias = EnumHelper.ToList<Frecuence>();
        var rtFrecuencias = new ResourceType
        {
            Name = "Frecuence",
            DataSource = frecuencias,
            KeyField = "Key",
            TextField = "Value",
            ForeignKeyField = "Frecuence"
        };
        radCalendar.ResourceTypes.Add(rtFrecuencias);

        IList<Person> response = GetMedicals();
        var rtMedical = new ResourceType
        {
            Name = "Medical",
            DataSource = response,
            KeyField = "Id",
            TextField = "CompleteName",
            ForeignKeyField = "Medical",
        };
        radCalendar.ResourceTypes.Add(rtMedical);
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
        
    }

    protected void radCalendar_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
    {
        var idOfficce = ddlOffices.SelectedValue;
        if (!string.IsNullOrEmpty(idOfficce))
        {
            var idAppointment = new Guid(e.Appointment.ID.ToString());
            var appoinment = BussinessFactory.GetAppointmentService().Get(idAppointment);
            var response = BussinessFactory.GetAppointmentService().Delete(appoinment);
            if (response.OperationResult == OperationResult.Success)
            {
                LoadAppointments(new Guid(idOfficce));
            }
        }
    }

    protected void radCalendar_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
    {
        var idOfficce = ddlOffices.SelectedValue;
        if (!string.IsNullOrEmpty(idOfficce))
        {
            int? frecuence = null;
            Guid? medical = null;
            if (e.Appointment.Resources.Count > 0)
            {
                if (e.Appointment.Resources[0].Key != null)
                {
                    frecuence = Convert.ToInt32(e.Appointment.Resources[0].Key);
                }
                if (e.Appointment.Resources[1].Key != null)
                {
                    medical = new Guid(e.Appointment.Resources[1].Key.ToString());
                }
            }
            var notificarCada = string.IsNullOrEmpty(e.Appointment.Attributes["NotifyEach"]) ? 0 : Convert.ToInt32(e.Appointment.Attributes["NotifyEach"]);
            var appointment = new Appointment
                                    {
                                        Id = Guid.NewGuid(),
                                        Subject = e.Appointment.Subject,
                                        StartDate = e.Appointment.Start,
                                        EndDate = e.Appointment.End,
                                        RecurrenceParentID = (Guid?) e.Appointment.RecurrenceParentID,
                                        RecurrenceRule = e.Appointment.RecurrenceRule,
                                        Description = e.Appointment.Description,
                                        Patient = e.Appointment.Attributes["Paciente"],
                                        NotifyEach = notificarCada,
                                        Frecuence = frecuence.HasValue ? frecuence.Value : (int?) null,
                                        Office = BussinessFactory.GetOfficeService().Get(new Guid(idOfficce)),
                                        CreationDate = CreationDate,
                                        CreatedBy = CreatedBy,
                                        IsActive = true,
                                        ModifiedBy = ModifiedBy,
                                        LastModified = LastModified,
                                        Medical = medical.HasValue ? BussinessFactory.GetPersonService().Get(medical) : null
                                    };
            var response = BussinessFactory.GetAppointmentService().Save(appointment);
            if(response.OperationResult == OperationResult.Success)
            {
                LoadAppointments(new Guid(idOfficce));
            }
        }
    }

    protected void radCalendar_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {
        var idOfficce = ddlOffices.SelectedValue;
        if (!string.IsNullOrEmpty(idOfficce))
        {
            int? frecuence = null;
            Guid? medical = null;
            if (e.ModifiedAppointment.Resources.Count > 0)
            {
                if (e.ModifiedAppointment.Resources[0].Key != null)
                {
                    frecuence = Convert.ToInt32(e.ModifiedAppointment.Resources[0].Key);
                }
                if (e.ModifiedAppointment.Resources[1].Key != null)
                {
                    medical = new Guid(e.ModifiedAppointment.Resources[1].Key.ToString());
                }
            }
            var idAppointment = new Guid(e.Appointment.ID.ToString());
            var appoinment = BussinessFactory.GetAppointmentService().Get(idAppointment);
            appoinment.Subject = e.ModifiedAppointment.Subject;
            appoinment.StartDate = e.ModifiedAppointment.Start;
            appoinment.EndDate = e.ModifiedAppointment.End;
            appoinment.Patient = e.ModifiedAppointment.Attributes["Paciente"];
            if (!string.IsNullOrEmpty(e.ModifiedAppointment.Attributes["NotifyEach"]))
                appoinment.NotifyEach = Convert.ToInt32(e.ModifiedAppointment.Attributes["NotifyEach"]);
            appoinment.Frecuence = frecuence.HasValue ? frecuence.Value : (int?)null;
            appoinment.Medical = medical.HasValue ? BussinessFactory.GetPersonService().Get(medical) : null;
            appoinment.Description = e.ModifiedAppointment.Description;
            appoinment.Office = BussinessFactory.GetOfficeService().Get(new Guid(idOfficce));
            appoinment.CreationDate = CreationDate;
            appoinment.CreatedBy = CreatedBy;
            appoinment.IsActive = true;
            appoinment.ModifiedBy = ModifiedBy;
            appoinment.LastModified = LastModified;
            var response = BussinessFactory.GetAppointmentService().Update(appoinment);
            if (response.OperationResult == OperationResult.Success)
            {
                LoadAppointments(new Guid(idOfficce));
            }
        }
    }

    protected void radCalendar_FormCreated(object sender, SchedulerFormCreatedEventArgs e)
    {
        if (e.Container.Mode == SchedulerFormMode.AdvancedInsert)
        {
            ConfigureNotifityEach(e);
        }
        if (e.Container.Mode == SchedulerFormMode.AdvancedEdit)
        {
            ConfigureNotifityEach(e);
            var idOfficce = ddlOffices.SelectedValue;
            if (!string.IsNullOrEmpty(idOfficce))
            {
                var appointment = BussinessFactory.GetAppointmentService().Get(new Guid(e.Appointment.ID.ToString()));
            }
        }
    }

    private void ConfigureNotifityEach(SchedulerFormCreatedEventArgs e)
    {
        var notificarCadaText = (RadTextBox)e.Container.FindControl("AttrNotifyEach");
        notificarCadaText.Label = "Notificar cada";
        notificarCadaText.ToolTip = @"Ingresar número de veces.";
        notificarCadaText.Width = 150;
    }

    protected void radCalendar_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        if (e.Command == SchedulerNavigationCommand.NavigateToNextPeriod ||
                e.Command == SchedulerNavigationCommand.NavigateToPreviousPeriod ||
                e.Command == SchedulerNavigationCommand.NavigateToSelectedDate)
        {
            var idOffice = ddlOffices.SelectedValue;
            switch (e.Command)
            {
                case SchedulerNavigationCommand.SwitchToDayView:

                    break;
                case SchedulerNavigationCommand.SwitchToMonthView:
                    break;
                case SchedulerNavigationCommand.SwitchToWeekView:

                    break;
                default:
                    LoadAppointments(new Guid(idOffice));
                    break;
            }
        }
    }

    protected void radCalendar_PreRender(object sender, EventArgs e)
    {
        var popupCalendar = radCalendar.FindControl("SelectedDateCalendar") as RadCalendar;
        if (popupCalendar == null) return;
        foreach (var dayWithAppointment in radCalendar.Appointments.Select(a => new RadCalendarDay
        {
            ToolTip = string.Format("Sr(a) {0}, Motivo: {1} ", a.Attributes["Paciente"],a.Subject),
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
           LoadAppointments(new Guid(idOfficce));
        }
    }

    private void LoadAppointments(Guid? idOffice)
    {
        var fecha = new DateTime(radCalendar.SelectedDate.Year, radCalendar.SelectedDate.Month, 1);
        var appointments = BussinessFactory.GetAppointmentService().GetByOffices(idOffice, fecha.AddMonths(-1), fecha.AddMonths(1));
        BindAppointments(appointments);
    }

    private void BindAppointments(IEnumerable<Appointment> appointments)
    {
        radCalendar.DataSource = appointments;
        radCalendar.DataBind();
    }

    protected void radCalendar_AppointmentDataBound(object sender, SchedulerEventArgs e)
    {
        var entity = (Appointment) e.Appointment.DataItem;
        if (entity != null)
        {
            e.Appointment.Attributes["Paciente"] = entity.Patient;
        }
    }
}