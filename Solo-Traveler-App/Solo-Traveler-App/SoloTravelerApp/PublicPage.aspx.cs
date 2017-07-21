using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoloTravelerApp
{
    public partial class PublicPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateAdminData();
            PopulateStaffData();
            PopulateUserData();
        }

        private void PopulateUserData()
        {
            UserDataLabel.Text = PopulateTable("User");
        }

        private void PopulateStaffData()
        {
            StaffDataLabel.Text = PopulateTable("Employee");
        }

        private void PopulateAdminData()
        {
            AdminDataLabel.Text = PopulateTable("Admin");
        }

        private string PopulateTable(string role)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.H3);
            htmlWriter.Write(role+" Data");
            htmlWriter.RenderEndTag();

            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Border, "1");
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Table);
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tbody);

            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);

            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Th);
            htmlWriter.Write("Name");
            htmlWriter.RenderEndTag();
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Th);
            htmlWriter.Write("Password");
            htmlWriter.RenderEndTag();

            List<string> idList = new List<string>();
            if (role.Equals("User"))
            {
                idList = DataManagementLayer.DAO.GetAllUserIds();
            }
            else
            {
                idList = DataManagementLayer.DAO.GetIdsByRole(role);
            }
            int count = 0;
            foreach (string id in idList)
            {
                if (count >= 3)
                {
                    break;
                }
                string password = "";
                if (role.Equals("User"))
                {
                    password = DataManagementLayer.DAO.ReadUserDetail(id, "Password");
                }
                else
                {
                    password = DataManagementLayer.DAO.ReadStaffDetail(id, "Password");
                }
                password = UtilitiesLibrary.AppUtilityClass.Decrypt(password);

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(id);
                htmlWriter.RenderEndTag();
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(password);
                htmlWriter.RenderEndTag();
                htmlWriter.RenderEndTag();

                count++;
            }

            htmlWriter.RenderEndTag();

            htmlWriter.RenderEndTag();
            htmlWriter.RenderEndTag();
            return htmlWriter.InnerWriter.ToString();
            
        }
    }
}