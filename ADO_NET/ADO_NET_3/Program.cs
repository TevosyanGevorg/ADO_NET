using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = ConfigurationManager.ConnectionStrings["first"].ConnectionString;
            string second = ConfigurationManager.ConnectionStrings["second"].ConnectionString;
            using (SqlConnection sqlConnection=new SqlConnection(first))
            {
                sqlConnection.Open();
                Console.WriteLine(sqlConnection.ClientConnectionId);
            }
            using (SqlConnection sqlConnection1 =new SqlConnection(first))
            {
                sqlConnection1.Open();
                Console.WriteLine(sqlConnection1.ClientConnectionId);
            }
            using (SqlConnection sqlConnection2 = new SqlConnection(first)) 
            {
                sqlConnection2.Open();
                Console.WriteLine(sqlConnection2.ClientConnectionId);
            }
            Console.ReadLine();
        }
    }
}
