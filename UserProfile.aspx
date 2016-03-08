<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Hello, <asp:Label ID="Hello" runat="server" ></asp:Label>
        </h1>
        Here are your details: <br />
        <b>Login name: </b>
        <asp:Label ID="loginName" runat="server"></asp:Label>
        <br />
        <b>Name: </b>
        <asp:Label ID="name" runat="server"></asp:Label>
        <br />
        <b>Email adress: </b>
        <asp:Label ID="email" runat="server"></asp:Label>
        <br />
        <b><asp:Label ID="contactNumber_lbl" runat="server"></asp:Label> </b>
        <asp:Label ID="contactNumber" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Add_property_btn" runat="server" OnClick="Add_property_btn_Click" Text="Add Property" Visible="False" />
        <asp:Button ID="Search_property_btn" runat="server" OnClick="Search_property_btn_Click" Text="Search Property" Visible="False" />
        <br />

        <asp:PlaceHolder ID="user" runat="server"></asp:PlaceHolder>
         
    
    </div>
    </form>
</body>
</html>
