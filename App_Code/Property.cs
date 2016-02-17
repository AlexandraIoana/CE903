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
    public double[] prices { get; set; }
    public String[] imgSrcs { get; set; }
    public Host host { get; set; }

	public Property()
	{

	}

    public Property(int id, String name, String location, int noRooms, double[] prices, String[] imgSrcs, Host host)
    {
        this.propertyId = id;
        this.name = name;
        this.location = location;
        this.numberRooms = noRooms;
        this.prices = prices;
        this.imgSrcs = imgSrcs;
        this.host = host;
    }

    /*
    public int searchProperty(String name)
    {
        // TODO
        throw new NotImplementedException();
    }
    */

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
            // TODO
            // Need to resolve this conflict about int and doubles in price.
            int noRooms = reader.GetInt32(3);
            int price = reader.GetInt32(4);
            // TODO
            // Make a host object that goes with the property
            String host = reader.GetString(5);
            properties.Add(new Property(id, name, location, noRooms, null, null, null));
        }

        return properties;
    }

    // TODO: Resolve conflict first with the doubles and int for price.
    public Property[] searchProperty(double[] prices)
    {
        // TODO
        throw new NotImplementedException();
    }
}