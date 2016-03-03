using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for LoggedUser
/// </summary>
public class LoggedUser : User
{
    private int userId;
    public int id
    {
        get
        {
            return userId;
        }
        set
        {
            this.userId = value;
        }
    }
    public String loginName { get; set; }
    public String name { get; set; }
    public String email { get; set; }
    public String password { get; set; }

	public LoggedUser()
	{

	}

    public LoggedUser(int id, String loginName, String name, String email, String password)
    {
        this.userId = id;
        this.loginName = loginName;
        this.name = name;
        this.email = email;
        this.password = password;
    }

    public Boolean checkLogin(String loginName, String password)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT login FROM LoggedUser WHERE login = @login AND password = @password;";
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
        String query = "SELECT login FROM LoggedUser WHERE login = @login;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@login", loginName);
        Object id = command.ExecuteScalar();
        if (id == null)
            return true;
        else
            return false;
    }

    public Boolean SignUp(String loginName, String name, String email, String password)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "INSERT INTO LoggedUser (login, name, email, password) VALUES (@login, @name, @email, @password);";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@login", loginName);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", password);
        int row = command.ExecuteNonQuery();
        if (row == 0)
            return false;
        else
            return true;
    }

    public Boolean messageHost(String loginName, Host host, String message) 
    {
        // TODO
        throw new NotImplementedException();
    }

    public Boolean requestBooking(LoggedUser loggedUser, Booking booking)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Methods that might be included and used in the future.
    public Boolean leaveReview(Property property, Booking booking, String message, int review)
    {
        // TODO
        throw new NotImplementedException();
    }

    public Boolean leaveReview(Host host, Booking booking, String message, int review)
    {
        // TODO
        throw new NotImplementedException();
    }

    public Boolean postPhoto()
    {
        // TODO
        throw new NotImplementedException();
    }
}