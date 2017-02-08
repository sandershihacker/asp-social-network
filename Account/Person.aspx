<%@ Page Title="Profile" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Person.aspx.cs" Inherits="Account_Person"%>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <h1 class="pageHeader">
        <asp:Label ID="Welcome" runat="server"></asp:Label>
    </h1>
    <div class="myProfile text-center center-block">
        <div class="profilePicture" style='background-image:url(<%=getImageUrl()%>)'></div>
        <p class="nameOfPerson"><%=getMyName()%></p>
    </div>
    <asp:Button runat="server" ID="displayInfo" OnClick="displayInfo_Click" Text="Personal Info" CssClass="mabutton center-block" />
    <asp:Button runat="server" ID="displayWall" OnClick="displayWall_Click" Text="Wall" CssClass="mabutton center-block" />
    <hr />
    <asp:Panel runat="server" ID="information">
        <p class="pageParagraph text-danger">Contact Information:</p>
        <br />
        <p class="pageParagraph">
            <asp:Label runat="server" ID="contactInfo"></asp:Label>
        </p>
        <hr />

        <p class="pageParagraph text-danger">Class:</p>
        <br />
        <p class="pageParagraph">
            <asp:Label runat="server" ID="classYear"></asp:Label>
        </p>
        <hr />

        <p class="pageParagraph text-danger">Hometown:</p>
        <br />
        <p class="pageParagraph">
            <asp:Label runat="server" ID="hometownLabel"></asp:Label>
        </p>
        <hr />

        <p class="pageParagraph text-danger">Self-introduction:</p>
        <br />
        <p class="pageParagraph">
            <asp:Label runat="server" ID="selfIntro"></asp:Label>
        </p>
    </asp:Panel>
    <asp:Panel runat="server" ID="wall">
        <asp:Repeater runat="server" ID="wallRepeater">
            <ItemTemplate>
                <p class="pageParagraph text-danger"><%# getFullName(Eval("Sender").ToString())%>:</p>
                <p class="pageParagraph"><%#Eval("Content")%></p>
                <p class="pageParagraph" style="text-align:right;"><%#Eval("Time")%></p>
                <hr />
            </ItemTemplate>
        </asp:Repeater>    
        <p class="text-danger pageParagraph">Feel free to leave a comment or question below:</p>
        <asp:TextBox runat="server" ID="commentBox" TextMode="MultiLine" CssClass="textArea center-block"></asp:TextBox>
        <br />
        <p class="errorMessage text-center">
            <asp:Label ID="contentError" runat="server"></asp:Label>
        </p>
        <asp:Button runat="server" ID="postComment" CssClass="mabutton center-block" Text="Post" OnClick="postComment_Click" />
    </asp:Panel>
    <br />

</asp:Content>

