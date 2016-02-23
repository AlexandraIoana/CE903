<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginHost.aspx.cs" Inherits="LoginHost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Login for Host</p>
        <asp:Label ID="loginName_lbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="loginName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="password_lbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
        <asp:Label ID="error_msg" runat="server"></asp:Label>

    </div>
    </form>
</body>
</html>
