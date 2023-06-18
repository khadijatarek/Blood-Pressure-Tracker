<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="bloodpressure_tracking.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Login</title>
    <style>
               body {
	font-family: Arial, sans-serif;
	background-color: #f9f9f9;
}
.container {
  margin: 0 auto;
  max-width: 300px;
}
h1 {
	text-align: center;
}
label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

input[type="text"], input[type="password"] {
  width: 93%;
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
  text-align: center;
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
            <h1>
                <label for="email">
                <img alt="" class="auto-style1" src="img/5.png" /></label></h1>
            <div>
                <label for="email">Email:</label>
                <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control" />
            </div>
            <div>
                <label for="password">Password:</label>
                <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div>
    <asp:Label ID="errorMsgLabel" runat="server" ForeColor="Red"></asp:Label>
</div>
            <div>
                <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" CssClass="btn btn-primary" />
                <br />
                New user? <asp:HyperLink ID="signupLink" runat="server" NavigateUrl="~/signup.aspx">Signup here</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
