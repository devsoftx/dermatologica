<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="PaymentCostCenter.aspx.cs" Inherits="Derma_Admin_PaymentCostCenter" %>

<%@ Register src="../../SmartControls/wucSearchPersons.ascx" tagname="wucsearchpersons" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

        .style3
        {
            width: 100%;
        }
        .style7
        {
            text-align: right;
        }
        .style8
        {
            width: 79px;
        }
        .style12
        {
            width: 100%;
        }
        .style10
        {
            width: 66px;
        }
        .style13
        {
            width: 65px;
        }
        .style14
        {
            width: 53px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Main">
                        <table width='800px' __designer:mapid="132">
                            <tr __designer:mapid="133">
                                <td __designer:mapid="134">
                                    &nbsp;
                                </td>
                                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;"
                                    colspan="2" __designer:mapid="135">
                                    Pagos a Centros de Costo</td>
                                <td __designer:mapid="136">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr __designer:mapid="137">
                                <td __designer:mapid="138">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="139" class="style7">
                                    <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                                </td>
                                <td __designer:mapid="13b">
                                    <table __designer:mapid="13c">
                                        <tr __designer:mapid="13d">
                                            <td __designer:mapid="13e">
                                                <asp:TextBox ID="txtDatePayment" runat="server" Enabled="False" Width="70px"></asp:TextBox>
                                            </td>
                                            <td __designer:mapid="140">
                                                <asp:Label ID="Label3" runat="server" Text="Tipo de Cambio"></asp:Label>
                                            </td>
                                            <td __designer:mapid="142">
                                                <asp:Label ID="Label11" runat="server" Text="Compra"></asp:Label>
                                            </td>
                                            <td __designer:mapid="144">
                                                <asp:TextBox ID="txtCompra" runat="server" Width="69px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td __designer:mapid="146">
                                                <asp:Label ID="Label12" runat="server" Text="Venta"></asp:Label>
                                            </td>
                                            <td __designer:mapid="148">
                                                <asp:TextBox ID="txtVenta" runat="server" Width="69px" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td __designer:mapid="14a">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr __designer:mapid="14b">
                                <td __designer:mapid="14c">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="14d" class="style7">
                                    <asp:Label ID="Label16" runat="server" Text="Deudor"></asp:Label>
                                </td>
                                <td __designer:mapid="14f">
                                    <table class="style3">
                                        <tr>
                                            <td class="style8">
                                    <asp:DropDownList ID="ddlDebtorCostCenter" runat="server">
                                    </asp:DropDownList>
                                            </td>
                                            <td class="style14">
                                    <asp:Label ID="Label18" runat="server" Text="Acreedor"></asp:Label>
                                            </td>
                                            <td>
                                    <asp:DropDownList ID="ddlCreditorCostCenter" runat="server">
                                    </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td __designer:mapid="151">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr __designer:mapid="1a9">
                                <td __designer:mapid="1aa">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="1ab" class="style7">
                                    <asp:Label ID="Label8" runat="server" Text="Concepto"></asp:Label>
                                </td>
                                <td __designer:mapid="1ad">
                                    <asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
                                </td>
                                <td __designer:mapid="1af">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr __designer:mapid="1b0">
                                <td __designer:mapid="1b1">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="1b2" class="style7">
                                    <asp:Label ID="Label5" runat="server" Text="Documento"></asp:Label>
                                </td>
                                <td __designer:mapid="1b4">
                                    <asp:DropDownList ID="ddlInvoice" runat="server">
                                        <asp:ListItem>Recibo</asp:ListItem>
                                        <asp:ListItem>Boleta</asp:ListItem>
                                        <asp:ListItem>Factura</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label7" runat="server" Text="N°"></asp:Label>
                                    <asp:TextBox ID="txtNInvoice" runat="server" Width="110px"></asp:TextBox>
                                </td>
                                <td __designer:mapid="1bb">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr __designer:mapid="1bc">
                                <td __designer:mapid="1bd">
                                    &nbsp;</td>
                                <td __designer:mapid="1be" class="style7">
                                    <asp:Label ID="Label19" runat="server" Text="Moneda"></asp:Label>
                                </td>
                                <td __designer:mapid="1c0">
                                    <table class="style12">
                                        <tr>
                                            <td class="style10">
                                    <asp:DropDownList ID="ddlCurrency" runat="server" AppendDataBoundItems="True" 
                                        Width="50px">
                                        <asp:ListItem>USD</asp:ListItem>
                                        <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                        <asp:ListItem>EUR</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                                            <td class="style13">
                    <asp:Label ID="Label2" runat="server" Text="Monto"></asp:Label>
                                            </td>
                                            <td>
                    <asp:TextBox ID="txtAmount" runat="server" Width="92px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td __designer:mapid="1c7">
                                    &nbsp;</td>
                            </tr>
                            <tr __designer:mapid="1bc">
                                <td __designer:mapid="1bd">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="1be" class="style7">
                                    <asp:Label ID="Label13" runat="server" Text="Medio de Pago"></asp:Label>
                                </td>
                                <td __designer:mapid="1c0">
                                    <asp:DropDownList ID="ddlMPayment" runat="server">
                                        <asp:ListItem>Efectivo</asp:ListItem>
                                        <asp:ListItem>Cheque</asp:ListItem>
                                        <asp:ListItem>Deposito</asp:ListItem>
                                        <asp:ListItem>Tarjeta de Credito</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Literal ID="litMensaje" runat="server" />
                                </td>
                                <td __designer:mapid="1c7">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr __designer:mapid="1c8">
                                <td __designer:mapid="1c9">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="1ca">
                                    &nbsp;</td>
                                <td __designer:mapid="1cc">
                                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                                        OnClick="btnAceptar_Click" />
                                </td>
                                <td __designer:mapid="1cd">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr __designer:mapid="1ce">
                                <td __designer:mapid="1cf">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="1d0">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="1d1">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="1d2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>

