using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Availability : System.Web.UI.Page
{
    LoggedUser loggedUser;
    Property property;
    protected void Page_Load(object sender, EventArgs e)
    {
        loggedUser = (LoggedUser)Session["User"];
        property = (Property)Session["Property"];
        if (loggedUser == null)
        {
            loggedUser = new LoggedUser();
        }
        if (property == null)
        {
            property = new Property();
        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)

    {
        Booking booking = new Booking();

        int propertyId = (int)Session["PropertyId"];
        List<DateTime> dates = Booking.checkBookedDates(propertyId);
        if (dates != null)
        {
            for (int i = 0; i < dates.Count(); i++)
            {
                Calendar1.SelectedDates.Add(dates[i]);
                Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Red;
            }
        }
      
            }

    protected void BackToBooking(object sender, EventArgs e)
    {
      

        Response.Redirect("RequestBooking.aspx");

    }
}