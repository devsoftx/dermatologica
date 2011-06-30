<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="EditOffice.aspx.cs"Inherits="Derma_Admin_EditOffice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://vivasky.com/labs/icolor/js/jquery.icolor.min.js"></script>
    <style type="text/css">
        .icolor
        {
            position: absolute;
        }
        .icolor_flat, .icolor_ft
        {
            position: relative;
        }
        .icolor td
        {
            width: 15px;
            height: 15px;
            border: solid 1px #000000;
            cursor: pointer;
        }
        .icolor table
        {
            background-color: #FFFFFF;
            border: solid 1px #ccc;
        }
        .icolor .icolor_tbx
        {
            width: 170px;
            border-top: 1px solid #999;
            border-left: 1px solid #ccc;
            border-right: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
        }
        .icolor_ok img
        {
            border: none;
        }
        .icolorC, h2
        {
            width: 500px;
            margin: 80px auto;
        }
        #icolor3 .icolor_tbx
        {
            width: 154px;
            padding-right: 16px;
        }
        #icolor3 .icolor_ok
        {
            position: absolute;
            left: 154px;
            top: 50%;
            margin-top: -8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="Main">
        <table>
            <tr>
                <td>
                </td>
                <td style="font-weight: bold; background-color: #006699; color: #FFFFFF; text-align: center;"
                    colspan="2">
                    Mantenimiento de Oficinas/Consultorios
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
                    <asp:Label ID="Label3" runat="server" Style="text-align: right" Text="Color"></asp:Label>
                </td>
                <td>
                    <div class="icolorC">
                        <asp:TextBox ID="txtColor" runat="server" Width="50px"></asp:TextBox>
                    </div>
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
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
    <script type="text/javascript">
        $("#MainContent_txtColor").icolor({
            onSelect: function (c) {
                this.$tb.css("background-color", c);
                this.$t.val(c);
            },
            showInput: true
        });	            
    </script>
</asp:Content>
