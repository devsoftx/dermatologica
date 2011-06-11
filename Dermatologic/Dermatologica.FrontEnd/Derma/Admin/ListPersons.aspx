<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListPersons.aspx.cs" Inherits="Derma_Admin_ListPersons" %>
<%@ Import Namespace="Dermatologic.Domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 23px;
        }
        .style4
        {
            width: 130px;
        }
        .style5
        {
            width: 445px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="main">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                Personas</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                    <table class="style1">
                        <tr>
                            <td class="style4" style="text-align: right">
                                <asp:Label ID="Label1" runat="server" style="text-align: right" 
                                    Text="Buscar Por Nombres"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="txtSearch" runat="server" Width="360px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Buscar" Width="80px" 
                                    onclick="btnSearch_Click" />
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
                <asp:GridView ID="gvPersons" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" onrowcommand="gvPersons_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText = "Nombres">
                            <ItemTemplate>
                                <asp:Literal ID = "litNombresCompletos" runat="server" Text = '<%# string.Format("{0} {1}", Eval("FirstName") , Eval("LastName")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText = "Tipo de Persona">
                            <ItemTemplate>
                                <asp:Literal ID = "litNombres" runat="server" Text = '<%# ((PersonType)Eval("PersonType")).Name %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DocumentType" HeaderText="Tipo de Documento" />
                        <asp:BoundField DataField="DocumentNumber" HeaderText="N° Documento" />
                        <asp:BoundField DataField="Email" HeaderText="Correo Electronico" />
                        <asp:BoundField DataField="CellPhone" HeaderText="Celular" />
                        <asp:TemplateField HeaderText="Acciones">
                         <ItemTemplate>
                           <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                            CommandName="cmd_editar">
                                <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnk_eliminar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                            CommandName="cmd_eliminar" OnClientClick="javascript:return confirm('¿Esta seguro de eliminar La Persona?');">
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
    </table>
     </div>
</asp:Content>

