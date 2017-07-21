using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoloTravelerApp
{
    public partial class LogOutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userid"] = null;
            Session["role"] = null;
            Response.Redirect("RegisterLoginPage.aspx");
        }
    }
}