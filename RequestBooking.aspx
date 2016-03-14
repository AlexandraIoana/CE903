<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RequestBooking.aspx.cs" Inherits="RequestBooking" %>

<script language="C#" runat="server">

    void Selection_Change(Object sender, EventArgs e)
    {
        Availability.Text = "";
        Check_Date(sender, e);
        startDateLab.Text = startDate.SelectedDate.ToShortDateString();



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
        if (result > 0 || result == 0)
        {
            error_msg.Text = "Please select future date";
            startDateLab.Text = "";
            SetFocus(startDateLab);
        }

    }

    void Calendar_Visibility_end(Object sender, EventArgs e)
    {
        if (startDateLab.Text == "")
        {
            error_msg.Text = "Please select a start date";
            endDateLab.Text = "";
            SetFocus(startDateLab);
        }


    }
    void Validate(Object sender, ServerValidateEventArgs e)
    {
        if (startDateLab.Text == "" || endDateLab.Text == "")
        {
            error_msg.Text = "Please select booking dates";
            e.IsValid = false;
            SetFocus(startDateLab);
        }
        else if (startDateLab.Text == "")
        {
            error_msg.Text = "Please select a start date";
            e.IsValid = false;
            SetFocus(startDateLab);
        }
        else if (endDateLab.Text == "")
        {
            error_msg.Text = "Please select an end date";
            e.IsValid = false;
            SetFocus(startDateLab);
        }

    }

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <h2>Request Booking</h2>
    <br />
    <p>You might want to check first the available dates of the property.</p>
    <asp:Button ID="Button1" runat="server" Text="Check Availability" class="btn btn-default" ValidateRequestMode="Disabled" PostBackUrl="~/Availability.aspx" />
    <br /><br />
    <div class="row">
        <div class="col-md-4" style="width: 8%">
            <asp:Label ID="Label1" runat="server" Text="Label">Start Date</asp:Label>
        </div>
        <div class="col-md-4" style="width: 21%">
            <asp:TextBox ID="startDateLab" runat="server" CssClass="form-control" Width="250px" />
        </div>

        <div class="col-md-4" style="width: 5%">
            <a href="#popup1">
                <asp:Image ID="ImageButton1" runat="server" ImageUrl="~/Content/Images/icon_calendar_small.png" />
            </a>
        </div>
    </div>
    <br />
    <div id="popup1" class="overlay">
        <div class="popup">
            <div class="content">
                <asp:Calendar ID="startDate" runat="server" OnSelectionChanged="Selection_Change" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
    </div>

    <div class="row">
        <div class="col-md-4" style="width: 8%">
            <asp:Label ID="Label2" runat="server" Text="Label">End Date</asp:Label>
        </div>
        <div class="col-md-4" style="width: 21%">
            <asp:TextBox ID="endDateLab" runat="server" CssClass="form-control" Width="250px" />
        </div>
        <div class="col-md-4" style="width: 5%">
            <a href="#popup2">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Images/icon_calendar_small.png" />
            </a>
        </div>
    </div>
    <div id="popup2" class="overlay">
        <div class="popup">
            <div class="content">
                <asp:Calendar ID="endDate" runat="server" OnSelectionChanged="Selection_ChangeEnd" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
    </div>
    <br />

    <asp:Button ID="reqBooking" runat="server" class="btn btn-default" Text="Request Booking" OnClick="Request_Booking" />
    <asp:Label ID="Availability" runat="server" Text=""></asp:Label>
    <asp:Label ID="error_msg" runat="server"></asp:Label>




</asp:Content>

