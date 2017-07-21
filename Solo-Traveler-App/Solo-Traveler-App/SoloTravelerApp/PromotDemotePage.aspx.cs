using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoloTravelerApp
{
    public partial class PromotDemotePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = (string)Session["role"];
            Thread.Sleep(1000);
            string userid = (string)Session["userid"];
            if (userid == null || role != "Admin")
            {
                Response.Redirect("AccessDenied.aspx");
            }
            PopulateTable();
            if (!IsPostBack)
            {
                RoleDDList.Items.Add(new ListItem("User", "User"));
                RoleDDList.Items.Add(new ListItem("Employee", "Employee"));
                RoleDDList.Items.Add(new ListItem("Admin", "Admin"));
            }
        }

        private void PopulateTable()
        {
            string relativeUsersXSLPath = "/App_Data/UsersPromDem.xslt";
            string relativeStaffXSLPath = "/App_Data/StaffPromDem.xslt";
            string relativeUsersPath = "/App_Data/Users.xml";
            string relativeStaffPath = "/App_Data/Staff.xml";
            string UsersHTML = SoloTravelerAppUtils.ConvertXMLToHTML(relativeUsersPath, true, relativeUsersXSLPath);
            string StaffHTML = SoloTravelerAppUtils.ConvertXMLToHTML(relativeStaffPath, true, relativeStaffXSLPath);

            UserEmployeTable.Text = UsersHTML + StaffHTML;
        }

        protected void PromDemButton_Click(object sender, EventArgs e)
        {
            int promDemCase = 0;
            string id = IdInput.Text;
            string changedRole = RoleDDList.SelectedValue;

            bool IdPresent = DataManagementLayer.DAO.CheckForUser(id);
            bool inStaff = false;
            bool inUser = false;
            if (!IdPresent)
            {
                IdPresent = DataManagementLayer.DAO.CheckForStaff(id);
                if (!IdPresent)
                {
                    OutputResp.Text = "Id does not exist. Try copying and pasting the Id from table.";
                    return;
                }
                else
                {
                    inStaff = true;
                }
            }
            else
            {
                inUser = true;
            }

            string currentRole = "";

            if (inUser)
            {
                currentRole = "User";
            }
            else if(inStaff)
            {
                currentRole = DataManagementLayer.DAO.ReadStaffDetail(id, "Role");
                int count = DataManagementLayer.DAO.GetStaffCount(currentRole);
                if (count == 1)
                {
                    OutputResp.Text = "This is the last entity of "+currentRole+" role. " +
                        "Which means once you promote/demote this entity, " +
                        "you will no longer be able to access their respective pages " +
                        "unless you add the entities to the database manually. " +
                        "Therefore, this update has been cancelled. " +
                        "Please promote a user to this role and try demoting it, " +
                        "when the entity count is more than 1.";
                    return;
                }
            }

            if(changedRole.CompareTo(currentRole) < 0)
            {
                promDemCase = 1;
            }else if (changedRole.CompareTo(currentRole) > 0)
            {
                promDemCase = 0;
            }
            else
            {
                OutputResp.Text = "Selected role does not Promote/Demote";
                return;
            }
            bool success = false;
            switch (promDemCase){
                case 0:
                    success = Demote(id, currentRole, changedRole);
                    break;
                case 1:
                    success = Promote(id, currentRole, changedRole);
                    break;
                default:
                    OutputResp.Text = "Selected role does not Promote/Demote";
                    return;
            }

            if (success)
            {
                if((string)Session["userid"] == id)
                {
                    Session["role"] = changedRole;
                }
                OutputResp.Text = "Update Successful";
                Response.Redirect("RedirectPage.aspx");
            }
            else
            {
                OutputResp.Text = "Something went wrong. Please try again later.";
            }
        }

        private bool Demote(string id, string currentRole, string changedRole)
        {
            bool success = false; 
            if (!currentRole.Equals("User"))
            {
                success = DataManagementLayer.DAO.DemoteStaff(id);
            }
            else
            {
                success = DataManagementLayer.DAO.UpdateStaff(id,"Role",changedRole);
            }

            return success;
        }

        private bool Promote(string id, string currentRole, string changedRole)
        {
            bool success = false;
            if (currentRole.Equals("User"))
            {
                success = DataManagementLayer.DAO.PromoteUser(id, changedRole);
            }
            else
            {
                success = DataManagementLayer.DAO.UpdateStaff(id, "Role", changedRole);
            }

            return success;
        }
    }
}