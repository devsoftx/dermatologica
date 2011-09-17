<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="EditPerson.aspx.cs" Inherits="Derma_Admin_EditPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtFechaCumpleaños").datepicker();
            $("#MainContent_txtFechaCumpleaños").datepicker($.datepicker.regional['es']);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width='650px'>
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
                <asp:Label ID="Label1" runat="server" Text="Nombres"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombres" runat="server" Width="321px"></asp:TextBox>
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
                <asp:Label ID="Label2" runat="server" Text="Apellido Paterno"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellidoPaterno" runat="server" Width="321px"></asp:TextBox>
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
                <asp:Label ID="Label13" runat="server" Text="Apellido Materno"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellidoMaterno" runat="server" Width="321px"></asp:TextBox>
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
                <asp:Label ID="Label3" runat="server" Text="Tipo de Documento"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="dwTipoDocumento" runat="server"/>                    
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
                <asp:Label ID="Label4" runat="server" Text="N° de Documento"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNumeroDocumento" runat="server" Width="100px" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtDocumentNumber" runat="server" ControlToValidate="txtNumeroDocumento"
                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <asp:Label ID="Label5" runat="server" Text="Tipo Persona"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="dwTipoPersona" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Teléfono"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Persona/Emergencia</td>
            <td>
                <asp:TextBox ID="txtEmergencyPerson" runat="server" Width="119px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Teléfono de Emergencia"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelefonoEmergencia" runat="server" Width="119px"></asp:TextBox>
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
                <asp:Label ID="Label8" runat="server" Text="Celular"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCelular" runat="server" Width="117px"></asp:TextBox>
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
                <asp:Label ID="Label9" runat="server" Text="Dirección"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server" Width="517px"></asp:TextBox>
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
                <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="517px"></asp:TextBox>
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
                <asp:Label ID="Label10" runat="server" Text="Fecha de Cumpleaños"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaCumpleaños" runat="server" Width="137px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
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
            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
