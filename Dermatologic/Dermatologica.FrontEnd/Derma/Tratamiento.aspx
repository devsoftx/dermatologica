<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="Tratamiento.aspx.cs"Inherits="Derma_Tratamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 107px;
            height: 21px;
        }
        .style4
        {
            height: 21px;
        }
        .style2
        {
            width: 107px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="style1" __designer:mapid="85e">
        <tr __designer:mapid="85f">
            <td class="style3" __designer:mapid="860">
            </td>
            <td class="style4" __designer:mapid="861">
                <asp:Literal ID="litMensaje" runat="server" />
            </td>
            <td class="style4" __designer:mapid="863">
            </td>
        </tr>
        <tr __designer:mapid="864">
            <td class="style2" __designer:mapid="865">
                <asp:Label ID="Label5" runat="server" Text="Servicio"></asp:Label>
            </td>
            <td __designer:mapid="867">
                <asp:DropDownList ID="dwService" runat="server">
                </asp:DropDownList>
            </td>
            <td __designer:mapid="869">
                                    &nbsp;
                                </td>
        </tr>
        <tr __designer:mapid="86a">
            <td class="style2" __designer:mapid="86b">
                <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
            </td>
            <td __designer:mapid="86d">
                <asp:TextBox ID="txtDescription" runat="server" Width="342px"></asp:TextBox>
            </td>
            <td __designer:mapid="86f">
                                    &nbsp;
                                </td>
        </tr>
        <tr __designer:mapid="870">
            <td class="style2" __designer:mapid="871">
                                    Buscar Paciente
                                </td>
            <td __designer:mapid="872">
                <table __designer:mapid="873">
                    <tr __designer:mapid="874">
                        <td __designer:mapid="875">
                            <asp:DropDownList ID="ddlDocumentType" runat="server" AppendDataBoundItems="True"
                                                    Width="100px">
                                <asp:ListItem>Dni</asp:ListItem>
                                <asp:ListItem Value="PAS">Pasaporte</asp:ListItem>
                                <asp:ListItem Value="CEX">Carnet de Extranjería</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td __designer:mapid="87a">
                                                DNI:
                                            </td>
                        <td __designer:mapid="87b">
                            <asp:TextBox ID="txtDni" runat="server" Width="100px" MaxLength="8" />
                        </td>
                        <td __designer:mapid="87d">
                            <asp:TextBox ID="txtPacient" runat="server" Width="339px"></asp:TextBox>
                        </td>
                        <td __designer:mapid="87f">
                            <asp:LinkButton runat="server" ID="lnkSearch" Text="Buscar" 
                                                    OnClick="lnkSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td __designer:mapid="881">
                                    &nbsp;
                                </td>
        </tr>
        <tr __designer:mapid="882">
            <td class="style2" __designer:mapid="883">
                                    Moneda</td>
            <td __designer:mapid="884">
                <asp:DropDownList ID="ddlCurrency" runat="server" AppendDataBoundItems="True" 
                                        Width="50px">
                    <asp:ListItem>USD</asp:ListItem>
                    <asp:ListItem Value="PEN">PEN</asp:ListItem>
                    <asp:ListItem>EUR</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td __designer:mapid="889">
                                    &nbsp;</td>
        </tr>
        <tr __designer:mapid="88a">
            <td class="style2" __designer:mapid="88b">
                                    Precio Total</td>
            <td __designer:mapid="88c">
                <asp:TextBox ID="TextBox1" runat="server" Width="89px"></asp:TextBox>
            </td>
            <td __designer:mapid="88e">
                                    &nbsp;</td>
        </tr>
        <tr __designer:mapid="88f">
            <td class="style2" __designer:mapid="890">
                <asp:Label ID="Label3" runat="server" Text="N° de Sesiones"></asp:Label>
            </td>
            <td __designer:mapid="892">
                <asp:Button ID="btnAddSessions" runat="server" onclick="btnAddSessions_Click" 
                                        Text="Agregar" />
            </td>
            <td __designer:mapid="896">
                                    &nbsp;
                                </td>
        </tr>
        <tr __designer:mapid="897">
            <td class="style2" __designer:mapid="898">
                                    &nbsp;
                                </td>
            <td __designer:mapid="899">
            </td>
            <td __designer:mapid="89a">
                                    &nbsp;
                                </td>
        </tr>
        <tr __designer:mapid="89b">
            <td class="style2" __designer:mapid="89c">
                                    &nbsp;
                                </td>
            <td __designer:mapid="89d">
                <asp:Label ID="Label6" runat="server" Text="Sesiones"></asp:Label>
            </td>
            <td __designer:mapid="89f">
                                    &nbsp;
                                </td>
        </tr>
        <tr __designer:mapid="8a0">
            <td class="style2" __designer:mapid="8a1">
                                    &nbsp;
                                    s</td>
            <td __designer:mapid="8a2">
                <asp:GridView ID="gvSessions" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" DataKeyNames="Id">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Descripcion">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDescripcion" runat="server"  Text='<%# Eval("Description") %>' 
                                                     with="100px" MaxLength="250">
                                            </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Currency" HeaderText="Moneda" />
                        <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                        <asp:TextBox ID="txtPrecio" runat="server" >
                        </asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Account" HeaderText="Acuenta" />
                        <asp:BoundField DataField="Residue" HeaderText="Saldo" />
                        <asp:TemplateField HeaderText="Completa">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsCompleted" runat="server" 
                                                        Checked = '<%# Eval("IsCompleted") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pagada">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsPaid" runat="server" Checked = '<%# Eval("IsPaid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" runat="server" 
                                                        Enabled = '<%# Request.QueryString.Get("action") == "new" ? false : true %>' 
                                                        
                                    NavigateUrl='<%# string.Format("EditSession.aspx?id={0}",Eval("Id")) %>'>Quitar</asp:HyperLink>
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
            <td __designer:mapid="8c4">
                                    &nbsp;
                                </td>
        </tr>
        <tr __designer:mapid="8c5">
            <td class="style2" __designer:mapid="8c6">
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" 
                                        Text="Aceptar" />
            </td>
            <td __designer:mapid="8c8">
                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" 
                                        Text="Cancelar" />
            </td>
            <td __designer:mapid="8ca">
                                    &nbsp;
                                </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
    </asp:Content>