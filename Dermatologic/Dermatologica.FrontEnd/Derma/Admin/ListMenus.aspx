<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListMenus.aspx.cs" Inherits="Derma_Admin_ListMenus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 34px;
        }
        .style3
        {
            width: 562px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="main">
    <div>
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    Menus del Sistema</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
        <asp:Literal ID="litMensaje" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
        <asp:GridView ID="gvMenus" runat="server" AutoGenerateColumns="False" 
            onrowcommand="gvMenus_RowCommand" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>                    
                <asp:BoundField DataField="Name" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Es Padre">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsPadre" runat="server" Enabled = "false"  Checked= '<%# Eval("ParentId") == null ? true : false %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Padre">
                    <ItemTemplate>
                        <asp:Label ID="lblPadre" runat="server" Text = '<%# Eval("ParentId") == null ? string.Empty : BussinessFactory.GetMenuService().Get(new Guid(Eval("ParentId").ToString())).Name %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Url" HeaderText="Url" />                
                <asp:BoundField DataField="IsActive" HeaderText="Activo" />
                <asp:BoundField DataField="LastModified" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Última Modificación" />                    
                <asp:TemplateField HeaderText="Acciones">                        
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" 
                            CommandArgument='<%# Eval("Id") %>' CommandName="cmd_editar">
                            <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnk_eliminar" runat="server" BorderStyle="None" 
                            CommandArgument='<%# Eval("Id") %>' CommandName="cmd_eliminar" 
                            OnClientClick="javascript:return confirm('¿Esta seguro de eliminar el menu?');">
                            <img id="Img4" src="~/images/action_delete.png" alt="Eliminar" border="0" runat="server" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
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
        <asp:LinkButton ID="lnkNew" runat="server" Text="Nuevo" onclick="lnkNew_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
    </div>
    <div>
    </div>
    </div>
</asp:Content>

