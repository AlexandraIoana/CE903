<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SignUpControl.ascx.cs" Inherits="SignUpControl" %>

    <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="loginName" ErrorMessage="Username is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="loginName_lbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="loginName" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="loginName" Display="Dynamic" ErrorMessage="Username must include 5-10 alphanumeric characters" ValidationExpression="[\w]{5,10}"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="name" ErrorMessage="Name is is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="name_lbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage="Email address is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="email_lbl" runat="server" Text="Email address"></asp:Label>
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="email" Display="Dynamic" ErrorMessage="Invalid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password" ErrorMessage="Password is required">*</asp:RequiredFieldValidator>        
        <asp:Label ID="password_lbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="password" Display="Dynamic" ErrorMessage="Password must be 5 -15 characters long" ValidationExpression="[\S]{5,15}"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="password" Display="Dynamic" ErrorMessage="Password needs to have at least one capital letter" ValidationExpression=".*[A-Z].*"></asp:RegularExpressionValidator>
        <br />
    </div>
    
 