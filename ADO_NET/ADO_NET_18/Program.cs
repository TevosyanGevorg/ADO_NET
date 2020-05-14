using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_18
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlExpression, connectionString);
                SqlCommandBuilder sqlCommandbulider = new SqlCommandBuilder(sqlDataAdapter);

                // устанавливаем команду на вставку
                sqlDataAdapter.InsertCommand = new SqlCommand("sp_CreateUser", sqlConnection);
                // это будет зранимая процедура
                sqlDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                // добавляем параметр для name
                sqlDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
                // добавляем параметр для age
                sqlDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@age", SqlDbType.Int, 0, "Age"));
                // добавляем выходной параметр для id
                SqlParameter parameter = sqlDataAdapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                DataTable dataTable = dataSet.Tables[0];
                // добавим новую строку
                DataRow newDataRow = dataTable.NewRow();
                newDataRow["Name"] = "Kris";
                newDataRow["Age"] = 26;
                dataTable.Rows.Add(newDataRow);

                sqlDataAdapter.Update(dataSet);
                dataSet.AcceptChanges();
                foreach (DataColumn column in dataTable.Columns)
                    Console.Write("\t{0}", column.ColumnName);
                Console.WriteLine();
                // перебор всех строк таблицы
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    // получаем все ячейки строки
                    foreach (object item in dataRow.ItemArray)
                        Console.Write("\t{0}", item);
                    Console.WriteLine();
                }
            }
            Console.Read();
        }
    }
}
