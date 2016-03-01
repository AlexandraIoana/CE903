<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1> Bed And Breakfast</h1>
        <p class="lead">Why Bed and Breakast</p>
        <p><a href="http://www.bnb.co.uk" class="btn btn-primary btn-lg">About Us &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>My Account</h2>
            <p>
                Please login if you are an existing user or signup if you are a new user.
            </p>
            <p>
               
                <asp:HyperLink class="btn btn-default" ID="HyperLink1" runat="server" Text="Login" NavigateUrl="~/Login.aspx">Login&raquo;</asp:HyperLink>
            
                <asp:HyperLink class="btn btn-default" ID="HyperLink2" runat="server" Text="Login" NavigateUrl="~/SignUp.aspx">Sign up&raquo;</asp:HyperLink>
             </p>
        </div>
        <div class="col-md-4">
            <h2>Search</h2>
            <p>
               Please enter keyword:

            </p>
            <p>
                <asp:TextBox runat="server" ID="searchkey" CssClass="form-control" Width="300px" />
                <i>eg. Dorset, cottage etc.</i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" OnClick="Button_Search" Text="Search" CssClass="btn btn-default" />
            </p>
              <p>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Gallery</h2>
            <p>
                Find out more from our gallery.
            </p>
            <p>
                
                <asp:HyperLink class="btn btn-default" ID="HyperLink4" runat="server" NavigateUrl="~/gallery.aspx">Gallery&raquo;</asp:HyperLink>
            </p>
        </div>
    </div>
</asp:Content>

