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

    public static ArrayList retrieveConversation(LoggedUser user, Host host)
    {
        ArrayList conversation = new ArrayList(new ArrayList());
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        int conversation_id = 0;
        String query = "SELECT id FROM Conversation WHERE host=@host AND loggedUser=@user";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@host", host.loginName);
        command.Parameters.AddWithValue("@user", user.loginName);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            conversation_id = reader.GetInt32(0);
        }
        db.CloseConnection();
        db.OpenConnection();
        String query1 = "SELECT content,initiator FROM Message WHERE conversation_id=@id";
        SqlCommand command1 = new SqlCommand(query1, connection);
        command1.Parameters.AddWithValue("@id", conversation_id);
        SqlDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            String message = reader1.GetString(0);
            String initiator = reader1.GetString(1);
            ArrayList array = new ArrayList();
            array.Add(message); array.Add(initiator);
            conversation.Add(array);
        }

        return conversation;

        

    }

    public static Boolean sendMessage(LoggedUser user, Host host, String message, String initiator)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        int conversation_id = 0;
        String query = "SELECT id FROM Conversation WHERE host=@host AND loggedUser=@user";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@host", host.loginName);
        command.Parameters.AddWithValue("@user", user.loginName);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
            conversation_id = reader.GetInt32(0);

        }
        db.CloseConnection();
        db.OpenConnection();
        if (conversation_id != 0)
        {
            String query1 = "INSERT INTO Message (content, conversation_id, initiator) VALUES (@text, @id, @init); SELECT SCOPE_IDENTITY();";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@text", message);
            command1.Parameters.AddWithValue("@id", conversation_id);
            command1.Parameters.AddWithValue("@init", initiator);
            Object id = command1.ExecuteScalar();
            if (id == null)
                return false;
            else
            {
                return true;
            }
        }
        else
        {
            String query3 = "INSERT INTO Conversation (host, loggedUser) VALUES (@host, @user);";
            SqlCommand command3 = new SqlCommand(query3, connection);
            command3.Parameters.AddWithValue("@host", host.loginName);
            command3.Parameters.AddWithValue("@user", user.loginName);
            Object id3 = command3.ExecuteScalar();
            int conversation_id1;
            if (id3 == null)
                return false;
            else
            {
                conversation_id1 = (Int32)id3;
                String query2 = "INSERT INTO Message (content, conversation_id, initiator) VALUES (@text, @id, @init); SELECT SCOPE_IDENTITY();";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@text", message);
                command2.Parameters.AddWithValue("@id", conversation_id1);
                command2.Parameters.AddWithValue("@init", initiator);
                Object id1 = command2.ExecuteScalar();
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