<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RequestBooking.aspx.cs" Inherits="RequestBooking" %>
<script language="C#" runat="server">

      void Selection_Change(Object sender, EventArgs e) 
      {
         Check_Date(sender, e);
         startDateLab.Text = startDate.SelectedDate.ToShortDateString();
         endDate.Visible = true;
         
      }
      void Selection_ChangeEnd(Object sender, EventArgs e)
      {
         // Check_Date(sender, e);
          endDateLab.Text = endDate.SelectedDate.ToShortDateString();
          if (startDate.SelectedDate != null && endDate.SelectedDate != null)
          {
              int result = DateTime.Compare(endDate.SelectedDate, startDate.SelectedDate);
              if (result < 0 || result == 0)
              {
                  error_msg.Text = "Please select end date a future date than start date";
              }
              else
              {
                  error_msg.Text = "";
              }
          }
      }
      void Check_Date(Object sender, EventArgs e)
      {
          DateTime localDate = DateTime.Now;
          int result = DateTime.Compare(localDate, startDate.SelectedDate);
          if (result>0 || result == 0 )
          {
              error_msg.Text = "Please select future date";
          }
         
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
            <asp:Calendar ID="startDate" runat="server" OnSelectionChanged="Selection_Change"  BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" >
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True"></SelectedDayStyle>
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="Label2" runat="server" Text="Label">End Date</asp:Label>
            <asp:TextBox id="endDateLab" runat="server" CssClass="form-control" Width="250px" /><br />
        </div>
        <div class="col-md-4">
            <asp:Calendar ID="endDate" runat="server" OnSelectionChanged="Selection_ChangeEnd" Visible="false" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True"></SelectedDayStyle>
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar><br />
        </div>
    </div>

    <asp:Button ID="reqBooking" runat="server"  class="btn btn-default" Text="Request Booking" OnClick="Request_Booking" />
    <asp:Label ID="error_msg" runat="server"></asp:Label>


    
</asp:Content>

