using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            int age = 80;
            string name = "Vilson";
            string sqlExpression = "INSERT INTO Users (Name,Age)VALUES(@name,@age)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                SqlParameter nameParameter = new SqlParameter("@name", name);
                SqlParameter ageParameter = new SqlParameter("@age", age);
                SqlParameter[] sqlParameters = { nameParameter, ageParameter };
                sqlCommand.Parameters.AddRange(sqlParameters);
                int number = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"Count of Added object: {number}");
            }

        }
    }
}
