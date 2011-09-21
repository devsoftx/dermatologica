<%@ Page Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="ListPersons.aspx.cs"Inherits="Derma_Admin_ListPersons" %>
<%@ Import Namespace="ASP.App_Code" %>
<%@ Import Namespace="Dermatologic.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="main">
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    Datos Personales Generales
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
                            <td style="text-align: right">
                                <asp:Label ID="Label1" runat="server" Style="text-align: right" Text="Buscar por Nombres"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearch" runat="server" Width="500px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Buscar" Width="80px" OnClick="btnSearch_Click" />
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
                    <asp:GridView ID="gvPersons" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowCommand="gvPersons_RowCommand" 
                        onrowdatabound="gvPersons_RowDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nombres">
                                <ItemTemplate>
                                    <asp:Literal ID="litNombresCompletos" runat="server" Text='<%# string.Format("{0} {1} {2}", Eval("FirstName") , Eval("LastNameP"), Eval("LastNameM")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoria">
                                <ItemTemplate>
                                    <asp:Literal ID="litNombres" runat="server" Text='<%# ((PersonType)Eval("PersonType")).Name %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Doc.">
                                <ItemTemplate>
                                    <asp:Literal ID="litDocType" runat="server" Text='<%#  Enum.GetName(typeof(DocumentType),Eval("DocumentType"))  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentNumber" HeaderText="N° Documento" />
                            <asp:BoundField DataField="Email" HeaderText="Correo Electronico" />
                            <asp:BoundField DataField="CellPhone" HeaderText="Celular" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_info" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                                        CommandName="cmd_info">
                                        <img id="Img1" src="~/images/warning.png" alt="Información privada" border="0" runat="server" />
                                    </asp:LinkButton>
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
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:LinkButton ID="lnkNew" runat="server" Text="Nuevo" OnClick="lnkNew_Click" />
                    <asp:Literal ID="litMensaje" runat="server" />
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
