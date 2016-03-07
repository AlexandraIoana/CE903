using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{

    LoggedUser customer = new LoggedUser();
    Host hostUser = new Host();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /**checks if the user tries to login as host or as customer and redirects him
    to the corresponding profile page*/
    protected void login_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //get host's username and paswword
            String username = loginName.Text;
            String pass = password.Text;

            //check if the user is a customer
            Boolean checkUser = customer.checkLogin(username, pass);
            //check if the user is a host
            Boolean checkHost = hostUser.checkLogin(username, pass);
            if (checkUser)//user is customer
            {
                //store details in a session and redirect to profile page
                LoggedUser loggedUser = (LoggedUser)Session["User"];
                if (loggedUser == null)
                {
                    loggedUser = new LoggedUser();
                }
                loggedUser.loginName = username;
                loggedUser.password = pass;

                Session["User"] = loggedUser;
                //Response.Redirect("SomePage.aspx");//profile of user
            }
            else if (checkHost) //user is host
            {
                //store details in a session and redirect to profile page
                Host host = (Host)Session["Host"];
                if (host == null)
                {
                    host = new Host();
                }

                //retrieve host's information
                host = Host.retrieveHost(username);
                Session["Host"] = host;
                Response.Redirect("UserProfile.aspx");//profile of host
            }
            else
            {
                error_msg.Text = "Wrong credentials, try again";
            }

        }
    }
}