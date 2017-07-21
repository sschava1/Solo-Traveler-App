<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicPage.aspx.cs" Inherits="SoloTravelerApp.PublicPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Public Page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>
    <link href="assets/css/common.css" rel="stylesheet" />
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
                <asp:MenuItem NavigateUrl="LogOutPage.aspx" Text="| LOGIN" Value="LOGIN"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <hr />
        <hr />
        <div id="header" >
            <h1>Welcome to the Solo Traveler Wep App public page</h1>
            <h3>This page will provide you the test inputs, information regarding how to use the web app, and the services implemented by the author</h3>
        </div>

        <div>
            <h3 style="text-align:center">Test Data</h3>
            <div>
                <asp:Label ID="AdminDataLabel" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="StaffDataLabel" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="UserDataLabel" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div id="stepsDiv">
            <h3>How to do member Log In?</h3>
            <ol>
                <li>Go to <a href="/page3/LogOutPage.aspx">login page</a></li>
                <li>Provide the username and password</li>
                <li>Click on the "Log In" Button</li>
            </ol>
            <h3>How to do staff Log In?</h3>
            <ol>
                <li>Go to <a href="/page3/LogOutPage.aspx">login page</a></li>
                <li>Provide the username and password</li>
                <li>Click on the "I am an Employee" checkbox</li>
                <li>Click on the "Log In" Button</li>
            </ol>
            <h3>How to Register/SignUp?</h3>
            <ol>
                <li>Go to <a href="/page3/LogOutPage.aspx">login page</a></li>
                <li>Click on "Register" Button</li>
                <li>Fill the required fields</li>
                <li>Enter the Image Verification string</li>
                <li>Click on the "Register" Button Again</li>
            </ol>
            <h3>How to Update Employee Info?</h3>
            <ol>
                <li>Go to <a href="/page3/LogOutPage.aspx">login page</a></li>
                <li>Provide the Staff username and password from Test Data table</li>
                <li>Click on the "I am an Employee" checkbox</li>
                <li>Click on the "Log In" Button</li>
                <li>App will land you on the <a href="/page3/EmployeeUpdatePage.aspx">Information Update Page</a></li>
                <li>Provide the id of the user whose attribute you want to update</li>
                <li>Select the attribute from the drop down list that you want to update</li>
                <li>Provide the valid value that you want the attribute to be updated to</li>
                <li>Click on the Update Button</li>
            </ol>
            <h3>How to Promote/Demote organization Entity?</h3>
            <ol>
                <li>Go to <a href="/page3/LogOutPage.aspx">login page</a></li>
                <li>Provide the Admin username and password from Test Data table</li>
                <li>Click on the "I am an Employee" checkbox</li>
                <li>Click on the "Log In" Button</li>
                <li>App will land you on the <a href="/page3/PromotDemotePage.aspx">Promote / Demote Page</a></li>
                <li>Provide the id of the entity whom you want to promote/demote</li>
                <li>Select the role from the drop down list to which you want to demote the entity to</li>
                <li>Click on the Promote / Demote Button</li>
            </ol>
        </div>

        <table id ="serviceDirectTable" class="table table-responsive">
        <tbody><tr>
            <td colspan="8" style="text-align:center"> ServiceDirectory: <a href="/PublicPage.aspx">WEBSTRAR</a></td>
        </tr>
        <tr>
            <td colspan="8" style="text-align:center">Project Name: Solo Traveler App</td>
        </tr>
        <tr>
            <td colspan="8" style="text-align:center">Author Name: Shirish Chavan</td>
        </tr>
        <tr style="text-align:center">
            <td>Provider Name</td>
            <td>Service Name</td>
            <td>Input Type</td>
            <td>Output Type</td>
            <td>TryIt link</td>
            <td>Service Description</td>
            <td>Resources used to implement the service</td>
            <td>Service Type</td>
        </tr>
		
        <tr style="text-align:center">
            <td>Geo Data Services</td>
            <td><a href="https://azure.geodataservice.net/GeoDataService.svc/GetUSDemographics?includecrimedata=false&amp;zipcode=85281">Crime Data Service</a></td>
            <td>Zipcode as integer</td>
            <td>XML format string</td>
            <td>Try It once you login through member credential</td>
            <td>
                Used the Geo Data service that returns certain crime data for a given location. This data is given
                in the form of xml string with the tags as the type of felony
            </td>
            <td>
                Implementended with the help of national crime data api at
                <a href="https://azure.geodataservice.net/GeoDataService.svc/GetUSDemographics?includecrimedata=false&amp;zipcode=85281">Geo Data Service</a>
            </td>
            <td>Public Restful Service</td>
        </tr>
		
        <tr style="text-align:center">
            <td>Shirish Chavan</td>
            <td><a href="http://webstrar17.fulton.asu.edu/page2/OmniWSDLServiceRef.svc">Store Search</a></td>
            <td>Zip code as String, store type as String</td>
            <td>Results in XML string format</td>
            <td><a href="http://webstrar17.fulton.asu.edu/page0/TryItPage.aspx">Try It</a></td>
            <td>
                A service which takes zip code and type of store as parameter. It returns a string containing
                all the near by stores separated by comma.
            </td>
            <td>Implemented with the help of <a href="https://developers.google.com/places/web-service/search">google nearby search</a> api</td>
            <td>Self created SOAP Service</td>
        </tr>
		
        <tr style="text-align:center">
            <td>Shirish Chavan</td>
            <td><a href="http://webstrar17.fulton.asu.edu/page2/OmniWSDLServiceRef.svc">Weather Data</a></td>
            <td>Zipcode as string, Date as DateTime</td>
            <td>Result in Json format</td>
            <td><a href="http://webstrar17.fulton.asu.edu/page0/TryItPage.aspx">Try It</a></td>
            <td>This service returns the 5 day weather forcast data of a given area from a given date</td>
            <td>Developed the service using <a href="https://darksky.net/dev/docs/time-machine">Dark Sky API</a> </td>
			<td>Self created SOAP Service</td>
        </tr>

        <tr style="text-align:center">
            <td>Shirish Chavan</td>
            <td>Encryption/Decryption Service</td>
            <td>string unencrypted input/encrypted input</td>
            <td>string encrypted output/decrypted output</td>
            <td><ul>
			<li>Encryption done when user registers</li>
			<li>Decryption done when user logins</li>
			</ul></td>
            <td>This service returns the encrypted/decrypted string depending on method called</td>
			<td>
                Referred the Lecture slides to get the algorithm for this service.
            </td>
			<td>DLL Service</td>
        </tr>
		
        <tr style="text-align:center">
            <td>ASU Repository</td>
            <td>Image Verifier Service</td>
            <td>string</td>
            <td>Return URL of image, string for image</td>
            <td><a href="/page3/LogOutPage.aspx">Try It using Register Page</a></td>
            <td>
                This service verifies if the user is not a bot, by providing an image with a string in order to do so.
            </td>
            <td>Used the ASU Repository <a href="http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/3Nt$@">Image Verification service</a> API</td>
			<td>ASU Repository Restful service</td>
        </tr>
		
		</tbody>
	</table>

    </form>
</body>
</html>
