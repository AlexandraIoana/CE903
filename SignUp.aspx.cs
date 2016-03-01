using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUp : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /**store user's details in the database*/
    protected void register_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //create a session
            LoggedUser user = (LoggedUser)Session["User"];
            if (user == null)
            {
                user = new LoggedUser();
            }

            //save details in a session
            user.loginName = loginName.Text;
            user.name = name.Text;
            user.email = email.Text.ToLower();//must be in lowercase
            user.password = password.Text;

            Session["User"] = user;
            bool registerUser = user.SignUp(user.loginName, user.name, user.email, user.password);//store in database
            if (registerUser == true)
            {
                //redirect to a page
            }
            else
            {
                error_msg.Text = "Something went wrong, enter your details again";
            }

        }
    }
}