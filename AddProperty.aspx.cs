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
        if (!Page.IsPostBack)
        {
            //add values to no_rooms ddl
            for (int i = 1; i < 11; i++)
            {
                no_rooms.Items.Add(i.ToString());
            }
        }
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
            addProperty.numberRooms = Convert.ToInt32(no_rooms.SelectedValue);//convert to integer
            addProperty.price = Convert.ToDouble(price); //convert to double
           
            Session["Property"] = addProperty;

            //get host's login name from the session
            String username = host.loginName;
            
            Boolean uploadProperty = host.addProperty(username, addProperty);
            if (uploadProperty == true)
            {
                //redirect to a page              
            }
            else
            {
                error_msg.Text = "Something went wrong, enter your details again";
            }

        }
    }
}