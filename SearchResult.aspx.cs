using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SearchResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // Check the values of the search textboxes and make the new search.
            String locat = "";
            double pric = 1000000;
            int numberOfGuests = 0;
            int searchBy = 0;
            List<Property> properties;
            if (location.Text != "")
            {
                locat = location.Text;
            }
            if (price.Text != "")
            {
                pric = double.Parse(price.Text);
            }
            if (numberGuests.Text != "")
            {
                numberOfGuests = int.Parse(numberGuests.Text);
            }


            if (price.Text != "" && location.Text == null && numberGuests.Text == null)
            {
                properties = SearchEngine.SearchPropertyByMaxPrice(pric);
            }
            else if (price.Text == null && location.Text == null && numberGuests.Text != null)
            {
                properties = SearchEngine.SearchPropertyByNumberOfGuests(numberOfGuests);
            }
            else
            {
                properties = SearchEngine.SearchByCompleteCriteria(locat, pric, numberOfGuests);
            }
            if (properties.Count == 0)
            {
                ErrorLabel.Text = "Could not find a match for the above criteria. Please try with other criteria.";
            }
            else
            {
                ErrorLabel.Text = "";
                displayProperties(properties);
            }
        }

        // Check in Session if there are search criteria to display results.
        String searchLocation = (String)Session["searchLocation"];
        if (searchLocation != null)
        {
            location.Text = searchLocation;

            List<Property> properties = SearchEngine.SearchPropertyByLocation(searchLocation);
            if (properties.Count == 0)
            {
                ErrorLabel.Text = "Could not find a match for the above criteria. Please try with other criteria.";
            }
            else
            {
                ErrorLabel.Text = "";
                displayProperties(properties);
            }
        }
    }

    protected void search_Click(object sender, EventArgs e)
    {
        // Do nothing, postback will handle it
    }

    protected void displayProperties(List<Property> properties)
    {
        results.Controls.Clear();
        HtmlGenericControl leftSide = new HtmlGenericControl("div");
        HtmlGenericControl rightSide = new HtmlGenericControl("div");

        leftSide.Attributes.CssStyle.Add("width", "50%");
        leftSide.Attributes.CssStyle.Add("float", "left");
        rightSide.Attributes.CssStyle.Add("width", "50%");
        rightSide.Attributes.CssStyle.Add("float", "right");

        int count = 0;
        foreach (Property property in properties)
        {
            property.loadImages();

            ImageButton propertyImage = new ImageButton();
            propertyImage.Height = 130;
            propertyImage.ID = "image" + count;
            if (property.images.Count == 0)
            {
                propertyImage.ImageUrl = "Content/Images/NoImageFound.png";
            }
            else
            {
                propertyImage.ImageUrl = "data:image/png;base64," + property.images[0].bytesInBase64;
            }

            HtmlGenericControl propertyInfo = new HtmlGenericControl("fieldset");
            HtmlGenericControl divPhoto = new HtmlGenericControl("div");
            HtmlGenericControl divInfo = new HtmlGenericControl("div");
            HtmlGenericControl propertyTitle = new HtmlGenericControl("h3");
            Label propertyLocation = new Label();
            Label propertyPrice = new Label();
            HyperLink link = new HyperLink();

            divPhoto.Attributes.CssStyle.Add("width", "200");
            divPhoto.Attributes.CssStyle.Add("float", "left");
            divInfo.Attributes.CssStyle.Add("margin-left", "15px");
            divInfo.Attributes.CssStyle.Add("display", "inline-block");

            propertyTitle.InnerHtml = property.name;
            propertyPrice.ForeColor = Color.Blue;
            propertyPrice.Text = "&pound; " + property.price.ToString();
            propertyLocation.Text = property.location;
            link.Text = "More details...";
            link.NavigateUrl = "ViewProperty.aspx?propertyId=" + property.propertyId;
            propertyImage.PostBackUrl = "ViewProperty.aspx?propertyId=" + property.propertyId;
            divPhoto.Controls.Add(propertyImage);
            divInfo.Controls.Add(propertyTitle);
            divInfo.Controls.Add(propertyPrice);
            divInfo.Controls.Add(new LiteralControl("<br />"));
            divInfo.Controls.Add(propertyLocation);
            divInfo.Controls.Add(new LiteralControl("<br />"));
            divInfo.Controls.Add(link);
            propertyInfo.Controls.Add(divPhoto);
            propertyInfo.Controls.Add(divInfo);
            propertyInfo.Controls.Add(new LiteralControl("<hr />"));

            if (count % 2 == 0)
            {
                leftSide.Controls.Add(propertyInfo);
            }
            else
            {
                rightSide.Controls.Add(propertyInfo);
            }
            count++;
        }

        results.Controls.Add(leftSide);
        results.Controls.Add(rightSide);
    }

}