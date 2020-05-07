using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_1 
{
    class Program
    {
        static void Main(string[] 
            args)
        {
            // STEP_1: ADD in to referrences System.Configuration referece
            // STEP_2: ADD in to namespaces using System.Configuration namespaces
            // STEP_3: ADD in to namespaces using System.Data.SqlClient namespaces
            // STEP_4: ADD in to file App.config/  ConectionString

            string connectionString = ConfigurationManager.ConnectionStrings["firsConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Connection is Opend");
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                Console.WriteLine("Connection is Closed");
            }
            Console.ReadLine();
        }
    }
}
