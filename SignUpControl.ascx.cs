using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUpControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public String LoginName
    {
        get { return loginName.Text; }
        set { loginName.Text = value; }
    }
    public String Name
    {
        get { return name.Text; }
        set { name.Text = value; }
    }
    public String Email
    {
        get { return email.Text; }
        set { email.Text = value; }
    }
    public String Password
    {
        get { return password.Text; }
        set { password.Text = value; }
    }
}