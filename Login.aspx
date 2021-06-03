<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication11.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script src="Bootstrap/js/bootstrap.js"></script>
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <script src="JQuery/jquery-3.6.0.min.js"></script>
    <style>


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="LoginArea">

          <fieldset>
            <legend> 點餐系統</legend>
         
        <p>Account:         
            <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox></p>
        <p>Password:
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></p>
        <asp:Button ID="Loginn" runat="server" Text="登入" OnClick="Loginn_Click" />
            <asp:Label ID="ltMessage" runat="server" ></asp:Label>
            <asp:PlaceHolder ID="Plc1" runat="server"></asp:PlaceHolder>

          </fieldset>
       </div>      
    </form>
</body>
</html>
