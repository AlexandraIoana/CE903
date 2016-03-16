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
        db.CloseConnection();
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
        db.CloseConnection();
        if (row == 0)
            return false;
        else
            return true;
    }

    // alexandra: added this method in order to be able to test the messaging system
    //copied it from Host.cs but changed the specifics
    public static LoggedUser retrieveUser(String loginName)
    {
        LoggedUser result = new LoggedUser();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM LoggedUser WHERE login = @login;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@login", loginName);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            String name = reader.GetString(1);
            String email = reader.GetString(2);
            String password = reader.GetString(3);
            result = new LoggedUser(1, loginName, name, email, password);
        }
        db.CloseConnection();
        return result;
    }

   
}