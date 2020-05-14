using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADO_NET_17
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                //sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlExpression, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                DataTable dataTable = dataSet.Tables[0];

                DataRow dataRow = dataTable.NewRow();
                dataRow["Name"] = "Anahit";
                dataRow["Age"] = 45;
                dataTable.Rows.Add(dataRow);

                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Update(dataSet);

                Console.WriteLine(sqlCommandBuilder.GetUpdateCommand().CommandText);
                Console.WriteLine(sqlCommandBuilder.GetInsertCommand().CommandText);
                Console.WriteLine(sqlCommandBuilder.GetDeleteCommand().CommandText);

                foreach (DataColumn dataColumn in dataTable.Columns)
                    Console.Write("\t{0}", dataColumn.ColumnName);
                Console.WriteLine();
                foreach (DataRow row in dataTable.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        Console.Write("\t{0}", cell);
                    Console.WriteLine();
                }
                Console.Read();
            }
        }
    }
}
