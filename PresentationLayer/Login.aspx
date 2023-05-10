<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentationLayer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    
<!DOCTYPE html>

<html>
<head>
    <title>Login Page</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }
        form {
            border: 3px solid #f1f1f1;
        }
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }
        button:hover {
            opacity: 0.8;
        }
        .cnbtn {
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 49%;
        }
        .lgnbtn {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 50%;
        }
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }
        img.avatar {
            width: 40%;
            border-radius: 50%;
        }
        .container {
            padding: 16px;
        }
        span.psw {
            float: right;
            padding-top: 16px;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }
            .cnbtn {
                width: 100%;
            }
        }
        .frmalg {
            margin: auto;
            width: 40%;
        }
    </style>

</head>
<body>
    <form id="form1" class="frmalg">

        <div class="container">
            <center>
                <h3>Login Page </h3>
            </center>
             <label for="uId"><b>UserId</b></label>&nbsp;
            <asp:TextBox ID="UserId" runat="server" placeholder="Enter UserId"></asp:TextBox>
            <label for="psw"><b>Password</b></label>
            <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
            <br />
            <asp:Button ID="logInButton" runat="server" CssClass="lgnbtn" OnClick="logInButton_Click" Text="Login" />
            <asp:Button runat="server" ID="btn_cancel" Text="Cancel" class="cnbtn" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>   
</asp:Content>
