using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUpHost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //store host's details in the database
    protected void register_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //create a session
            Host registerHost = (Host)Session["Host"];
            if (registerHost == null)
            {
                registerHost = new Host();
            }

            //save details in a session
            registerHost.loginName = loginName.Text;
            registerHost.name = name.Text;
            registerHost.email = email.Text.ToLower();//must be in lowercase
            registerHost.password = password.Text;
            registerHost.contactNumber = contactNumber.Text;

            Session["Host"] = registerHost;
            bool registerUser = registerHost.SignUp(registerHost.loginName, registerHost.name,
                registerHost.email,registerHost.password,registerHost.contactNumber);//store in database
            //bool registerUser = registerHost.SignUp();//store in database

            if (registerUser == true)
            {
                //redirect to a page - upload property details
                Response.Redirect("AddProperty.aspx");
            }
            else
            {
                error_msg.Text = "Something went wrong, enter your details again";
            }

        }
    }
}