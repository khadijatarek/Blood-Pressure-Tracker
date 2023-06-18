using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace bloodpressure_wcf
{
    public class BloodPressureWCF : IBloodPressureWCF
    {
        public string GetBloodPressureRange(double systolic, double diastolic)
        {
            string bp = "";
            if (systolic < 80 || diastolic < 40 || systolic > 200 || diastolic > 120 || diastolic >= systolic || systolic-diastolic<10)
            {
                System.Windows.MessageBox.Show("Please enter a valid blood pressure.", "Blood Pressure Tracker", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                bp = "";
            }
            else if (systolic <= 90 && diastolic <= 60)
            {
                bp = "Low";
            }
            else if ((systolic > 90 && systolic <= 120) && (diastolic > 60 && diastolic <= 80))
            {
                bp = "Normal";
            }
            else if ((systolic > 120 && systolic <= 130) && (diastolic > 80 && diastolic <= 84))
            {
                bp = "Elevated";
            }
            else if ((systolic > 130 && systolic <= 139) || (diastolic > 84 && diastolic <= 89))
            {
                bp = "Stage 1 Hypertension";
            }
            else if ((systolic > 139 && systolic <= 180) || (diastolic > 89 && diastolic <= 120))
            {
                bp = "Stage 2 Hypertension";
            }
            else
            {
                bp = "Hypertensive Crisis";
            }
            return bp;
        }

        public string GetDietRecommendation(String email, double systolicBP, double diastolicBP)
        {
            int age = 0;
            double weight = 0.0;
            string gender = "";
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True"))
            {
                //get gender , age , weight to use it in recommendation
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT gender, age, weight FROM users where email=@email", con);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        gender = reader.GetString(0);
                        age = reader.GetInt32(1);
                        weight = reader.GetDouble(2);
                    }
                }
                reader.Close();
                con.Close();

                Dictionary<string, string> dietPlans = new Dictionary<string, string>();
                dietPlans.Add("Low", "Increase your intake of fluids and salt. Eat small, frequent meals throughout the day rather than large meals.");
                dietPlans.Add("Normal", "Balanced diet plan with moderate salt and fat intake.");
                dietPlans.Add("Elevated", "Low-fat, low-sodium diet plan with emphasis on fruits, vegetables and lean proteins. Reduce alcohol and caffeine intake.");
                dietPlans.Add("Stage 1 Hypertension", "Low-fat, low-sodium diet plan with emphasis on fruits, vegetables and lean proteins. Reduce alcohol and caffeine intake. Limit added sugars and saturated fats.");
                dietPlans.Add("Stage 2 Hypertension", "Low-sodium diet plan with emphasis on fruits, vegetables, whole grains, and low-fat dairy. Limit added sugars and saturated fats.");
                dietPlans.Add("Hypertensive Crisis", "Seek immediate medical attention.");

                string bpRange = GetBloodPressureRange(systolicBP, diastolicBP);
                
                if (bpRange != "")
                {
                    string dietPlan = dietPlans[bpRange];
                    if (gender == "M" || gender == "m")
                    {
                        if (age >= 18 && age <= 30)
                        {
                            dietPlan += " Increase protein intake to support muscle growth.";
                        }
                        else if (age > 30 && age <= 50)
                        {
                            dietPlan += " Increase fiber intake to support cardiovascular health.";
                        }
                        else if (age > 50)
                        {
                            dietPlan += " Increase calcium and vitamin D intake to support bone health.";
                        }
                    }
                    else if (gender == "F" || gender == "f")
                    {
                        if (age >= 18 && age <= 30)
                        {
                            dietPlan += " Increase iron and folate intake to support reproductive health.";
                        }
                        else if (age > 30 && age <= 50)
                        {
                            dietPlan += " Increase calcium and vitamin D intake to support bone health.";
                        }
                        else if (age > 50)
                        {
                            dietPlan += " Increase fiber intake to support digestive health.";
                        }
                    }

                    if (weight > 100)
                    {
                        dietPlan += " Reduce calorie intake to support weight loss.";
                    }
                    return dietPlan;
                }
                else return "";
            }
        }


        //get all readings from its table to view it inside the chart
        public List<BloodPressureReading> GetBloodPressureReadings(int id)
        {
            List<BloodPressureReading> readings = new List<BloodPressureReading>();

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SYS, DIA, Time FROM readings where userid=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BloodPressureReading reading = new BloodPressureReading();

                    reading.Systolic = reader.GetInt32(0);
                    reading.Diastolic = reader.GetInt32(1);
                    reading.ReadingDate = reader.GetDateTime(2);
                    readings.Add(reading);
                }

                reader.Close();
                con.Close();
            }

            return readings;
        }

        public string getReminder(int id)
        {
            int readingsCount;
            String message;

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=bloodPressure;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Readings WHERE USERID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                readingsCount = (int)cmd.ExecuteScalar();
                con.Close();
            }

            if (readingsCount == 0)
            {
                message = "Measure your blood pressure & add your first reading!";

            }
            else if (readingsCount >= 1)
            {
                message = "Don't forget to measure your blood pressure & add a new reading!";
            }
            else message = "Don't know";
            return message;
        }

    }
}
