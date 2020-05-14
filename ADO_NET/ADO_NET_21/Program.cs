using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO_NET_21
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("BookStore");
            DataTable dataTable = new DataTable("Books");
            dataSet.Tables.Add(dataTable);

            DataColumn dataColumn_id = new DataColumn("Id", Type.GetType("System.Int32"));
            dataColumn_id.Unique = true;
            dataColumn_id.AllowDBNull = false;
            dataColumn_id.AutoIncrement = true;
            dataColumn_id.AutoIncrementSeed = 1;
            dataColumn_id.AutoIncrementStep = 1;
            DataColumn dataColumn_name = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn dataColumn_price = new DataColumn("Price", Type.GetType("System.Decimal"));
            dataColumn_price.DefaultValue = 100;
            DataColumn dataColumn_discount = new DataColumn("Discount", Type.GetType("System.Decimal"));
            dataColumn_discount.Expression = "Price * 0.2";

            dataTable.Columns.AddRange(new DataColumn[] { dataColumn_id, dataColumn_name, dataColumn_price, dataColumn_discount });
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["Id"] };
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.Add(new object[] { null, "war and world", 200 });
            dataTable.Rows.Add(new object[] { null, "fathers and sons", 170 });

            Console.Write("\t ID \t Name \t Price \t discount");
            Console.WriteLine();
            foreach (DataRow _dataRow in dataTable.Rows)
            {
                foreach (var item in _dataRow.ItemArray)
                {
                    Console.Write($"\t{item}");
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
