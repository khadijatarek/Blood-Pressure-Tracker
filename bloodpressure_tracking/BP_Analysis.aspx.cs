using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using bloodpressure_tracking.wcfService;

namespace bloodpressure_tracking
{
    public partial class BP_Analysis : System.Web.UI.Page
    {

        private HttpCookie myCookie;
        private string myemail;
        protected void Page_Load(object sender, EventArgs e)
        {
            myCookie = Request.Cookies["email"];
            myemail = myCookie.Value;
            if (!IsPostBack)
            {
                user_Data.userSoapClient client = new user_Data.userSoapClient();
                int id= client.get_id(myemail);

                wcfService.BloodPressureWCFClient obj = new wcfService.BloodPressureWCFClient();
                BloodPressureReading[] readingsArray = obj.GetBloodPressureReadings(id);
                List<BloodPressureReading> readingsList = new List<BloodPressureReading>(readingsArray);
                

                Chart1.Series.Add("Systolic");
                Chart1.Series.Add("Diastolic");

                // Bind the data to the chart control
                Chart1.Series["Systolic"].Points.DataBindXY(readingsList, "ReadingDate", readingsList, "Systolic");
                Chart1.Series["Diastolic"].Points.DataBindXY(readingsList, "ReadingDate", readingsList, "Diastolic");

                // Customize the appearance of the chart control
                Chart1.Titles.Add("Blood Pressure Readings");
                Chart1.ChartAreas[0].AxisX.Title = "Date";
                Chart1.ChartAreas[0].AxisY.Title = "Pressure";
                Chart1.Legends.Add(new Legend("Legend"));

                //chart type
                Chart1.Series["Systolic"].ChartType = SeriesChartType.Line;
                Chart1.Series["Diastolic"].ChartType = SeriesChartType.Line;

                //colors
                Chart1.Series["Systolic"].Color = Color.BlueViolet;
                Chart1.Series["Diastolic"].Color = Color.Violet;

                // Hide the 'Series1' label from the chart legend
                Chart1.Series[0].IsVisibleInLegend = false;
            }
        }

        protected void ButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }

        protected void ButtonTrackBP_Click(object sender, EventArgs e)
        {
            Response.Redirect("storingpressure.aspx");
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void ButtonDeleteReadings_Click(object sender, EventArgs e)
        {

            user_Data.userSoapClient obj = new user_Data.userSoapClient();
            obj.delete_readings(myemail);
        }

        protected void ButtonAnalysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("BP_Analysis.aspx");
        }
    }
}