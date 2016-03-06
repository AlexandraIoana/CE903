<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayMessages.aspx.cs" Inherits="DisplayMessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            Conversation between <asp:Label ID="user_name"  runat="server"></asp:Label> and <asp:Label ID="host_name"  runat="server"></asp:Label>
        </p>
        <p>
            <asp:PlaceHolder ID="messages" runat="server"></asp:PlaceHolder><br />
        </p>
        <p>
            <asp:TextBox ID="new_message" runat="server" Height="86px" MaxLength="300" Rows="3"  Width="183px"></asp:TextBox><br />
        </p>
        <p>
            <asp:Label ID="empty_message"  runat="server"></asp:Label><br />
        </p>
        <p>
            <asp:Button ID="sendButton" runat="server" Text="Send Message" OnClick="send_Click" /><br />
        </p>
    </div>
    </form>
</body>
</html>