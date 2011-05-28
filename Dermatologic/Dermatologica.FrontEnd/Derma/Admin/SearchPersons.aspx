<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Admin/Popup.master" AutoEventWireup="true" CodeFile="SearchPersons.aspx.cs" Inherits="Derma_SearchPersons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main">
        <div>
            <asp:Literal ID="litMensaje" runat="server" Text="Pacientes" />
        </div>        
        <div>
            <div>
                <div><asp:Literal runat="server" ID = "lblSearch" Text="Buscar por Nombres:"/></div>
                <div><asp:TextBox runat="server" ID = "txtSearch"/></div>
                <div><asp:Button runat="server" ID ="btnSearch" Text="Buscar" 
                        onclick="btnSearch_Click" /></div>
            </div>
            <div>
                <asp:GridView ID="gvPersons" runat="server" AutoGenerateColumns="False" 
                onrowcommand="gvPersons_RowCommand" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="Nombres" />                                        
                    <asp:BoundField DataField="LastName" HeaderText="Apellidos" />                                        
                    <asp:BoundField DataField="DateBirthDay" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha de Cumpleaños" />                                                       
                    <asp:BoundField DataField="Email" HeaderText="Correo" />                                        
                    <asp:BoundField DataField="LastActivityDate" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha de Creación" />                                                       
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
        </div>        
    </div>
</asp:Content>