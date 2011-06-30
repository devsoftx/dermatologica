<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="EditService.aspx.cs" Inherits="Derma_Admin_EditService" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 115px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Main">
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
        <asp:Literal ID="litMensaje" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" style="text-align: right" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="184px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" style="text-align: right" 
                        Text="Descripcion"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="499px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" style="text-align: right" 
                        Text="Centro de Costo"></asp:Label>
                </td>
                <td>
                                    <asp:DropDownList ID="ddlCostCenter" runat="server">
                                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" style="text-align: right" 
                        Text="Precio Unitario:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCurrency" runat="server" AppendDataBoundItems="True" 
                                        Width="50px">
                                        <asp:ListItem>USD</asp:ListItem>
                                        <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                        <asp:ListItem>EUR</asp:ListItem>
                                    </asp:DropDownList>
                    <telerik:RadNumericTextBox ID="txtPrice" Runat="server"
                        DataType="System.Decimal" MaxValue="9999" MinValue="0" Width="75px">
                    </telerik:RadNumericTextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                                    onclick="btnAceptar_Click" />
                            </td>
                <td>
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