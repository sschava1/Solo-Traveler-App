using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoloTravelerApp
{
    public partial class locationinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = (string)Session["role"];
            Thread.Sleep(1000);
            string userid = (string)Session["userid"];
            if (userid == null || role != "User")
            {
                Response.Redirect("AccessDenied.aspx");
            }

            if (!IsPostBack)
            {
                Crime_Weather.Visible = false;
                NearestStoreDiv.Visible = false;
                NearestStoreOutDiv.Visible = false;

                StoreDDList.Items.Add(new ListItem("ATM", "atm"));
                StoreDDList.Items.Add(new ListItem("Bank", "bank"));
                StoreDDList.Items.Add(new ListItem("Bicycle Store", "bicycle_store"));
                StoreDDList.Items.Add(new ListItem("Book Store", "book_store"));
                StoreDDList.Items.Add(new ListItem("Convenience Store", "convenience_store"));
                StoreDDList.Items.Add(new ListItem("Clothing Store", "clothing_store"));
                StoreDDList.Items.Add(new ListItem("Department Store", "department_store"));
                StoreDDList.Items.Add(new ListItem("Hardware Store", "hardware_store"));
                StoreDDList.Items.Add(new ListItem("Home Goods Store", "home_goods_store"));
                StoreDDList.Items.Add(new ListItem("Liquor Store", "liquor_store"));
                StoreDDList.Items.Add(new ListItem("Night Club", "night_club"));
                StoreDDList.Items.Add(new ListItem("Shoe Store", "shoe_store"));
                StoreDDList.Items.Add(new ListItem("Store", "store"));
            }
        }

        protected void RetrieveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string validationResp = ValidateFields();

                if (!validationResp.Equals("success"))
                {
                    CrimeDataOutput.Text = validationResp;
                    return;
                }
                string input = ZipcodeInput.Text;
                DateTime date = Convert.ToDateTime(DateInput.Text);
                int inputVal;

                if (input.Equals(""))
                {
                    CrimeDataOutput.Text = "Please provide valid input";
                    return;
                }
                if (!int.TryParse(input, out inputVal))
                {
                    CrimeDataOutput.Text = "Invalid ZipCode";
                    return;
                }
                string xml = ServiceLayer.ServiceCall.GetCrimeData(inputVal);
                string output = SoloTravelerAppUtils.ConvertXMLToHTML(xml , false,"/App_Data/CrimeData.xslt");
                string weatherResp = ServiceLayer.ServiceCall.GetWeatherData(input, date);
                CrimeDataOutput.Text = output;
                WeatherDataOutput.Text = weatherResp;

                Crime_Weather.Visible = true;
                NearestStoreDiv.Visible = true;
                NearestStoreOutDiv.Visible = true;
            }
            catch (Exception ex)
            {
                CrimeDataOutput.Text = "Something went wrong";
                Crime_Weather.Visible = true;
            }
            
        }

        private string ValidateFields()
        {
            string resp = "success";

            if (ZipcodeInput.Text.Equals(""))
            {
                resp = "Zipcode field cannot be blank";
            }

            if (DateInput.Text.Equals(""))
            {
                resp = "Date field cannot be blank";
            }
            

            return resp;
        }

        protected void StoreDetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string zipCode = ZipcodeInput.Text;
                string type = StoreDDList.SelectedValue;

                string xmlResponse = ServiceLayer.ServiceCall.GetNearestStoreData(zipCode, type);
                string output = SoloTravelerAppUtils.ConvertXMLToHTML(xmlResponse, false, "/App_Data/NearestStore.xslt");
                NearestStoreOutLabel.Text = output;
                
            }
            catch (Exception ex)
            {
                NearestStoreOutLabel.Text = "Something went wrong";
            }
        }
        
        private void ClearFields()
        {

            WeatherDataOutput.Text = "";
            CrimeDataOutput.Text = "";
            NearestStoreOutLabel.Text = "";
        }
    }
}