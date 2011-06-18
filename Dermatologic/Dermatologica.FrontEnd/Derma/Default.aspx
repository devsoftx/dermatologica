﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Derma_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlOffices">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
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
                            <td><asp:Literal ID="litMessage" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Bienvenido <asp:Literal ID="litUser" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>                                
                                <asp:DropDownList ID="ddlOffices" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOffices_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height:30px;"></td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadScheduler ID="radCalendar" runat="server" Skin="Simple" Culture="es-PE"
                                    SelectedView="MonthView" DayEndTime="18:30:00" DayStartTime="09:00:00" OnAppointmentDelete="radCalendar_AppointmentDelete"
                                    OnAppointmentInsert="radCalendar_AppointmentInsert" OnAppointmentUpdate="radCalendar_AppointmentUpdate"
                                    OverflowBehavior="Expand" WorkDayEndTime="18:30:00" WorkDayStartTime="09:00:00"
                                    EnableCustomAttributeEditing="True" OnPreRender="radCalendar_PreRender" EnableDescriptionField="True"
                                    OnFormCreated="radCalendar_FormCreated" OnNavigationComplete="radCalendar_NavigationComplete"
                                    RowHeight="35px" OnAppointmentClick="radCalendar_AppointmentClick" Width="100%">
                                    <WeekView DayEndTime="18:30:00" DayStartTime="09:00:00" WorkDayEndTime="18:30:00"
                                        WorkDayStartTime="09:00:00" />
                                    <DayView DayEndTime="18:30:00" DayStartTime="09:00:00" />
                                    <AdvancedForm Modal="True" EnableCustomAttributeEditing="True" />
                                    <TimelineView UserSelectable="false" />
                                    <Localization AllDay="Todo el dia" AdvancedAllDayEvent="Todo el día" AdvancedCalendarCancel="Cancelar"
                                        AdvancedCalendarToday="Hoy" AdvancedClose="Cerrar" AdvancedDaily="Diario" AdvancedDay="Día"
                                        AdvancedDays="dias" AdvancedDescription="Descripción" AdvancedDone="OK" AdvancedEditAppointment="Editar Evento"
                                        AdvancedEndAfter="Fin despues de" AdvancedEndByThisDate="Fin de" AdvancedEndDateRequired="Fecha final es necesario"
                                        AdvancedEndTimeRequired="Hoa final es necesario" AdvancedEvery="Cada" AdvancedEveryWeekday="Cada día de semana"
                                        AdvancedFirst="primero" AdvancedFourth="cuarto" AdvancedFrom="Hora inicial" AdvancedHourly="Cada hora"
                                        AdvancedHours="horas" AdvancedInvalidNumber="número no válido" AdvancedLast="último"
                                        AdvancedMaskDay="día" AdvancedMaskWeekday="día entre semana" AdvancedMaskWeekendDay="día de fin de semana"
                                        AdvancedMonthly="Mensual" AdvancedMonths="meses" AdvancedNewAppointment="Nuevo Evento"
                                        AdvancedNoEndDate="sin fecha de fin" AdvancedOccurrences="ocurrencias" AdvancedOf="de"
                                        AdvancedOfEvery="de cada" AdvancedRecurEvery="repetir cada" AdvancedRecurrence="repetir"
                                        AdvancedReset="restablecer excepciones" AdvancedSecond="segundo" AdvancedStartDateRequired="Fecha inicial es necesaria"
                                        AdvancedStartTimeBeforeEndTime="Fecha Final debe ser mayor que la fecha inicial"
                                        AdvancedStartTimeRequired="Hora inicial es necesaria" AdvancedSubject="Título"
                                        AdvancedSubjectRequired="Debe ingresar una descripción su cita" AdvancedThe="El"
                                        AdvancedThird="tercero" AdvancedTo="Fecha Final" AdvancedWeekly="Semanal" AdvancedWeeks="semanas en"
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
                                        ShowBusinessHours="Mostrar horas laborales" ShowMore="más..." />
                                    <AppointmentTemplate>
                                        <div>
                                            <b style="font-size: 10px;">
                                                <%# Eval("Subject") %></b>
                                            <div style="font-style: italic; font-size: 9px;">
                                                <%# Eval("Medical.Text") %></div>
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