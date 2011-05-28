<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="EditMedication.aspx.cs" Inherits="Derma_Admin_EditMedication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
                    <asp:DropDownList ID="dwService" runat="server">
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
                    <asp:TextBox ID="TextBox1" runat="server" Width="339px"></asp:TextBox>
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
                    <asp:GridView ID="gvSessions" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None">
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" 
                        Text="Aceptar" />
                </td>
                <td>
                    <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                        Text="Cancelar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>

