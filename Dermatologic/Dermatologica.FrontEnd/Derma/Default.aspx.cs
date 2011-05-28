using System;
using System.Globalization;
using ASP.App_Code;
using Telerik.Web.UI;

public partial class Derma_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        ConfigureRadCalendar();
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

        //var frecuencias = UtilListas.listaItemTablas(9);
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

        //var tipos = UtilListas.listaItemTablas(5);
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
    protected void radCalendar_AppointmentClick(object sender, Telerik.Web.UI.SchedulerEventArgs e)
    {

    }
    protected void radCalendar_AppointmentDelete(object sender, Telerik.Web.UI.SchedulerCancelEventArgs e)
    {

    }
    protected void radCalendar_AppointmentInsert(object sender, Telerik.Web.UI.SchedulerCancelEventArgs e)
    {

    }
    protected void radCalendar_AppointmentUpdate(object sender, Telerik.Web.UI.AppointmentUpdateEventArgs e)
    {

    }
    protected void radCalendar_FormCreated(object sender, Telerik.Web.UI.SchedulerFormCreatedEventArgs e)
    {

    }
    protected void radCalendar_NavigationComplete(object sender, Telerik.Web.UI.SchedulerNavigationCompleteEventArgs e)
    {

    }
    protected void radCalendar_PreRender(object sender, EventArgs e)
    {

    }
}