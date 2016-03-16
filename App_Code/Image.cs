using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Image
/// </summary>
public class Image
{
    public int id { get; set; }
    public String name { get; set; }
    public String contentType { get; set; }
    public Byte[] bytes { get; set; }
    public String bytesInBase64 { get; set; }
    public String user { get; set; }
    public int propertyId { get; set; }

	public Image()
	{
	
	}

    public Image(String name, String contentType, Byte[] b)
    {
        this.name = name.Substring(0, Math.Min(name.Length, 50));
        this.contentType = contentType;
        bytes = b;
        bytesInBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
        user = null;
        propertyId = -1;
    }

    public Image(String name, String contentType, Byte[] b, String user, int property)
    {
        this.name = name.Substring(0, Math.Min(name.Length, 50));
        this.contentType = contentType;
        bytes = b;
        bytesInBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
        this.user = user;
        this.propertyId = property;
    }

    public Image(int id, String name, String contentType, Byte[] b, String user, int property)
    {
        this.id = id;
        this.name = name.Substring(0, Math.Min(name.Length, 50));
        this.contentType = contentType;
        bytes = b;
        bytesInBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
        this.user = user;
        this.propertyId = property;
    }

    public Boolean saveImageInDb()
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "INSERT INTO Images (name, contentType, property, userLogin, data) VALUES (@name, @contentType, @property, @user, @data);";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@contentType", contentType);
        if (propertyId != -1)
        {
            command.Parameters.AddWithValue("@property", propertyId);
        }
        else
        {
            command.Parameters.AddWithValue("@property", "NULL");
        }
        command.Parameters.AddWithValue("@user", user);
        command.Parameters.AddWithValue("@data", bytes);

        try
        {
            System.Diagnostics.Debug.Write(command.CommandText);
            command.ExecuteNonQuery();
            db.CloseConnection();
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.Message);
            db.CloseConnection();
            return false;
        }
    }

    public Boolean loadImageFromDb(int i)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Images WHERE id = @id;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", i);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            id = reader.GetInt32(0);
            name = reader.GetString(1);
            contentType = reader.GetString(2);
            long len = reader.GetBytes(5, 0, null, 0, 0);
            bytes = new Byte[len];
            reader.GetBytes(5, 0, bytes, 0, (int)len);
            bytesInBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            user = reader.GetString(4);
            propertyId = reader.GetInt32(3);
            db.CloseConnection();
            return true;
        }
        db.CloseConnection();
        return false;
    }

    public List<Image> loadImagesFromDbWithPropertyId(int i)
    {
        List<Image> images = new List<Image>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT * FROM Images WHERE property = @id;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", i);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            String name = reader.GetString(1);
            String contentType = reader.GetString(2);
            long len = reader.GetBytes(5, 0, null, 0, 0);
            byte[] bytes = new Byte[len];
            reader.GetBytes(5, 0, bytes, 0, (int)len);
            int property = reader.GetInt32(3);
            String user = reader.GetString(4);
            images.Add(new Image(id, name, contentType, bytes, user, property));
        }
        db.CloseConnection();
        return images;
    }
}