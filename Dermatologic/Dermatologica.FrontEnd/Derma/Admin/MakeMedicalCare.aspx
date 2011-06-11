<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="MakeMedicalCare.aspx.cs"Inherits="Derma_Admin_MakeMedicalCare" %>

<%@ Register src="../../SmartControls/wucSearchPersons.ascx" tagname="wucSearchPersons" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtDateAttention").datepicker();
            $("#MainContent_txtDateAttention").datepicker($.datepicker.regional['es']);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="Main">
        <table>
            <tr style="text-align: center">
                <td>
                    &nbsp;
                </td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF">
                    Atención Medica
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
                    <asp:Literal ID="litMensaje" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDateAttention" runat="server" Width="140px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Sesión"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSession" runat="server" Enabled="False" Width="151px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Paciente"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPatient" runat="server" Enabled="False" Width="275px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Operador Medico</td>
                <td>
                    <asp:DropDownList ID="ddlPersonType" runat="server" Width="150px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Médico"></asp:Label>
                </td>
                <td>
                    <uc1:wucSearchPersons ID="ucSearchPersonsMedical" runat="server" WebServiceMethod="LoadPersons" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Comentario"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="502px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Registrar Atención"
                        Width="123px" />
                </td>
                <td>
                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdnValue" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>
