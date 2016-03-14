using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestBooking : System.Web.UI.Page
{
    Host host;
    LoggedUser loggedUser;
    Property property;
    protected void Page_Load(object sender, EventArgs e)
    {
        loggedUser = (LoggedUser)Session["User"];
        host = (Host)Session["Host"];
        property = (Property)Session["Property"];
        if (loggedUser == null && host == null)
        {
            Response.Redirect("/Login.aspx");
        }
        if (property == null)
        {
            property = new Property();
        }
    }
    protected void Request_Booking(object sender, EventArgs e)
    {
        try
        {
            DateTime startDate = Convert.ToDateTime(startDateLab.Text);
            DateTime endDate = Convert.ToDateTime(endDateLab.Text);
            Boolean isAvailable = Check_Availability(sender, e);
            if (isAvailable)
            {
                Booking bookingReq = new Booking();
                int propertyId = (int)Session["PropertyId"];
                Property propertyret = Property.retrieveProperty(propertyId);
                bookingReq.loggedUser = loggedUser;
                bookingReq.property = propertyret;
                bookingReq.startDate = startDateLab.Text;
                bookingReq.endDate = endDateLab.Text;

                property.propertyId = propertyId;
                Session["BookingDetails"] = bookingReq;
                Session["startDate"] = startDateLab.Text;
                Session["endDate"] = endDateLab.Text;
                Session["PropertyName"] = propertyret.name;
                Session["PropertyPrice"] = "&pound; " + propertyret.price.ToString();
                Session["loggedUser"] = loggedUser;
                Response.Redirect("BookingReqConfirmation.aspx");
            }
            else
            {
                Availability.Text = "Property not availabe from " + startDateLab.Text + " to " + endDateLab.Text;
                startDateLab.Text = "";
                endDateLab.Text = "";
            }
        }
        catch (Exception)
        {
            error_msg.Text = "Please enter the two dates.";
        }
    }
    protected Boolean Check_Availability(Object sender, EventArgs e)
    {
      
        int propertyId = (int)Session["PropertyId"];
        Boolean isAvailable = false;
        DateTime startDate = Convert.ToDateTime(startDateLab.Text);
        DateTime endDate = Convert.ToDateTime(endDateLab.Text);
        List<DateTime> dates = Booking.checkBookedDates(propertyId);
        if (dates.Count > 0)
        {
            List<DateTime> bookedDates = getDates(startDate, endDate);
            foreach (DateTime d in bookedDates) {
                if (dates.Contains(d)) {
                    return isAvailable;
                }
            }
            /*if (bookedDates.Contains(startDate) || dates.Contains(endDate))
            {

                isAvailable = false;

            }
            else
            {*/
                //Availability.Text = "Property is availabe for the dates. Kindly make booking.";
                isAvailable = true;
            //}

        }
        else
        {
            //Availability.Text = "Property is availabe for the dates. Kindly make booking.";
            isAvailable = true;
        }
        return isAvailable;
 
    }

    public List<DateTime> getDates(DateTime start, DateTime end)
    {
        DateTime date = start;
        List<DateTime> dates = new List<DateTime>();
        dates.Add(start);
        while ((date = date.AddDays(1)).Date <= end.Date)
        {
            dates.Add(date);
        }
        return dates;
    }

    protected void CheckAvailability(object sender, EventArgs e)
    {
        Response.Redirect("Availability.aspx");
    }
}