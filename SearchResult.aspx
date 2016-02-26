<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="location" runat="server"></asp:TextBox>
        <asp:TextBox ID="numberGuests" type="number" runat="server"></asp:TextBox>
        <asp:TextBox ID="price" type="number" runat="server"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="Search" />
    </div>
    </form>
</body>
</html>
