<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ViewProperty.aspx.cs" Inherits="ViewProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        Property details:
            </p>
    <asp:FileUpload ID="FileUpload" runat="server" Visible="false"/>
    <asp:Button ID="btnUpload" runat="server" Text="Upload"
        OnClick="btnUpload_Click" Visible="false"/>
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""
        Font-Names="Arial"></asp:Label>
    <asp:Image ID="Image" runat="server" Visible="false" />
                <p>
                
                <asp:HyperLink class="btn btn-default" ID="HyperLink4" runat="server" NavigateUrl="~/email.aspx">Contact Host&raquo;</asp:HyperLink>
            </p>
</asp:Content>

