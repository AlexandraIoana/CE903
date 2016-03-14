<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeFile="AddProperty.aspx.cs" Inherits="AddProperty" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <h3>Add Property</h3>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name" ErrorMessage="Name of the property is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="propertyName_lbl" runat="server" Text="Property name"></asp:Label>
        <asp:TextBox ID="name" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="location" ErrorMessage="Location of the property is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="location_lbl" runat="server" Text="Location"></asp:Label>
        <asp:TextBox ID="location" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="no_rooms" ErrorMessage="Number of rooms is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="no_rooms_lbl" runat="server" Text="Number of rooms"></asp:Label>
        <asp:TextBox ID="no_rooms" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RangeValidator id="Range1" ControlToValidate="no_rooms" MinimumValue="1" MaximumValue="500" Type="Integer" EnableClientScript="false" Text="The value for number of rooms must be from 1 to 500" runat="server"/>
        <br />
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="no_guests" ErrorMessage="Number of guests is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="no_guests_lbl" runat="server" Text="Number of guests"></asp:Label>
        <asp:TextBox ID="no_guests" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RangeValidator id="RangeValidator2" ControlToValidate="no_guests" MinimumValue="1" MaximumValue="500" Type="Integer" EnableClientScript="false" Text="The value for number of guests must be from 1 to 500" runat="server"/>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="price" ErrorMessage="Price of the property is required">*</asp:RequiredFieldValidator>
        <asp:Label ID="price_lbl" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="price" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Price format 0.00" ValidationExpression="^\d+(\.\d{1,2})?$" ControlToValidate="price"></asp:RegularExpressionValidator>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please complete all the fields before proceeding: " />
        <br />
        <asp:Button ID="upload_property" CssClass="btn btn-default" runat="server" Text="Add Property" OnClick="upload_property_Click" />   
        <asp:Label ID="error_msg" runat="server"></asp:Label>
    
    </div>


</asp:Content>