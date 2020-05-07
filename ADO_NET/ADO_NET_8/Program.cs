using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine($"{sqlDataReader.GetName(0)}\t{sqlDataReader.GetName(1)}\t{sqlDataReader.GetName(2)}");
                    while(sqlDataReader.Read())
                    {
                        int id = sqlDataReader.GetInt32(0);
                        string name = sqlDataReader.GetString(1);
                        int age = sqlDataReader.GetInt32(2);
                        Console.WriteLine($"{id}\t{name}\t{age}");
                    }
                }
                sqlDataReader.Close();
            }
            Console.Read();
        }
    }
}
