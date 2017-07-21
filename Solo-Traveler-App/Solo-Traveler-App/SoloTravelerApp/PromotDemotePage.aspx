<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PromotDemotePage.aspx.cs" Inherits="SoloTravelerApp.PromotDemotePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Promote / Demote Page</title>
    <link href="assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" align="center" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <DynamicHoverStyle BackColor="#6699FF" />
            <Items>
                <asp:MenuItem NavigateUrl="PublicPage.aspx" Text="Home " Value="Home"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="locationinfo.aspx" Text="| Location Information" Value="Location Information"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="EmployeeUpdatePage.aspx" Text="| Update Information" Value="Update Information"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="PromotDemotePage.aspx" Text="| Promote/Demote" Value="Promote/Demote"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="LogOutPage.aspx" Text="| LOGOUT" Value="LOGOUT"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <hr />
        <hr />
        <div id="header">
            <h1>Welcome to the Solo Traveler App Admin</h1>
            <h3>You can use this page to promote or demote a user or another staff or yourself</h3>
            <h3>Enter the Id of the person you want promote or demote.</h3>
            <h3>You can also demote yourself, but remember, you will no longer have access to this page.</h3>
            <h3>For access reasons, if there is only one Admin or Employee left, the promotion or demotion will not take place.</h3>
        </div>
            <div>
            <asp:Label ID="UserEmployeTable" runat="server" Text=""></asp:Label>
        </div>
        <hr />
        <div>
            <asp:Label ID="IdLabel" runat="server" Text="Id: "></asp:Label>
            <asp:TextBox ID="IdInput" runat="server"></asp:TextBox>
            <asp:Label ID="PromDemLabel" runat="server" Text="Promote/Demote: "></asp:Label>
            <asp:DropDownList ID="RoleDDList" runat="server">
            </asp:DropDownList>
        </div>
        <hr />
        <asp:Button ID="PromDemButton" runat="server" Text="Promote/Demote" OnClick="PromDemButton_Click" />
        <div>
            <asp:Label ID="OutputResp" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
