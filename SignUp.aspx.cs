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
        if (!IsPostBack)
        {
            SignUpViews.ActiveViewIndex = 0;//idsplay customer registration
        }
    }

    protected void SignUpTab_Click(object sender, EventArgs e)
    {
        Button clicked = sender as Button;
        if (clicked.ID == "SignUpHost_btn")
        {
            SignUpViews.ActiveViewIndex = 1;//display host registration
        }
        else
        {
            SignUpViews.ActiveViewIndex = 0;//idsplay customer registration
        }
    }


    /**register user as customer*/
    protected void registerCustomer_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {

            //create a session
            LoggedUser user = (LoggedUser)Session["User"];
            if (user == null)
            {
                user = new LoggedUser();
            }
            //check that username is unique
            Boolean check = user.checkUsername(SignUpControl_Customer.LoginName);
            if (check)
            {
                //save details in a session
                user.loginName = SignUpControl_Customer.LoginName;
                user.name = SignUpControl_Customer.Name;
                user.email = SignUpControl_Customer.Email.ToLower();//must be in lowercase
                user.password = SignUpControl_Customer.Password;

                Session["User"] = user;
                bool registerUser = user.SignUp(user.loginName, user.name, user.email, user.password);//store in database
                if (registerUser)
                {
                    //redirect to a page
                    Response.Redirect("UserProfile.aspx");
                }
                else
                {
                    errorCustomer_msg.Text = "Something went wrong, enter your details again";
                }
            }
            else
            {
                errorCustomer_msg.Text = "Change username";
            }

        }
    }

    /**register user as host*/
    protected void registerHost_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {

            //create a session
            Host registerHost = (Host)Session["Host"];
            if (registerHost == null)
            {
                registerHost = new Host();
            }
            Boolean check = registerHost.checkUsername(SignUpControl_Host.LoginName);
            if (check)
            {
                //save details in a session
                registerHost.loginName = SignUpControl_Host.LoginName;
                registerHost.name = SignUpControl_Host.Name;
                registerHost.email = SignUpControl_Host.Email.ToLower();//must be in lowercase
                registerHost.password = SignUpControl_Host.Password;
                registerHost.contactNumber = contactNumber.Text.Trim();//remove whitespace

                Session["Host"] = registerHost;
                bool registerUser = registerHost.SignUp(registerHost.loginName, registerHost.name,
                    registerHost.email, registerHost.password, registerHost.contactNumber);//store in database

                if (registerUser)
                {
                    //redirect to a page - host's profile
                    Response.Redirect("UserProfile.aspx");
                }
                else
                {
                    errorHost_msg.Text = "Something went wrong, enter your details again";
                }
            }
            else
            {
                errorHost_msg.Text = "Change username";
            }

        }
    }
}