<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TechFix.Customer.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resgister</title>
    <style>
       @import url('stylesheet.css');
         body {
            font-family: Arial, sans-serif;
            background-color: aliceblue;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            max-width: 1000px;
            width: 600px;
            margin: 20px auto;
            padding: 20px;
            background-color: #ffffff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .container h1 {
            text-align: center;
        }

        .form-group {
            width: 100%;
            margin-bottom: 15px;
            display: flex;
            flex-direction: column; /* Stack label and input vertically */
        }

        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #555;
        }

        .form-group input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 25px;
            font-size: 16px;
            box-sizing: border-box; /* Include padding and border in width */
        }

        .form-group input:focus {
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
            outline: none;
        }

        .btn {
            display: block;
            width: 100%;
            padding: 15px;
            background-color: #3333ff;
            color: #ffffff;
            border: none;
            border-radius: 30px;
            font-weight: 600;
            cursor: pointer;
            text-align: center;
            transition: background-color 0.3s;
        }

        .btn:hover {
            background-color: #0000cc;
        }

        #error {
            color: #e74c3c; /* Red color for errors */
            font-weight: bold;
        }

        .text-center {
            text-align: center;
        }

        /* Media Queries for responsiveness */
        @media (max-width: 600px) {
            .container {
                padding: 15px;
            }

            .form-group input {
                padding: 8px;
                font-size: 14px;
            }

            .btn {
                padding: 10px;
                font-size: 16px;
            }
        }

    </style>
</head>
<body>
      <form id="form1" runat="server">
        <div class="container">
            <h1>Register</h1>
            <div class="form-group">
                <label>Username:</label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Client Name:</label>
                <asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Age:</label>
                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Address:</label>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="addBtn" runat="server" Text="Create Account" CssClass="btn" OnClick="addBtn_Click" />
            </div>
            <div class="form-group">
                <asp:Button ID="loginBtn" runat="server" Text="Login" CssClass="btn" OnClick="loginBtn_Click" />
            </div>
            <asp:Label ID="lblText" runat="server" ForeColor="Green"></asp:Label>
            <div id="error"></div>
        </div>
    </form>
</body>
</html>
