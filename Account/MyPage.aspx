<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeFile="MyPage.aspx.cs" Inherits="Account_MyPage" MasterPageFile="~/MasterPage.master" Title="MyPage"%>

<asp:Content ContentPlaceHolderID="CPH1" runat="server">

    
    <h1 class="pageHeader">
        <asp:Label ID="Welcome" runat="server"></asp:Label>
    </h1>
    <asp:Panel runat="server" ID="photoFalse" CssClass="text-center">
        <p class="pageParagraph">
            Please upload a square or near-square picture of yourself, and make sure that your face is in the middle. 
            Failure to upload a picture of yourself will result in <font color="red">deletion</font> of your profile picture.
        </p>
        <br />
        <asp:FileUpload CssClass="center-block" runat="server" ID="loadPicture" BorderStyle="None" />
        <br /><br />
        <asp:Button CssClass="mabutton" ID="uploadPicture" OnClick="uploadPicture_Click" Text="Upload" runat="server" />
    </asp:Panel>
    <asp:Panel runat="server" ID="photoTrue" CssClass="text-center">
        <div class="myProfile text-center center-block">
            <div class="profilePicture" style='background-image:url(<%= imageUrl%>)'></div>
            <p class="nameOfPerson"><%=getMyName()%></p>
        </div>
        Change profile picture:
        <br />
        <asp:FileUpload CssClass="center-block" runat="server" ID="loadNewPicture" BorderStyle="None" />
        <br /><br />
        <asp:Button CssClass="mabutton" ID="uploadNewPicture" OnClick="uploadNewPicture_Click" Text="Upload" runat="server" />
    </asp:Panel>
    <p class="errorMessage text-center">
        <asp:Label ID="errorMessage" runat="server"></asp:Label>
    </p>
    <asp:Panel runat="server" ID="managerPage" CssClass="text-center">
        <asp:Button runat="server" CssClass="mabutton" ID="Manage" Text="Manage" OnClick="goManage" />
    </asp:Panel>

    <br /><br />

    <hr />
    <p class="pageParagraph text-center">Self-introduction:</p>
    <asp:TextBox ID="textbox" runat="server" TextMode="MultiLine" CssClass="center-block textArea"></asp:TextBox>
    <br />
    <p class="errorMessage text-center">
        <asp:Label ID="textAreaError" runat="server"></asp:Label>
    </p>
    <br />
    <asp:Button runat="server" CssClass="mabutton center-block" ID="PostIntro" Text="Save Intro" OnClick="Save_Intro" />
    
    <hr />
    <p class="pageParagraph text-center">Contact Information:</p>
    <asp:TextBox ID="contactInfo" runat="server" TextMode="MultiLine" CssClass="center-block contactText"></asp:TextBox>
    <br />
    <p class="errorMessage text-center">
        <asp:Label ID="contactError" runat="server"></asp:Label>
    </p>
    <br />
    <asp:Button runat="server" CssClass="mabutton center-block" ID="postContactInfo" Text="Save Info" OnClick="Save_Info" />

    <br />

    <hr />
    <p class="pageParagraph text-center">Account Information:</p>
    <br />
    <p class="pageParagraph text-center">Update Name:</p>
    <asp:TextBox ID="newName" runat="server" CssClass="center-block"></asp:TextBox>
    <br />
    <p class="errorMessage text-center">
        <asp:Label ID="nameError" runat="server"></asp:Label>
    </p>
    <br />
    <asp:Button runat="server" CssClass="mabutton center-block" ID="changeName" Text="Update Name" OnClick="Update_Name" />

    <br />
    <p class="pageParagraph text-center">Hometown:</p>
    <asp:TextBox ID="hometownTextBox" runat="server" CssClass="center-block"></asp:TextBox>
    <br />
    <p class="errorMessage text-center">
        <asp:Label ID="hometownError" runat="server"></asp:Label>
    </p>
    <br />
    <asp:Button runat="server" CssClass="mabutton center-block" ID="hometownButton" Text="Update Hometown" OnClick="hometownButton_Click" />


    <br />
    <p class="pageParagraph text-center">Change Password:</p>
    <p class="pageParagraph text-center">Old Password:</p>
    <asp:TextBox ID="oldPass" TextMode="Password" runat="server" CssClass="center-block"></asp:TextBox>
    <br />
    <p class="pageParagraph text-center">New Password:</p>
    <asp:TextBox ID="newPass1" TextMode="Password" runat="server" CssClass="center-block"></asp:TextBox>
    <br />
    <p class="pageParagraph text-center">Enter again:</p>
    <br />
    <asp:TextBox ID="newPass2" TextMode="Password" runat="server" CssClass="center-block"></asp:TextBox>
    <p class="errorMessage text-center">
        <asp:Label ID="passError" runat="server"></asp:Label>
    </p>
    <br />
    <asp:Button runat="server" CssClass="mabutton center-block" ID="updatePass" Text="Update Password" OnClick="Update_Pass" />


    <br />

</asp:Content>