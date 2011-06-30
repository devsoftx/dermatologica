<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListRates.aspx.cs" Inherits="Derma_Admin_ListRates" %>
<%@ Import Namespace="Dermatologic.Domain" %>
<%@ Register src="../../SmartControls/wucSearchPersons.ascx" tagname="wucSearchPersons" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 81px;
        }
        .style3
        {
            width: 151px;
            text-align: right;
        }
        .style4
        {
            width: 211px;
        }
        .style5
        {
            width: 49px;
            text-align: right;
        }
        .style7
        {
            width: 48px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Main">
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    Lista de Tarifas</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
            <asp:Literal ID="litMensaje" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <table class="style1">
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
                            </td>
                            <td class="style3">
                    <asp:DropDownList ID="ddlPersonType" runat="server" Width="150px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlPersonType_SelectedIndexChanged">
                    </asp:DropDownList>
                            </td>
                            <td class="style5">
                                <asp:Label ID="Label1" runat="server" Text="Tratante"></asp:Label>
                            </td>
                            <td class="style4">
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
                                <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                                    Text="Buscar" />
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
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="gvRates" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        onrowcommand="gvRates_RowCommand">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Tratamiento">
                                <ItemTemplate>
                                    <asp:Literal ID="litService" runat="server" Text='<%# ((Service)Eval("Service")).Name %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Currency" HeaderText="Moneda" />
                            <asp:BoundField DataField="UnitCost" HeaderText="Tarifa" />
                             <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                           <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                            CommandName="cmd_editar">
                                <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnk_eliminar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                            CommandName="cmd_eliminar" OnClientClick="javascript:return confirm('¿Esta seguro de eliminar La Tarifa?');">
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
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
            <asp:LinkButton ID="lnkNew" runat="server" Text="Nuevo" onclick="lnkNew_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>

