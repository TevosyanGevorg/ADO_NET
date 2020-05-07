using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SecondConn"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string firsConnectionId = Convert.ToString(sqlConnection.ClientConnectionId);
            sqlConnection.Close();
            sqlConnection.Open();
            string secondConnectionId = Convert.ToString(sqlConnection.ClientConnectionId);
            sqlConnection.Close();

            if(firsConnectionId != secondConnectionId)
            {
                Console.WriteLine("firsConnectionId != secondConnectionId");
            }
            else
            {
                Console.WriteLine($"firsConnectionId   = {firsConnectionId}");
                Console.WriteLine($"secondConnectionId = {secondConnectionId}");
            }
            Console.ReadLine();
        }
    }
}
