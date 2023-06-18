using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace bloodpressure_tracking
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private HttpCookie myCookie;
        private string myemail;
        protected void Page_Load(object sender, EventArgs e)
        {
            myCookie = Request.Cookies["email"];
            myemail = myCookie.Value;
            /*
            user_Data.userSoapClient obj = new user_Data.userSoapClient();
            int id = obj.get_id(myemail);
            wcfService.BloodPressureWCFClient client = new wcfService.BloodPressureWCFClient();
            string message = client.getReminder(id);
            if (!IsPostBack)
            {
                MessageBox.Show(message);
            }
            */
                
        }
        protected void addReadingButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(systolic.Text) || String.IsNullOrEmpty(diastolic.Text))
            {
                error_label.Visible = true;
            }
            else
            {
                //get range & diet recommendations according to blood pressure 
                wcfService.BloodPressureWCFClient client = new wcfService.BloodPressureWCFClient();      
                Label2.Text= client.GetBloodPressureRange(Int32.Parse(systolic.Text), Int32.Parse(diastolic.Text));
                Label4.Text = client.GetDietRecommendation(myemail,Int32.Parse(systolic.Text), Int32.Parse(diastolic.Text));
                if (Label2.Text != "")//satisfy all the conditions
                {
                    //store blood pressure in db if range !=""
                    user_Data.userSoapClient obj = new user_Data.userSoapClient();
                    obj.StoringPressure(myemail, Int32.Parse(systolic.Text), Int32.Parse(diastolic.Text));
                    Panel1.Visible = true;
                }
                else
                    Panel1.Visible = false;
               

            }
        }

        protected void ButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }

        protected void ButtonAnalysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("BP_Analysis.aspx");
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void ButtonTrackBP_Click(object sender, EventArgs e)
        {
            Response.Redirect("storingpressure.aspx");
        }
    }
}