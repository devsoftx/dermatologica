<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="UsersInRoles.aspx.cs" Inherits="Derma_Admin_UsersInRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <asp:Literal ID="litMensaje" runat="server" />
    </div>
    <div id = "main">     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td><asp:Label Text = "Rol" runat="server" ID="Label2" /></td>
                        <td><asp:DropDownList ID="ddlRole" runat="server" AppendDataBoundItems="True" 
                                Width="100px" AutoPostBack="True" 
                                onselectedindexchanged="ddlRole_SelectedIndexChanged"/></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Label Text = "Nombre" runat="server" ID="lblNombre" /></td>
                        <td><asp:TextBox runat="server" ID="txtNombre" ReadOnly="True" /></td>
                        <td></td>        
                        <td></td>        
                    </tr>
                    <tr>
                        <td><asp:Label Text = "Descripción" runat="server" ID="lblUrl" /></td>
                        <td><asp:TextBox runat="server" ID="txtDescription" ReadOnly="True" /></td>
                        <td></td>
                        <td></td>
                    </tr>            
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlRole" EventName="SelectedIndexChanged">
                </asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        
    </div>
    <div style="width:150px; height:20px;">        
        <div style="float:left;"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click" /></div>
        <div><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" /></div>
    </div>
</asp:Content>

