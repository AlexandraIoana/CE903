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

	public Image()
	{
	
	}

    public Image(String name, String contentType, Byte[] b)
    {
        this.name = name.Substring(0, Math.Min(name.Length, 50));
        this.contentType = contentType;
        bytes = b;
        bytesInBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
    }

    public Boolean saveImageInDb()
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "INSERT INTO Images (name, contentType, data) VALUES (@name, @contentType, @data);";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@ContentType", contentType);
        command.Parameters.AddWithValue("@Data", bytes);
        try
        {
            command.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.Message);
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
            long len = reader.GetBytes(3, 0, null, 0, 0);
            bytes = new Byte[len];
            reader.GetBytes(3, 0, bytes, 0, (int)len);
            bytesInBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            return true;
        }
        return false;
    }
}