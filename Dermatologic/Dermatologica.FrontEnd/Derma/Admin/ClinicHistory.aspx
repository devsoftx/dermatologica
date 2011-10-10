<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="ClinicHistory.aspx.cs" Inherits="Derma_Admin_ClinicHistory" %>

<%@ Import Namespace="Dermatologic.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvMedications" EventName="gvPersons_RowCommand">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvMedications" EventName="gvPersons_PageIndexChanging">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch" EventName="btnSearch_Click">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReport" LoadingPanelID="rlpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="rlpLoading" Transparency="50" Height="100%"
        Width="100%">
        <table style="height: 100%; width: 100%;">
            <tr>
                <td width="100%" style="background-color: #F0FFFF">
                    <img src="../../Images/loading.gif" alt="Loading..." style="border: 0px;" />
                </td>
            </tr>
        </table>
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
        <asp:UpdatePanel ID="upnBlockingpprovalFlow" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlReport">
                    <table width='100%'>
                        <tr>
                            <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;">
                                Tratamientos
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litMensaje" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="Label1" runat="server" Style="text-align: right" Text="Buscar Por Paciente"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSearch" runat="server" Width="386px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCostCenter" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btnSearch" Text="Buscar" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvMedications" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    ForeColor="#333333" GridLines="None" OnRowCommand="gvMedication_RowCommand" Width="100%"
                                    AllowPaging="True" OnPageIndexChanging="gvMedications_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Paciente">
                                            <ItemTemplate>
                                                <asp:Literal ID="litPatient" runat="server" Text='<%# string.Format("{0} {1} {2}", ((Person)Eval("Patient")).FirstName,((Person)Eval("Patient")).LastNameP, ((Person)Eval("Patient")).LastNameM) %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unidad de Neg.">
                                            <ItemTemplate>
                                                <asp:Literal ID="litCostCenter" runat="server" Text='<%# ((Service)Eval("Service")).CostCenter.Name %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tratamiento">
                                            <ItemTemplate>
                                                <asp:Literal ID="litService" runat="server" Text='<%# ((Service)Eval("Service")).Name %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LastModified" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Inicio de Tratamiento" />
                                        <asp:CheckBoxField DataField="IsCompleted" HeaderText="Completo" />
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk_editar" runat="server" BorderStyle="None" CommandArgument='<%# Eval("id") %>'
                                                    CommandName="cmd_editar">
                                                    <img id="Img3" src="~/images/action_check.png" alt="Editar" border="0" runat="server" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>
