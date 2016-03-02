<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TestImages.aspx.cs" Inherits="TestImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload"
        OnClick="btnUpload_Click" />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""
        Font-Names="Arial"></asp:Label>
    <hr />

    <asp:DropDownList ID="ddlImages" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="FetchImage">
        <asp:ListItem Text="Select Image" Value="0" />
    </asp:DropDownList>
    <hr />
    <asp:Image ID="Image1" runat="server" Visible="false" />
</asp:Content>

