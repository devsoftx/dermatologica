<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true" CodeFile="StaffInformation.aspx.cs" Inherits="Derma_Admin_StaffInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 28px;
        }
        .style3
        {
            width: 273px;
            text-align: right;
        }
        .style4
        {
            width: 169px;
        }
        .style5
        {
            width: 470px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtJoinDate").datepicker();
            $("#MainContent_txtJoinDate").datepicker($.datepicker.regional['es']);
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Main ">
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Fecha de Ingreso"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtJoinDate" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Salario Neto Mensual"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtNetMonthlySalary" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="Hora Extra"></asp:Label>
                </td>
                <td class="style4">
                                            <asp:TextBox ID="txtOvertimePay" runat="server" 
                        Width="97px"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Tipo de Empleado"></asp:Label>
                </td>
                <td class="style4">
                                                 
                    <asp:DropDownList ID="ddlEmployeeType" runat="server" Width="83px">
                    </asp:DropDownList>
                               </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label6" runat="server" Text="Tipo de Contrato"></asp:Label>
                </td>
                <td class="style4">
                                                 
                    <asp:DropDownList ID="ddlTypeContract" runat="server" Width="130px">
                    </asp:DropDownList>
                               </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label1" runat="server" Text="Centro de Costo"></asp:Label>
                </td>
                <td class="style4">
                                                 
                    <asp:DropDownList ID="ddlCostCenter" runat="server" Width="83px">
                    </asp:DropDownList>
                               </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Literal runat="server" ID="litMensajes" />
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                                    onclick="btnAceptar_Click" />
                </td>
                <td class="style4">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                    onclick="btnCancelar_Click" />
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" Runat="Server">
</asp:Content>