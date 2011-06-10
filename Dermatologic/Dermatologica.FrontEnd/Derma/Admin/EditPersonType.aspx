<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="EditPersonType.aspx.cs" Inherits="Derma_Admin_EditPersonType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 77px;
            text-align: right;
        }
        .style3
        {
            width: 521px;
        }
        .style6
        {
            text-align: right;
            height: 21px;
        }
        .style8
        {
            height: 21px;
        }
        .style9
        {
            width: 38px;
            text-align: right;
            height: 21px;
        }
        .style10
        {
            width: 38px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Main">
        <table class="style1">
            <tr>
                <td class="style9">
                    </td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;" 
                    colspan="2">
                    Mantenimiento de Tipo de Persona</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
        <asp:Literal ID="litMensaje" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" style="text-align: right" Text="Nombre"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtName" runat="server" Width="184px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" style="text-align: right" 
                        Text="Descripcion"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDescription" runat="server" Width="499px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                                &nbsp;</td>
                <td class="style2">
                                &nbsp;</td>
                <td class="style3">
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

