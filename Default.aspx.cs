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

        string keyword = searchKey.Text;
        if (keyword != null)
        {
            Session["SearchLocation"] = keyword;
            Response.Redirect("SearchResult.aspx");
        }
        else
        {
            ErrorLabel.Text = "Please enter a location. :)";
        }

    }
}