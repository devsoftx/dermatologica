﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListAppoiments.aspx.cs" Inherits="Derma_Admin_ListAppoiments" %>
<%@ Import Namespace="Dermatologic.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="main">
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    Listado de Citas
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
                                <asp:Label ID="Label1" runat="server" Style="text-align: right" Text="Buscar por Medico/Cosmeatra"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearch" runat="server" Width="450px"></asp:TextBox>
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
                    <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowCommand="gvAppointments_RowCommand">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>                            
                            <asp:BoundField DataField="StartDate" HeaderText="Fecha" />
                            <asp:BoundField DataField="Patient" HeaderText="Paciente" />
                            <asp:BoundField DataField="Description" HeaderText="Descripción" />
                            <asp:BoundField DataField="Subject" HeaderText="Tratamiento" />
                            <asp:TemplateField HeaderText="Oficina/Consultorio">
                                <ItemTemplate>
                                    <asp:Literal ID="litOffice" runat="server" Text='<%# Eval("Office") != null ? ((Office)Eval("Office")).Name : string.Empty %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Op. Medico">
                                <ItemTemplate>
                                    <asp:Literal ID="litNombres" runat="server" Text='<%# Eval("Medical") != null ? ((Person)Eval("Medical")).CompleteName : string.Empty  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>                            
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
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>