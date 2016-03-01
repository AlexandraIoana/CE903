using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // Check the values of the search textboxes and make the new search.
        }

        // Check in Session if there are search criteria to display results.
    }
    protected void Button_ViewProperty(object sender, EventArgs e)
    {

        //string location = location.Text;
        string noOfGuests = numberGuests.Text;
        //string price = price.Text;
        if (noOfGuests != null)
        {
            Response.Redirect("SearchResult.aspx");

        }
        else
        {
            ErrorLabel.Text = "Could not find a match for the above criteria. Please try with other criteria";
        }

    }
    protected void Button_ViewPropertyDetails(object sender, EventArgs e)
    {

        string propertyId = "null";

        if (propertyId != null)
        {
            Response.Redirect("ViewProperty.aspx");

        }
        else
        {
            ErrorLabel.Text = "Could not find property details. Please contact the host";
        }

    }
}