using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Booking
/// </summary>
public class Booking
{
    private int bookingId { get; set; }
    private LoggedUser loggedUser { get; set; }
    private Property property { get; set; }
    private String startDate { get; set; }
    private String endDate { get; set; }

	public Booking()
	{

	}

    public Booking(int id, LoggedUser loggedUser, Property property, String startDate, String endDate)
    {
        this.bookingId = id;
        this.loggedUser = loggedUser;
        this.property = property;
        this.startDate = startDate;
        this.endDate = endDate;
    }

    public Boolean createBooking(LoggedUser loggedUser, Property property, String startDate, String endDate)
    {
        // TODO
        throw new NotImplementedException();
    }
}