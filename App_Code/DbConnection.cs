using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// 

/// Summary description for DbConnection
/// 

public class DbConnection
{
    SqlConnection conn = null;
    string connString = "";
    public DbConnection()
    {
        // CHANGE HERE IN THE FUTURE WITH THE CORRECT CONNECTION STRING
        connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        conn = new SqlConnection(connString);
    }

    public SqlConnection OpenConnection()
    {
        if (conn.State != ConnectionState.Open)
        {
            conn.Open();
        }
        return conn;
    }

    public void CloseConnection()
    {
        if (conn.State != ConnectionState.Closed)
            conn.Close();
    }
}