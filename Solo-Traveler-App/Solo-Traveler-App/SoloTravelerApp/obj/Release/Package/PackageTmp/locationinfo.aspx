<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="locationinfo.aspx.cs" Inherits="SoloTravelerApp.locationinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Location Information</title>
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="assets/javascript/locinfo.js"></script>
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
            <h1>Welcome to the Solo Traveler App</h1>
            <h3>You can use this page to get information regarding the destination you wish to travel.</h3>
            <h3>Enter the zip code to retrieve the recent criminal activities from the area. So you can reckon, how safe is your planned destination.</h3>
            <h3>Enter the date you wish to travel, and get the weather forecast of the destination on that date.</h3>
            <h3>Search for the convenience stores near the destination, in order to get an idea of what you need to carry and what you can risk leaving behind.</h3>
        </div>
        <div id ="Information" >

            
            <asp:TextBox ID="ZipcodeInput" runat="server" placeholder ="Zipcode"></asp:TextBox>

            <asp:TextBox ID="DateInput" class="datepicker" runat="server" placeholder ="Date"></asp:TextBox>

            <asp:Button ID="RetrieveButton" runat="server" Text="Submit" OnClick="RetrieveButton_Click" />
                        
        </div>
        <div id ="Crime_Weather" runat ="server">
                <asp:Label ID="CrimeDataOutput" runat="server" Text=""></asp:Label>
                <asp:Label ID="WeatherDataOutput" runat="server" Text=""></asp:Label>
        </div>
        <hr />
        <div id ="NearestStoreDiv" runat ="server">

            <asp:DropDownList ID="StoreDDList" runat="server">
            </asp:DropDownList>
            <asp:Button ID="StoreDetails" runat="server" Text="Get Details" OnClick="StoreDetailsButton_Click" />
                        
        </div>
        <div id ="NearestStoreOutDiv" runat ="server">
                <asp:Label ID="NearestStoreOutLabel" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
