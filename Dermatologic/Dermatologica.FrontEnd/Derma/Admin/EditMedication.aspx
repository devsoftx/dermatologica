<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="EditMedication.aspx.cs"Inherits="Derma_Admin_EditMedication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 107px;
            height: 21px;
        }
        .style4
        {
            height: 21px;
        }
        .style2
        {
            width: 107px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
                            <tr>
                                <td class="style3">
                                </td>
                                <td class="style4">
                                    <asp:Literal ID="litMensaje" runat="server" />
                                </td>
                                <td class="style4">
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label5" runat="server" Text="Servicio"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dwService" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
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
                                <td class="style2">
                                    Buscar Paciente
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlDocumentType" runat="server" AppendDataBoundItems="True"
                                                    Width="50px">
                                                    <asp:ListItem>Dni</asp:ListItem>
                                                    <asp:ListItem Value="PAS">Pasaporte</asp:ListItem>
                                                    <asp:ListItem Value="CEX">Carnet de Extranjería</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                DNI:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDni" runat="server" Width="120px" />
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
                                <td class="style2">
                                    <asp:Label ID="Label3" runat="server" Text="N° de Sesiones"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumberSessions" runat="server" Width="40px"></asp:TextBox>
                                    <asp:Button ID="btnAddSessions" runat="server" Text="Agregar" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
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
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:GridView ID="gvSessions" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="IdMedication" HeaderText="IdMedication" />
                                            <asp:BoundField DataField="Description" HeaderText="Descripcion" />
                                            <asp:BoundField DataField="Currency" HeaderText="Moneda" />
                                            <asp:BoundField DataField="Price" HeaderText="Precio" />
                                            <asp:BoundField DataField="Account" HeaderText="Acuenta" />
                                            <asp:BoundField DataField="Residue" HeaderText="Saldo" />
                                            <asp:CheckBoxField DataField="IsCompleted" HeaderText="Completa" />
                                            <asp:CheckBoxField DataField="IsPaid" HeaderText="Pagada" />
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
                                <td class="style2">
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
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
    <telerik:radwindowmanager showcontentduringload="false" autosize="false" id="RadWindowManager1"
			width="510px" height="410px" runat="server" modal="true" behaviors="Close, Resize"
			destroyonclose="false">
		<Windows>
			<telerik:RadWindow ID="rw1" runat="server" Height="410px" Width="510px" Modal="true"
				Title="Busqueda de Pacientes">
			</telerik:RadWindow>        
		</Windows>
	</telerik:radwindowmanager>
</asp:Content>