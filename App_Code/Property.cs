using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Property
/// </summary>
public class Property
{
    private int propertyId { get; set; }
    private String name { get; set; }
    private String location { get; set; }
    private double[] prices { get; set; }
    private String[] imgSrcs { get; set; }
    private Host host { get; set; }

	public Property()
	{

	}

    public Property(int id, String name, String location, double[] prices, String[] imgSrcs, Host host)
    {
        this.propertyId = id;
        this.name = name;
        this.location = location;
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

    public int searchProperty(String location)
    {
        // TODO
        throw new NotImplementedException();
    }

    public int searchProperty(double[] prices)
    {
        // TODO
        throw new NotImplementedException();
    }
}