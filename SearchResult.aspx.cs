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
            String locat = "";
            double pric = 0;
            int numberOfGuests = 0;
            if (location.Text != "")
            {
                locat = location.Text;
            }
            if (Double.Parse(price.Text) != null)
            {
                pric = double.Parse(price.Text);
            }
            if (int.Parse(numberGuests.Text) != null)
            {
                numberOfGuests = int.Parse(numberGuests.Text);
            }

            List<Property> properties = SearchEngine.SearchByCompleteCriteria(locat, pric, numberOfGuests);

            results.Controls.Clear();
            foreach (Property property in properties)
            {
                PlaceHolder propertyInfo = new PlaceHolder();
                Label propertyTitle = new Label();
                Label propertyLocation = new Label();
                Label propertyPrice = new Label();

                propertyTitle.Text = property.name + " / ";
                propertyPrice.Text = property.price.ToString() + " / ";
                propertyLocation.Text = property.location;
                propertyInfo.Controls.Add(propertyTitle);
                propertyInfo.Controls.Add(propertyPrice);
                propertyInfo.Controls.Add(propertyLocation);
                propertyInfo.Controls.Add(new LiteralControl("<br />"));

                results.Controls.Add(propertyInfo);
            }
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

    protected void search_Click(object sender, EventArgs e)
    {

    }
}