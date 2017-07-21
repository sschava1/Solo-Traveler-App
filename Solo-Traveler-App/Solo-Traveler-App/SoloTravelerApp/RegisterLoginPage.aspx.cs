using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoloTravelerApp
{
    public partial class RegisterLoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userid"] = null;
            Session["role"] = null;
            if (!IsPostBack)
            {
                loginform.Visible = true;
                signupform.Visible = false;
            }
            VerImage.ImageUrl = "";
        }

        protected void Log_In_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!loginform.Visible)
                {
                    loginform.Visible = true;
                    signupform.Visible = false;
                    ClearAllFormFields();
                    return;
                }
                string userId = UsernameInput.Text;
                string password = PasswordInput.Text;
                bool isEmployee = EmployeeCheckBox.Checked;
                bool validUserName = false;

                string validationResponse = ValidateForBlankFields();
                if (!validationResponse.Equals("success"))
                {
                    Output.Text = validationResponse;
                    return;
                }
                if (isEmployee)
                {
                    validUserName = DataManagementLayer.DAO.CheckForStaff(userId);
                    if (validUserName)
                    {
                        string dbPwd = DataManagementLayer.DAO.ReadStaffDetail(userId, "Password");
                        if (password.Equals(UtilitiesLibrary.AppUtilityClass.Decrypt(dbPwd)))
                        {
                            Session["userid"] = userId;
                            Session["role"] = DataManagementLayer.DAO.ReadStaffDetail(userId, "Role");
                            Output.Text = "";
                            Response.Redirect("RedirectPage.aspx");
                        }
                        else
                        {
                            Output.Text = "Invalid Password.";
                        }
                    }
                    else
                    {
                        Output.Text = "Invalid Employee Username.";
                    }
                }
                else
                {
                    validUserName = DataManagementLayer.DAO.CheckForUser(userId);
                    if (validUserName)
                    {
                        string dbPwd = DataManagementLayer.DAO.ReadUserDetail(userId, "Password");
                        if (password.Equals(UtilitiesLibrary.AppUtilityClass.Decrypt(dbPwd)))
                        {
                            Session["userid"] = userId;
                            Session["role"] = "User";
                            Output.Text = "";
                            Response.Redirect("RedirectPage.aspx");
                        }
                        else
                        {
                            Output.Text = "Invalid Password.";
                        }
                    }
                    else
                    {
                        Output.Text = "Invalid Username.";
                    }
                }
            }
            catch (Exception ex)
            {
                Output.Text = "Something went wrong.";
            }
            
        }

        protected void Register_Button_Click(object sender, EventArgs e)
        {
            if (!signupform.Visible)
            {
                loginform.Visible = false;
                signupform.Visible = true;
                ClearAllFormFields();
                return;
            }

            bool imageValid = ValidateImage();
            if (!imageValid)
            {
                Output.Text = "Image String is invalid";
                return;
            }
            Entity.User newUser = new Entity.User();
            newUser.Firstname = SU_FirstNameInput.Text;
            newUser.Lastname = SU_LastNameInput.Text;
            newUser.Email = SU_EmailInput.Text;
            newUser.Phone = SU_PhoneInput.Text;
            newUser.Id = SU_UsernameInput.Text;
            newUser.Pwd = SU_PasswordInput.Text;

            string validationResponse = ValidateForBlankFields();
            if (!validationResponse.Equals("success"))
            {
                Output.Text = validationResponse;
                return;
            }
            if (DataManagementLayer.DAO.CheckForUser(newUser.Id) || DataManagementLayer.DAO.CheckForStaff(newUser.Id))
            {
                Output.Text = "Username already taken. Try something else";
                return;
            }

            if (!UtilitiesLibrary.AppUtilityClass.ValidatePhoneNum(newUser.Phone))
            {
                Output.Text = "Invalid Phone number.";
                return;
            }

            newUser.Pwd = UtilitiesLibrary.AppUtilityClass.Encrypt(newUser.Pwd);
            bool success = DataManagementLayer.DAO.AddUser(newUser);

            if (success)
            {
                Output.Text = "Registered Successfully.";
                loginform.Visible = true;
                signupform.Visible = false;
            }
            else
            {
                Output.Text = "Something went wrong. Please try later.";
            }

        }

        private void ClearAllFormFields()
        {
            SU_FirstNameInput.Text = "";
            SU_LastNameInput.Text = "";
            SU_EmailInput.Text = "";
            SU_PhoneInput.Text = "";
            SU_UsernameInput.Text = "";
            SU_PasswordInput.Text = "";

            UsernameInput.Text = "";
            PasswordInput.Text = "";
            ImgStrInput.Text = "";
            EmployeeCheckBox.Checked = false;
            
        }

        private string ValidateForBlankFields()
        {
            if (SU_FirstNameInput.Text.Equals("") && signupform.Visible)
            {
                return "First Name cannot be blank";
            }
            if (SU_LastNameInput.Text.Equals("") && signupform.Visible)
            {
                return "Last Name cannot be blank";
            }
            if ((SU_UsernameInput.Text.Equals("") && signupform.Visible) || (UsernameInput.Text.Equals("") && loginform.Visible))
            {
                return "Id cannot be blank";
            }
            if ((SU_PasswordInput.Text.Equals("") && signupform.Visible) || (PasswordInput.Text.Equals("") && loginform.Visible))
            {
                return "Password cannot be blank";
            }
            if (SU_PhoneInput.Text.Equals("") && signupform.Visible)
            {
                return "Phone cannot be blank";
            }
            if (SU_EmailInput.Text.Equals("") && signupform.Visible)
            {
                return "Email cannot be blank";
            }
            if (ImgStrInput.Text.Equals("") && signupform.Visible)
            {
                return "Verification String cannot be blank";
            }
            return "success";
        }

        private void AssignImage()
        {
            ImgVerifierServiceRef.ServiceClient imgVerServ = new ImgVerifierServiceRef.ServiceClient();

            string imgStr = imgVerServ.GetVerifierString("5");
            Session["str"] = imgStr;


            VerImage.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + imgStr;
            
        }

        protected void ReloadImage_Button_Click(object sender, EventArgs e)
        {
            AssignImage();
        }

        private bool ValidateImage()
        {
            string imgStr = (string)Session["str"];
            if (ImgStrInput.Text != null && imgStr != null && ImgStrInput.Text.Equals(imgStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}