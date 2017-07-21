<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeUpdatePage.aspx.cs" Inherits="SoloTravelerApp.EmployeeUpdatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Information Update Page</title>
    <link href="assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" align="center" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <DynamicHoverStyle BackColor="#6699FF" />
            <Items>
                <asp:MenuItem NavigateUrl="PublicPage.aspx" Text="Home" Value="Home "></asp:MenuItem>
                <asp:MenuItem NavigateUrl="locationinfo.aspx" Text="| Location Information" Value="Location Information"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="EmployeeUpdatePage.aspx" Text="| Update Information" Value="Update Information"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="PromotDemotePage.aspx" Text="| Promote/Demote" Value="Promote/Demote"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="LogOutPage.aspx" Text="LOGOUT" Value="| LOGOUT"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <hr />
        <hr />
        <div id="header">
            <h1>Welcome to the Solo Traveler App Employee</h1>
            <h3>You can use this page to get information regarding the users that are registered to this page.</h3>
            <h3>You can also update the particular attributes of the user.</h3>
        </div>
        <div>
            <asp:Label ID="UserTable" runat="server" Text=""></asp:Label>
        </div>
        <hr />
        <div>
            <asp:Label ID="IdLabel" runat="server" Text="Id: "></asp:Label>
            <asp:TextBox ID="IdInput" runat="server"></asp:TextBox>
            <asp:Label ID="ColumnLabel" runat="server" Text=" Column: "></asp:Label>
            <asp:DropDownList ID="ColumnDDList" runat="server">
            </asp:DropDownList>
            <asp:Label ID="ValueLabel" runat="server" Text=" Value: "></asp:Label>
            <asp:TextBox ID="ValueInput" runat="server"></asp:TextBox>
        </div>
        <hr />
        <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" style="height: 29px" />
        <div>
            <asp:Label ID="OutputResp" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
