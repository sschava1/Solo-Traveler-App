using System;
using System.Threading;
using System.Web.UI.WebControls;

namespace SoloTravelerApp
{
    public partial class EmployeeUpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = (string)Session["role"];
            Thread.Sleep(1000);
            string userid = (string)Session["userid"];
            if (userid == null || role != "Employee")
            {
                Response.Redirect("AccessDenied.aspx");
            }
            PopulateTable();
            if (!IsPostBack)
            {
                ColumnDDList.Items.Add(new ListItem("First Name", "First"));
                ColumnDDList.Items.Add(new ListItem("Last Name", "Last"));
                ColumnDDList.Items.Add(new ListItem("Email", "Email"));
                ColumnDDList.Items.Add(new ListItem("Phone", "Phone"));
            }

        }

        private void PopulateTable()
        {
            string relativeUsersXSLPath = "/App_Data/UsersInfo.xslt";
            string relativeUsersPath = "/App_Data/Users.xml";
            string UsersHTML = SoloTravelerAppUtils.ConvertXMLToHTML(relativeUsersPath, true, relativeUsersXSLPath);

            UserTable.Text = UsersHTML;
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            string id = IdInput.Text;
            string attr = ColumnDDList.SelectedValue;
            string val = ValueInput.Text;

            if (attr.Equals("Phone"))
            {
                success = UtilitiesLibrary.AppUtilityClass.ValidatePhoneNum(val);

                if (!success)
                {
                    OutputResp.Text = "Phone number invalid";
                    return;
                }
            }

            success = DataManagementLayer.DAO.UpdateUser(id, attr, val);

            if (success)
            {
                PopulateTable();
                OutputResp.Text = "Update Successful";
            }
            else
            {
                OutputResp.Text = "Something went wrong. Please try again later";
            }


        }
    }
}