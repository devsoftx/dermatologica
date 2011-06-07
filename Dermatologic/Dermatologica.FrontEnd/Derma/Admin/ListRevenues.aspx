<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListRevenues.aspx.cs" Inherits="Derma_Admin_ListRevenues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 15px;
        }
        .style3
        {
            width: 72px;
            text-align: left;
        }
        .style4
        {
            width: 108px;
        }
        .style5
        {
            width: 240px;
        }
        .style6
        {
            width: 195px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table class="style1">
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
                            <td class="style3">
                                <asp:Label ID="Label1" runat="server" style="text-align: left" 
                                    Text="Buscar Por"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:Label ID="Label2" runat="server" Text="Moneda"></asp:Label>
                                    <asp:DropDownList ID="ddlCurrency" runat="server" AppendDataBoundItems="True" 
                                        Width="50px">
                                        <asp:ListItem>USD</asp:ListItem>
                                        <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                        <asp:ListItem>EUR</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                            <td class="style5">
                                <asp:Label ID="Label3" runat="server" Text="Medio de pago"></asp:Label>
                    <asp:DropDownList ID="ddlMPayment" runat="server">
                        <asp:ListItem>Efectivo</asp:ListItem>
                        <asp:ListItem>Cheque</asp:ListItem>
                        <asp:ListItem>Deposito</asp:ListItem>
                        <asp:ListItem>Tarjeta de Credito</asp:ListItem>
                    </asp:DropDownList>
                            </td>
                            <td class="style6">
                                <asp:Label ID="Label4" runat="server" Text="Documento"></asp:Label>
                    <asp:DropDownList ID="ddlInvoice" runat="server">
                        <asp:ListItem>Recibo</asp:ListItem>
                        <asp:ListItem>Boleta</asp:ListItem>
                        <asp:ListItem>Factura</asp:ListItem>
                    </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                                    Text="Buscar" />
                            </td>
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
                    <asp:GridView ID="gvRevenues" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="532px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="DatePayment" HeaderText="Fecha" />
                            <asp:BoundField DataField="MPayment" HeaderText="Medio de pago" />
                            <asp:BoundField DataField="Invoice" HeaderText="Documento" />
                            <asp:BoundField DataField="NInvoice" HeaderText="N°" />
                            <asp:BoundField DataField="Currency" HeaderText="Moneda" />
                            <asp:BoundField DataField="Amount" HeaderText="Monto" />
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>

