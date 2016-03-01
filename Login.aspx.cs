using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{

    LoggedUser user = new LoggedUser();
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
            Boolean check = user.checkLogin(username, pass);
            if (check.Equals(true))//correct credentials
            {
                //store details in a session and redirect to a new page
                LoggedUser loggedUser = (LoggedUser)Session["User"];
                if (loggedUser == null)
                {
                    loggedUser = new LoggedUser();
                }
                loggedUser.loginName = username;
                loggedUser.password = pass;

                Session["User"] = loggedUser;
                //Response.Redirect("SomePage.aspx");
            }
            else
            {
                error_msg.Text = "Wrong credentials, pleasse try again";
            }

        }
    }
}