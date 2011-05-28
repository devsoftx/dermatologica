<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListMedications.aspx.cs" Inherits="Derma_Admin_ListMedications" %>
<%--<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%--<telerik:radcodeblock id="rcbInvitation" runat="server">
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
	</telerik:radcodeblock>
     <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
	   <AjaxSettings>			
			<telerik:AjaxSetting AjaxControlID="btnDoPostBack">
			   <UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
			   </UpdatedControls>
			 </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnSearch">
			   <UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
			   </UpdatedControls>
			 </telerik:AjaxSetting>
	   </AjaxSettings>
	 </telerik:RadAjaxManager>
	<telerik:radajaxloadingpanel runat="server" id="rlpLoading" transparency="50" height="100%"
		width="100%">
		<table style="height: 100%; width: 100%;" border="0">
			<tr>
				<td width="100%" align="center" valign="middle" style="background-color: #F0FFFF">
					<img src='../../images/loading.gif'
						alt="Loading..." style="border: 0px;" />
				</td>
			</tr>
		</table>
	</telerik:radajaxloadingpanel>
    <telerik:radajaxpanel id="RadAjaxPanel1" runat="server" clientevents-onrequeststart="conditionalPostback">
		<asp:UpdatePanel ID="upnBlockingpprovalFlow" runat="server" 
			UpdateMode="Conditional">
			<ContentTemplate>
				<asp:Panel runat="server" ID="pnlReport">
                <div>
                    <table >
                        <tr>
                            <td >&nbsp;</td>
                            <td ><asp:Literal ID="litMensaje" runat="server" /></td>
                            <td>&nbsp;</td>
                            <td><asp:Button ID="btnSearch" runat="server" Text="Buscar" 
                                    onclick="btnSearch_Click" /></td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                            <td >
                                <asp:GridView ID="gvMedications" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                                    onrowcommand="gvMedication_RowCommand" Width="558px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Description" HeaderText="Descripción" />
                                        <asp:BoundField DataField="NumberSessions" HeaderText="N° de Sesiones" />
                                        <asp:BoundField DataField="TotalPrice" HeaderText="Precio" />
                                        <asp:CheckBoxField DataField="IsCompleted" HeaderText="Completo" />
                                        <asp:CheckBoxField DataField="IsPaid" HeaderText="Pagado" />
                                        <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                       <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                                        CommandName="cmd_editar">
                                            <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lnk_eliminar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                                        CommandName="cmd_eliminar" OnClientClick="javascript:return confirm('¿Esta seguro de eliminar El Tratamiento?');">
                                            <img id="Img4" src="~/images/action_delete.png" alt="Eliminar" border="0" runat="server" />
                                        </asp:LinkButton>
                                         </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                |</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:LinkButton ID="lnkNew" runat="server" Text="Nuevo" onclick="lnkNew_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>            
                    </table>
                </div>
                <asp:Button ID="btnDoPostBack" runat="server" BorderStyle="None" Height="0" Width="0"
					OnClick="btnDoPostBack_Click" /> 
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </telerik:radajaxpanel>--%>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
    <%--<telerik:radwindowmanager showcontentduringload="false" autosize="false" id="RadWindowManager1"
			width="510px" height="410px" runat="server" modal="true" behaviors="Close, Resize"
			destroyonclose="false">
		<Windows>
			<telerik:RadWindow ID="rw1" runat="server" Height="410px" Width="510px" Modal="true"
				Title="Busqueda de Pacientes">
			</telerik:RadWindow>        
		</Windows>
	</telerik:radwindowmanager>--%>
</asp:Content>