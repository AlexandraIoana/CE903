using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchEngine
/// </summary>
public class SearchEngine
{
	public SearchEngine()
	{

	}

    public static List<Property> SearchPropertyByLocation(String location)
    {
        return new Property().searchProperty(location);
    }

    public static List<Property> SearchPropertyByMaxPrice(double price)
    {
        return new Property().searchProperty(price);
    }

    public static List<Property> SearchPropertyByNumberOfGuests(int numberGuests)
    {
        return new Property().searchProperty(numberGuests);
    }

    public static List<Property> SearchByCompleteCriteria(String location, double maxPrice, int numberGuests)
    {
        return new Property().searchByCompleteCriteria(location, maxPrice, numberGuests);
    }
}