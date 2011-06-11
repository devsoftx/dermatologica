<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="ListRevenues.aspx.cs" Inherits="Derma_Admin_ListRevenues" %>

<%@ Import Namespace="Dermatologic.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<script type="text/javascript">
    $(function () {
        $("#MainContent_txtDatePay").datepicker();
        $("#MainContent_txtDatePay").datepicker($.datepicker.regional['es']);
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <table width='850px'>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    Ingresos
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
                    <table>
                        <tr>
                            <td>
                                <b><asp:Label ID="Label1" runat="server" Style="text-align: left" Text="Buscador"></asp:Label></b>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Fecha de Pago:"></asp:Label>
                                <asp:TextBox ID="txtDatePay" runat="server" Width="80px" />
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Moneda"></asp:Label>
                                <asp:DropDownList ID="ddlCurrency" runat="server" AppendDataBoundItems="True" Width="50px">
                                    <asp:ListItem>USD</asp:ListItem>
                                    <asp:ListItem Value="PEN">PEN</asp:ListItem>
                                    <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Medio de pago:"></asp:Label>
                                <asp:DropDownList ID="ddlMPayment" runat="server">
                                    <asp:ListItem>Efectivo</asp:ListItem>
                                    <asp:ListItem>Cheque</asp:ListItem>
                                    <asp:ListItem>Deposito</asp:ListItem>
                                    <asp:ListItem>Tarjeta de Credito</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Documento:"></asp:Label>
                                <asp:DropDownList ID="ddlInvoice" runat="server">
                                    <asp:ListItem>Recibo</asp:ListItem>
                                    <asp:ListItem>Boleta</asp:ListItem>
                                    <asp:ListItem>Factura</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Buscar" />
                            </td>
                        </tr>
                    </table>
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
                    <asp:GridView ID="gvRevenues" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="800px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="DatePayment" HeaderText="Fecha" />
                            <asp:TemplateField HeaderText="Paciente">
                                <ItemTemplate>
                                    <asp:Literal ID="litNombres" Text='<%# string.Format("{0} {1} {2}", ((Person)Eval("Pacient")).FirstName,((Person)Eval("Pacient")).LastNameP,((Person)Eval("Pacient")).LastNameM ) %>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tratamiento">
                                <ItemTemplate>
                                    <asp:Literal ID="litTratamiento" Text='<%# ((Session)Eval("Session")).Medication.Service.Name %>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>
