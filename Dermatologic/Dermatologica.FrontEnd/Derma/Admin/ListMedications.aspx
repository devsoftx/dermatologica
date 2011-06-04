﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="ListMedications.aspx.cs"Inherits="Derma_Admin_ListMedications" %>
<%@ Import Namespace="Dermatologic.Domain" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 132px;
        }
        .style3
        {
            width: 323px;
        }
        .style4
        {
            width: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Literal ID="litMensaje" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td class="style2" style="text-align: right">
                                <asp:Label ID="Label1" runat="server" style="text-align: right" 
                                    Text="Buscar Por Paciente"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:TextBox ID="txtSearch" runat="server" Width="386px"></asp:TextBox>
                            </td>
                            <td class="style4">
                            <asp:Button runat="server" ID="btnSearch" Text="Buscar" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                &nbsp; &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>                
                <td>
                    <asp:GridView ID="gvMedications" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowCommand="gvMedication_RowCommand" Width="750px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Servicio">
                                <ItemTemplate>
                                    <asp:Literal ID="litService" runat="server" Text='<%# ((Service)Eval("Service")).Name %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paciente">
                                <ItemTemplate>
                                    <asp:Literal ID="litPatient" runat="server" Text='<%# string.Format("{0} {1}", ((Person)Eval("Patient")).FirstName,((Person)Eval("Patient")).LastName) %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Description" HeaderText="Descripción" />
                            <asp:BoundField DataField="NumberSessions" HeaderText="N° de Sesiones" />
                            <asp:BoundField DataField="LastModified" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Inicio de Tratamiento" />                    
                            <asp:CheckBoxField DataField="IsCompleted" HeaderText="Completo" />
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
            </tr>
            <tr>                
                <td>
                    <asp:LinkButton ID="lnkNew" runat="server" Text="Nuevo" OnClick="lnkNew_Click" />
                </td>                
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>                
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>
