using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    Property property = new Property();
    String host_name;
    /**display user's profile*/
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Host host = (Host)Session["Host"];
            LoggedUser loggedUser = (LoggedUser)Session["User"];
            host_name = (String)Request.QueryString["hostId"];
            if (loggedUser == null && host == null) //user is not a customer or a host
            {
                //something went wrong redirect to login page
                Response.Redirect("Login.aspx");
            }

            if (host == null)//user is not a host
            {
                // Check if id of host is in queryString
                if (host_name != null)
                {
                    ContactHostBtn.Visible = true;
                    loadOtherHostProfile(host_name);
                }
                else
                {
                    //customer's profile
                    Hello.Text = "Hello, " + loggedUser.name;
                    loginName.Text = loggedUser.loginName;
                    name.Text = loggedUser.name;
                    email.Text = loggedUser.email;
                    Search_property_btn.Visible = true;

                    List<Booking> acceptedBookings = Booking.getAcceptedBookings(loggedUser.loginName);
                    List<Booking> rejectedBookings = Booking.getRejectedBookings(loggedUser.loginName);

                    if (acceptedBookings.Count != 0)
                    {
                        HtmlGenericControl title = new HtmlGenericControl("h3");
                        title.InnerHtml = "Accepted Booking Requests";
                        bookingInformation.Controls.Add(title);
                        bookingInformation.Controls.Add(new HtmlGenericControl("hr"));
                        foreach (Booking b in acceptedBookings)
                        {
                            displayBookingInfoUser(b);
                        }
                    }

                    if (rejectedBookings.Count != 0)
                    {
                        HtmlGenericControl title = new HtmlGenericControl("h3");
                        title.InnerHtml = "Rejected Booking Requests";
                        bookingInformation.Controls.Add(title);
                        bookingInformation.Controls.Add(new HtmlGenericControl("hr"));
                        foreach (Booking b in rejectedBookings)
                        {
                            displayBookingInfoUser(b);
                        }
                    }
                }
            }
            else //user is a host
            {
                // Check if id of host is in queryString
                if (host_name != null && host.loginName != host_name)
                {
                    loadOtherHostProfile(host_name);
                }
                else
                {
                    //host's profile
                    Hello.Text = "Hello, " + host.name;
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
                        List<Booking> pendingBookings = Booking.getPendingBookings(host.loginName);

                        foreach (Property p in h_property)
                        {
                            addPropertyInfo(p, h_property.IndexOf(p) + 1);
                        }

                        if (pendingBookings.Count != 0)
                        {
                            HtmlGenericControl title = new HtmlGenericControl("h3");
                            title.InnerHtml = "Pending Booking Requests";
                            bookingInformation.Controls.Add(title);
                            bookingInformation.Controls.Add(new HtmlGenericControl("hr"));

                            foreach (Booking b in pendingBookings)
                            {
                                displayBookingInfoHost(b);
                            }
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
        else
        {
            // Is postback
            Host host = (Host)Session["Host"];
            LoggedUser loggedUser = (LoggedUser)Session["User"];

            if (host != null)
            {
                user.Controls.Add(new LiteralControl("<br />"));
                //display properties for host
                Boolean check = property.checkProperty(host.loginName);
                if (check)
                {
                    //retrieve property information for host
                    List<Property> h_property = property.retrievePropertyByHost(host.loginName);
                    List<Booking> pendingBookings = Booking.getPendingBookings(host.loginName);

                    foreach (Property p in h_property)
                    {
                        addPropertyInfo(p, h_property.IndexOf(p) + 1);
                    }

                    if (pendingBookings.Count != 0)
                    {
                        HtmlGenericControl title = new HtmlGenericControl("h3");
                        title.InnerHtml = "Pending Booking Requests";
                        bookingInformation.Controls.Add(title);
                        bookingInformation.Controls.Add(new HtmlGenericControl("hr"));

                        foreach (Booking b in pendingBookings)
                        {
                            displayBookingInfoHost(b);
                        }
                    }
                }
                else
                {
                    Label no_property = new Label();
                    no_property.Text = "No properties for display";
                    user.Controls.Add(no_property);
                }
            }
            else
            {
                //customer's profile
                Hello.Text = "Hello, " + loggedUser.name;
                loginName.Text = loggedUser.loginName;
                name.Text = loggedUser.name;
                email.Text = loggedUser.email;
                Search_property_btn.Visible = true;

                List<Booking> acceptedBookings = Booking.getAcceptedBookings(loggedUser.loginName);
                List<Booking> rejectedBookings = Booking.getRejectedBookings(loggedUser.loginName);

                if (acceptedBookings.Count != 0)
                {
                    HtmlGenericControl title = new HtmlGenericControl("h3");
                    title.InnerHtml = "Accepted Booking Requests";
                    bookingInformation.Controls.Add(title);
                    bookingInformation.Controls.Add(new HtmlGenericControl("hr"));
                    foreach (Booking b in acceptedBookings)
                    {
                        displayBookingInfoUser(b);
                    }
                }

                if (rejectedBookings.Count != 0)
                {
                    HtmlGenericControl title = new HtmlGenericControl("h3");
                    title.InnerHtml = "Rejected Booking Requests";
                    bookingInformation.Controls.Add(title);
                    bookingInformation.Controls.Add(new HtmlGenericControl("hr"));
                    foreach (Booking b in rejectedBookings)
                    {
                        displayBookingInfoUser(b);
                    }
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

    protected void addPropertyInfo(Property p, int index)
    {
        Label property_num = new Label();
        property_num.Text = "Property " + index.ToString();
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
        String[] labels = { "Name: ", "Location: ", "Number of rooms: ", "Number of guests: ", "Price: " };
        for (int i = 0; i < labels.Length; i++)
        {
            Label label = new Label();
            label.ID = "Label" + i.ToString();
            label.Text = labels[i];

            user.Controls.Add(label);
            if (i == 0)
            {
                HyperLink propertyLink = new HyperLink();
                propertyLink.NavigateUrl = "~/ViewProperty?propertyId=" + p.propertyId;
                propertyLink.Text = property_info[i].Text;
                user.Controls.Add(propertyLink);
            }
            else
            {
                user.Controls.Add(property_info[i]);
            }
            user.Controls.Add(new LiteralControl("<br />"));
        }
        user.Controls.Add(new LiteralControl("<br />"));
    }

    protected void displayBookingInfoHost(Booking b)
    {
        PlaceHolder booking = new PlaceHolder();
        booking.ID = "booking-" + b.bookingId;

        HtmlGenericControl bookingTitle = new HtmlGenericControl("h4");
        bookingTitle.InnerHtml = b.loggedUser.name + " wants to stay in " + b.property.name;

        Label date = new Label();
        date.Text = "From: " + b.startDate + " to " + b.endDate + "&nbsp;&nbsp;";

        Button accept = new Button();
        Button reject = new Button();

        accept.Text = "Accept Booking";
        accept.ID = "a-" + b.bookingId;
        accept.CssClass = "btn btn-primary";
        reject.Text = "Reject Booking";
        reject.ID = "r-" + b.bookingId;
        reject.CssClass = "btn btn-danger";

        accept.Click += new EventHandler(acceptBooking);
        reject.Click += new EventHandler(rejectBooking);
        booking.Controls.Add(bookingTitle);
        booking.Controls.Add(date);
        booking.Controls.Add(accept);
        booking.Controls.Add(new LiteralControl("<span>&nbsp;</span>"));
        booking.Controls.Add(reject);
        bookingInformation.Controls.Add(booking);
        bookingInformation.Controls.Add(new HtmlGenericControl("hr"));
    }

    protected void displayBookingInfoUser(Booking b)
    {
        PlaceHolder booking = new PlaceHolder();
        booking.ID = "booking-" + b.bookingId;

        HtmlGenericControl bookingTitle = new HtmlGenericControl("h4");
        HyperLink link = new HyperLink();
        link.NavigateUrl = "/ViewProperty?propertyId=" + b.property.propertyId;
        link.Text = b.property.name;
        bookingTitle.InnerHtml = "Staying in ";
        bookingTitle.Controls.Add(link);

        Label date = new Label();
        date.Text = "From: " + b.startDate + " to " + b.endDate + "&nbsp;&nbsp;";

        Button contact = new Button();

        contact.Text = "Contact Host";
        contact.ID = "host-" + b.property.host.loginName;
        contact.CssClass = "btn btn-primary";
        contact.Click += new EventHandler(ContactHostFromProperty);

        booking.Controls.Add(bookingTitle);
        booking.Controls.Add(date);
        bookingInformation.Controls.Add(booking);
        booking.Controls.Add(contact);
        bookingInformation.Controls.Add(new HtmlGenericControl("hr"));
    }

    protected void ContactHostFromProperty(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        String[] id = b.ID.Split('-');
        Host host = Host.retrieveHost(id[1]);
        Session["messageFor"] = host;
        Response.Redirect("DisplayMessages.aspx");
    }


    protected void acceptBooking(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        String[] id = b.ID.Split('-');
        int bookingId = int.Parse(id[1]);
        Booking.acceptBooking(bookingId);
        Response.Redirect(Request.RawUrl);
    }

    protected void rejectBooking(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        String[] id = b.ID.Split('-');
        int bookingId = int.Parse(id[1]);
        Booking.rejectBooking(bookingId);
        Response.Redirect(Request.RawUrl);
    }

    protected void Contact_Host(object sender, EventArgs e)
    {
        Host host = (Host)Session["retrievedHostFromProfile"]; 
        Session["messageFor"] = host;
        Response.Redirect("DisplayMessages.aspx");
    }

    protected void loadOtherHostProfile(String host_name)
    {
        // Load Host Profile from ViewProfile
        Host retrieveHost = Host.retrieveHost(host_name);
        Session["retrievedHostFromProfile"] = retrieveHost;
        Hello.Text = "Profile of host " + retrieveHost.name;

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
                addPropertyInfo(p, h_property.IndexOf(p) + 1);
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