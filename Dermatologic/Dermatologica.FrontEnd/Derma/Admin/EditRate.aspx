<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="EditRate.aspx.cs" Inherits="Derma_Admin_EditRatet" %>
<%@ Register src="../../SmartControls/wucSearchPersons.ascx" tagname="wucSearchPersons" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 127px;
            text-align: right;
        }
        .style3
        {
            width: 60px;
        }
        .style4
        {
            width: 30px;
        }
        .style5
        {
            width: 154px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Main">
        <table class="style1">
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td colspan="2" style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    Asignación de Tarifas</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
        <asp:Literal ID="litMensaje" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label5" runat="server" Text="Tratante"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlService" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Tratante"></asp:Label>
                </td>
                <td>
                    <table class="style1">
                        <tr>
                            <td class="style4" style="text-align: left">
                                <asp:Label ID="Label3" runat="server" style="text-align: left" Text="Tipo"></asp:Label>
                            </td>
                            <td class="style5">
                    <asp:DropDownList ID="ddlPersonType" runat="server" Width="150px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlPersonType_SelectedIndexChanged">
                    </asp:DropDownList>
                            </td>
                            <td>
                            <asp:UpdatePanel ID="upPanel" runat="server">
                            <ContentTemplate>
                                <uc1:wucSearchPersons ID="ucSearchPersonsMedical" runat="server" WebServiceMethod="LoadPersons" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlPersonType" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                            </asp:UpdatePanel>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Tarifa"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCurrency" runat="server" AppendDataBoundItems="True" 
                                        Width="50px">
                                        <asp:ListItem>USD</asp:ListItem>
                                        <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                        <asp:ListItem>EUR</asp:ListItem>
                                    </asp:DropDownList>
                    <telerik:RadNumericTextBox ID="txtUnitCost" Runat="server"
                        DataType="System.Decimal" MaxValue="9999" MinValue="0" Width="75px">
                    </telerik:RadNumericTextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label6" runat="server" Text="Tarifa Por Titularidad"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCurrency1" runat="server" AppendDataBoundItems="True" 
                                        Width="50px">
                                        <asp:ListItem>USD</asp:ListItem>
                                        <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                        <asp:ListItem>EUR</asp:ListItem>
                                    </asp:DropDownList>
                    <telerik:RadNumericTextBox ID="txtUnitCostPartner" Runat="server"
                        DataType="System.Decimal" MaxValue="9999" MinValue="0" Width="75px" 
                        Value="0">
                    </telerik:RadNumericTextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" Text="Observación"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtObservation" runat="server" Width="502px" Rows="5" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                                    onclick="btnAceptar_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                    onclick="btnCancelar_Click" />
                            </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>

