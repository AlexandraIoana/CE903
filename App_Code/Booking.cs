using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Booking
/// </summary>
public class Booking
{
    public int bookingId { get; set; }
    public LoggedUser loggedUser { get; set; }
    public Property property { get; set; }
    public String startDate { get; set; }
    public String endDate { get; set; }

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
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "INSERT INTO Booking (start_date, end_date, user, property) VALUES (@startDate, @endDate, @user, @property);";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@startDate", startDate);
        command.Parameters.AddWithValue("@endDate", endDate);
        command.Parameters.AddWithValue("@user", loggedUser.loginName);
        command.Parameters.AddWithValue("@property", property.propertyId);
        int row = command.ExecuteNonQuery();
        if (row == 0)
            return false;
        else
            return true;
    }
}