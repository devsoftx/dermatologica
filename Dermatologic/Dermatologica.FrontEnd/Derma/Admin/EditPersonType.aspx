<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="EditPersonType.aspx.cs" Inherits="Derma_Admin_EditPersonType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="Main">
        <table>
            <tr>
                <td>
                </td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;"
                    colspan="2">
                    Mantenimiento de Categoria/Función
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
                    <asp:Label ID="Label1" runat="server" Style="text-align: right" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="184px"></asp:TextBox>
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
                    <asp:Label ID="Label2" runat="server" Style="text-align: right" Text="Descripcion"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="499px"></asp:TextBox>
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
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
