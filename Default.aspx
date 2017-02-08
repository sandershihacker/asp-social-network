<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Default.aspx.cs" Inherits="Default" Title="Home" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="CPH1" runat="server">
    <h1 class="pageHeader">The Social Hub</h1>
    <div class="frontPic"></div>
    <asp:Panel ID="guestPanel" runat="server">
        <p class="pageParagraph">
            Welcome to The Social Hub! Through the Social Hub, you will be able to 
            get to know people around school, and put faces to the names of the names
            that you are vaguely familiar with. This is a great opportunity for newly 
            admitted students to get to know potential classmates, best friends, roommates,
            and perhaps even girlfriends and boyfriends! Please 
            <a class="malink" href="Account/Register.aspx">sign up</a> if using for 
            the first time, <a class="malink" href="Account/Login.aspx">login</a> otherwise.
        </p>   
    </asp:Panel>
    <asp:Panel runat="server" ID="userPanel">
        <p class="pageParagraph">
            Welcome to The Social Hub, <%=getName() %>! Feel free to check out your future 
            classmates' profiles through the tabs in the navigation bar! Don't forget to 
            upload your own profile picture on the <a class="malink" href="Account/MyPage.aspx">MyPage</a>
            page! Remember, your profile will not show on the site until you upload your photo!
        </p>
    </asp:Panel>
    <p class="pageParagraph text-danger">
        There are currently <%= getTotUsers() %> registered users, and <%= getPhotoUsers() %> of them have uploaded their photo.
        Log in and check their profiles by clicking on their profile pictures!
    </p>
    
</asp:Content>