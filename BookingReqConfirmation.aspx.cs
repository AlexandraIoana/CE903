using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookingReqConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Confirmation(object sender, EventArgs e)
    {
        Response.Redirect("Host.aspx");
        confirmation_msg.Text = "System hit a glitch!, please enter your details again";
    }

     protected void Redo_Booking(object sender, EventArgs e)
        {
             Response.Redirect("RequestBooking.aspx");
     
        }
    }