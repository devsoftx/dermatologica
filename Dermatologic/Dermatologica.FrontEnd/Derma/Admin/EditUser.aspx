<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"CodeFile="EditUser.aspx.cs"Inherits="Derma_Admin_EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .row_left
        {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="main">
        <div>
            <table width="100%" align="right">
                <tr>
                    <td align="right" class="row_left" >
                        <asp:Label ID="LblTextUpdate" runat="server" AssociatedControlID="UserName"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="row_left">
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="wizardUser">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="row_left">
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="wizardUser">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="row_left">
                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                            ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                            ValidationGroup="wizardUser">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="row_left">
                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                            ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="wizardUser">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="row_left">
                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                            ErrorMessage="Security question is required." ToolTip="Security question is required."
                            ValidationGroup="wizardUser">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="row_left">
                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                            ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                            ValidationGroup="wizardUser">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="row_left" >
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                            ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                            ValidationGroup="wizardUser"></asp:CompareValidator>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="color: Red;" class="row_left">
                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td  align="right" class="row_left">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
