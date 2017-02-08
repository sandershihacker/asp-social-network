<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" MasterPageFile="~/MasterPage.master" Title="Login"%>

<asp:Content ContentPlaceHolderID="CPH1" runat="server">
    <h1 class="pageHeader">Log in</h1>
    <br />
    <div class="text-center">
        <asp:RequiredFieldValidator ForeColor="Red" ID="IDvalidate" runat="server" ControlToValidate="andrewID" ErrorMessage="Andrew ID required!" Text="*" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
        Andrew ID:
        <asp:TextBox ID="andrewID" runat="server"></asp:TextBox>
        <br /><br /><br />
        <asp:RequiredFieldValidator ForeColor="Red" ID="Passvalidate" runat="server" ControlToValidate="password" ErrorMessage="Password required!" Text="*" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
        Password:
        <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
        <br /><br /><br />
        <asp:Button OnClick="Submit" Text="Sign in" runat="server" CssClass="mabutton" />
        <br /><br />
        <asp:ValidationSummary ForeColor="Red" ID="loginvs" runat="server" HeaderText="" DisplayMode="List" />
        <br /><br />
        <p class="errorMessage">
            <asp:Label ID="checkID" runat="server"></asp:Label>
            <asp:Label ID="checkPass" runat="server"></asp:Label>
        </p>
        <a href="Register.aspx" class="malink">Don't have an account? Click here to sign up!</a>
    </div>
</asp:Content>