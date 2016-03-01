<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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

    </asp:Content>