using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoloTravelerApp
{
    public partial class RedirectPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = (string)Session["role"];
            Thread.Sleep(1000);
            string userid = (string)Session["userid"];
            if (userid == null || role == null)
            {
                Response.Redirect("AccessDenied.aspx");
            }else if (userid != null && role == "User")
            {
                Response.Redirect("locationinfo.aspx");
            }
            else if (userid != null && role == "Employee")
            {
                Response.Redirect("EmployeeUpdatePage.aspx");
            }
            else if (userid != null && role == "Admin")
            {
                Response.Redirect("PromotDemotePage.aspx");
            }
            else
            {
                Response.Redirect("RegisterLoginPage.aspx");
            }
        }
    }
}