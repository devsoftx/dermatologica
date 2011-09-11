using System;
using System.Collections;
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
        if (!IsPostBack)
        {
            ConfigureRadCalendar();
            var date = DateTime.Now.ToShortDateString();
            if (!string.IsNullOrEmpty(date))
                radCalendar.SelectedDate = DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("ES-pe"));
            var userName = Session["userName"];
            if (userName != null)
            {
                LoadAppointments(radCalendar.SelectedDate);
            }   
        }
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
            Name = "Frecuencia",
            DataSource = frecuencias,
            KeyField = "Key",
            TextField = "Value",
            ForeignKeyField = "Frecuence"
        };
        radCalendar.ResourceTypes.Add(rtFrecuencias);

        IEnumerable<Person> medicals = GetMedicals();
        IEnumerable<Person> cosmeatras = GetCosmeatras();
        var response = medicals.Union(cosmeatras).OrderBy(p => p.CompleteName).ToList();
        var rtMedical = new ResourceType()
        {
            Name = "Medico/Cosmeatra",
            DataSource = response,
            KeyField = "Id",
            TextField = "CompleteName",
            ForeignKeyField = "Medical",
            
        };
        radCalendar.ResourceTypes.Add(rtMedical);

        var offices = BussinessFactory.GetOfficeService().GetAll(p => p.IsActive).OrderBy(u => u.Name).ToList();

        var rtOffice = new ResourceType
        {
            Name = "Consultorio",
            DataSource = offices,
            KeyField = "Id",
            TextField = "Name",
            ForeignKeyField = "Office",
        };
        radCalendar.ResourceTypes.Add(rtOffice);
    }

    private IEnumerable<Person> GetMedicals()
    {
        var example = new Person
                          {
                              PersonType = {Id = new Guid("DA913E86-1EB8-41E1-8DA0-81ABD6195254")}
                          };
        return BussinessFactory.GetPersonService().GetPacients(example).Pacients.OrderBy(p => p.CompleteName).ToList();
    }

    private IEnumerable<Person> GetCosmeatras()
    {
        var example = new Person
        {
            PersonType = { Id = new Guid("FB546D8B-898C-4E19-8937-ADA8FC10F744") }
        };
        return BussinessFactory.GetPersonService().GetPacients(example).Pacients.OrderBy(p => p.CompleteName).ToList();
    }

    protected void radCalendar_AppointmentClick(object sender, SchedulerEventArgs e)
    {
        if(e.Appointment.ID != null)
            Response.Redirect(string.Format("Appointment.aspx?id={0}&action=edit&returnUrl={1}", e.Appointment.ID,Request.RawUrl));
    }

    protected void radCalendar_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
    {
        var idAppointment = new Guid(e.Appointment.ID.ToString());
        var appoinment = BussinessFactory.GetAppointmentService().Get(idAppointment);
        appoinment.IsActive = false;
        appoinment.LastModified = LastModified;
        appoinment.ModifiedBy = ModifiedBy;
        appoinment.CreatedBy = CreatedBy;
        appoinment.CreationDate = CreationDate;
        var response = BussinessFactory.GetAppointmentService().Update(appoinment);
        if (response.OperationResult == OperationResult.Success)
        {
            LoadAppointments(radCalendar.SelectedDate);
        }
    }

    protected void radCalendar_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
    {
        int? frecuence = null;
        Guid? medical = null;
        Guid? idOfficce = null;
        if (e.Appointment.Resources.Count > 0)
        {
            var resFrecuence = e.Appointment.Resources.GetResourceByType("Frecuencia");
            if (resFrecuence != null)
            {
                frecuence = Convert.ToInt32(resFrecuence.Key);
            }
            var resMedical = e.Appointment.Resources.GetResourceByType("Medico/Cosmeatra");
            if (resMedical != null)
            {
                medical = new Guid(resMedical.Key.ToString());
            }
            var resConsultorio = e.Appointment.Resources.GetResourceByType("Consultorio");
            if (resConsultorio != null)
            {
                idOfficce = new Guid(resConsultorio.Key.ToString());
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
                                    Office = idOfficce.HasValue ? BussinessFactory.GetOfficeService().Get(idOfficce) : null,
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
            LoadAppointments(radCalendar.SelectedDate);
        }
        else
        {
            litMessage.Text = string.Format("No se pudo guardar la cita, Error: {0}", response.Message);
        }
    }

    protected void radCalendar_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {
        int? frecuence = null;
        Guid? medical = null;
        Guid? idOfficce = null;
        if (e.ModifiedAppointment.Resources.Count > 0)
        {
            var resFrecuence = e.ModifiedAppointment.Resources.GetResourceByType("Frecuencia");
            if (resFrecuence != null)
            {
                frecuence = Convert.ToInt32(resFrecuence.Key);
            }
            var resMedical = e.ModifiedAppointment.Resources.GetResourceByType("Medico/Cosmeatra");
            if (resMedical != null)
            {
                medical = new Guid(resMedical.ToString());
            }
            var resConsultorio = e.ModifiedAppointment.Resources.GetResourceByType("Consultorio");
            if (resConsultorio != null)
            {
                idOfficce = new Guid(resConsultorio.Key.ToString());
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
        if (appoinment.Frecuence == null)
            appoinment.Frecuence = frecuence.HasValue ? frecuence.Value : (int?) null;
        if (appoinment.Medical == null)
            appoinment.Medical = medical.HasValue ? BussinessFactory.GetPersonService().Get(medical) : null;
        if (appoinment.Office == null)
            appoinment.Office = idOfficce.HasValue ? BussinessFactory.GetOfficeService().Get(idOfficce) : null;
        appoinment.Description = e.ModifiedAppointment.Description;
        appoinment.IsActive = true;
        appoinment.CreationDate = CreationDate;
        appoinment.CreatedBy = CreatedBy;
        appoinment.ModifiedBy = ModifiedBy;
        appoinment.LastModified = LastModified;
        var response = BussinessFactory.GetAppointmentService().Update(appoinment);
        if (response.OperationResult == OperationResult.Success)
        {
            LoadAppointments(radCalendar.SelectedDate);
        }
        else
        {
            litMessage.Text = string.Format("No se pudo guardar la cita, Error: {0}", response.Message);
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
        }
    }

    private void ConfigureNotifityEach(SchedulerFormCreatedEventArgs e)
    {
        var notificarCadaText = (RadTextBox)e.Container.FindControl("AttrNotifyEach");
        notificarCadaText.Label = "Notificar cada";
        notificarCadaText.ToolTip = @"Ingresar número de veces.";
        notificarCadaText.Width = 150;

        var checkBox = (CheckBox)e.Container.FindControl("AllDayEvent");
        checkBox.Checked = false;
    }

    protected void radCalendar_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        if (e.Command == SchedulerNavigationCommand.NavigateToNextPeriod ||
                e.Command == SchedulerNavigationCommand.NavigateToPreviousPeriod ||
                e.Command == SchedulerNavigationCommand.NavigateToSelectedDate)
        {
            switch (e.Command)
            {
                case SchedulerNavigationCommand.SwitchToDayView:
                    LoadAppointments(radCalendar.SelectedDate);
                    break;
                case SchedulerNavigationCommand.SwitchToMonthView:
                    LoadAppointments(radCalendar.SelectedDate);
                    break;
                case SchedulerNavigationCommand.SwitchToWeekView:
                    LoadAppointments(radCalendar.SelectedDate);
                    break;
                case SchedulerNavigationCommand.SwitchToSelectedDay:
                    LoadAppointments(radCalendar.SelectedDate);
                    break;
                default:
                    LoadAppointments(radCalendar.SelectedDate);
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

    private void LoadAppointments(DateTime? dateTime)
    {
        if (dateTime.HasValue)
        {
            var fecha = new DateTime(radCalendar.SelectedDate.Year, radCalendar.SelectedDate.Month, 1);
            var appointments = BussinessFactory.GetAppointmentService().GetByOffices(fecha.AddMonths(-1), fecha.AddMonths(1));
            BindAppointments(appointments);
        }
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
            if (entity.Office != null)
            {
                var color = entity.Office.ColorId;
                if (!string.IsNullOrEmpty(color))
                    e.Appointment.BackColor = Color.FromName(color);
            }
            if (entity.Medical != null)
            {
                e.Appointment.ToolTip = string.Format("Medico/Cosmeatra: {0}", entity.Medical.CompleteName);
            }
        }
    }
    protected void radCalendar_AppointmentCancelingEdit(object sender, AppointmentCancelingEditEventArgs e)
    {
        if (e.Appointment.Subject == String.Empty)
        {
            e.Cancel = true;
        }
        LoadAppointments(radCalendar.SelectedDate);
    }
    protected void radCalendar_NavigationCommand(object sender, SchedulerNavigationCommandEventArgs e)
    {
        switch (e.Command)
        {
            case SchedulerNavigationCommand.SwitchToDayView:
                LoadAppointments(radCalendar.SelectedDate);
                break;
            case SchedulerNavigationCommand.SwitchToMonthView:
                LoadAppointments(radCalendar.SelectedDate);
                break;
            case SchedulerNavigationCommand.SwitchToWeekView:
                LoadAppointments(radCalendar.SelectedDate);
                break;
            case SchedulerNavigationCommand.SwitchToSelectedDay:
                LoadAppointments(radCalendar.SelectedDate);
                break;
            default:
                LoadAppointments(radCalendar.SelectedDate);
                break;
        }
    }
}