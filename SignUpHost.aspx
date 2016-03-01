<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SignUpHost.aspx.cs" Inherits="SignUpHost" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <p>Sign up for Host</p>
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
        <asp:Label ID="contactNumber_lbl" runat="server" Text="Contact number"></asp:Label>
        <asp:TextBox ID="contactNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="registerHost" runat="server" Text="Sign Up" OnClick="register_Click" />
        <asp:Label ID="error_msg" runat="server"></asp:Label>

    </div>
    
    </asp:Content>