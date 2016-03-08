using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    Property property = new Property();
    /**display user's profile*/
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Host host = (Host)Session["Host"];
            LoggedUser loggedUser = (LoggedUser)Session["User"];
            String host_name = (String)Request.QueryString["hostId"];
            if (host_name != null)
            {
                // Load Host Profile from ViewProfile
                Host retrieveHost = Host.retrieveHost(host_name);

                //host's profile
                loginName.Text = retrieveHost.loginName;
                name.Text = retrieveHost.name;
                email.Text = retrieveHost.email;
                contactNumber.Text = retrieveHost.contactNumber;
                String number = "Contact number:";
                contactNumber_lbl.Text = number;

                user.Controls.Add(new LiteralControl("<br />"));
                //display properties for host
                Boolean check = property.checkProperty(retrieveHost.loginName);

                if (check)
                {
                    //retrieve property information for host
                    List<Property> h_property = property.retrievePropertyByHost(retrieveHost.loginName);

                    foreach (Property p in h_property)
                    {
                        Label property_num = new Label();
                        property_num.Text = "Property " + (h_property.IndexOf(p) + 1).ToString();
                        user.Controls.Add(property_num);
                        user.Controls.Add(new LiteralControl("<br />"));

                        Label p_name = new Label();
                        p_name.Text = p.name;
                        Label p_location = new Label();
                        p_location.Text = p.location;
                        Label p_rooms = new Label();
                        p_rooms.Text = p.numberRooms.ToString();
                        Label p_guests = new Label();
                        p_guests.Text = p.numberGuests.ToString();
                        Label p_price = new Label();
                        p_price.Text = p.price.ToString();
                        Label[] property_info = { p_name, p_location, p_rooms, p_guests, p_price };
                        //add labels
                        String[] labels = { "Name:", "Location:", "Number of rooms:", "Number of guests", "Price:" };
                        for (int i = 0; i < labels.Length; i++)
                        {
                            Label label = new Label();
                            label.ID = "Label" + i.ToString();
                            label.Text = labels[i];

                            user.Controls.Add(label);
                            user.Controls.Add(property_info[i]);
                            user.Controls.Add(new LiteralControl("<br />"));
                        }
                        user.Controls.Add(new LiteralControl("<br />"));
                    }
                }

            }
            else if (host == null)//user is not a host
            {
                if (loggedUser == null)//user is not a customer
                {
                    //something went wrong redirect to login page
                    Response.Redirect("Login.aspx");
                }
                else//user is a customer
                {
                    //customer's profile
                    Hello.Text = loggedUser.name;
                    loginName.Text = loggedUser.loginName;
                    name.Text = loggedUser.name;
                    email.Text = loggedUser.email;
                    Search_property_btn.Visible = true;
                }
            }
            else //user is a host
            {
                //host's profile
                Hello.Text = host.name;
                loginName.Text = host.loginName;
                name.Text = host.name;
                email.Text = host.email;
                contactNumber.Text = host.contactNumber;
                String number = "Contact number:";
                contactNumber_lbl.Text = number;
                Add_property_btn.Visible = true;

                user.Controls.Add(new LiteralControl("<br />"));
                //display properties for host
                Boolean check = property.checkProperty(host.loginName);
                if (check)
                {
                    //retrieve property information for host
                    List<Property> h_property = property.retrievePropertyByHost(host.loginName);

                    foreach (Property p in h_property)
                    {
                        Label property_num = new Label();
                        property_num.Text = "Property " + (h_property.IndexOf(p) + 1).ToString();
                        user.Controls.Add(property_num);
                        user.Controls.Add(new LiteralControl("<br />"));

                        Label p_name = new Label();
                        p_name.Text = p.name;
                        Label p_location = new Label();
                        p_location.Text = p.location;
                        Label p_rooms = new Label();
                        p_rooms.Text = p.numberRooms.ToString();
                        Label p_guests = new Label();
                        p_guests.Text = p.numberGuests.ToString();
                        Label p_price = new Label();
                        p_price.Text = p.price.ToString();
                        Label[] property_info = { p_name, p_location, p_rooms, p_guests, p_price };
                        //add labels
                        String[] labels = { "Name:", "Location:", "Number of rooms:", "Number of guests", "Price:" };
                        for (int i = 0; i < labels.Length; i++)
                        {
                            Label label = new Label();
                            label.ID = "Label" + i.ToString();
                            label.Text = labels[i];

                            user.Controls.Add(label);
                            user.Controls.Add(property_info[i]);
                            user.Controls.Add(new LiteralControl("<br />"));
                        }
                        user.Controls.Add(new LiteralControl("<br />"));
                    }
                }
                else
                {
                    Label no_property = new Label();
                    no_property.Text = "No properties for display";
                    user.Controls.Add(no_property);
                }
            }
        }
    }

    protected void Add_property_btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProperty.aspx");
    }

    protected void Search_property_btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResult.aspx");
    }
}