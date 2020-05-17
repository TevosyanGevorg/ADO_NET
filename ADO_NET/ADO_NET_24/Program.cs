using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace ADO_NET_24
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression = "SELECT * FROM Users";
            using(SqlConnection sqlConnection =new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlExpression, sqlConnection);
                DataSet dataSet = new DataSet("Users");
                DataTable dataTable = new DataTable("User");
                dataSet.Tables.Add(dataTable);
                sqlDataAdapter.Fill(dataSet.Tables["User"]);
                dataSet.WriteXml("usersdb.xml");
                Console.WriteLine("Data Saved into fail");
                Console.ReadLine();
            }
            DataSet dataSet2 = new DataSet();
            dataSet2.ReadXml("usersdb.xml");
            // выбираем первую таблицу
            DataTable dataTable2 = dataSet2.Tables[0];

            foreach (DataColumn dataColumn in dataTable2.Columns)
                Console.Write("\t{0}", dataColumn.ColumnName);
            Console.WriteLine();
            // перебор всех строк таблицы
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                var cells = dataRow.ItemArray;
                foreach (object cell in dataRow.ItemArray)
                    Console.Write("\t{0}", cell);
                Console.WriteLine();
            }

        }
    }
}
