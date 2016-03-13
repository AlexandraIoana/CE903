<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RequestBooking.aspx.cs" Inherits="RequestBooking" %>
<script language="C#" runat="server">

      void Selection_Change(Object sender, EventArgs e) 
      {
          Availability.Text = "";
         Check_Date(sender, e);
         startDateLab.Text = startDate.SelectedDate.ToShortDateString();
         startDate.Visible = false;
         
         
      }
      void Selection_ChangeEnd(Object sender, EventArgs e)
      {
         // Check_Date(sender, e);
          
          endDateLab.Text = endDate.SelectedDate.ToShortDateString();
          endDate.Visible = false;
          if (startDate.SelectedDate != null && endDate.SelectedDate != null)
          {
              int result = DateTime.Compare(endDate.SelectedDate, startDate.SelectedDate);
              if (result < 0 || result == 0)
              {
                  error_msg.Text = "End date must be after the start date";
                  endDateLab.Text = "";
                  SetFocus(endDateLab);
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
              startDateLab.Text = "";
              SetFocus(startDateLab);
          }
         
       }
      void Calendar_Visibility(Object sender, EventArgs e)
      {
          startDate.Visible = true;
      }
      void Calendar_Visibility_end(Object sender, EventArgs e)
      {
          if (startDateLab.Text == "")
          {
              error_msg.Text = "Please select a start date";
              startDate.Visible = true;
              endDate.Visible = false;
              endDateLab.Text = "";
              SetFocus(startDateLab);
          }
         
          endDate.Visible = true;
      }

   </script>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <h2>Request Booking</h2>
    <br />
    <div class="row">
        <div class="col-md-4" style="width: 8%">
            <asp:Label ID="Label1" runat="server" Text="Label">Start Date</asp:Label>
</div><div class="col-md-4" style="width: 21%">
            <asp:TextBox ID="startDateLab" runat="server" CssClass="form-control" Width="250px" required /><br />
        </div>
        <div class="col-md-4" style="align-content: center">

            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Content/Images/icon_calendar_small.png" OnClick="Calendar_Visibility" />
        </div>
        <div class="col-md-4">
            <asp:Calendar ID="startDate" runat="server" OnSelectionChanged="Selection_Change" Visible="false" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
        <div class="col-md-4" style="width: 8%">
            <asp:Label ID="Label2" runat="server" Text="Label">End Date</asp:Label>
            </div><div class="col-md-4" style="width: 21%">
            <asp:TextBox ID="endDateLab" runat="server" CssClass="form-control" Width="250px" required /><br />
        </div>
        <div class="col-md-4" style="height: inherit">
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Content/Images/icon_calendar_small.png" OnClick="Calendar_Visibility_end" ImageAlign="Baseline" />
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
            </asp:Calendar>
            <br />
        </div>
    </div>
    <div class="row">
        <asp:Button ID="Button1" runat="server" Text="Check Availability" class="btn btn-default" />
        <asp:Button ID="reqBooking" runat="server" class="btn btn-default" Text="Request Booking" OnClick="Request_Booking" />
    </div>
    <div class="row">
        <asp:Label ID="Availability" runat="server" Text=""></asp:Label>
    </div>
    <div class="row">
        <asp:Label ID="error_msg" runat="server"></asp:Label>
    </div>
  

    
</asp:Content>

