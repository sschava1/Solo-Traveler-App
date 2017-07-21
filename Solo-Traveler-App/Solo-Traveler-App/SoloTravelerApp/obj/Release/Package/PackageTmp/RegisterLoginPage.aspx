<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterLoginPage.aspx.cs" Inherits="SoloTravelerApp.RegisterLoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="assets/css/form.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u"/>
</head>
<body>
    <div class="container">
	    <div class="login">
		    <h4>Login to Solo Traveler App</h4>
            <form id="form1" runat="server" class="login-inner">
                <div id="loginform" runat="server">
                    <div>


                        <asp:TextBox ID="UsernameInput" runat="server" placeholder ="Username"></asp:TextBox>
                    </div>
                    <div>

                        <asp:TextBox ID="PasswordInput" TextMode="Password" runat="server" placeholder ="Password"></asp:TextBox>
                    </div>
                    <div>
                        <asp:CheckBox ID="EmployeeCheckBox" runat="server" Text="I am an Employee" />

                    </div>
                </div>
                <div id ="signupform" runat="server">
                    <div>

                        <asp:TextBox ID="SU_FirstNameInput" runat="server" placeholder ="First Name"></asp:TextBox>
                    </div>
                    <div>

                        <asp:TextBox ID="SU_LastNameInput" runat="server" placeholder ="Last Name"></asp:TextBox>
                    </div>

                    <div>

                        <asp:TextBox ID="SU_EmailInput" runat="server" placeholder ="Email"></asp:TextBox>
                    </div>
                    <div>

                        <asp:TextBox ID="SU_PhoneInput" runat="server" placeholder ="Phone"></asp:TextBox>
                    </div>

                    <div>


                        <asp:TextBox ID="SU_UsernameInput" runat="server" placeholder ="Username"></asp:TextBox>
                    </div>
                    <div>

                        <asp:TextBox ID="SU_PasswordInput" TextMode="Password" runat="server" placeholder ="Password"></asp:TextBox>
                
                    </div>
                    <div>  
                        <asp:Image ID="VerImage" runat="server" />
                        <asp:TextBox ID="ImgStrInput" runat="server" placeholder ="Image String"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="ReloadImage" runat="server" Text="Reload Image" OnClick="ReloadImage_Button_Click" />
                    </div>
                </div>
                <div>
             
                    <asp:Button ID="LogInButton" runat="server" Text="Log In" OnClick="Log_In_Button_Click" />
                    <asp:Button ID="Register_button" runat="server" Text="Register" OnClick="Register_Button_Click" />
             
                </div>
                <asp:Label ID="Output" runat="server" Text=""></asp:Label>

        

        
            </form>
        </div>
    </div>
</body>
</html>
