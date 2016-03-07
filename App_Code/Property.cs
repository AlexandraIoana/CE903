using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Property
/// </summary>
public class Property
{
    public int propertyId { get; set; }
    public String name { get; set; }
    public String location { get; set; }
    public int numberRooms { get; set; }
    public int numberGuests { get; set; }
    public double price { get; set; }
    public String[] imgSrcs { get; set; }
    public Host host { get; set; }

	public Property()
	{

	}

    public Property(int id, String name, String location, int noRooms, int noGuests, double price, String[] imgSrcs, Host host)
    {
        this.propertyId = id;
        this.name = name;
        this.location = location;
        this.numberRooms = noRooms;
        this.numberGuests = noGuests;
        this.price = price;
        this.imgSrcs = imgSrcs;
        this.host = host;
    }

    /**Check if host has any properties to display in his profile*/
    public Boolean checkProperty(String loginName)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT host FROM Property WHERE host = @loginName;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@loginName", loginName);
        Object id = command.ExecuteScalar();
        if (id == null)
            return false;
        else
            return true;
    }
    /**retrieve properties of a particular host*/
    public List<Property> retrievePropertyByHost(String loginName)
    {
        List<Property> property = new List<Property>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Property WHERE host = @loginName;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@loginName", loginName);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String name = reader.GetString(1);
            String locat = reader.GetString(2);
            int noRooms = reader.GetInt32(3);
            int noGuests = reader.GetInt32(4);
            double price = reader.GetDouble(5);
            Host host = Host.retrieveHost(loginName);
            Property p = new Property(id, name, locat, noRooms, noGuests, price, null, host);
            property.Add(p);
        }

        return property;
    }

    public Property retrieveProperty(String name)
    {
        Property property = new Property();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Property WHERE name = @name;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", name);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String locat = reader.GetString(2);
            int noRooms = reader.GetInt32(3);
            int noGuests = reader.GetInt32(4);
            double price = reader.GetDouble(5);
            String hostLoginName = reader.GetString(6);
            Host host = Host.retrieveHost(hostLoginName);
            property = new Property(id, name, locat, noRooms, noGuests, price, null, host);
        }

        return property;
    }
    

    public List<Property> searchProperty(String location)
    {
        List<Property> properties = new List<Property>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Property WHERE location LIKE @location;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@location", "%" + location + "%");
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String name = reader.GetString(1);
            String locat = reader.GetString(2);
            int noRooms = reader.GetInt32(3);
            int noGuests = reader.GetInt32(4);
            double price = reader.GetDouble(5);
            String hostLoginName = reader.GetString(6);
            Host host = Host.retrieveHost(hostLoginName);
            properties.Add(new Property(id, name, locat, noRooms, noGuests, price, null, host));
        }

        return properties;
    }

    public List<Property> searchProperty(double maxPrice)
    {
        List<Property> properties = new List<Property>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Property WHERE price <= @maxPrice;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@maxPrice", maxPrice);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String name = reader.GetString(1);
            String locat = reader.GetString(2);
            int noRooms = reader.GetInt32(3);
            int noGuests = reader.GetInt32(4);
            double price = reader.GetDouble(5);
            String hostLoginName = reader.GetString(6);
            Host host = Host.retrieveHost(hostLoginName);
            properties.Add(new Property(id, name, locat, noRooms, noGuests, price, null, host));
        }

        return properties;
    }

    public List<Property> searchProperty(int noGuests)
    {
        List<Property> properties = new List<Property>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Property WHERE no_of_guests >= @numberGuests;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@numberGuests", noGuests);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String name = reader.GetString(1);
            String locat = reader.GetString(2);
            int noRooms = reader.GetInt32(3);
            int nuGuests = reader.GetInt32(4);
            double price = reader.GetDouble(5);
            String hostLoginName = reader.GetString(6);
            Host host = Host.retrieveHost(hostLoginName);
            properties.Add(new Property(id, name, locat, noRooms, nuGuests, price, null, host));
        }

        return properties;
    }

    public List<Property> searchByCompleteCriteria(String location, double maxPrice, int noGuests)
    {
        List<Property> properties = new List<Property>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Property WHERE no_of_guests <= @numberGuests AND price <= @maxPrice AND location LIKE @location ORDER BY price ASC;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@numberGuests", noGuests);
        command.Parameters.AddWithValue("@maxPrice", maxPrice);
        command.Parameters.AddWithValue("@location", "%" + location + "%");
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String name = reader.GetString(1);
            String locat = reader.GetString(2);
            int noRooms = reader.GetInt32(3);
            int nuGuests = reader.GetInt32(4);
            double price = reader.GetDouble(5);
            String hostLoginName = reader.GetString(6);
            Host host = Host.retrieveHost(hostLoginName);
            properties.Add(new Property(id, name, locat, noRooms, nuGuests, price, null, host));
        }

        return properties;
    }
}