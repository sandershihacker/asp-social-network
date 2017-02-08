<%@ Page Title="SCS" MasterPageFile="~/MasterPage.master" Language="C#"%>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <h1 class="pageHeader">School of Computer Science</h1>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM Users WHERE school = 'SCS' AND photo = 'true'">
        </asp:SqlDataSource>
            <div class="profileWrapper center-block">
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <a href="<%# String.Format("/Account/Person.aspx?p={0}",Eval("Id")) %>">
                            <div class="profile text-center">
                                <div class="profilePicture" style="background-image:url(Account/ProfilePictures/<%#Eval("id")%>.jpg);"></div>
                                <p class="nameOfPerson"><%#Eval("name")%></p>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            
    </div>
    <br style="clear:both;" />
</asp:Content>

