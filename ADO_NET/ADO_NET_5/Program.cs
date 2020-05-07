using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
            {
                sqlConnection.Open();
                //============INSERT================
                Console.WriteLine("Input Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Input Age: ");
                int age = int.Parse(Console.ReadLine());
                string sqlExpression = string.Format("INSERT INTO Users (Name, Age) VALUES ('{0}', {1})", name, age);
                SqlCommand sqlCommand = new SqlCommand(sqlExpression,sqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"Count Of Added Object is: {number}");
                //============UPDATE=================
                Console.WriteLine("Input The New Name");
                name = Console.ReadLine();
                sqlExpression = Convert.ToString($"UPDATE Users SET Name='{name}' WHERE Age=24");
                sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                number = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"Count Of UPDATED Object is: {number}");
            }
            Console.ReadLine();
        }
    }
}
