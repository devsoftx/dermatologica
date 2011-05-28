<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Derma_Default" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="upCalendar">
                    <ContentTemplate>
                        <asp:Panel runat="Server" ID="panContainer">
                            <telerik:RadScheduler ID="radCalendar" runat="server" Skin="Simple" Culture="Spanish (Peru)"
                                SelectedView="MonthView" DayEndTime="18:30:00" DayStartTime="09:00:00" OnAppointmentDelete="radCalendar_AppointmentDelete"
                                OnAppointmentInsert="radCalendar_AppointmentInsert" OnAppointmentUpdate="radCalendar_AppointmentUpdate"
                                OverflowBehavior="Expand" WorkDayEndTime="18:30:00" WorkDayStartTime="09:00:00"
                                EnableCustomAttributeEditing="true" OnPreRender="radCalendar_PreRender" EnableDescriptionField="True"
                                onformcreated="radCalendar_FormCreated" 
                                onnavigationcomplete="radCalendar_NavigationComplete" RowHeight="35px" 
                                onappointmentclick="radCalendar_AppointmentClick">
                                <weekview dayendtime="18:30:00" daystarttime="09:00:00" workdayendtime="18:30:00"
                                    workdaystarttime="09:00:00" />
                                <dayview dayendtime="18:30:00" daystarttime="09:00:00" />
                                <advancedform modal="True" enablecustomattributeediting="True" />
                                <timelineview userselectable="false" />
                                <localization allday="Todo el dia" advancedalldayevent="Todo el día" advancedcalendarcancel="Cancelar"
                                    advancedcalendartoday="Hoy" advancedclose="Cerrar" advanceddaily="Diario" advancedday="Día"
                                    advanceddays="dias" advanceddescription="Descripción" advanceddone="OK" advancededitappointment="Editar Evento"
                                    advancedendafter="Fin despues de" advancedendbythisdate="Fin de" advancedenddaterequired="Fecha final es necesario"
                                    advancedendtimerequired="Hoa final es necesario" advancedevery="Cada" advancedeveryweekday="Cada día de semana"
                                    advancedfirst="primero" advancedfourth="cuarto" advancedfrom="Hora inicial" advancedhourly="Cada hora"
                                    advancedhours="horas" advancedinvalidnumber="número no válido" advancedlast="último"
                                    advancedmaskday="día" advancedmaskweekday="día entre semana" advancedmaskweekendday="día de fin de semana"
                                    advancedmonthly="Mensual" advancedmonths="meses" advancednewappointment="Nuevo Evento"
                                    advancednoenddate="sin fecha de fin" advancedoccurrences="ocurrencias" advancedof="de"
                                    advancedofevery="de cada" advancedrecurevery="repetir cada" advancedrecurrence="repetir"
                                    advancedreset="restablecer excepciones" advancedsecond="segundo" advancedstartdaterequired="Fecha inicial es necesaria"
                                    advancedstarttimebeforeendtime="Fecha Final debe ser mayor que la fecha inicial"
                                    advancedstarttimerequired="Hora inicial es necesaria" advancedsubject="Título"
                                    advancedsubjectrequired="Debe ingresar una descripción su cita" advancedthe="El"
                                    advancedthird="tercero" advancedto="Fecha Final" advancedweekly="Semanal" advancedweeks="semanas en"
                                    advancedworking="trabajando..." advancedyearly="Anual" cancel="Cancelar" confirmcancel="Cancelar"
                                    confirmdeletetext="¿Esta seguro de eliminar esta cita?" confirmdeletetitle="Confirmar eliminación"
                                    confirmrecurrencedeleteoccurrence="Eliminar solo esta cita" confirmrecurrencedeleteseries="Eliminar la serie de citas"
                                    confirmrecurrencedeletetitle="Eliminación de una cita periodica" confirmrecurrenceeditoccurrence="Editar solo esta cita"
                                    confirmrecurrenceeditseries="Editar la seria de citas" confirmrecurrenceedittitle="Edición de una cita periodica"
                                    contextmenuaddappointment="Nueva cita" contextmenuaddrecurringappointment="Nueva cita periodica"
                                    contextmenudelete="Eliminar" contextmenuedit="Editar" contextmenugototoday="Ir a Hoy"
                                    headerday="Día" headermonth="Mes" headermultiday="multi-día" headernextday="día siguiente"
                                    headerprevday="día anterior" headertimeline="Linea de Tiempo" headertoday="hoy"
                                    headerweek="Semana" save="Guardar" show24hours="Mostrar todas las horas" showadvancedform="Detalle"
                                    showbusinesshours="Mostrar horas laborales" showmore="más..." />
                                <appointmenttemplate>
                                    <div>
                                        <b style="font-size: 10px;"><%# Eval("Subject") %></b>
                                        <%--<div style="font-style: italic; font-size: 9px;"><%# Eval("Tipo.Text") %></div>--%>
                                    </div>
                                </appointmenttemplate>
                            </telerik:RadScheduler>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radCalendar" EventName="AppointmentInsert" />
                        <asp:AsyncPostBackTrigger ControlID="radCalendar" EventName="AppointmentUpdate" />
                        <asp:AsyncPostBackTrigger ControlID="radCalendar" EventName="AppointmentDelete" />
                        <asp:AsyncPostBackTrigger ControlID="radCalendar" EventName="PreRender" />
                        <asp:AsyncPostBackTrigger ControlID="radCalendar" EventName="FormCreated" />
                        <asp:AsyncPostBackTrigger ControlID="radCalendar" EventName="Navigationcomplete" />
                        <asp:AsyncPostBackTrigger ControlID="radCalendar" EventName="Appointmentclick" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>        
    </table>
</asp:Content>