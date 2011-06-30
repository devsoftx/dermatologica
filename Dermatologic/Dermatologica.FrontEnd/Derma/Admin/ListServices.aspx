<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListServices.aspx.cs" Inherits="Derma_Admin_ListServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 53px;
        }
        .style3
        {
            width: 181px;
        }
        .style4
        {
            width: 98px;
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
                    Servicios de la Clinica</td>
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
                    <table class="style1">
                        <tr>
                            <td class="style4" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" style="text-align: right" 
                                    Text="Centro de Costo"></asp:Label>
                            </td>
                            <td class="style3">
                                    <asp:DropDownList ID="ddlCostCenter" runat="server">
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
                    <asp:GridView ID="gvServices" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        onrowcommand="gvServices_RowCommand">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Nombre" />
                            <asp:BoundField DataField="Description" HeaderText="Descripción" />
                            <asp:BoundField DataField="Price" HeaderText="Precio" />
                            <asp:BoundField DataField="Currency" HeaderText="Moneda" />
                            <asp:BoundField DataField="LastModified" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Última Modificación" />                    
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

