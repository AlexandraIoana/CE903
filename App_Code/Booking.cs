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
    public String status { get; set; }

	public Booking()
	{

	}

    public Booking(int id, LoggedUser loggedUser, Property property, String startDate, String endDate, String status)
    {
        this.bookingId = id;
        this.loggedUser = loggedUser;
        this.property = property;
        this.startDate = startDate;
        this.endDate = endDate;
        this.status = status;
    }

    public Boolean createBooking(LoggedUser loggedUser, Property property, String startDate, String endDate)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "INSERT INTO Booking (start_date, end_date, loggedUser, property, status) VALUES (@startDate, @endDate, @user, @property, @status);";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@startDate", Convert.ToDateTime(startDate));
        command.Parameters.AddWithValue("@endDate", Convert.ToDateTime(endDate));
        command.Parameters.AddWithValue("@user", loggedUser.loginName);
        command.Parameters.AddWithValue("@property", property.propertyId);
        command.Parameters.AddWithValue("@status", "PENDING");
        int row = command.ExecuteNonQuery();
        if (row == 0)
            return false;
        else
            return true;
    }

    public static List<Booking> getPendingBookings(String hostLogin)
    {
        List<Booking> booking = new List<Booking>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Booking INNER JOIN Property ON Property.id = property WHERE Property.host = @host AND status = 'PENDING'";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@host", hostLogin);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String start = reader.GetDateTime(1).ToShortDateString();
            String end = reader.GetDateTime(2).ToShortDateString();
            String user = reader.GetString(3);
            int propertyId = reader.GetInt32(4);
            String status = reader.GetString(5);
            LoggedUser loggedUser = LoggedUser.retrieveUser(user);
            Property property = Property.retrieveProperty(propertyId);
            booking.Add(new Booking(id, loggedUser, property, start, end, status));
        }
        db.CloseConnection();
        return booking;
    }

    public static List<Booking> getAcceptedBookings(String userLogin)
    {
        List<Booking> booking = new List<Booking>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Booking WHERE status = 'ACCEPTED' AND DATEDIFF(DAY, GETDATE(), start_date) >= 0 AND loggedUser = @user";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@user", userLogin);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String start = reader.GetDateTime(1).ToShortDateString();
            String end = reader.GetDateTime(2).ToShortDateString();
            String user = reader.GetString(3);
            int propertyId = reader.GetInt32(4);
            String status = reader.GetString(5);
            LoggedUser loggedUser = LoggedUser.retrieveUser(user);
            Property property = Property.retrieveProperty(propertyId);
            booking.Add(new Booking(id, loggedUser, property, start, end, status));
        }
        db.CloseConnection();
        return booking;
    }

    public static List<Booking> getRejectedBookings(String userLogin)
    {
        List<Booking> booking = new List<Booking>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Booking WHERE status = 'REJECTED' AND DATEDIFF(DAY, GETDATE(), start_date) >= 0 AND loggedUser = @user";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@user", userLogin);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String start = reader.GetDateTime(1).ToShortDateString();
            String end = reader.GetDateTime(2).ToShortDateString();
            String user = reader.GetString(3);
            int propertyId = reader.GetInt32(4);
            String status = reader.GetString(5);
            LoggedUser loggedUser = LoggedUser.retrieveUser(user);
            Property property = Property.retrieveProperty(propertyId);
            booking.Add(new Booking(id, loggedUser, property, start, end, status));
        }
        db.CloseConnection();
        return booking;
    }

    public static Boolean acceptBooking(int bookingId)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "UPDATE Booking SET status = @status WHERE id = @id;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@status", "ACCEPTED");
        command.Parameters.AddWithValue("@id", bookingId);
        int row = command.ExecuteNonQuery();
        if (row == 0)
            return false;
        else
            return true;
    }

    public static Boolean rejectBooking(int bookingId)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "UPDATE Booking SET status = @status WHERE id = @id;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@status", "REJECTED");
        command.Parameters.AddWithValue("@id", bookingId);
        int row = command.ExecuteNonQuery();
        db.CloseConnection();
        if (row == 0)
            return false;
        else
            return true;
    }

    public static int getAllVisitsOfThisUserInProperty(String userLogin, int propertyId)
    {
        int visits = 0;
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT COUNT(id) FROM Booking WHERE property = @propertyId AND DATEDIFF(DAY, start_date, GETDATE()) >= 0 AND loggedUser = @user;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@propertyId", propertyId);
        command.Parameters.AddWithValue("@user", userLogin);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            visits = reader.GetInt32(0);
        }
        db.CloseConnection();
        return visits;
    }

    public static List<DateTime> checkAcceptedBookedDates(int propertyId)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        List<DateTime> propDates = new List<DateTime>();
        int propCount = isPropertyExist(propertyId);
        if (propCount != 0)
        {
            DateTime propStartDate, propEndDate;
            String query = "SELECT start_date, end_date FROM Booking WHERE property = @propertyId AND status = 'ACCEPTED';";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@propertyId", propertyId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                propStartDate = reader.GetDateTime(0);
                propEndDate = reader.GetDateTime(1);
                for (var date = propStartDate; date <= propEndDate; date = date.AddDays(1))
                {
                    propDates.Add(date);
                }
            }
        }
        else {
            db.CloseConnection();
        	propDates = null;
        }
        db.CloseConnection();
        return propDates;
    }

    public static List<DateTime> checkPendingBookedDates(int propertyId)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        List<DateTime> propDates = new List<DateTime>();
        int propCount = isPropertyExist(propertyId);
        if (propCount != 0)
        {
            DateTime propStartDate, propEndDate;
            String query = "SELECT start_date, end_date FROM Booking WHERE property = @propertyId AND status = 'PENDING';";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@propertyId", propertyId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                propStartDate = reader.GetDateTime(0);
                propEndDate = reader.GetDateTime(1);
                for (var date = propStartDate; date <= propEndDate; date = date.AddDays(1))
                {
                    propDates.Add(date);
                }
            }
        }
        else
        {
            db.CloseConnection();
            propDates = null;
        }
        db.CloseConnection();
        return propDates;
    }

    public static int isPropertyExist(int propertyId)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        int propCount = 0;
        String query = "SELECT count(property) FROM Booking WHERE property = @propertyId;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@propertyId", propertyId);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            propCount = reader.GetInt32(0);
        }
        db.CloseConnection();
        return propCount;
    }

}
