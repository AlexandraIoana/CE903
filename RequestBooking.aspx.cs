using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestBooking : System.Web.UI.Page
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
    protected void Request_Booking(object sender, EventArgs e)
    {

        Booking bookingReq = new Booking();
        bookingReq.loggedUser = loggedUser;
        bookingReq.property = property;
        bookingReq.startDate = startDateLab.Text;
        bookingReq.endDate = endDateLab.Text;
        int propertyId = (int)Session["propertyId"];
        property.propertyId = propertyId;
        Boolean BookingOk = bookingReq.createBooking(loggedUser, property, bookingReq.startDate, bookingReq.endDate);
        if (BookingOk)
        {
            Response.Redirect("BookingReqConfirmation.aspx");
        }
        else
        {
            error_msg.Text = "System hit a glitch!, please enter your details again";
        }
    }
}