<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 style="color:whitesmoke"> IBAN</h1>
        <p class="lead" style="color:whitesmoke">Uk's no.1 Bed and Breakfast</p>
        <p><a href="/About.aspx" class="btn btn-primary btn-lg">About Us &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4" style="width:40%">
            <h2>My Account</h2>
            <p>
                Please login if you are an existing user or signup if you are a new user.
            </p>
            <p>
               
                <asp:HyperLink class="btn btn-default" ID="HyperLink1" runat="server" Text="Login" NavigateUrl="~/Login.aspx">Login&raquo;</asp:HyperLink>
            
                <asp:HyperLink class="btn btn-default" ID="HyperLink2" runat="server" Text="Login" NavigateUrl="~/SignUp.aspx">Sign up&raquo;</asp:HyperLink>
             </p>
        </div>
        <div class="col-md-4" style="width:60%">
            <h2>&nbsp;Search</h2>
            <p>
               &nbsp;&nbsp;&nbsp;Please enter a location:
            </p>

           <div class="col-md-4" style="width:38%">

                <asp:TextBox runat="server" ID="searchKey" CssClass="form-control" Width="260px" placeholder="eg. Colchester, London, etc." /> </div>
              <div class="col-md-4" style="width:18%">
            <asp:Button runat="server" OnClick="Button_Search" Text="Search" CssClass="btn btn-default" />
               </div> 
         
            </div>
          
    </div>
 

                <p>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
            </p>
     
</asp:Content>

