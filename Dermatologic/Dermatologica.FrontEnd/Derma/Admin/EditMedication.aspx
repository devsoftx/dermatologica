<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="EditMedication.aspx.cs" Inherits="Derma_Admin_EditMedication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 107px;
            text-align: right;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="342px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" Text="Paciente"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="338px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Text="N° de Sesiones"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNumberSessions" runat="server" Width="40px"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Agregar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Sesiones"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Descripcion" />
                            <asp:BoundField HeaderText="Moneda" />
                            <asp:BoundField HeaderText="Precio" />
                            <asp:BoundField HeaderText="Acuenta" />
                            <asp:BoundField HeaderText="Saldo" />
                            <asp:CheckBoxField HeaderText="Completa" />
                            <asp:CheckBoxField HeaderText="Pagada" />
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
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                                    onclick="btnAceptar_Click" />
                            </td>
                <td>
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                    onclick="btnCancelar_Click" />
                            </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>

