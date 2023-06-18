<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="storingpressure.aspx.cs" Inherits="bloodpressure_tracking.WebForm1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blood Pressure Tracker</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <style>
       

        h1 {
            background-color: darkcyan;
            color: #fff;
            margin: 5px;
            padding: 30px;
        }

      

        
        input[type="number"] {
            display: block;
            font-size: 16px;
            margin: 10px 5px;
            padding: 5px;
            max-width: 300px; 
        }


 .button {
  background-color: darkcyan;
  color:white;
  border: none;
  padding: 10px;
  margin: 5px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease-in-out;
  float:left;
}

/* Change the background color of the button when hovered over */
.button:hover {
   background-color: #003f3f ;
   color: white ;
   text-decoration: none;

}
.form-group {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: 10px;
}



   #addReadingButton, #error_label{
  margin-left: 10px;
}

   .myform {
       margin-left: 20px;
        margin-right: 20px;
        margin-top:20px;
   }

        .auto-style3 {
            width: 147px;
            height: 146px;
            float: right;
            margin-right: 20px;
            margin-top: 40px;
        }

        .auto-style4 {
            width: 138px;
            height: 129px;
            position: absolute; left: 40px; top: 130px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
         <div>
  <asp:Button ID="ButtonProfile" runat="server" Text="Profile" CssClass="button" OnClick="ButtonProfile_Click" />          
  <asp:Button ID="ButtonTrackBP" runat="server" Text="Track Blood Pressure" CssClass="button" OnClick="ButtonTrackBP_Click" style="background-color: #002929;" />
  <asp:Button ID="ButtonAnalysis" runat="server" Text="Blood Pressure Analysis" CssClass="button" OnClick="ButtonAnalysis_Click" />
     <asp:Button ID="ButtonLogOut" runat="server" Text="LogOut" CssClass="button" OnClick="ButtonLogOut_Click" />
</div>

         <h1 style="text-align:right">120/80</h1>
         
    

         <img alt="" class="auto-style4" src="img/3.png" /><br />
         <br />
         <br />
        
<div class="form-group">
    <label for="systolic" class="control-label">Systolic</label><br />
    <asp:TextBox ID="systolic" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox> <br />
     <label for="diastolic" class="control-label">Diastolic</label> <br />
    
        <asp:TextBox ID="diastolic" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>  <br />
    <asp:Label ID="error_label" runat="server" Font-Bold="False" Font-Size="Medium" ForeColor="Red" Text="Please enter your blood pressure" Visible="False"></asp:Label>
  
    <asp:Button ID="addReadingButton" runat="server" Text="Add Reading" CssClass="button" OnClick="addReadingButton_Click" />

   
</div>
        <br />

       &nbsp;<br />
         <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="187px" Visible="False">
            <h1 >Diet Recommendation according to your Blood Preasure</h1>

           <div class="myform">
               
            <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Your Blood Pressure Range is " ></asp:Label>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
               &nbsp;<img alt="" class="auto-style3" src="img/4.png" /><br />
               <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Your Recommended Diet: "></asp:Label>
               <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
               </div>
            

        </asp:Panel>
    </form>
</body>
</html>