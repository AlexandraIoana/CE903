<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:TextBox ID="location" runat="server"></asp:TextBox>
        <asp:TextBox ID="numberGuests" type="number" runat="server"></asp:TextBox>
        <asp:TextBox ID="price" type="number" runat="server"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="Search" OnClick="Button_ViewProperty" />
    </div>
    <div>
                      <p>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
            </p>
    </div>
    <div>
        <asp:Button ID="ViewProperty" runat="server" Text="Search" OnClick="Button_ViewPropertyDetails" />
    </div>
</asp:Content>