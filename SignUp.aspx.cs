using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUp : System.Web.UI.Page
{
    Host h = new Host();
    LoggedUser c = new LoggedUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // SignUpViews.ActiveViewIndex = 0;//idsplay customer registration
        }
    }

    protected void SignUpTab_Click(object sender, EventArgs e)
    {
        Button clicked = sender as Button;
        if (clicked.ID == "SignUpHost_btn")
        {
            SignUpHost_btn.CssClass = "btn btn-info";
            SignUpCustomer_btn.CssClass = "btn btn-default";
            SignUpViews.ActiveViewIndex = 1;//display host registration
        }
        else
        {
            SignUpCustomer_btn.CssClass = "btn btn-info";
            SignUpHost_btn.CssClass = "btn btn-default";
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
            Session["User"] = null;
            Session["Host"] = null;
            //check that username is unique
            Boolean check = user.checkUsername(SignUpControl_Customer.LoginName);
            Boolean check2 = h.checkUsername(SignUpControl_Customer.LoginName);
            if (check && check2)
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
            Session["User"] = null;
            Session["Host"] = null;
            //check username for host is unique
            Boolean check = registerHost.checkUsername(SignUpControl_Host.LoginName);
            Boolean check2 = c.checkUsername(SignUpControl_Host.LoginName);
            if (check && check2)
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