<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="MakePaymentsPersonal.aspx.cs"Inherits="Derma_Admin_MakePaymentsPersonal" %>

<%@ Import Namespace="Dermatologic.Domain" %>
<%@ Register Src="../../SmartControls/wucSearchPersons.ascx" TagName="wucsearchpersons"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 160px;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 29px;
        }
        .style5
        {
            width: 111px;
        }
        .style6
        {
            width: 27px;
        }
        .style7
        {
            width: 132px;
        }
        .style15
        {
            width: 490px;
        }
        .style16
        {
            width: 16px;
        }
        .style17
        {
            text-align: right;
        }
        .style18
        {
            width: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlPersonType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAceptar">
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
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
        style="margin-right: 73px">
        <asp:UpdatePanel ID="upnBlockingpprovalFlow" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlReport">
                    <div id="Main">
                        <table width='800px'>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;"
                                    colspan="2">
                                    Pagos al Personal
                                </td>
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style17">
                                    <asp:Label ID="Label4" runat="server" Text="Fecha" style="text-align: right"></asp:Label>
                                </td>
                                <td class="style15">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtDatePayment" runat="server" Enabled="False" Width="70px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="Tipo de Cambio"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="Compra"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCompra" runat="server" Width="69px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text="Venta"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVenta" runat="server" Width="69px" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style17">
                                    <asp:Label ID="Label17" runat="server" Text="Tratante"></asp:Label>
                                </td>
                                <td class="style15">
                                    <table>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label18" runat="server" Style="text-align: left" Text="Tipo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPersonType" runat="server" Width="150px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlPersonType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style2">
                                                <uc1:wucsearchpersons ID="ucSearchPersonsMedical" runat="server" WebServiceMethod="LoadPersons" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style17">
                                    &nbsp;</td>
                                <td class="style15">
                                    <table class="style3">
                                        <tr>
                                            <td class="style7">
                                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" 
                                                    Text="Buscar Atenciones" Width="124px" />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlMedicalCareType" runat="server">
                                                    <asp:ListItem>Normales</asp:ListItem>
                                                    <asp:ListItem>Por Titularidad</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    </td>
                                <td class="style18">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    </td>
                                <td class="style17">
                                    </td>
                                <td style="color: #CC3300" class="style15">
                                    Elija las atenciones a pagar haciendo un Check en la columna pagar
                                </td>
                                <td class="style18">
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style17">
                                    &nbsp;</td>
                                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;" 
                                    class="style15">
                                    Atenciones no Canceladas
                                </td>
                                <td class="style18">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style17">
                                    &nbsp;
                                </td>
                                <td class="style15">
                                    <asp:GridView ID="gvMedicalCares" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" DataKeyNames="Id" Width="650px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="N#">
                                                <ItemTemplate>
                                                    <asp:Literal ID="litNSession" runat="server" Text='<%# ((Session)Eval("Session")).RowId %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sesión">
                                                <ItemTemplate>
                                                    <asp:Literal ID="litSession" runat="server" Text='<%# ((Session)Eval("Session")).Description %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Fecha de Atencion" DataField="DateAttention" DataFormatString="{0:dd-MM-yyyy}" />
                                            <asp:TemplateField HeaderText="Moneda">
                                                <ItemTemplate>
                                                    <asp:Literal ID="litCurrency" runat="server" Text='<%# ((Session)Eval("Session")).Currency %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Precio">
                                                <ItemTemplate>
                                                    <asp:Literal ID="litPrice" runat="server" Text='<%# ((Session)Eval("Session")).Price %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sesión Pagada">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkIsPaid" runat="server" Checked='<%# ((Session)Eval("Session")).IsPaid %>'
                                                        Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tarifa">
                                                <ItemTemplate>
                                                    <asp:Literal ID="litRate" runat="server" Text='<%# ((Rate)Eval("Rate")).UnitCost %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Tarifa Titular">
                                                <ItemTemplate>
                                                    <asp:Literal ID="litRate" runat="server" Text='<%# ((Rate)Eval("Rate")).UnitCostPartner %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pagar">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkPay" runat="server" Checked="false"
                                                        Enabled="true" />
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
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style17">
                                    <asp:Label ID="Label10" runat="server" Text="Monto Adeudado"></asp:Label>
                                </td>
                                <td class="style15">
                                    <table class="style3">
                                        <tr>
                                            <td class="style4">
                                                <asp:Label ID="lblUSD" runat="server" Height="16px" Width="50px">USD</asp:Label>
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtPayUSD" runat="server" Enabled="False" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="style6">
                                                <asp:Label ID="lblPEN" runat="server" Height="16px" Width="50px">S/.</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPayPEN" runat="server" Enabled="False" Width="105px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style17">
                                    <asp:Label ID="Label8" runat="server" Text="Concepto"></asp:Label>
                                </td>
                                <td class="style15">
                                    <asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
                                </td>
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style17">
                                    <asp:Label ID="Label5" runat="server" Text="Documento"></asp:Label>
                                </td>
                                <td class="style15">
                                    <asp:DropDownList ID="ddlInvoice" runat="server">
                                        <asp:ListItem>Recibo</asp:ListItem>
                                        <asp:ListItem>Boleta</asp:ListItem>
                                        <asp:ListItem>Factura</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label7" runat="server" Text="N°"></asp:Label>
                                    <asp:TextBox ID="txtNInvoice" runat="server" Width="110px"></asp:TextBox>
                                </td>
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style17">
                                    <asp:Label ID="Label13" runat="server" Text="Medio de Pago"></asp:Label>
                                </td>
                                <td class="style15">
                                    <asp:DropDownList ID="ddlMPayment" runat="server">
                                        <asp:ListItem>Efectivo</asp:ListItem>
                                        <asp:ListItem>Cheque</asp:ListItem>
                                        <asp:ListItem>Deposito</asp:ListItem>
                                        <asp:ListItem>Tarjeta de Credito</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Literal ID="litMensaje" runat="server" />
                                </td>
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                                </td>
                                <td class="style15">
                                </td>
                                <td class="style18">
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
                                <td class="style15">
                                    &nbsp;
                                </td>
                                <td class="style18">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>
