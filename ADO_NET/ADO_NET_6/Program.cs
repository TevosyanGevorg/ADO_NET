using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection sqlConnection =new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if(sqlDataReader.HasRows)
                {
                    Console.WriteLine($"{sqlDataReader.GetName(0)}\t{sqlDataReader.GetName(1)}\t{sqlDataReader.GetName(2)}");
                    while (sqlDataReader.Read())
                    {
                        object id = sqlDataReader.GetValue(0);
                        object name = sqlDataReader.GetValue(1);
                        object age = sqlDataReader.GetValue(2);
                        Console.WriteLine($"{id}\t{name}\t{age}");
                    }
                    //while (sqlDataReader.Read())
                    //{
                    //    object id = sqlDataReader["ID"];
                    //    object name = sqlDataReader["name"];
                    //    object age = sqlDataReader["age"];
                    //    Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
                    //}
                }
                sqlDataReader.Close();
            }
            Console.Read();

        }
    }
}
