<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <asp:TextBox ID="location" runat="server" placeholder="Location"></asp:TextBox>
        <asp:TextBox ID="numberGuests" type="number" runat="server" placeholder="Number of guests"></asp:TextBox>
        <asp:TextBox ID="price" type="number" runat="server" placeholder="Max price willing to pay"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="Search" OnClick="search_Click" />
    </div>
    <hr />
    <fieldset>
        <asp:PlaceHolder ID="results" runat="server"></asp:PlaceHolder>
    </fieldset>
    <div>
            <p>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
            </p>
    </div>
</asp:Content>