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
        int propertyId = (int)Session["PropertyId"];
        Property propertyret = Property.retrieveProperty(propertyId);
        bookingReq.loggedUser = loggedUser;
        bookingReq.property = propertyret;
        bookingReq.startDate = startDateLab.Text;
        bookingReq.endDate = endDateLab.Text;
       
        property.propertyId = propertyId;
        Session["BookingDetails"] = bookingReq;
        Session["startDate"] = startDateLab.Text; ;
        Session["endDate"] = endDateLab.Text;
        Session["PropertyName"] = property.name;
        Session["PropertyPrice"] = property.price;
        Session["loggedUser"] = loggedUser;
        Response.Redirect("BookingReqConfirmation.aspx");

    }
}