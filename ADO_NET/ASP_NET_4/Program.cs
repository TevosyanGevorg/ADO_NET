using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ASP_NET_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM Users";
                sqlCommand.Connection = sqlConnection;
            }
            //==================================SELECT==================================
            string connectionString1 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression1 = "SELECT * FROM Users";
            using (SqlConnection sqlConnecton =new SqlConnection(connectionString1))
            {
                sqlConnecton.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression1, sqlConnecton);
            }
            //=================================INSERT===================================
            string connectionString2 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression2 = "INSERT INTO Users (Name,Age) values('Tom',18)";
            using (SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression2, sqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"Count of Added object: {number}");
            }
            //=================================UPDATE======================================
            string connectionString3 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression3 = "UPDATE Users SET Age=20 WHERE Name='Tom'";
            using (SqlConnection sqlConnection=new SqlConnection(connectionString3))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression3, sqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"Count of Updated Object: {number}");
            }
            //====================================DELETE=======================================
            string connectionString4 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression4 = "DELETE FROM Users WHERE Name='Tom'";
            using (SqlConnection sqlConnection =new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression4, sqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"Count of DLETEED Object:{number}");
            }

        }
    }
}
