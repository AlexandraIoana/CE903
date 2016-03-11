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
        if (!IsPostBack)
        {
            LoggedUser loggedUser = (LoggedUser)Session["User"];
            Host host = (Host)Session["Host"];
            if (loggedUser != null)
            {
                //get username
                String customer_username = loggedUser.loginName;
                //display message
                logout_lbl.Text = "You are already login as " + "." + customer_username;
                logout.Visible = true;

            }
            else if (host != null)
            {
                //get username
                String host_username = host.loginName;
                //display message
                logout_lbl.Text = "You are already login as " + host_username;
                logout.Visible = true;
            }
            else
            {
                logout.Visible = false;
            }
        }
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
                loggedUser = LoggedUser.retrieveUser(username);

                Session["User"] = loggedUser;
                Response.Redirect("UserProfile.aspx");//profile of user
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
    /**destroy sessions*/
    protected void logout_Click(object sender, EventArgs e)
    {
        Session["User"] = null;
        Session["Host"] = null;
        Response.Redirect("Login.aspx");
    }
}