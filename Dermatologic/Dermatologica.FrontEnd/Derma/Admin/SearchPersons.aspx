<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Admin/Popup.master" AutoEventWireup="true"CodeFile="SearchPersons.aspx.cs"Inherits="Derma_SearchPersons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" style="left: 50px;">
        <div>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Literal runat="server" ID="lblSearch" Text="Buscar por Nombres:" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtSearch" />
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnSearch" Text="Buscar" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:UpdatePanel ID="updPanel" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvPersons" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPersons_RowCommand"
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombres">
                                    <ItemTemplate>
                                        <asp:Literal ID="litNombres" Text='<%# string.Format("{0} {1}", Eval("FirstName"),Eval("LastName") ) %>'
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DateBirthDay" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha de Cumpleaños" />
                                <asp:BoundField DataField="Email" HeaderText="Correo" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                <table>
                    <tr>
                        <td><asp:Button ID="btnAcept" runat="server" Text="Aceptar" 
                                onclick="btnAcept_Click" /></td>
                        <td><asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
                                onclick="btnCancel_Click" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
