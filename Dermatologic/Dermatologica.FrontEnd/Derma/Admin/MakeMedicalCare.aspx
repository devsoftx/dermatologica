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
        <script type="text/javascript">
            $(function () {
                $("#MainContent_txtDateAttention").datepicker();
                $("#MainContent_txtDateAttention").datepicker($.datepicker.regional['es']);
            });
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<telerik:RadCodeBlock ID="rcbInvitation" runat="server">
        <script type="text/javascript">
            function openRadWindow(url, rw) {
                var aleatorio = Math.ceil(Math.random() * 1000);
                var oWnd = radopen(url + '&al=' + aleatorio.toString(), rw);
                oWnd.center();
                oWnd.add_close(CloseRadWindow);
            }

            function CloseRadWindow(oWnd, args) {
                var arg = args.get_argument();
                __doPostBack("<%= btnDoPostBack.UniqueID %>", '');
            }

            function conditionalPostback(sender, eventArgs) {
                var theRegexp = new RegExp("\.btnExportReport$", "ig");
                if (eventArgs.get_eventTarget().match(theRegexp)) {
                    eventArgs.set_enableAjax(false);
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnDoPostBack">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="rlpLoading" Transparency="50" Height="100%"
        Width="100%">
        <table style="height: 100%; width: 100%;" border="0">
            <tr>
                <td width="100%" align="center" valign="middle" style="background-color: #F0FFFF">
                    <img src='../../images/loading.gif' alt="Loading..." style="border: 0px;" />
                </td>
            </tr>
        </table>
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" ClientEvents-OnRequestStart="conditionalPostback">
        <asp:UpdatePanel ID="upnBlockingpprovalFlow" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlReport">
    <div id="Main">
        <table class="style1">
            <tr style="text-align: center">
                <td class="style2">
                    &nbsp;</td>
                <td class="style3" 
                    style="font-weight: bold; background-color: #006699; color: #FFFFFF">
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
                    <asp:TextBox ID="txtDateAttention" runat="server" Width="126px"></asp:TextBox>
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
                    <asp:TextBox ID="txtDescription" runat="server" Width="502px" Rows="5" 
                        TextMode="MultiLine"></asp:TextBox>
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
     <asp:HiddenField ID="hdnValue" runat="server" />
                    <asp:Button ID="btnDoPostBack" runat="server" BorderStyle="None" Height="0" Width="0"
                        OnClick="btnDoPostBack_Click" />
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
<telerik:radwindowmanager showcontentduringload="false" autosize="false" id="RadWindowManager1"
			width="650px" height="410px" runat="server" modal="true" behaviors="Close, Resize, Move"
			destroyonclose="false">
		<Windows>
			<telerik:RadWindow ID="rw1" runat="server" Height="410px" Width="650px" Modal="true"
				Title="Busqueda de Pacientes">
			</telerik:RadWindow>        
		</Windows>
	</telerik:radwindowmanager>
</asp:Content>

