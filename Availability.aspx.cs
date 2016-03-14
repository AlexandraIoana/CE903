using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Availability : System.Web.UI.Page
{
    List<DateTime> aDates;
    List<DateTime> pDates;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        Booking booking = new Booking();
        int propertyId = 0;
        try
        {
            propertyId = (int)Session["PropertyId"];
        }
        catch (Exception)
        {
            Response.Redirect("/SearchResult.aspx");
        }

        if (Request.QueryString["host"] == "true")
        {
            Button1.Visible = false;
            aDates = Booking.checkAcceptedBookedDates(propertyId);
            pDates = null;
        }
        else
        {
            Button2.Visible = false;
            aDates = Booking.checkAcceptedBookedDates(propertyId);
            pDates = Booking.checkPendingBookedDates(propertyId);
        }

        if (aDates != null)
        {
            for (int i = 0; i < aDates.Count(); i++)
            {
                Calendar1.SelectedDates.Add(aDates[i]);
                Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Red;
            }
        }

        if (pDates != null)
        {
            for (int i = 0; i < pDates.Count(); i++)
            {
                Calendar1.SelectedDates.Add(pDates[i]);
            }
        }

    }

    protected void BackToBooking(object sender, EventArgs e)
    {
        Response.Redirect("/RequestBooking.aspx");
    }

    protected void BackToUserProfile(object sender, EventArgs e)
    {
        Response.Redirect("/UserProfile.aspx");
    }
}