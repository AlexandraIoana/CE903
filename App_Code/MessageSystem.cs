using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MessageSystem
/// </summary>
public class MessageSystem
{
    public MessageSystem()
    {
        
    }

    public ArrayList retrieveConversation(LoggedUser user, Host host)
    {
        ArrayList conversation = new ArrayList();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT id FROM Conversation WHERE host=@host AND loggerUser=@user";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@host", host.loginName);
        command.Parameters.AddWithValue("@user", user.loginName);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            int conversation_id = reader.GetInt32(0);
            String query1 = "SELECT content FROM Message WHERE conversation_id=@id";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@id", conversation_id);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                String message = reader1.GetString(0);
                conversation.Add(message);
            }
        }

        return conversation;

    }

    public Boolean sendMessage(LoggedUser user, Host host, String message)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        String query = "SELECT id FROM Conversation WHERE host=@host AND loggerUser=@user";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@host", host.loginName);
        command.Parameters.AddWithValue("@user", user.loginName);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read()) {
            int conversation_id = reader.GetInt32(0);
            String query1 = "INSERT INTO Message (content, conversation_id) VALUES (@text, @id); SELECT SCOPE_IDENTITY();";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@text", message);
            command1.Parameters.AddWithValue("@id", conversation_id);
            Object id = command.ExecuteScalar();
            if (id == null)
                return false;
            else
            {
                return true;
            }

        }
        else
        {
            String query1 = "INSERT INTO Conversation (host, loggedUser) VALUES (@host, @user); SELECT SCOPE_IDENTITY();";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@host", host.loginName);
            command1.Parameters.AddWithValue("@user", user.loginName);
            Object id = command.ExecuteScalar();
            int conversation_id;
            if (id == null)
                return false;
            else
            {
                conversation_id = (Int32) id;
                String query2 = "INSERT INTO Message (content, conversation_id) VALUES (@text, @id); SELECT SCOPE_IDENTITY();";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@text", message);
                command2.Parameters.AddWithValue("@id", conversation_id);
                Object id1 = command.ExecuteScalar();
                if (id1 == null)
                    return false;
                else
                {
                    return true;
                }
            }
        }
    }

}