using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

	public Host()
	{

	}

    public Host(int id, String loginName, String name, String email, String password)
    {
        this.hostId = id;
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
        // TODO
        throw new NotImplementedException();
    }

    // Methods that might be included and used in the future.
    public Boolean leaveReview(LoggedUser loggedUser, Booking booking, String message, int review)
    {
        // TODO
        throw new NotImplementedException();
    }
}