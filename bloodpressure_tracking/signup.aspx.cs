using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace bloodpressure_tracking
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "" || ageTextBox.Text == "" || genderTextBox.Text == "" || weightTextBox.Text == "" || heightTextBox.Text == "" || emailTextBox.Text == "" || passwordTextBox.Text == "")
            {
                errorMsgLabel.Text = "Please enter all the fields.";
                return;
                
            }
            else 
            {
                try
                {
                    //use service to register
                    user_Data.userSoapClient obj = new user_Data.userSoapClient();
                    int num = obj.Register(nameTextBox.Text, Int32.Parse(ageTextBox.Text), genderTextBox.Text[0], float.Parse(weightTextBox.Text), float.Parse(heightTextBox.Text), emailTextBox.Text, passwordTextBox.Text);
                    if (num == 0)
                    { }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Please enter data in a correct format.", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}