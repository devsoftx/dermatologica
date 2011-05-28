<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="EditRole.aspx.cs" Inherits="Derma_Admin_EditRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
        <asp:Literal ID="litMensaje" runat="server" />
    </div>
    <div id = "main">        
        <table cellpadding="1" cellspacing="1">
            <tr>
                <td><asp:Label Text = "Rol" runat="server" ID="lblLogin" /></td>
                <td><asp:TextBox runat="server" ID="txtRolName" /></td>
                <td><asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ErrorMessage="*" 
                        ControlToValidate="txtRolName"></asp:RequiredFieldValidator></td>        
                <td></td>        
            </tr>            
            <tr>
                <td><asp:Label Text = "Descripción" runat="server" ID="Label1" /></td>
                <td><asp:TextBox runat="server" ID="txtDescripción" /></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" 
                        ControlToValidate="txtDescripción"></asp:RequiredFieldValidator></td>        
                <td></td>        
            </tr>            
        </table>
    </div>
    <div style="width:150px; height:20px;">        
        <div style="float:left;"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                onclick="btnAceptar_Click" style="height: 26px" /></div>
        <div><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" /></div>
    </div>
</asp:Content>

