using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace bloodpressure_tracking
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
            {

                errorMsgLabel.Text = "Please enter a username and password.";
                return;
            }
            else
            {
                //use service to login
                user_Data.userSoapClient obj = new user_Data.userSoapClient();
                String name = obj.login(emailTextBox.Text, passwordTextBox.Text);

                if (string.IsNullOrEmpty(name)) { }
                else
                {
                    
                    HttpCookie myCookie = new HttpCookie("email",emailTextBox.Text);
                    Response.Cookies.Add(myCookie);

                    user_Data.userSoapClient objj = new user_Data.userSoapClient();
                    int id = objj.get_id(emailTextBox.Text);
                    wcfService.BloodPressureWCFClient client = new wcfService.BloodPressureWCFClient();
                    string message = client.getReminder(id);
                    MessageBox.Show(message, "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Response.Redirect("storingpressure.aspx");
                }
            }
        }
    }
}