<%@ Page MasterPageFile="~/MasterPage.master" Title="CFA"%>

<asp:Content ContentPlaceHolderID="CPH1" runat="server">
    <h1 class="pageHeader">College of Fine Arts</h1>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM Users WHERE school = 'CFA' AND photo = 'true'">
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