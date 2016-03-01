using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginHost : System.Web.UI.Page
{
    Host host = new Host();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //get host's username and paswword
            String username = loginName.Text;
            String pass = password.Text;

            //check credentials
            Boolean check = host.checkLogin(username, pass);
            if (check.Equals(true))//correct credentials
            {
                //store details in a session and redirect to a new page
                Host loggedHost = (Host)Session["Host"];
                if (loggedHost == null)
                {
                    loggedHost = new Host();
                }
                loggedHost.loginName = username;
                loggedHost.password = pass;

                Session["Host"] = loggedHost;
                //Response.Redirect("SomePage.aspx");
            }
            else
            {
                error_msg.Text = "Wrong credentials, pleasse try again";
            }

        }
    }
}