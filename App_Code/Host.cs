using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Host
/// </summary>
public class Host : User
{
    private int hostId;
    public int id
    {
        get
        {
            return hostId;
        }
        set
        {
            this.hostId = value;
        }
    }
    public String loginName { get; set; }
    public String name { get; set; }
    public String email { get; set; }
    public String password { get; set; }
    public String contactNumber { get; set; }

	public Host()
	{

	}

    public Host(int id, String loginName, String name, String email, String password, String contactNumber)
    {
        this.hostId = id;
        this.loginName = loginName;
        this.name = name;
        this.email = email;
        this.password = password;
        this.contactNumber = contactNumber;
    }

    public Boolean checkLogin(String loginName, String password)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT login FROM Host WHERE login = @login AND password = @password;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@login", loginName);
        command.Parameters.AddWithValue("@password", password);
        Object id = command.ExecuteScalar();
        if (id == null)
            return false;
        else
            return true;
    }
    /**Check uniqness of username return ture if the username is unique*/
    public Boolean checkUsername(String loginName)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT login FROM Host WHERE login = @login;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@login", loginName);
        Object id = command.ExecuteScalar();
        if (id == null)
            return true;
        else
            return false;
    }

    public Boolean SignUp(String loginName, String name, String email, String password) {
        return SignUp(loginName, name, email, password, null);
    }

    public Boolean SignUp(String loginName, String name, String email, String password, String contactNumber)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "INSERT INTO Host (login, name, email, password, contact_number) VALUES (@login, @name, @email, @password, @contactNumber);";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@login", loginName);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", password);
        command.Parameters.AddWithValue("@contactNumber", contactNumber);
        int row = command.ExecuteNonQuery();
        if (row == 0)
            return false;
        else
            return true;
    }

    public Boolean answerUser(String loginName, LoggedUser loggedUser, String message) 
    {
        // TODO
        throw new NotImplementedException();
    }

    public Boolean acceptBooking(LoggedUser loggedUser, Booking booking, String message)
    {
        // TODO
        throw new NotImplementedException();
    }

    public Boolean declineBooking(LoggedUser loggedUser, Booking booking, String message)
    {
        // TODO
        throw new NotImplementedException();
    }

    public Boolean addProperty(String loginName, Property property)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "INSERT INTO Property (name, location, no_of_rooms, no_of_guests, price, host) VALUES (@name, @location, @noRooms, @noGuests, @price, @host); SELECT SCOPE_IDENTITY();";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", property.name);
        command.Parameters.AddWithValue("@location", property.location);
        command.Parameters.AddWithValue("@noRooms", property.numberRooms);
        command.Parameters.AddWithValue("@noGuests", property.numberGuests);
        command.Parameters.AddWithValue("@price", property.price);
        command.Parameters.AddWithValue("@host", loginName);
        Object id = command.ExecuteScalar();
        if (id == null)
            return false;
        else
        {
            property.propertyId = (Int32) id;
            return true;
        }
    }

    public static Host retrieveHost(String loginName)
    {
        Host result = new Host();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Host WHERE login = @login;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@login", loginName);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            String name = reader.GetString(1);
            String email = reader.GetString(2);
            String password = reader.GetString(3);
            String contactNo = reader.GetString(4);
            result = new Host(1, loginName, name, email, password, contactNo);
        }
        
        return result;
    }

    // Methods that might be included and used in the future.
    public Boolean leaveReview(LoggedUser loggedUser, Booking booking, String message, int review)
    {
        // TODO
        throw new NotImplementedException();
    }
}