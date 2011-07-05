<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="MakeMedicalCare.aspx.cs"Inherits="Derma_Admin_MakeMedicalCare" %>

<%@ Register src="../../SmartControls/wucSearchPersons.ascx" tagname="wucSearchPersons" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtDateAttention").datepicker();
            $("#MainContent_txtDateAttention").datepicker($.datepicker.regional['es']);
        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 85px;
        }
        .style2
        {
            width: 568px;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 160px;
        }
        .style5
        {
            text-align: right;
            width: 112px;
        }
        .style6
        {
            width: 36px;
        }
        .style7
        {
            text-align: right;
            width: 36px;
        }
        .style8
        {
            width: 112px;
        }
        .style9
        {
            width: 373px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="Main">
        <table>
            <tr style="text-align: center">
                <td class="style6">
                    &nbsp;</td>
                <td colspan="2" style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    &nbsp;
                    Atención Medica
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;
                </td>
                <td class="style2">
                    <asp:Literal ID="litMensaje" runat="server" />
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtDateAttention" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="Label1" runat="server" Text="Sesión"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtSession" runat="server" Enabled="False" Width="151px"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="Label2" runat="server" Text="Paciente"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtPatient" runat="server" Enabled="False" Width="275px"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style5">
                    Operador Medico</td>
                <td class="style2">
                    <table class="style3">
                        <tr>
                            <td class="style4">
                    <asp:DropDownList ID="ddlPersonType" runat="server" Width="150px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlPersonType_SelectedIndexChanged">
                    </asp:DropDownList>
                            </td>
                            <td class="style9">
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
                            <td class="style9">
                                <asp:CheckBox ID="chkIsReplacement" runat="server" Text="Reemplaza" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="Label5" runat="server" Text="Comentario"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtDescription" runat="server" Width="502px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Registrar Atención"
                        Width="123px" />
                </td>
                <td class="style2">
                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdnValue" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>
