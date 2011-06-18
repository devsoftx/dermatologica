<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="EditMenu.aspx.cs" Inherits="Derma_Admin_EditMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <asp:Literal ID="litMensaje" runat="server" />
    </div>
    <div id = "main">        
        <table cellpadding="1" cellspacing="1">
            <tr>
                <td><asp:Label Text = "Padre" runat="server" ID="Label2" /></td>
                <td><asp:DropDownList ID="ddlMenuPadre" runat="server" AppendDataBoundItems="True" 
                        Width="100px"/></td>
                <td><asp:CheckBox ID="CheckBox1" runat="server" Text = "Es Padre" 
                        oncheckedchanged="CheckBox1_CheckedChanged" AutoPostBack="True" /></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Label Text = "Nombre" runat="server" ID="lblNombre" /></td>
                <td><asp:TextBox runat="server" ID="txtNombre" /></td>
                <td><asp:RequiredFieldValidator ID="rfvLogin" runat="server" ErrorMessage="*" 
                        ControlToValidate="txtNombre"></asp:RequiredFieldValidator></td>        
                <td></td>        
            </tr>
            <tr>
                <td><asp:Label Text = "Descripción" runat="server" ID="Label3" /></td>
                <td><asp:TextBox runat="server" ID="txtDescription" /></td>
                <td></td>        
                <td></td>        
            </tr>
            <tr>
                <td><asp:Label Text = "Url" runat="server" ID="lblUrl" /></td>
                <td><asp:TextBox runat="server" ID="txtUrl" /></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Label Text = "Orden" runat="server" ID="Label1" /></td>
                <td><asp:TextBox runat="server" ID="txtOrder" /></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
    <div style="width:150px; height:20px;">        
        <div style="float:left;"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click" /></div>
        <div><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" /></div>
    </div>
</asp:Content>

