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
    public double price { get; set; }
    public String[] imgSrcs { get; set; }
    public Host host { get; set; }

	public Property()
	{

	}

    public Property(int id, String name, String location, int noRooms, double price, String[] imgSrcs, Host host)
    {
        this.propertyId = id;
        this.name = name;
        this.location = location;
        this.numberRooms = noRooms;
        this.price = price;
        this.imgSrcs = imgSrcs;
        this.host = host;
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
            double price = reader.GetDouble(4);
            String hostLoginName = reader.GetString(5);
            Host host = Host.retrieveHost(hostLoginName);
            property = new Property(id, name, location, noRooms, price, null, host);
        }

        return property;
    }
    

    public List<Property> searchProperty(String location)
    {
        List<Property> properties = new List<Property>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Property WHERE location = @location;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@location", location);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String name = reader.GetString(1);
            String locat = reader.GetString(2);
            int noRooms = reader.GetInt32(3);
            double price = reader.GetDouble(4);
            String hostLoginName = reader.GetString(5);
            Host host = Host.retrieveHost(hostLoginName);
            properties.Add(new Property(id, name, location, noRooms, price, null, host));
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
            double price = reader.GetDouble(4);
            String hostLoginName = reader.GetString(5);
            Host host = Host.retrieveHost(hostLoginName);
            properties.Add(new Property(id, name, location, noRooms, price, null, host));
        }

        return properties;
    }
}