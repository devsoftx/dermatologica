<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListUsers.aspx.cs" Inherits="Derma_Admin_ListUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="main">
        <div>
            <asp:Literal ID="litMensaje" runat="server" />
        </div>
        <div>
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" 
                onrowcommand="gvUsers_RowCommand" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="Login" />                                        
                    <asp:BoundField DataField="Email" HeaderText="Correo" />                                        
                    <asp:BoundField DataField="IsLockedOut" HeaderText="Esta Bloqueado" />                                        
                    <asp:BoundField DataField="LastActivityDate" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha de Creación" />                                   
                    <asp:TemplateField HeaderText="Rol Asignado">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkRol" runat="server" NavigateUrl = '<%# string.Format("{0}/Derma/Admin/UsersInRoles.aspx?userId={1}", ConfigurationManager.AppSettings["path"],Eval("ProviderUserKey"))  %>' Text = "Rol"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("ProviderUserKey") %>'
                            CommandName="cmd_editar">
                                <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnk_eliminar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("ProviderUserKey") %>'
                            CommandName="cmd_eliminar" OnClientClick="javascript:return confirm('¿Esta seguro de eliminar el usuario?');">
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
        </div>
        <div>
            <asp:LinkButton ID="lnkNew" runat="server" Text="Nuevo" onclick="lnkNew_Click" />
        </div>
    </div>
</asp:Content>

