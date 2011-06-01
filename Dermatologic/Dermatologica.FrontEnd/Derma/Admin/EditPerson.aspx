<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="EditPerson.aspx.cs" Inherits="Derma_Admin_EditPerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtFechaCumpleaños").datepicker();
            $("#MainContent_txtFechaCumpleaños").datepicker($.datepicker.regional['es']);
        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 26px;
        }
        .style3
        {
            width: 147px;
            text-align: right;
        }
        .style4
        {
            width: 26px;
            height: 26px;
        }
        .style5
        {
            width: 147px;
            height: 26px;
            text-align: right;
        }
        .style6
        {
            height: 26px;
        }
        .style7
        {
            width: 731px;
        }
        .style8
        {
            height: 26px;
            width: 731px;
        }
        .style9
        {
            width: 26px;
            height: 22px;
        }
        .style10
        {
            width: 147px;
            height: 22px;
            text-align: right;
        }
        .style11
        {
            width: 731px;
            height: 22px;
        }
        .style12
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style7">
        <asp:Literal ID="litMensaje" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text="Nombres"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtNombres" runat="server" Width="321px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Text="Apellidos"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtApellidos" runat="server" Width="321px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label3" runat="server" Text="Tipo de Documento"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="dwTipoDocumento" runat="server" 
                    AppendDataBoundItems="True">
                    <asp:ListItem>Dni</asp:ListItem>
                    <asp:ListItem Value="PAS">Pasaporte</asp:ListItem>
                    <asp:ListItem Value="CEX">Carnet de Extranjería</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label4" runat="server" Text="N° de Documento"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtNumeroDocumento" runat="server" Width="100px" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtDocumentNumber" runat="server" 
                    ControlToValidate="txtNumeroDocumento" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label5" runat="server" Text="Tipo Persona"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="dwTipoPersona" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
            </td>
            <td class="style5">
                <asp:Label ID="Label6" runat="server" Text="Teléfono"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtTelefono" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label7" runat="server" Text="Teléfono de Emergencia"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtTelefonoEmergencia" runat="server" Width="119px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label8" runat="server" Text="Celular"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtCelular" runat="server" Width="117px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label9" runat="server" Text="Dirección"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtDireccion" runat="server" Width="517px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtEmail" runat="server" Width="517px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label10" runat="server" Text="Fecha de Cumpleaños"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtFechaCumpleaños" runat="server" Width="137px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
            </td>
            <td class="style10">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td class="style12">
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                                    onclick="btnAceptar_Click" />
                            </td>
            <td class="style7">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                    onclick="btnCancelar_Click" />
                            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>