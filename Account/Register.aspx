<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" MasterPageFile="~/MasterPage.master" Title="Register"%>

<asp:Content ContentPlaceHolderID="CPH1" runat="server">

    <h1 class="pageHeader">Register Account</h1>
    <br />
    <div class="text-center">
        <asp:RequiredFieldValidator ForeColor="Red" ID="idvalidate" runat="server" ControlToValidate="andrewID" ErrorMessage="We need your Andrew ID." Text="*" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
        Andrew ID: 
        <asp:TextBox ID="andrewID" runat="server"></asp:TextBox>
        <br/><br/>
        <asp:RequiredFieldValidator ForeColor="Red" ID="namevalidate" runat="server" ControlToValidate="name" ErrorMessage="You don't have a name!?" Text="*" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
        Full Name: 
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <br/>
        <br />
        <p class="text-center text-danger">Warning: It is strongly recommended that you use a different password from the one you use on the SIO.</p>
        <br/>
        <asp:RequiredFieldValidator ForeColor="Red" ID="passvalidate" runat="server" ControlToValidate="password" ErrorMessage="You know what passwords are for right?" Text="*" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
        Password: 
        <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
        <br /><br />
        <asp:RequiredFieldValidator ForeColor="Red" ID="pass2validate" runat="server" ControlToValidate="password1" ErrorMessage="Type the password twice to guarentee that you haven't made a typo." Text="*" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
        Re-type password: 
        <asp:TextBox ID="password1" TextMode="Password" runat="server"></asp:TextBox>
        <br/><br/>
        <asp:RequiredFieldValidator ForeColor="Red" ID="hometownvalidate" runat="server" ControlToValidate="hometown" ErrorMessage="Please fill in your hometown." Text="*" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
        Hometown: 
        <asp:TextBox ID="hometown" runat="server"></asp:TextBox>
        <br /><br />
        <asp:RequiredFieldValidator ForeColor ="Red" ID="schoolvalidate" runat ="server" ControlToValidate="schools" ErrorMessage="Please select a school." Text="*" SetFocusOnError ="true" EnableClientScript="true" InitialValue="none"></asp:RequiredFieldValidator>
        School: 
        <asp:DropDownList ID="schools" runat="server">
            <asp:ListItem Text="---------Select School---------" Value="none"></asp:ListItem>
            <asp:ListItem Text="College of Fine Arts" Value="CFA"></asp:ListItem>
            <asp:ListItem Text="Carnegie Institute of Technology" Value="CIT"></asp:ListItem>
            <asp:ListItem Text="Dietrich College" Value="DC"></asp:ListItem>
            <asp:ListItem Text="Mellon College of Science" Value="MCS"></asp:ListItem>
            <asp:ListItem Text="School of Computer Science" Value="SCS"></asp:ListItem>
            <asp:ListItem Text="Tepper School of Business" Value="Tepper"></asp:ListItem>
        </asp:DropDownList> 
        <br /><br />
        <asp:RequiredFieldValidator ForeColor ="Red" ID="classvalidate" runat ="server" ControlToValidate="classYear" ErrorMessage="Please select the class." Text="*" SetFocusOnError ="true" EnableClientScript="true" InitialValue="none"></asp:RequiredFieldValidator>
        Class: 
        <asp:DropDownList ID="classYear" runat="server">
            <asp:ListItem Text="---Select Class Year---" Value="none"></asp:ListItem>
            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
        </asp:DropDownList> 
        <asp:ValidationSummary ID="RegisterValidationSummary" runat="server" ForeColor="Red" HeaderText="Fix the following error(s), please." DisplayMode="List" />
        <p class="errorMessage">
            <asp:Label ID="pwCheck" runat="server"></asp:Label>
            <asp:Label ID="IDCheck" runat="server"></asp:Label>
            <asp:Label ID="tooLong" runat="server"></asp:Label>
        </p>
        <br /><br />
        <asp:Button CssClass="mabutton" OnClick="Submit" Text="Submit" runat="server" />
        <br />
        <br />
    </div>
</asp:Content>