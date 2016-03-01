<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
    
        Sign up<br />
        <br />
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
        <asp:Button ID="register" runat="server" Text="Sign Up" OnClick="register_Click" />
        <asp:Label ID="error_msg" runat="server"></asp:Label>
    </div>
</asp:Content>

