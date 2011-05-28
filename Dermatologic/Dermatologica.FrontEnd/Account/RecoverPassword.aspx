<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="Account_RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <asp:Literal ID="litMensaje" runat="server" />
    </div>
    <div id="main">
        <table cellpadding="1" cellspacing="1">
            <tr>
                <td><asp:Label Text = "Nombre de Usuario" runat="server" ID="lblLogin" /></td>
                <td><asp:TextBox runat="server" ID="txtLogin" ReadOnly="false" /></td>
                <td><asp:RequiredFieldValidator ID="rfvLogin" runat="server" ErrorMessage="*" 
                        ControlToValidate="txtLogin"></asp:RequiredFieldValidator></td>        
                <td></td>        
            </tr>            
        </table>
    </div>
    <div style="width:150px; height:20px;">        
        <div style="float:left;"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click" /></div>
        <div><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" /></div>
    </div>
</asp:Content>

