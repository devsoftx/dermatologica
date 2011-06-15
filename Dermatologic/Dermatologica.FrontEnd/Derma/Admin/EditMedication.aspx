﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="EditMedication.aspx.cs" Inherits="Derma_Admin_EditMedication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <telerik:radcodeblock id="rcbInvitation" runat="server">
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
    <telerik:radajaxmanager id="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dwService">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAceptar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCancelar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddSessions">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
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
    </telerik:radajaxmanager>
    <telerik:radajaxloadingpanel runat="server" id="rlpLoading" transparency="50" height="100%"
        width="100%">
        <table style="height: 100%; width: 100%;" border="0">
            <tr>
                <td width="100%" align="center" valign="middle" style="background-color: #F0FFFF">
                    <img src='../../images/loading.gif' alt="Loading..." style="border: 0px;" />
                </td>
            </tr>
        </table>
    </telerik:radajaxloadingpanel>
    <telerik:radajaxpanel id="RadAjaxPanel1" runat="server" clientevents-onrequeststart="conditionalPostback">
        <asp:UpdatePanel ID="upnBlockingpprovalFlow" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlReport">
                    <div id="Main">
                        <table >
                            <tr>
                                <td >
                                </td>
                                <td >
                                    <asp:Literal ID="litMensaje" runat="server" />
                                </td>
                                <td >
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:Label ID="Label5" runat="server" Text="Servicio"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dwService" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="dwService_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" Width="342px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Buscar Paciente
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlDocumentType" runat="server" AppendDataBoundItems="True"
                                                    Width="100px">
                                                    <asp:ListItem>Dni</asp:ListItem>
                                                    <asp:ListItem Value="PAS">Pasaporte</asp:ListItem>
                                                    <asp:ListItem Value="CEX">Carnet de Extranjería</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                DNI:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDni" runat="server" Width="100px" MaxLength="8" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPacient" runat="server" Width="339px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkSearch" Text="Buscar" OnClick="lnkSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Moneda</td>
                                <td>
                                    <asp:Label ID="lblCurrency" runat="server" Width="50px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td >
                                    Precio Unitario</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtPrice" Runat="server" 
                                        DataType="System.Decimal" MaxValue="9999" MinValue="1" Width="50px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:Label ID="Label3" runat="server" Text="N° de Sesiones"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtNumberSessions" Runat="server" 
                                        DataType="System.Int32" MaxValue="99" MinValue="1" Width="35px">
                                        <NumberFormat AllowRounding="False" DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                    <asp:Button ID="btnAddSessions" runat="server" onclick="btnAddSessions_Click" 
                                        Text="Agregar" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Descuento Total</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtDiscountT" Runat="server" 
                                        DataType="System.Decimal" MaxValue="99" MinValue="0" Width="35px">
                                        <NumberFormat AllowRounding="False" DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Precio Total</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtPriceT" Runat="server" 
                                        DataType="System.Decimal" MaxValue="9999" MinValue="1" Width="50px" 
                                        ReadOnly="True">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td >
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Sesiones"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:GridView ID="gvSessions" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" DataKeyNames="Id" 
                                        onrowcommand="gvSessions_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="RowId" HeaderText="N#" />
                                            <asp:BoundField DataField="Currency" HeaderText="Moneda" />
                                            <asp:BoundField DataField="Price" HeaderText="Precio" />
                                            <asp:BoundField DataField="Account" HeaderText="Acuenta" />
                                            <asp:BoundField DataField="Residue" HeaderText="Saldo" />
                                            <asp:TemplateField HeaderText="Atentida">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkIsCompleted" runat="server" Checked = '<%# Eval("IsCompleted") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pagada">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkIsPaid" runat="server" Checked = '<%# Eval("IsPaid") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pagar">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lnkPay" runat="server" Enabled = '<%# Request.QueryString.Get("action") == "new" ? false : true %>' NavigateUrl='<%# string.Format("MakePayments.aspx?idSession={0}&idMedication={1}",Eval("Id"),Request.QueryString.Get("id")) %>'>Pagar</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Atender">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lnkAtender" runat="server" Enabled = '<%# Request.QueryString.Get("action") == "new" ? false : true %>' NavigateUrl='<%# string.Format("MakeMedicalCare.aspx?idSession={0}&idMedication={1}",Eval("Id"),Request.QueryString.Get("id")) %>'>Atender</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                                                                        
                                            <asp:BoundField DataField="Description" HeaderText="Descripcion" />
                                            <asp:TemplateField HeaderText="Acciones">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                                                        CommandName="cmd_editar" Enabled = '<%# Request.QueryString.Get("action") == "new" ? false : true %>'>
                                                        <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="lnk_eliminar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                                                        CommandName="cmd_eliminar" OnClientClick="javascript:return confirm('¿Esta seguro de eliminar El Tratamiento?');" Enabled = '<%# Request.QueryString.Get("action") == "new" ? false : true %>'>
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
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
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
                    <asp:Button ID="btnDoPostBack" runat="server" BorderStyle="None" Height="0" Width="0"
                        OnClick="btnDoPostBack_Click" />
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </telerik:radajaxpanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
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
