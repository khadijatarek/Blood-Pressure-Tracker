using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace bloodpressure_service
{
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
     
    public class user : System.Web.Services.WebService
    {

        [WebMethod]
        public int Register(string fname, int age, char gender, float w, float h, string email, string password)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True");

            con.Open();

            // Check if email already exists
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE email = @l", con);
            SqlParameter checkParam = new SqlParameter("@l", email);
            checkCmd.Parameters.Add(checkParam);

            int emailCount = (int)checkCmd.ExecuteScalar();

            if (emailCount > 0)
            {
                // email already exists, show error message and return
                System.Windows.Forms.MessageBox.Show("This Email is already taken.", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                con.Close();
                return 0;
            }

            // email does not exist, insert new user
            SqlCommand cmd = new SqlCommand("insert into Users (name,age,gender,weight, height,email, password) values (@name,@age,@gender,@weight,@height,@email,@password)", con);

            cmd.Parameters.AddWithValue("@name", fname);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@weight", w);
            cmd.Parameters.AddWithValue("@height", h);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();

            con.Close();

            System.Windows.Forms.MessageBox.Show("Successfully registered.", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return 1;
        }

        [WebMethod]
        public List<userData> get_info(string email)
        {
            List<userData> information = new List<userData>();

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select name, age, gender, weight, height, password from Users WHERE email=@email", con);              
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userData info = new userData();

                    info.name = reader.GetString(0);
                    info.age = reader.GetInt32(1);
                    info.gender = reader.GetString(2)[0];
                    info.weight = (float)reader.GetDouble(3);
                    info.height = (float)reader.GetDouble(4);
                    info.password = reader.GetString(5);

                    information.Add(info);
                }

                reader.Close();
                con.Close();
            }
            return information;
        }    
        [WebMethod]
        public void update(string email, string fname, int age, char gender, float w, float h, string password)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Users SET name=@name, age=@age, gender=@gender, weight=@weight, height=@height, password=@password WHERE email=@email", con);

            cmd.Parameters.AddWithValue("@name", fname);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@weight", w);
            cmd.Parameters.AddWithValue("@height", h);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Your info has been updated successfully.", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        [WebMethod]
        public void delete_readings(string email)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True");
            con.Open();
            int id = get_id(email);
            SqlCommand cmd = new SqlCommand("DELETE FROM Readings WHERE UserId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Your Readings have been deleted successfully.", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        [WebMethod]
        public void delete_user(string email)
        {
            delete_readings(email);
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE email = @email", con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Your Account has been deleted successfully.", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [WebMethod]
        public int get_id(string email)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select id from Users WHERE email=@email", con);
            cmd.Parameters.AddWithValue("@email", email);
            int id = (int)cmd.ExecuteScalar();
            return id;

        }

        [WebMethod]
        public string login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                //check the email and password are not equal null
                System.Windows.Forms.MessageBox.Show("Please enter your email and password.","Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            else
            {
                try
                {
                    //check if this email exists in the db to login
                    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True");
                    con.Open();

                    string selectQuery = "SELECT name FROM Users WHERE email=@email AND password=@password";
                    SqlCommand cmd = new SqlCommand(selectQuery, con);
                    SqlParameter p1 = new SqlParameter("@email", email);
                    SqlParameter p2 = new SqlParameter("@password", password);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);

                    string name = (string)cmd.ExecuteScalar();

                    con.Close();
                    if (!string.IsNullOrEmpty(name))
                    {
                        System.Windows.Forms.MessageBox.Show($"Welcome, {name}!", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return name;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid email or password. Please try again.", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                catch (SqlException)
                {
                    System.Windows.Forms.MessageBox.Show("Login failed.", "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }


        [WebMethod]
        public void StoringPressure(String email, int sys, int dia)
        {
            int id = get_id(email);
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into readings (UserID,SYS,DIA,Time) values (@id,@sys,@dia,@t)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@sys", sys);
            cmd.Parameters.AddWithValue("@dia", dia);
            cmd.Parameters.AddWithValue("@t", DateTime.Now);
            cmd.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show("Your reading has successfully added: " + DateTime.Now, "Blood Pressure Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();


        }

    }
    public class userData
    {
        public String name { get; set; }

        public int age { get; set; }

        public char gender { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public String password { get; set; }
    }
}
