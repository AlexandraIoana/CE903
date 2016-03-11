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
        Confirm.Enabled = false;
        GoBack.Visible = false;
        Booking bookingReq = (Booking)Session["BookingDetails"];
        int propertyId = (int)Session["PropertyId"];
        Property propertyret = Property.retrieveProperty(propertyId);
        Boolean BookingOk = bookingReq.createBooking(loggedUser, propertyret, bookingReq.startDate, bookingReq.endDate);
        if (BookingOk)
        {
            confirmation_msg.Text = "Your Booking is done. Kindly please contact the host for making payment";
            ContactHostBtn.Visible = true;
            
        }
        else
        {
            error_msg.Text = "Sorry we hit a glitch!, please enter your details again";
        }
        
        
    }

    protected void Contact_Host(object sender, EventArgs e)
    {
        int propertyId = (int)Session["propertyId"];
        property = Property.retrieveProperty(propertyId);
        Session["messageFor"] = property.host;
        Response.Redirect("DisplayMessages.aspx");

    }

     protected void Redo_Booking(object sender, EventArgs e)
        {
             Response.Redirect("RequestBooking.aspx");
     
        }
    }