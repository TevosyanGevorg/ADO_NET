using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;
                try
                {
                    sqlCommand.CommandText = "INSERT INTO Users(Name,Age) VALUES('Tim',34)";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO Users(Name,Age)VALUES('Kat',31) ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("Data Added Into DataBase");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    sqlTransaction.Rollback();
                }
            }
        }
    }
}
