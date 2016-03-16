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
        String query1 = "SELECT id,content,initiator,message_read FROM Message WHERE conversation_id=@id";
        SqlCommand command1 = new SqlCommand(query1, connection);
        command1.Parameters.AddWithValue("@id", conversation_id);
        SqlDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            int id = reader1.GetInt32(0); 
            String message = reader1.GetString(1);
            String initiator = reader1.GetString(2);
            int read = reader1.GetInt32(3);
            ArrayList array = new ArrayList();
            array.Add(message); array.Add(initiator); array.Add(read); array.Add(id);
            conversation.Add(array);
        }
        db.CloseConnection();
        return conversation;
    }

    public static ArrayList retrieveUsers(int conversationid)
    {
        ArrayList users = new ArrayList();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();

        String query1 = "SELECT host, loggedUser FROM Conversation WHERE id=@id";
        SqlCommand command1 = new SqlCommand(query1, connection);
        command1.Parameters.AddWithValue("@id", conversationid);
        SqlDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            String host = reader1.GetString(0);
            String user = reader1.GetString(1);
            Host h = Host.retrieveHost(host);
            LoggedUser u = LoggedUser.retrieveUser(user);
            users.Add(h);
            users.Add(u);
        }
        db.CloseConnection();
        return users;
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
            String query1 = "INSERT INTO Message (content, conversation_id, initiator, message_read) VALUES (@text, @id, @init, @read); SELECT SCOPE_IDENTITY();";
            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@text", message);
            command1.Parameters.AddWithValue("@id", conversation_id);
            command1.Parameters.AddWithValue("@init", initiator);
            command1.Parameters.AddWithValue("@read", 0);
            Object id = command1.ExecuteScalar();
            db.CloseConnection();
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
            int id3 = command3.ExecuteNonQuery();
            int conversation_id1;
            if (id3 == 0) {
                db.CloseConnection();
                return false;
            }
            else
            {
                String query4 = "SELECT id FROM Conversation WHERE host=@host AND loggedUser=@user";
                SqlCommand command4 = new SqlCommand(query4, connection);
                command4.Parameters.AddWithValue("@host", host.loginName);
                command4.Parameters.AddWithValue("@user", user.loginName);
                SqlDataReader reader4 = command4.ExecuteReader();
                while (reader4.Read())
                {
                    conversation_id = reader4.GetInt32(0);
                }
                db.CloseConnection();
                db.OpenConnection();
                String query2 = "INSERT INTO Message (content, conversation_id, initiator, message_read) VALUES (@text, @id, @init, @read); SELECT SCOPE_IDENTITY();";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@text", message);
                command2.Parameters.AddWithValue("@id", conversation_id);
                command2.Parameters.AddWithValue("@init", initiator);
                command2.Parameters.AddWithValue("@read", 0);
                Object id1 = command2.ExecuteScalar();
                db.CloseConnection();
                if (id1 == null)
                    return false;
                else
                {
                    return true;
                }
            }
        }
        
    }

    public static Boolean updateMessageToRead(int id)
    {
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();

        String query = "UPDATE Message SET message_read = 1 WHERE id=@id;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        
        db.CloseConnection();

        return true;
    }

    public static List<ArrayList> getUserUnreadConversation(String userLogin)
    {
        List<ArrayList> conversationIds = new List<ArrayList>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        int conversation_id;
        String query = "SELECT DISTINCT conversation_id, host FROM Conversation INNER JOIN Message ON conversation_id = Conversation.id WHERE loggedUser = @user AND message_read = 0 AND initiator = 'host';";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@user", userLogin);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            conversation_id = reader.GetInt32(0);
            String host = reader.GetString(1);
            ArrayList aux = new ArrayList();
            aux.Add(conversation_id);
            aux.Add(host);
            conversationIds.Add(aux);
        }
        db.CloseConnection();
        return conversationIds;
    }

    public static List<ArrayList> getUserReadConversation(String userLogin)
    {
        List<ArrayList> conversationIds = new List<ArrayList>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        int conversation_id;
        String query = "SELECT conversation_id, host FROM Conversation INNER JOIN Message ON conversation_id = Conversation.id WHERE loggedUser = @user EXCEPT (SELECT DISTINCT conversation_id, host FROM Conversation INNER JOIN Message ON conversation_id = Conversation.id WHERE loggedUser = @user AND message_read = 0 AND initiator = 'host');";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@user", userLogin);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            conversation_id = reader.GetInt32(0);
            String host = reader.GetString(1);
            ArrayList aux = new ArrayList();
            aux.Add(conversation_id);
            aux.Add(host);
            conversationIds.Add(aux);
        }
        db.CloseConnection();
        return conversationIds;
    }

    public static List<ArrayList> getHostUnreadConversation(String hostLogin)
    {
        List<ArrayList> conversationIds = new List<ArrayList>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        int conversation_id;
        String query = "SELECT DISTINCT conversation_id, loggedUser FROM Conversation INNER JOIN Message ON conversation_id = Conversation.id WHERE host = @host AND message_read = 0 AND initiator = 'user';";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@host", hostLogin);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            conversation_id = reader.GetInt32(0);
            String user = reader.GetString(1);
            ArrayList aux = new ArrayList();
            aux.Add(conversation_id);
            aux.Add(user);
            conversationIds.Add(aux);
        }
        db.CloseConnection();
        return conversationIds;
    }

    public static List<ArrayList> getHostReadConversation(String hostLogin)
    {
        List<ArrayList> conversationIds = new List<ArrayList>();
        DbConnection db = new DbConnection();
        SqlConnection connection = db.OpenConnection();
        int conversation_id;
        String query = "SELECT conversation_id, loggedUser FROM Conversation INNER JOIN Message ON conversation_id = Conversation.id WHERE host = @host EXCEPT (SELECT DISTINCT conversation_id, loggedUser FROM Conversation INNER JOIN Message ON conversation_id = Conversation.id WHERE host = @host AND message_read = 0 AND initiator = 'user');";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@host", hostLogin);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            conversation_id = reader.GetInt32(0);
            String user = reader.GetString(1);
            ArrayList aux = new ArrayList();
            aux.Add(conversation_id);
            aux.Add(user);
            conversationIds.Add(aux);
        }
        db.CloseConnection();
        return conversationIds;
    }

}