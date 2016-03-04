<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BookingReqConfirmation.aspx.cs" Inherits="BookingReqConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Please find your booking details</h2>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField HeaderText="Property" />
            <asp:BoundField HeaderText="Start Date" />
            <asp:BoundField HeaderText="End Date" />
            <asp:BoundField HeaderText="Guests" />
        </Columns>
    </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <asp:Button ID="Confirm" runat="server" Text="Confirm Booking" OnClick="Confirmation" />
    <asp:Button ID="GoBack" runat="server" Text="Go Back" OnClick="Redo_Booking"/>
    <asp:Label ID="confirmation_msg" runat="server"></asp:Label>

</asp:Content>

