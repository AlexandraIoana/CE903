﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Sign up<br />
        <br />
        <asp:Label ID="loginName_lbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="loginName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="name_lbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="email_lbl" runat="server" Text="Email address"></asp:Label>
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="password_lbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="register" runat="server" Text="Sign Up" OnClick="register_Click" />
        <asp:Label ID="error_msg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
