using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button_Search(object sender, EventArgs e)
    {

        string keyword = searchkey.Text;
        if (keyword != null)
        {
                  Response.Redirect("SearchResult.aspx");

        }
        else
        {
            ErrorLabel.Text = "Could not find a match for the keyword. Please try with another keyword";
        }

    }
}