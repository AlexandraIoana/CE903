﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestBooking : System.Web.UI.Page
{
    Host host;
    LoggedUser loggedUser;
    Property property;
    protected void Page_Load(object sender, EventArgs e)
    {
        loggedUser = (LoggedUser)Session["User"];
        host = (Host)Session["Host"];
        property = (Property)Session["Property"];
        try
        {
            int propertyId = (int)Session["propertyId"];
        }
        catch (Exception)
        {
            Response.Redirect("/SearchResult.aspx");
        }
        if (loggedUser == null && host == null)
        {
            Response.Redirect("/Login.aspx");
        }
        if (property == null)
        {
            property = new Property();
        }
    }
    protected void Request_Booking(object sender, EventArgs e)
    {
        try
        {
            DateTime startDate = Convert.ToDateTime(startDateLab.Text);
            DateTime endDate = Convert.ToDateTime(endDateLab.Text);
            if (startDate < DateTime.Now || endDate < DateTime.Now)
            {
                error_msg.Text = "Please enter dates that are in the future.";
            }
            else
            {
                Boolean isAvailable = Check_Availability(sender, e);
                if (isAvailable)
                {
                    Booking bookingReq = new Booking();
                    int propertyId = (int)Session["PropertyId"];
                    Property propertyret = Property.retrieveProperty(propertyId);
                    bookingReq.loggedUser = loggedUser;
                    bookingReq.property = propertyret;
                    bookingReq.startDate = startDateLab.Text;
                    bookingReq.endDate = endDateLab.Text;

                    property.propertyId = propertyId;
                    Session["BookingDetails"] = bookingReq;
                    Session["startDate"] = startDateLab.Text;
                    Session["endDate"] = endDateLab.Text;
                    Session["PropertyName"] = propertyret.name;
                    Session["PropertyPrice"] = "&pound; " + propertyret.price.ToString();
                    Session["loggedUser"] = loggedUser;
                    Response.Redirect("BookingReqConfirmation.aspx");
                }
                else
                {
                    Availability.Text = "Property not availabe from " + startDateLab.Text + " to " + endDateLab.Text;
                    startDateLab.Text = "";
                    endDateLab.Text = "";
                }
            }
        }
        catch (Exception)
        {
            error_msg.Text = "Please enter the two dates.";
        }
    }
    protected Boolean Check_Availability(Object sender, EventArgs e)
    {

        int propertyId = (int)Session["PropertyId"];
        Boolean isAvailable = false;
        DateTime startDate = Convert.ToDateTime(startDateLab.Text);
        DateTime endDate = Convert.ToDateTime(endDateLab.Text);
        List<DateTime> aDates = Booking.checkAcceptedBookedDates(propertyId);
        List<DateTime> pDates = Booking.checkPendingBookedDates(propertyId);
        if (aDates != null)
        {
            List<DateTime> bookedDates = getDates(startDate, endDate);
            foreach (DateTime d in bookedDates)
            {
                if (aDates.Contains(d))
                {
                    return isAvailable;
                }
                if (pDates.Contains(d))
                {
                    return isAvailable;
                }
            }

            isAvailable = true;
        }
        else
        {
            isAvailable = true;
        }
        return isAvailable;

    }

    public List<DateTime> getDates(DateTime start, DateTime end)
    {
        DateTime date = start;
        List<DateTime> dates = new List<DateTime>();
        dates.Add(start);
        while ((date = date.AddDays(1)).Date <= end.Date)
        {
            dates.Add(date);
        }
        return dates;
    }

    protected void CheckAvailability(object sender, EventArgs e)
    {
        Response.Redirect("Availability.aspx");
    }
}