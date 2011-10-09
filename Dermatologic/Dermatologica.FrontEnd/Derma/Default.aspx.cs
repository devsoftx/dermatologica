using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
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
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ES-pe");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ES-pe");
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            var id = Request.Params.Get("id");
            if (id == null)
            {
                radCalendar.SelectedDate = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", currentCulture);
                var userName = Session["userName"];
                if (userName != null)
                {
                    LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.MonthView);
                }   
            }
            else
            {
                var appointment = BussinessFactory.GetAppointmentService().Get(new Guid(id)).Entity;
                DateTime? date = appointment.StartDate;
                if (date != null)
                    radCalendar.SelectedDate = DateTime.ParseExact(date.Value.ToShortDateString(), "dd/MM/yyyy", currentCulture);
                radCalendar.SelectedView = SchedulerViewType.DayView;
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.DayView);
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
        var rtMedical = new ResourceType
        {
            Name = "Medico/Cosmeatra",
            DataSource = response,
            KeyField = "Id",
            TextField = "CompleteName",
            ForeignKeyField = "Medical",
            
        };
        radCalendar.ResourceTypes.Add(rtMedical);

        var responseOffice = BussinessFactory.GetOfficeService().GetAll(p => p.IsActive);
        if (responseOffice.OperationResult == OperationResult.Success)
        {
            var offices = responseOffice.Results.OrderBy(u => u.Name).ToList();
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
        const string url = "Default.aspx";
        var id = Request.Params.Get("id");
        Response.Redirect(string.IsNullOrEmpty(id)
                              ? string.Format("Appointment.aspx?id={0}&action=edit&returnUrl={1}", e.Appointment.ID,
                                              Request.RawUrl)
                              : string.Format("Appointment.aspx?id={0}&action=edit&returnUrl={1}", e.Appointment.ID, url));
    }

    protected void radCalendar_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
    {
        var idAppointment = new Guid(e.Appointment.ID.ToString());
        var appoinment = BussinessFactory.GetAppointmentService().Get(idAppointment).Entity;
        appoinment.IsActive = false;
        appoinment.LastModified = LastModified;
        appoinment.ModifiedBy = ModifiedBy;
        appoinment.CreatedBy = CreatedBy;
        appoinment.CreationDate = CreationDate;
        var response = BussinessFactory.GetAppointmentService().Update(appoinment);
        if (response.OperationResult == OperationResult.Success)
        {
            LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.MonthView);
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
                                    Office = idOfficce.HasValue ? BussinessFactory.GetOfficeService().Get(idOfficce).Entity : null,
                                    CreationDate = CreationDate,
                                    CreatedBy = CreatedBy,
                                    IsActive = true,
                                    ModifiedBy = ModifiedBy,
                                    LastModified = LastModified,
                                    Medical = medical.HasValue ? BussinessFactory.GetPersonService().Get(medical).Entity : null
                                };
        var response = BussinessFactory.GetAppointmentService().Save(appointment);
        if(response.OperationResult == OperationResult.Success)
        {
            if (radCalendar.SelectedView == SchedulerViewType.MonthView)
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.MonthView);
            if (radCalendar.SelectedView == SchedulerViewType.DayView)
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.DayView);
            if (radCalendar.SelectedView == SchedulerViewType.WeekView)
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.WeekView);
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
        var appoinment = BussinessFactory.GetAppointmentService().Get(idAppointment).Entity;
        appoinment.Subject = e.ModifiedAppointment.Subject;
        appoinment.StartDate = e.ModifiedAppointment.Start;
        appoinment.EndDate = e.ModifiedAppointment.End;
        appoinment.Patient = e.ModifiedAppointment.Attributes["Paciente"];
        if (!string.IsNullOrEmpty(e.ModifiedAppointment.Attributes["NotifyEach"]))
            appoinment.NotifyEach = Convert.ToInt32(e.ModifiedAppointment.Attributes["NotifyEach"]);
        if (appoinment.Frecuence == null)
            appoinment.Frecuence = frecuence.HasValue ? frecuence.Value : (int?) null;
        if (appoinment.Medical == null)
            appoinment.Medical = medical.HasValue ? BussinessFactory.GetPersonService().Get(medical).Entity : null;
        if (appoinment.Office == null)
            appoinment.Office = idOfficce.HasValue ? BussinessFactory.GetOfficeService().Get(idOfficce).Entity : null;
        appoinment.Description = e.ModifiedAppointment.Description;
        appoinment.IsActive = true;
        appoinment.CreationDate = CreationDate;
        appoinment.CreatedBy = CreatedBy;
        appoinment.ModifiedBy = ModifiedBy;
        appoinment.LastModified = LastModified;
        var response = BussinessFactory.GetAppointmentService().Update(appoinment);
        if (response.OperationResult == OperationResult.Success)
        {
            if (radCalendar.SelectedView == SchedulerViewType.MonthView)
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.MonthView);
            if (radCalendar.SelectedView == SchedulerViewType.DayView)
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.DayView);
            if (radCalendar.SelectedView == SchedulerViewType.WeekView)
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.WeekView);
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

    protected void radCalendar_PreRender(object sender, EventArgs e)
    {
        var popupCalendar = radCalendar.FindControl("SelectedDateCalendar") as RadCalendar;
        if (popupCalendar == null) return;
        var appointments = radCalendar.Appointments;
        Color color;
        switch (appointments.Count)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                color = Color.Aquamarine;
                break;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
                color = Color.Blue;
                break;
            default:
                color = Color.Red;
                break;
        }
        foreach (var dayWithAppointment in appointments.Select(a => new RadCalendarDay
        {
            ToolTip = string.Format("N° de Citas: {0}", appointments.Count),
            Date = a.Start
        }))
        {
            dayWithAppointment.ItemStyle.BackColor = color;
            popupCalendar.SpecialDays.Add(dayWithAppointment);
        }
    }

    private void LoadAppointments(DateTime? dateTime, SchedulerViewType view)
    {
        DateTime? start = null;
        DateTime? end = null;
        DateTime[] days = new DateTime[2];
        if (dateTime.HasValue)
        {
            switch (view)
            {
                case SchedulerViewType.DayView:
                    start = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, 8, 0, 0);
                    end = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, 21, 0, 0);
                    break;
                case SchedulerViewType.MonthView:
                    start = new DateTime(dateTime.Value.Year, dateTime.Value.Month, 1, 8, 0, 0);
                    end = AppointmentService.GetNroDaysFromMonth(dateTime) > 30
                                       ? new DateTime(dateTime.Value.Year, dateTime.Value.Month, 31, 21, 0, 0)
                                       : new DateTime(dateTime.Value.Year, dateTime.Value.Month, 30, 21, 0, 0);
                    break;
                case SchedulerViewType.WeekView:
                    days = BussinessFactory.GetAppointmentService().GetDatesNearby(dateTime.Value);
                    start = new DateTime(days[0].Year, days[0].Month, days[0].Day, 8, 0, 0);
                    end = new DateTime(days[1].Year, days[1].Month, days[1].Day, 21, 0, 0);
                    break;
            }
            radCalendar.SelectedView = view;
            var response = BussinessFactory.GetAppointmentService().GetAppointments(start, end);
            if (response.OperationResult == OperationResult.Success)
            {
                var appointments = response.Results;
                BindAppointments(appointments);
            }
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
        LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.MonthView);
    }

    protected void radCalendar_NavigationCommand(object sender, SchedulerNavigationCommandEventArgs e)
    {
        switch (e.Command)
        {
            case SchedulerNavigationCommand.SwitchToMonthView:
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.MonthView);
                break;
            case SchedulerNavigationCommand.SwitchToWeekView:
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.WeekView);
                break;
            case SchedulerNavigationCommand.SwitchToDayView:
                LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.DayView);
                break;
            case SchedulerNavigationCommand.SwitchToSelectedDay:
                LoadAppointments(e.SelectedDate, SchedulerViewType.DayView);
                break;
            case SchedulerNavigationCommand.NavigateToPreviousPeriod:
                if(radCalendar.SelectedView == SchedulerViewType.MonthView)
                    LoadAppointments(radCalendar.SelectedDate.AddMonths(-1), SchedulerViewType.MonthView);
                if (radCalendar.SelectedView == SchedulerViewType.DayView)
                    LoadAppointments(radCalendar.SelectedDate.AddDays(-1), SchedulerViewType.DayView);
                if (radCalendar.SelectedView == SchedulerViewType.WeekView)
                    LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.WeekView);
                break;
            case SchedulerNavigationCommand.NavigateToNextPeriod:
                if(radCalendar.SelectedView == SchedulerViewType.MonthView)
                    LoadAppointments(radCalendar.SelectedDate.AddMonths(1), SchedulerViewType.MonthView);
                if (radCalendar.SelectedView == SchedulerViewType.DayView)
                    LoadAppointments(radCalendar.SelectedDate.AddDays(1), SchedulerViewType.DayView);
                if (radCalendar.SelectedView == SchedulerViewType.WeekView)
                    LoadAppointments(radCalendar.SelectedDate, SchedulerViewType.WeekView);
                break;
            case SchedulerNavigationCommand.NavigateToSelectedDate:
                LoadAppointments(e.SelectedDate, SchedulerViewType.DayView);
                break;
            default:
                LoadAppointments(e.SelectedDate, SchedulerViewType.MonthView);
                break;
        }
    }

}