<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DisplayMessages.aspx.cs" Inherits="DisplayMessages" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
  </asp:Content>