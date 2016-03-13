<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <div class="form-group col-lg-4" style="display: inline-block">
            <div class="input-group">
                <span class="input-group-addon">Location</span>
                <asp:TextBox ID="location" CssClass="form-control" runat="server" placeholder="Colchester, Chelmsford"></asp:TextBox>
            </div>
        </div>
        <div class="form-group col-lg-3" style="display: inline-block">
            <div class="input-group">
                <span class="input-group-addon">Number of Guests</span>
                <asp:TextBox ID="numberGuests" CssClass="form-control" min="1" Style="display: inline-block" type="number" runat="server" placeholder="2, 3, 4..."></asp:TextBox>
            </div>
        </div>
        <div class="form-group col-lg-3" style="display: inline-block">
            <div class="input-group">
                <span class="input-group-addon">Max price &pound;</span>
                <asp:TextBox ID="price" CssClass="form-control" min="1" Style="display: inline-block" type="number" runat="server" placeholder="£10, £50, £60..."></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="search_Click" />
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
