<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="loginName_lbl" runat="server" Text="Login name: "></asp:Label>
    
        <asp:Label ID="loginName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="name_lbl" runat="server" Text="Name: "></asp:Label>
        <asp:Label ID="name" runat="server"></asp:Label>
        <br />
        <asp:Label ID="email_lbl" runat="server" Text="Email adress: "></asp:Label>
        <asp:Label ID="email" runat="server"></asp:Label>
        <br />
        <asp:Label ID="contactNumber_lbl" runat="server"></asp:Label>
        <asp:Label ID="contactNumber" runat="server"></asp:Label>
    
        <br />
        <asp:PlaceHolder ID="user" runat="server"></asp:PlaceHolder>
    
        <br />
        <asp:Button ID="Add_property_btn" runat="server" OnClick="Add_property_btn_Click" Text="Add Property" Visible="False" />
    
    </div>
    </form>
</body>
</html>
