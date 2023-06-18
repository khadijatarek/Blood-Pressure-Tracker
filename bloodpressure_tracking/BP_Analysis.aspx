<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BP_Analysis.aspx.cs" Inherits="bloodpressure_tracking.BP_Analysis" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

                h1 {
            background-color: darkcyan;
            color: #fff;
            margin: 0;
            padding: 30px;
            font-weight: normal;
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
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
  
  <asp:Button ID="ButtonProfile" runat="server" Text="Profile" CssClass="button" OnClick="ButtonProfile_Click" />          
  <asp:Button ID="ButtonTrackBP" runat="server" Text="Track Blood Pressure" CssClass="button" OnClick="ButtonTrackBP_Click" />
  <asp:Button ID="ButtonAnalysis" runat="server" Text="Blood Pressure Analysis" CssClass="button" OnClick="ButtonAnalysis_Click" style="background-color: #002929;" />
     <asp:Button ID="ButtonLogOut" runat="server" Text="LogOut" CssClass="button" OnClick="ButtonLogOut_Click" />
</div>
        <h1>Blood Pressure Analysis</h1>
        <div>
            &nbsp;<asp:Button ID="deleteReadingBtn" runat="server" Text="Delete Readings" CssClass="button" OnClick="ButtonDeleteReadings_Click" style="float:right;"/>
        </div>
        <asp:Chart ID="Chart1" runat="server" Height="570px" Width="1180px">
            <series>
                <asp:Series Name="Series1" ChartType="Line">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <br />
  
    </form>
</body>
</html>
