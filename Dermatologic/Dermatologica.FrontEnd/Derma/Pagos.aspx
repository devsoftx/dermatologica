<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="Pagos.aspx.cs" Inherits="Derma_Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 60px;
            text-align: right;
        }
        .style3
        {
            width: 409px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    PAGOS</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" style="text-align: right" 
                        Text="Buscar Por"></asp:Label>
                </td>
                <td class="style3">
                                                <asp:DropDownList ID="ddlDocumentType" 
                        runat="server" AppendDataBoundItems="True"
                                                    Width="100px">
                                                    <asp:ListItem>Dni</asp:ListItem>
                                                    <asp:ListItem Value="PAS">Pasaporte</asp:ListItem>
                                                    <asp:ListItem Value="CEX">Carnet de Extranjería</asp:ListItem>
                                                </asp:DropDownList>
                                            <asp:TextBox ID="TextBox1" runat="server" Width="253px"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                <asp:GridView ID="gvMedications" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Description" HeaderText="Descripción" />
                        <asp:BoundField DataField="NumberSessions" HeaderText="N° de Sesiones" />
                        <asp:CheckBoxField DataField="IsCompleted" HeaderText="Completo" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" 
                                    CommandArgument='<%# Eval("id") %>' CommandName="cmd_editar">
                                <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                            </asp:LinkButton>
                                <asp:LinkButton ID="lnk_eliminar" runat="server" BorderStyle="None" 
                                    CommandArgument='<%# Eval("id") %>' CommandName="cmd_eliminar" 
                                    OnClientClick="javascript:return confirm('¿Esta seguro de eliminar El Tratamiento?');">
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
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                <asp:GridView ID="gvSessions" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" DataKeyNames="Id">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Description" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Currency" HeaderText="Moneda" />
                        <asp:BoundField DataField="Price" HeaderText="Precio" />
                        <asp:BoundField DataField="Account" HeaderText="Acuenta" />
                        <asp:BoundField DataField="Residue" HeaderText="Saldo" />
                        <asp:TemplateField HeaderText="Completa">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsCompleted" runat="server" 
                                                        Checked = '<%# Eval("IsCompleted") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pagada">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsPaid" runat="server" Checked = '<%# Eval("IsPaid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pagar">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" runat="server" 
                                                        Enabled = '<%# Request.QueryString.Get("action") == "new" ? false : true %>' 
                                                        
                                    NavigateUrl='<%# string.Format("EditSession.aspx?id={0}",Eval("Id")) %>'>Pagar</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" 
                                    CommandArgument='<%# Eval("id") %>' CommandName="cmd_editar">
                                <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                            </asp:LinkButton>
                                <asp:LinkButton ID="lnk_eliminar" runat="server" BorderStyle="None" 
                                    CommandArgument='<%# Eval("id") %>' CommandName="cmd_eliminar" 
                                    OnClientClick="javascript:return confirm('¿Esta seguro de eliminar La Sesion?');">
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
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>

