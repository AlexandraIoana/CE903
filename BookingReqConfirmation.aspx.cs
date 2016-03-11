using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookingReqConfirmation : System.Web.UI.Page
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
    
        PropertyNameLb.Text =(String)Session["PropertyName"];
        StartDateLb.Text = (String)Session["StartDate"];
        EndDateLb.Text = (String)Session["EndDate"];
       // Double propertyPrice =(Double)Session["PropertyPrice"];
        PropertyPriceLb.Text = Session["PropertyPrice"].ToString();
   
    }
    
    protected void Confirmation(object sender, EventArgs e)
    {
        Booking bookingReq = (Booking)Session["BookingDetails"];
        int propertyId = (int)Session["PropertyId"];
        Property propertyret = Property.retrieveProperty(propertyId);
        Boolean BookingOk = bookingReq.createBooking(loggedUser, propertyret, bookingReq.startDate, bookingReq.endDate);
        if (BookingOk)
        {
            confirmation_msg.Text = "Booking Done. Kindly contact the host for payment";
        }
        else
        {
            error_msg.Text = "Sorry we hit a glitch!, please enter your details again";
        }
        
        
    }

     protected void Redo_Booking(object sender, EventArgs e)
        {
             Response.Redirect("RequestBooking.aspx");
     
        }
    }