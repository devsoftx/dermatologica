<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="Appointment.aspx.cs" Inherits="Derma_Appointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="main">
        <table cellpadding="1" cellspacing="1">
            <tr>
                <td>
                    <asp:Label Text="Paciente" runat="server" ID="Label0" />
                </td>
                <td>
                    <asp:Label runat="server" ID="txtPatient" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Fecha y Hora Inicio:" runat="server" ID="Label1" />
                </td>
                <td>
                    <asp:Label runat="server" ID="txtDateStart" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Fecha y Hora Final:" runat="server" ID="Label2" />
                </td>
                <td>
                    <asp:Label runat="server" ID="txtDateEnd" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Medico/Cosmetra:" runat="server" ID="Label3" />
                </td>
                <td>
                    <asp:Label runat="server" ID="txtMedical" Width="250px" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Consultorio:" runat="server" ID="Label4" />
                </td>
                <td>
                    <asp:Label runat="server" ID="txtConsultorio" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Description:" runat="server" ID="Label5" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" Enabled="False" Rows="3" 
                        TextMode="MultiLine" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>
