<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="MakePaymentsPersonal.aspx.cs" Inherits="Derma_Admin_MakePaymentsPersonal" %>
<%@ Import Namespace="Dermatologic.Domain" %>
<%@ Register src="../../SmartControls/wucSearchPersons.ascx" tagname="wucsearchpersons" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
        }
        .style5
        {
            width: 83px;
            text-align: right;
        }
        .style6
        {
            width: 410px;
            text-align: right;
        }
        .style7
        {
            width: 73px;
            text-align: right;
        }
        .style10
        {
            width: 66px;
        }
        .style11
        {
            width: 37px;
            text-align: right;
        }
        .style8
        {
            width: 79px;
        }
        .style12
        {
            width: 100%;
        }
        .style13
        {
            width: 65px;
        }
        .style14
        {
            width: 56px;
        }
        .style15
        {
            width: 112px;
            text-align: right;
        }
        .style16
        {
            width: 543px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Main">
        <table class="style1">
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;" 
                    class="style4" colspan="2">
                    Pagos al Personal</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                </td>
                <td class="style16">
                    <table class="style1">
                        <tr>
                            <td class="style5">
                    <asp:TextBox ID="txtDatePayment" runat="server" Enabled="False" Width="70px"></asp:TextBox>
                            </td>
                            <td class="style6">
                    <asp:Label ID="Label3" runat="server" Text="Tipo de Cambio"></asp:Label>
                            </td>
                            <td class="style7">
                    <asp:Label ID="Label11" runat="server" Text="Compra"></asp:Label>
                            </td>
                            <td class="style10">
                    <asp:TextBox ID="txtCompra" runat="server" Width="69px" Enabled="False"></asp:TextBox>
                            </td>
                            <td class="style11">
                    <asp:Label ID="Label12" runat="server" Text="Venta"></asp:Label>
                            </td>
                            <td class="style8">
                    <asp:TextBox ID="txtVenta" runat="server" Width="69px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label16" runat="server" Text="Centro de Costo"></asp:Label>
                </td>
                <td class="style16">
                    <asp:DropDownList ID="ddlCostCenter" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label17" runat="server" Text="Tratante"></asp:Label>
                </td>
                <td class="style16">
                    <table class="style1">
                        <tr>
                            <td class="style4" style="text-align: left">
                                <asp:Label ID="Label18" runat="server" style="text-align: left" Text="Tipo"></asp:Label>
                            </td>
                            <td class="style5">
                    <asp:DropDownList ID="ddlPersonType" runat="server" Width="150px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlPersonType_SelectedIndexChanged">
                    </asp:DropDownList>
                            </td>
                            <td>
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
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label14" runat="server" Text="Buscar Atenciones"></asp:Label>
                </td>
                <td class="style16">
                    <asp:Button ID="btnSearch" runat="server" Text="Buscar" 
                        onclick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                                    <asp:GridView ID="gvMedicalCares" runat="server" 
                        AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" DataKeyNames="Id" > 
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                             <asp:TemplateField HeaderText="Sesión">
                                            <ItemTemplate>
                                                <asp:Literal ID="litSession" runat="server" Text='<%# ((Session)Eval("Session")).Description %>'></asp:Literal>
                                            </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:BoundField HeaderText="Fecha de Atencion" DataField="DateAttention" />
                                            <asp:TemplateField HeaderText="Sesión">
                                            <ItemTemplate>
                                                <asp:Literal ID="litCurrency" runat="server" Text='<%# ((Session)Eval("Session")).Currency %>'></asp:Literal>
                                            </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Precio">
                                            <ItemTemplate>
                                                <asp:Literal ID="litPrice" runat="server" Text='<%# ((Session)Eval("Session")).Price %>'></asp:Literal>
                                            </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Acuenta">
                                            <ItemTemplate>
                                                <asp:Literal ID="litAccount" runat="server" Text='<%# ((Session)Eval("Session")).Account %>'></asp:Literal>
                                            </ItemTemplate>
                                             </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Saldo">
                                            <ItemTemplate>
                                                <asp:Literal ID="litResidue" runat="server" Text='<%# ((Session)Eval("Session")).Residue %>'></asp:Literal>
                                            </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pagada">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkIsPaid" runat="server" Checked = '<%# ((Session)Eval("Session")).IsPaid %>'  Enabled=false />
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
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label10" runat="server" Text="Saldo"></asp:Label>
                    </td>
                <td class="style16">
                                    <asp:Label ID="lblCurrency" runat="server" Width="50px" 
                        Height="16px"></asp:Label>
                    <asp:TextBox ID="txtResidue" runat="server" Enabled="False" Width="105px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label8" runat="server" Text="Concepto"></asp:Label>
                </td>
                <td class="style16">
                    <asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label5" runat="server" Text="Documento"></asp:Label>
                </td>
                <td class="style16">
                    <asp:DropDownList ID="ddlInvoice" runat="server">
                        <asp:ListItem>Recibo</asp:ListItem>
                        <asp:ListItem>Boleta</asp:ListItem>
                        <asp:ListItem>Factura</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label7" runat="server" Text="N°"></asp:Label>
                    <asp:TextBox ID="txtNInvoice" runat="server" Width="110px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label1" runat="server" Text="Moneda"></asp:Label>
                </td>
                <td class="style16">
                                    <table class="style12">
                                        <tr>
                                            <td class="style10">
                                    <asp:DropDownList ID="ddlCurrency" runat="server" AppendDataBoundItems="True" 
                                        Width="50px">
                                        <asp:ListItem>USD</asp:ListItem>
                                        <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                        <asp:ListItem>EUR</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                                            <td class="style13">
                    <asp:Label ID="Label2" runat="server" Text="Monto"></asp:Label>
                                            </td>
                                            <td>
                    <asp:TextBox ID="txtAmount" runat="server" Width="92px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label13" runat="server" Text="Medio de Pago"></asp:Label>
                </td>
                <td class="style16">
                    <asp:DropDownList ID="ddlMPayment" runat="server">
                        <asp:ListItem>Efectivo</asp:ListItem>
                        <asp:ListItem>Cheque</asp:ListItem>
                        <asp:ListItem>Deposito</asp:ListItem>
                        <asp:ListItem>Tarjeta de Credito</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                                    <asp:Button ID="btnAceptar" runat="server"  
                                        Text="Aceptar" />
                                </td>
                <td class="style16">
                                    <asp:Button ID="btnCancelar" runat="server"  
                                        Text="Cancelar" />
                                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>

