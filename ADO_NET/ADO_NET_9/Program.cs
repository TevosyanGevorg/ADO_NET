using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            using (SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //=========================SELECT COUNT(*)======================================
                string sqlExpression = "SELECT COUNT(*) FROM Users";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                object count = sqlCommand.ExecuteScalar();
                Console.WriteLine($"sqlCommand.ExecuteScalar()= {count}");
                //=============================SELECT MIN======================================
                sqlCommand.CommandText = "SELECT MIN(Age) FROM Users";
                object minAge = sqlCommand.ExecuteScalar();
                Console.WriteLine($"SELECT MIN(Age) FROM Users= {minAge}");
            }
        }
    }
}
