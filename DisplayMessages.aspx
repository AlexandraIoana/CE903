<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DisplayMessages.aspx.cs" Inherits="DisplayMessages" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h3>
            Conversation between <asp:Label ID="user_name"  runat="server"></asp:Label> and <asp:Label ID="host_name"  runat="server"></asp:Label>
        </h3>
        <p>
            <asp:PlaceHolder ID="messages" runat="server"></asp:PlaceHolder><br />
        </p>
        <br />
            <asp:TextBox ID="new_message" TextMode="MultiLine" CssClass="form-control" runat="server" Height="86px" MaxLength="300" Rows="3"  Columns="40"></asp:TextBox><br />
        <p> 
            <asp:Label ID="empty_message"  runat="server"></asp:Label><br />
        </p>
        <p>
            <asp:Button ID="sendButton" CssClass="btn btn-default" runat="server" Text="Send Message" OnClick="send_Click" /><br />
        </p>
    </div>
  </asp:Content>