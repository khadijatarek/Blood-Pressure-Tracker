<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="bloodpressure_tracking.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <style>
        body {
	font-family: Arial, sans-serif;
	background-color: #f9f9f9;
}

.container {
margin: 0 auto;
  max-width: 400px;
  
    
}

h1 {
	text-align: center;
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

input {
   width: 94%;
  padding: 10px;
  margin-bottom: 20px;
  border: none;
  border-radius: 5px;
  box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
}

input[type="submit"] {
  display: block;
  width: 100%;
  padding: 10px;
  margin-top: 20px;
  border: none;
  border-radius: 5px;
  background-color: darkcyan;
  color: #fff;
  font-weight: bold;
  cursor: pointer;
}

input[type="submit"]:hover {
	background-color: #003f3f ;
  color: white ;
  text-decoration: none;
}

a:hover {
  text-decoration: underline;
}
        .auto-style1 {
            width: 137px;
            height: 126px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="container">
            <h1><img alt="" class="auto-style1" src="img/5.png" /></h1>
            <div>
                <label for="name">Name:</label>
                <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" />
            </div>
            <div>
                <label for="age">Age:</label>
                <asp:TextBox ID="ageTextBox" runat="server" CssClass="form-control" />
            </div>
            <div>
                <label for="gender">Gender:</label>
                <asp:TextBox ID="genderTextBox" runat="server" CssClass="form-control" placeholder="M/F" />
            </div>
            <div>
                <label for="weight">Weight (kg):</label>
                <asp:TextBox ID="weightTextBox" runat="server" CssClass="form-control" />
            </div>
            <div>
                <label for="height">Height (cm):</label>
                <asp:TextBox ID="heightTextBox" runat="server" CssClass="form-control" />
            </div>
            <div>
                <label for="email">Email:</label>
                <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control" />
            </div>
            <div>
                <label for="password">Password:</label>
                <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
             <asp:Label ID="errorMsgLabel" runat="server" ForeColor="Red"></asp:Label>
            <div>
                <asp:Button ID="submitButton" runat="server" Text="Register" OnClick="submitButton_Click" CssClass="btn btn-primary" />
                <br />
                Already have an account
                <asp:HyperLink ID="loginLink" runat="server" NavigateUrl="~/Login.aspx">Login here</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>