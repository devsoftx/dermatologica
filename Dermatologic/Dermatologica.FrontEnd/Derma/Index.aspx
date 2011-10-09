<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Derma_Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <p>
        Bienvenido <asp:Literal ID="litUserName" runat="server" /> para actualizar sus datos haga click <asp:LinkButton runat="server" ID="lnkUser">aquí</asp:LinkButton>
    </p>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>