<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProperty.aspx.cs" Inherits="AddProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <p>Add Property</p>
        <asp:Label ID="propertyName_lbl" runat="server" Text="Property name"></asp:Label>
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="location_lbl" runat="server" Text="Location"></asp:Label>
        <asp:TextBox ID="location" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="no_rooms_lbl" runat="server" Text="Number of rooms"></asp:Label>
        <asp:DropDownList ID="no_rooms" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <asp:Label ID="price_lbl" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="price" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="upload_property" runat="server" Text="Add Property" OnClick="upload_property_Click" />   
        <asp:Label ID="error_msg" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
