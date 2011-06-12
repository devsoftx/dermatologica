<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Admin/Popup.master" AutoEventWireup="true"
    CodeFile="SearchPersons.aspx.cs" Inherits="Derma_SearchPersons" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <telerik:RadCodeBlock ID="rcbInvitation" runat="server">
        <script language="javascript" type="text/javascript">
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            }

            function onClose() {
                var oWindow = GetRadWindow();
                oWindow.Close('id');
            }		    
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" style="left: 50px;">
        <asp:UpdatePanel ID="updPanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <asp:Literal runat="server" ID="lblSearch" Text="Buscar por Nombres:" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtSearch" Width="300px" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnSearch" Text="Buscar" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>                    
                        <asp:GridView ID="gvPersons" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" DataKeyNames="Id" Width="620px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Sel." SelectImageUrl="~/Images/action_check.png"
                                    ShowSelectButton="True" />
                                <asp:TemplateField HeaderText="Nombres">
                                    <ItemTemplate>
                                        <asp:Literal ID="litNombres" Text='<%# string.Format("{0} {1} {2}", Eval("FirstName"),Eval("LastNameP"),Eval("LastNameM") ) %>'
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DocumentType" HeaderText="Tipo de Documento" />
                                <asp:BoundField DataField="DocumentNumber" HeaderText="N° Documento" />
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
                    </div>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnAcept" runat="server" Text="Aceptar" OnClick="btnAcept_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClientClick="onClose();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="gvPersons" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
