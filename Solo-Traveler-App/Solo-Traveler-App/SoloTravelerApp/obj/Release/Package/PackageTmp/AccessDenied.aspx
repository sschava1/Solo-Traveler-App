<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="SoloTravelerApp.AccessDenied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Access Denied Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
        <DynamicHoverStyle BackColor="#6699FF" />
        <Items>
            <asp:MenuItem NavigateUrl="PublicPage.aspx" Text="Home " Value="Home"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="locationinfo.aspx" Text="| Location Information" Value="Location Information"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="EmployeeUpdatePage.aspx" Text="| Update Information" Value="Update Information"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="PromotDemotePage.aspx" Text="| Promote/Demote" Value="Promote/Demote"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="LogOutPage.aspx" Text="LOGOUT" Value="| LOGOUT"></asp:MenuItem>
        </Items>
            </asp:Menu>
    <hr />
    <hr />
        <h1>Access Denied</h1>
    <br/>
    <h3>You dont have enough rights to gain the access of this page</h3>
    </form>
</body>
</html>
