using System;
using System.Collections.Generic;
using System.Collections;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        Boolean logout;
        try
        {
            logout = true;
            Boolean.Parse(Request.QueryString["logout"]);
        }
        catch (Exception)
        {
            logout = false;
        }
        if (logout)
        {
            Session.Clear();
        }

        if (Session["Host"] == null && Session["User"] == null)
        {
            PlaceHolderLogout.Visible = false;
        }
        else
        {
            Host host = (Host)Session["Host"];
            LoggedUser user = (LoggedUser)Session["User"];

            if (host != null)
            {
                List<Booking> pendingBookings = Booking.getPendingBookings(host.loginName);
                List<ArrayList> unreadConversations = MessageSystem.getHostUnreadConversation(host.loginName);
                int count = pendingBookings.Count;
                int unread = unreadConversations.Count;
                if (count == 1 && unread == 0)
                {
                    userName.Text = host.name + " (" + count + " pending booking request)";
                } else if (count > 1 && unread == 0) {
                    userName.Text = host.name + " (" + count + " pending booking requests)";
                }
                else if (count == 0 && unread == 1)
                {
                    userName.Text = host.name + " (" + unread + " unread conversation)";
                }
                else if (count == 0 && unread > 1)
                {
                    userName.Text = host.name + " (" + unread + " unread conversations)";
                }
                else if (count == 1 && unread == 1)
                {
                    userName.Text = host.name + " (" + count + " pending booking request and " + unread + " unread conversation)";
                }
                else if (count == 1 && unread > 1)
                {
                    userName.Text = host.name + " (" + count + " pending booking request and " + unread + " unread conversations)";
                }
                else if (count > 1 && unread == 1)
                {
                    userName.Text = host.name + " (" + count + " pending booking requests and " + unread + " unread conversation)";
                }
                else if (count > 1 && unread > 1)
                {
                    userName.Text = host.name + " (" + count + " pending booking requests and " + unread + " unread conversations)";
                }
                else
                {
                    userName.Text = host.name;
                }
            }
            else
            {
                List<ArrayList> unreadConversations = MessageSystem.getUserUnreadConversation(user.loginName);
                int unread = unreadConversations.Count;
                if (unread == 1)
                {
                    userName.Text = user.name + " (" + unread + " unread conversation)";
                }
                else if (unread > 1)
                {
                    userName.Text = user.name + " (" + unread + " unread conversations)";
                }
                else
                {
                    userName.Text = user.name;
                }
            }
            PlaceHolderLogin.Visible = false;
        }

        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}