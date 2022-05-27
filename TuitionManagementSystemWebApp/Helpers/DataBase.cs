using System.Data.SqlClient;

namespace TuitionManagementSystemWebApp.Helpers
{
    public class DataBase
    {
        public static SqlConnection GetConnection()
        {
            String connectionString = "Data Source=.\\SQLExpress;Initial Catalog=TuitionMS;Integrated Security=True;";

            return new SqlConnection(connectionString);

        }
    }
}
