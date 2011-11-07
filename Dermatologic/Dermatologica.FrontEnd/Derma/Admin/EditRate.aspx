<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="EditRate.aspx.cs"Inherits="Derma_Admin_EditRatet" %>

<%@ Register Src="../../SmartControls/wucSearchPersons.ascx" TagName="wucSearchPersons"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dwCostCenter" EventName="dwCostCenter_SelectedIndexChanged">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPersonType" EventName="ddlPersonType_SelectedIndexChanged">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="rlpLoading" Transparency="50" Height="100%"
        Width="100%">
        <table style="height: 100%; width: 100%;">
            <tr>
                <td width="100%" style="background-color: #F0FFFF">
                    <img src="../../Images/loading.gif" alt="Loading..." style="border: 0px;" />
                </td>
            </tr>
        </table>
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
        <asp:UpdatePanel ID="upnBlockingpprovalFlow" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlReport">
                    <table width="100%">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2" style="font-weight: bold; background-color: #006699; color: #FFFFFF;
                                text-align: center;">
                                Asignación de Tarifas
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Literal ID="litMensaje" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Centro de Costo"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="dwCostCenter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dwCostCenter_SelectedIndexChanged"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Tratamiento"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlService" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Tratante"></asp:Label>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPersonType" runat="server" Width="150px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlPersonType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <uc1:wucSearchPersons ID="ucSearchPersonsMedical" runat="server" WebServiceMethod="LoadPersons" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Tarifa"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCurrency" runat="server" AppendDataBoundItems="True" Width="50px">
                                    <asp:ListItem>USD</asp:ListItem>
                                    <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                    <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>
                                <telerik:RadNumericTextBox ID="txtUnitCost" runat="server" DataType="System.Decimal"
                                    MaxValue="9999" MinValue="0" Width="75px">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Tarifa Partner"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCurrency1" runat="server" AppendDataBoundItems="True" Width="50px">
                                    <asp:ListItem>USD</asp:ListItem>
                                    <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                    <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>
                                <telerik:RadNumericTextBox ID="txtUnitCostPartner" runat="server" DataType="System.Decimal"
                                    MaxValue="9999" MinValue="0" Width="75px" Value="0">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Observación"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtObservation" runat="server" Width="502px" Rows="5" TextMode="MultiLine"
                                    Height="48px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>
