<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="MakeMedicalCare.aspx.cs" Inherits="Derma_Admin_MakeMedicalCare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 118px;
            text-align: right;
        }
        .style3
        {
            width: 360px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Main">
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    Atención Medica</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                                    <asp:Literal ID="litMensaje" runat="server" />
                                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDateAttention" runat="server" Enabled="False" Width="126px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Sesión"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtSession" runat="server" Enabled="False" Width="151px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Paciente"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtPatient" runat="server" Enabled="False" Width="275px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Text="Médico"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtMedical" runat="server" Width="272px"></asp:TextBox>
                                                <asp:LinkButton runat="server" ID="lnkSearch" Text="Buscar" 
                                                    OnClick="lnkSearch_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label5" runat="server" Text="Comentario"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDescription" runat="server" Width="502px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" 
                                        Text="Registrar Atención" Width="123px" />
                                </td>
                <td class="style3">
                                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" 
                                        Text="Cancelar" />
                                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>

