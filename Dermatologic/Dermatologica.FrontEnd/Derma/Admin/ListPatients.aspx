<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="ListPatients.aspx.cs" Inherits="Derma_Admin_ListPatients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 190%;
        }
        .style2
        {
            width: 50px;
        }
        .style3
        {
            width: 384px;
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
    <div>
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                    Buscador de Pacientes</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
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
                                <asp:Button ID="btnSearch" runat="server" Text="Buscar" Width="101px" />
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
                <td class="style3">
                    <asp:GridView ID="gvPatients" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="735px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nombres">
                                <ItemTemplate>
                                        <asp:Literal ID="litNombres" Text='<%# string.Format("{0} {1}", Eval("FirstName"),Eval("LastName") ) %>'
                                            runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentType" HeaderText="Documento" />
                            <asp:BoundField DataField="DocumentNumber" HeaderText="N°" />
                            <asp:BoundField DataField="CellPhone" HeaderText="Celular" />
                            <asp:BoundField DataField="EmergencyPhone" HeaderText="Tel.  de Emergencia" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
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

