using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_7
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadDataAsynch().GetAwaiter();
            Console.Read();
        }
        private static async Task ReadDataAsynch()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression = "SELECT * FROM Users";
            using(SqlConnection sqlConnection =new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                if(sqlDataReader.HasRows)
                {
                    Console.WriteLine($"{sqlDataReader.GetName(0)}\t{sqlDataReader.GetName(1)}\t{sqlDataReader.GetName(2)}");
                    while(await sqlDataReader.ReadAsync())
                    {
                        object id = sqlDataReader.GetValue(0);
                        object name = sqlDataReader.GetValue(1);
                        object age = sqlDataReader.GetValue(2);
                        Console.WriteLine($"{id}\t{name}\t{age}");
                    }
                }
                sqlDataReader.Close();
            }
        }
    }
}
