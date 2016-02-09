using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        // TODO
        throw new NotImplementedException();
    }
    
    public Boolean SignUp(String loginName, String name, String email, String password)
    {
        // TODO
        throw new NotImplementedException();
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