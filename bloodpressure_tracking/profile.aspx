<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="bloodpressure_tracking.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" type="text/css" href="styles.css"/>
    <style>
        /* Set the background color of the entire page to dark cyan */
/* Set the background color of the entire page to dark cyan */
body {
  background-color: #ffffff;
}

/* Set the font color of the entire page to white */
body, input, button {
  color: white;
}

/* Center the form in the middle of the page */
.centered {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: lightcyan;
  padding: 20px;
  border-radius: 10px;
  color: black ;
}

/* Style the textboxes with a dark cyan background and white text */
.textbox {
  background-color: darkcyan;
  border: none;
  padding: 10px;
  margin: 5px;
  border-radius: 5px;
}

/* Style the button with a dark cyan background and white text */
.button {
  background-color: darkcyan;
  border: none;
  padding: 10px;
  margin: 5px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease-in-out;
  margin-top:5px;
}

/* Change the background color of the button when hovered over */
.button:hover {
   background-color: #003f3f ;
   color: white ;
   text-decoration: none;
}
        .auto-style1 {
            width: 200px;
            height: 200px;
            margin-left: 900px;
            margin-top: 100px;
        }
       
    </style>
</head>

<body>    
    <form id="form1" runat="server" >

 <div>
  
<asp:Button ID="ButtonProfile" runat="server" Text="Profile" CssClass="button" OnClick="ButtonProfile_Click" style="background-color: #002929;" />     
  <asp:Button ID="ButtonTrackBP" runat="server" Text="Track Blood Pressure" CssClass="button" OnClick="ButtonTrackBP_Click" />
  <asp:Button ID="ButtonAnalysis" runat="server" Text="Blood Pressure Analysis" CssClass="button" OnClick="ButtonAnalysis_Click" />
     <asp:Button ID="ButtonLogOut" runat="server" Text="LogOut" CssClass="button" OnClick="ButtonLogOut_Click" />
</div>


  <div class="centered">
     
    <label for="txtName">Name:</label><br/>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox><br/>
    <label for="txtAge">Age:</label><br/>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox"></asp:TextBox><br/>
    <label for="txtGender">Gender:</label><br/>
    <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox"></asp:TextBox><br/>
    <label for="txtWeight">Weight:</label><br/>
    <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox"></asp:TextBox><br/>
    <label for="txtHeight">Height:</label><br/>
    <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox"></asp:TextBox><br/>
    <label for="txtPassword">Password:</label><br/>
    <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox"></asp:TextBox><br/>
    <asp:Button ID="edit" runat="server" Text="Edit" CssClass="button" OnClick="edit_Click" />
      <asp:Button ID="update" runat="server" Text="Update" CssClass="button" OnClick="update_Click" />
      <asp:Button ID="delete" runat="server" Text="Delete" CssClass="button" OnClick="Delete_Click" />
  </div>
</form>
    <p>
        <img class="auto-style1" src="img/1.png" />
</body>
</html>