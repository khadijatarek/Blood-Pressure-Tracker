using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bloodpressure_tracking.user_Data;
using System.Windows;


namespace bloodpressure_tracking
{
    public partial class home : System.Web.UI.Page
    {
        private HttpCookie myCookie;
        private string myemail;
        protected void Page_Load(object sender, EventArgs e)
        {
            myCookie = Request.Cookies["email"];
            myemail = myCookie.Value;
            if (!IsPostBack)
            {
                TextBox1.ReadOnly = true;
                TextBox2.ReadOnly = true;
                TextBox3.ReadOnly = true;
                TextBox4.ReadOnly = true;
                TextBox5.ReadOnly = true;
                TextBox6.ReadOnly = true;
                update.Visible = false;

                //get user's data from databaase
                List<userData> data = new List<userData>();
                using (user_Data.userSoapClient obj = new user_Data.userSoapClient())
                {
                    data = obj.get_info(myemail).ToList();
                }
                if (data.Count > 0)
                {
                    //load the data in the textboxes
                    TextBox1.Text = data[0].name;
                    TextBox2.Text = data[0].age.ToString();
                    TextBox3.Text = data[0].gender.ToString();
                    TextBox4.Text = data[0].weight.ToString();
                    TextBox5.Text = data[0].height.ToString();
                    TextBox6.Text = data[0].password;
                }
            }
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            TextBox3.ReadOnly = false;
            TextBox4.ReadOnly = false;
            TextBox5.ReadOnly = false;
            TextBox6.ReadOnly = false;

            edit.Visible = false;
            update.Visible = true;
        }

        protected void update_Click(object sender, EventArgs e)
        {
            user_Data.userSoapClient obj = new user_Data.userSoapClient();
            obj.update(myemail, TextBox1.Text, int.Parse(TextBox2.Text), TextBox3.Text[0], float.Parse(TextBox4.Text), float.Parse(TextBox5.Text), TextBox6.Text);


            // Set the textboxes back to readonly mode
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;
            TextBox4.ReadOnly = true;
            TextBox5.ReadOnly = true;
            TextBox6.ReadOnly = true;

            edit.Visible = true;
            update.Visible = false;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            user_Data.userSoapClient obj = new user_Data.userSoapClient();
            obj.delete_user(myemail);

        }

        protected void ButtonAnalysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("BP_Analysis.aspx");
        }


        protected void ButtonTrackBP_Click(object sender, EventArgs e)
        {
            Response.Redirect("storingpressure.aspx");
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {         
            Response.Redirect("login.aspx");
        }

        protected void ButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }
    }
}