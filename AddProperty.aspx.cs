using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProperty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //store property's details to the database
    protected void upload_property_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //create session
            Property addProperty = (Property)Session["Property"];
            Host host = (Host)Session["Host"];
            if (addProperty == null)
            {
                addProperty = new Property();
            }

            //save details in a session
            addProperty.name = name.Text;
            addProperty.location = location.Text;
            addProperty.numberRooms = Convert.ToInt32(no_rooms.Text);//convert to integer
            addProperty.numberGuests = Convert.ToInt32(no_guests.Text);//convert to integer
            addProperty.price = double.Parse(price.Text); //convert to double

            Session["Property"] = addProperty;

            //get host's login name from the session
            String username = host.loginName;
            Boolean uploadProperty = host.addProperty(username, addProperty);
            Property property = Property.retrieveProperty(addProperty.name);
            if (uploadProperty)
            {
                //redirect to a page     
                Response.Redirect("ViewProperty.aspx?propertyId=" + property.propertyId);
            }
            else
            {
                error_msg.Text = "Something went wrong, enter your details again";
            }

        }
    }
}