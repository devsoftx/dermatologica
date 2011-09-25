<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="Appointment.aspx.cs" Inherits="Derma_Appointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="main">
        <table>
            <tr >
                <td>
                    
                </td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    Detalle de Cita
                </td>
                <td>
                    
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Paciente" runat="server" ID="Label0" />
                </td>
                <td>
                    <asp:TextBox ID="txtPatient" runat="server">
                    </asp:TextBox>
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
                    <asp:DropDownList ID="ddlMedical" runat="server">
                    </asp:DropDownList>
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
                    <asp:DropDownList ID="ddlConsultorio" runat="server">
                    </asp:DropDownList>
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
                    <asp:TextBox runat="server" ID="txtDescription" Rows="5" TextMode="MultiLine" Width="400" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
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
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
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
