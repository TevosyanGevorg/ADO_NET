using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO_NET_20
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression = "SELECT * FROM Users";
            using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlExpression, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                foreach (DataTable dataTable in dataSet.Tables)
                {
                    //Console.WriteLine(dataTable.TableName);
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        Console.Write($"\t{column.ColumnName}");
                    }
                    Console.WriteLine();
                    foreach (DataRow dataRows in dataTable.Rows)
                    {
                        var row = dataRows.ItemArray;
                        foreach (var item in row)
                        {
                            Console.Write($"\t{item}");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
