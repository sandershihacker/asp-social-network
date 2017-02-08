<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Manager_Default" MasterPageFile="~/MasterPage.master" Title="Manage"%>

<asp:Content ContentPlaceHolderID="CPH1" runat="server">
    <h1 class="pageHeader">Manager</h1>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                SelectCommand="SELECT * FROM Users">
    </asp:SqlDataSource>
    <div class="theTablea">
        <table class="theTable">
            <thead>
                <tr>
                    <td>Andrew ID</td>
                    <td>ID</td>
                    <td>Name</td>
                    <td>School</td>
                    <td>Photo Upload</td>
                    
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("AndrewId") %></td>
                            <td><%#Eval("Id") %></td>
                            <td><%#Eval("name")%></td>
                            <td><%#Eval("school")%></td>
                            <td><%#Eval("photo")%></td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>       
    </div>
    <br />
    <p class="pageParagraph">
        <asp:Label runat="server" ID="numUser"></asp:Label>
    </p>
    

    <asp:Panel ID="managerPanel" runat="server">
        <hr/>
        <br />
        <p class="text-center">The ID number:</p>
    
        <asp:TextBox CssClass="center-block" runat="server" ID="theIdNumber"></asp:TextBox>
        <br />    
        <p class="errorMessage text-center">
            <asp:Label ID="err" runat="server"></asp:Label>
        </p>
        <br />
        <asp:Button runat="server" Text="Delete Pic" OnClick="DelPic" CssClass="mabutton center-block" />
        <br />
        <asp:Button runat="server" Text="Delete User" OnClick="DelUser" CssClass="mabutton center-block" />

        <hr/>

        <asp:Repeater runat="server" ID="wallRepeater">
            <ItemTemplate>
                <p class="pageParagraph text-danger"><%# getFullName(Eval("Sender").ToString()) + "to " + getFullName(Eval("Receiver").ToString())%>:</p>
                <p class="pageParagraph"><%#Eval("Content")%></p>
                <p class="pageParagraph" style="text-align:right;"><%#Eval("Time")%></p>
                <hr />
            </ItemTemplate>
        </asp:Repeater>    

    </asp:Panel>
    <br />
        
   
</asp:Content>

