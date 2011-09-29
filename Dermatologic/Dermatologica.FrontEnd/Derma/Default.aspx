<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="Default.aspx.cs"Inherits="Derma_Default" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radCalendar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="rlpLoading" Transparency="50" Height="100%"
        Width="100%">
        <table style="height: 100%; width: 100%;" border="0">
            <tr>
                <td width="100%" align="center" valign="middle" style="background-color: #F0FFFF">
                    <img src="../Images/loading.gif" alt="Loading..." style="border: 0px;" />
                </td>
            </tr>
        </table>
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
        <asp:UpdatePanel ID="upnBlockingpprovalFlow" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlReport">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <asp:Literal ID="litMessage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadScheduler ID="radCalendar" runat="server" Skin="Simple" Culture="es-PE"
                                    SelectedView="MonthView" DayEndTime="21:00:00" DayStartTime="08:00:00" OnAppointmentDelete="radCalendar_AppointmentDelete"
                                    OnAppointmentInsert="radCalendar_AppointmentInsert" OnAppointmentUpdate="radCalendar_AppointmentUpdate"
                                    OverflowBehavior="Expand" WorkDayEndTime="21:00:00" WorkDayStartTime="08:00:00"
                                    EnableCustomAttributeEditing="True" OnPreRender="radCalendar_PreRender" EnableDescriptionField="True"
                                    OnFormCreated="radCalendar_FormCreated" OnNavigationComplete="radCalendar_NavigationComplete"
                                    RowHeight="35px" OnAppointmentClick="radCalendar_AppointmentClick" Width="100%"
                                    OnAppointmentDataBound="radCalendar_AppointmentDataBound" 
                                    onappointmentcancelingedit="radCalendar_AppointmentCancelingEdit" 
                                    onnavigationcommand="radCalendar_NavigationCommand">
                                    <WeekView DayEndTime="21:00:00" DayStartTime="08:00:00" WorkDayEndTime="21:00:00"
                                        WorkDayStartTime="08:00:00" />
                                    <DayView DayEndTime="21:00:00" DayStartTime="08:00:00" />
                                    <AdvancedForm Modal="True" EnableCustomAttributeEditing="True" />
                                    <TimelineView UserSelectable="false" />
                                    <Localization AllDay="Todo el dia" AdvancedAllDayEvent="Todo el día" AdvancedCalendarCancel="Cancelar"
                                        AdvancedCalendarToday="Hoy" AdvancedClose="Cerrar" AdvancedDaily="Diario" AdvancedDay="Día"
                                        AdvancedDays="dias" AdvancedDescription="Descripción" AdvancedDone="OK" AdvancedEditAppointment="Editar Evento"
                                        AdvancedEndAfter="Fin despues de" AdvancedEndByThisDate="Fin de" AdvancedEndDateRequired="Fecha final es necesario"
                                        AdvancedEndTimeRequired="Hora final es necesario" AdvancedEvery="Cada" AdvancedEveryWeekday="Cada día de semana"
                                        AdvancedFirst="primero" AdvancedFourth="cuarto" AdvancedFrom="Fecha y hora iniciales" AdvancedHourly="Cada hora"
                                        AdvancedHours="horas" AdvancedInvalidNumber="número no válido" AdvancedLast="último"
                                        AdvancedMaskDay="día" AdvancedMaskWeekday="día entre semana" AdvancedMaskWeekendDay="día de fin de semana"
                                        AdvancedMonthly="Mensual" AdvancedMonths="meses" AdvancedNewAppointment="Nuevo Evento"
                                        AdvancedNoEndDate="sin fecha de fin" AdvancedOccurrences="ocurrencias" AdvancedOf="de"
                                        AdvancedOfEvery="de cada" AdvancedRecurEvery="repetir cada" AdvancedRecurrence="repetir"
                                        AdvancedReset="restablecer excepciones" AdvancedSecond="segundo" AdvancedStartDateRequired="Fecha inicial es necesaria"
                                        AdvancedStartTimeBeforeEndTime="Fecha Final debe ser mayor que la fecha inicial"
                                        AdvancedStartTimeRequired="Hora inicial es necesaria" AdvancedSubject="Tratamiento"
                                        AdvancedSubjectRequired="Debe ingresar una descripción su cita" AdvancedThe="El"
                                        AdvancedThird="tercero" AdvancedTo="Fecha y hora finales" AdvancedWeekly="Semanal" AdvancedWeeks="semanas en"
                                        AdvancedWorking="trabajando..." AdvancedYearly="Anual" Cancel="Cancelar" ConfirmCancel="Cancelar"
                                        ConfirmDeleteText="¿Esta seguro de eliminar esta cita?" ConfirmDeleteTitle="Confirmar eliminación"
                                        ConfirmRecurrenceDeleteOccurrence="Eliminar solo esta cita" ConfirmRecurrenceDeleteSeries="Eliminar la serie de citas"
                                        ConfirmRecurrenceDeleteTitle="Eliminación de una cita periodica" ConfirmRecurrenceEditOccurrence="Editar solo esta cita"
                                        ConfirmRecurrenceEditSeries="Editar la seria de citas" ConfirmRecurrenceEditTitle="Edición de una cita periodica"
                                        ContextMenuAddAppointment="Nueva cita" ContextMenuAddRecurringAppointment="Nueva cita periodica"
                                        ContextMenuDelete="Eliminar" ContextMenuEdit="Editar" ContextMenuGoToToday="Ir a Hoy"
                                        HeaderDay="Día" HeaderMonth="Mes" HeaderMultiDay="multi-día" HeaderNextDay="día siguiente"
                                        HeaderPrevDay="día anterior" HeaderTimeline="Linea de Tiempo" HeaderToday="hoy"
                                        HeaderWeek="Semana" Save="Guardar" Show24Hours="Mostrar todas las horas" ShowAdvancedForm="Detalle"
                                        ShowBusinessHours="Mostrar horas laborales" ShowMore="+" />
                                    <AppointmentTemplate>
                                        <div>
                                            <b style="font-size: 10px;">
                                                <%# Eval("Paciente")%></b>
                                            <div style="font-style: italic; font-size: 9px;">
                                                <%# Eval("Description")%></div>
                                                <div style="font-size: 9px;">
                                                <%# Eval("Subject")%></div>
                                        </div>
                                    </AppointmentTemplate>
                                </telerik:RadScheduler>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </telerik:RadAjaxPanel>
</asp:Content>
