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

    public static List<Property> SearchPropertyByMaxPrice(Double price)
    {
        return new Property().searchProperty(price);
    }

    // Need to add number of guests in database.
    public static List<Property> SearchPropertyByNumberOfGuests(int numberGuests)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Need to add number of guests in database.
    public static List<Property> SearchByCompleteCriteria(String location, Double maxPrice, int numberGuests)
    {
        // TODO
        throw new NotImplementedException();
    }
}