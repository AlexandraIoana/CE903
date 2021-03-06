﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BookingReqConfirmation.aspx.cs" Inherits="BookingReqConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>Please find your booking details
    </h2>
    <div class="row">
        <div class="col-md-4" style="width: 13%">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Property Name"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <p>
                <asp:Label ID="PropertyNameLb" runat="server" Text="Propety Name" CssClass="form-control"></asp:Label>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4" style="width: 13%">
            <p>
                <asp:Label ID="Label2" runat="server" Text="Start Date"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <p>
                <asp:Label ID="StartDateLb" runat="server" Text="" CssClass="form-control"></asp:Label>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4" style="width: 13%">
            <p>
                <asp:Label ID="Label3" runat="server" Text="End Date"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <p>
                <asp:Label ID="EndDateLb" runat="server" Text="" CssClass="form-control"></asp:Label>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4" style="width: 13%">
            <p>
                <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <p>
                <asp:Label ID="PropertyPriceLb" runat="server" Text="" CssClass="form-control"></asp:Label>
            </p>
        </div>
    </div>


    <p>&nbsp;</p>
    <asp:Button ID="Confirm" CssClass="btn btn-default" runat="server" Text="Confirm Booking" OnClick="Confirmation" />
    <asp:Button ID="GoBack" CssClass="btn btn-default" runat="server" Text="Go Back" OnClick="Redo_Booking" />
    <h3>
        <asp:Label ID="confirmation_msg" runat="server"></asp:Label></h3>
    <asp:Button class="btn btn-default" ID="ContactHostBtn" runat="server" Visible="false" Text="Contact Host" OnClick="Contact_Host" />

    <asp:Label ID="error_msg" runat="server"></asp:Label>

</asp:Content>

