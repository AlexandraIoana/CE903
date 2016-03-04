<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RequestBooking.aspx.cs" Inherits="RequestBooking" %>
<script language="C#" runat="server">

      void Selection_Change(Object sender, EventArgs e) 
      {
         startDateLab.Text = startDate.SelectedDate.ToShortDateString();
         
      }
      void Selection_ChangeEnd(Object sender, EventArgs e)
      {

          endDateLab.Text = endDate.SelectedDate.ToShortDateString();
      }
      void show_calandar(Object sender, EventArgs e)
      {
          endDateLab.Text = "hello";
          //startDate.Visible = true;
      }

   </script>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

	<h2>Request Booking</h2><BR />
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="Label1" runat="server" Text="Label">Start Date</asp:Label>
            <asp:TextBox id="startDateLab" runat="server" CssClass="form-control" Width="250px" /><br/>
        </div>
        <div class="col-md-4">
            <asp:Calendar ID="startDate" runat="server" SelectionMode="Day" ShowGridLines="True" OnSelectionChanged="Selection_Change" >
                <SelectedDayStyle BackColor="Yellow" ForeColor="Red"></SelectedDayStyle>
            </asp:Calendar>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="Label2" runat="server" Text="Label">End Date</asp:Label>
            <asp:TextBox id="endDateLab" runat="server" CssClass="form-control" Width="250px" /><br />
        </div>
        <div class="col-md-4">
            <asp:Calendar ID="endDate" runat="server" SelectionMode="Day" ShowGridLines="True" OnSelectionChanged="Selection_ChangeEnd">
                <SelectedDayStyle BackColor="Yellow" ForeColor="Red"></SelectedDayStyle>
            </asp:Calendar><br />
        </div>
    </div>


    <asp:Label ID="Label3" runat="server" Text="Label">Number of Guest</asp:Label>
    <asp:TextBox ID="noGuests" runat="server" CssClass="form-control"></asp:TextBox><br />
    <asp:Button ID="reqBooking" runat="server"  class="btn btn-default" Text="Request Booking" OnClick="Request_Booking" />
    <asp:Label ID="error_msg" runat="server"></asp:Label>


    
</asp:Content>

