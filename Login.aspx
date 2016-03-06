<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <p>Login</p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="loginName" ErrorMessage="Username is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="loginName_lbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="loginName" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" ErrorMessage="Password is required">*</asp:RequiredFieldValidator>     
        <asp:Label ID="password_lbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please complete all the fields before proceeding: " />
        <br />
        <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
        <asp:Label ID="error_msg" runat="server"></asp:Label>

    </div>

    </asp:Content>