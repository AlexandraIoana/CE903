<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1>
            Hello, <asp:Label ID="Hello" runat="server" ></asp:Label>
        </h1>
        Here are your details: <br />
        <b>Login name: </b>
        <asp:Label ID="loginName" runat="server"></asp:Label>
        <br />
        <b>Name: </b>
        <asp:Label ID="name" runat="server"></asp:Label>
        <br />
        <b>Email adress: </b>
        <asp:Label ID="email" runat="server"></asp:Label>
        <br />
        <b><asp:Label ID="contactNumber_lbl" runat="server"></asp:Label> </b>
        <asp:Label ID="contactNumber" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Add_property_btn" runat="server" OnClick="Add_property_btn_Click" Text="Add Property" Visible="False" />
        <asp:Button ID="Search_property_btn" runat="server" OnClick="Search_property_btn_Click" Text="Search Property" Visible="False" />
        <br />

        <asp:PlaceHolder ID="user" runat="server"></asp:PlaceHolder>
         
    
    </div>
</asp:Content>
