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
            if (properties.Count == 0)
            {
                ErrorLabel.Text = "Could not find a match for the above criteria. Please try with other criteria";
            }
            else
            {
                results.Controls.Clear();
                foreach (Property property in properties)
                {
                    PlaceHolder propertyInfo = new PlaceHolder();
                    HtmlGenericControl propertyTitle = new HtmlGenericControl("h3");
                    Label propertyLocation = new Label();
                    Label propertyPrice = new Label();
                    HyperLink link = new HyperLink();

                    propertyTitle.InnerHtml = property.name;
                    propertyPrice.ForeColor = Color.Blue;
                    propertyPrice.Text = "&pound; " + property.price.ToString();
                    propertyLocation.Text = property.location + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                    link.Text = "More details...";
                    link.NavigateUrl = "ViewProperty.aspx?propertyId=" + property.propertyId;
                    propertyInfo.Controls.Add(propertyTitle);
                    propertyInfo.Controls.Add(propertyPrice);
                    propertyInfo.Controls.Add(new LiteralControl("<br />"));
                    propertyInfo.Controls.Add(propertyLocation);
                    propertyInfo.Controls.Add(link);
                    propertyInfo.Controls.Add(new LiteralControl("<hr />"));

                    results.Controls.Add(propertyInfo);
                }
            }
        }

        // Check in Session if there are search criteria to display results.
    }

    protected void search_Click(object sender, EventArgs e)
    {

    }
}