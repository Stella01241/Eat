<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Group.aspx.cs" Inherits="WebApplication11.Create_Group" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style>
        .Create_btn{
            margin-right: 30px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

       團名: <asp:TextBox ID="Group" runat="server"></asp:TextBox>  <br />   
       店名: <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><br />
       團圖: <asp:FileUpload ID="Upload" runat="server" />

        <asp:Button ID="OK" class="Create_btn" runat="server" Text="OK" OnClick="OK_Click" />
        <asp:Button ID="Reset" runat="server" Text="返回" OnClick="Reset_Click" />
    </form>
</body>
</html>
