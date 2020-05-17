using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_23
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("Store");
            // таблица компаний
            DataTable companies_DataTable = new DataTable("Companies");
            DataColumn compId_DataColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            DataColumn compName_DataColumn = new DataColumn("Name", Type.GetType("System.String"));
            // добавляем столбцы
            companies_DataTable.Columns.Add(compId_DataColumn);
            companies_DataTable.Columns.Add(compName_DataColumn);
            // добавляем таблицу в dataset
            dataSet.Tables.Add(companies_DataTable);

            // вторая таблица - смартфонов компаний
            DataTable phones_DataTable = new DataTable("Phones");
            DataColumn phoneId_DataColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            DataColumn phoneName_DataColumn = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn phonePrice_DataColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
            DataColumn phoneCompany_DataColumn = new DataColumn("CompanyId", Type.GetType("System.Int32"));
            // добавляем столбцы в таблицу смартфонов
            phones_DataTable.Columns.Add(phoneId_DataColumn);
            phones_DataTable.Columns.Add(phoneName_DataColumn);
            phones_DataTable.Columns.Add(phonePrice_DataColumn);
            phones_DataTable.Columns.Add(phoneCompany_DataColumn);
            // добавляем таблицу смартфонов
            dataSet.Tables.Add(phones_DataTable);

            // Добавим ряд данных
            companies_DataTable.Rows.Add(new object[] { 1, "Apple" });
            companies_DataTable.Rows.Add(new object[] { 2, "Samsung" });

            phones_DataTable.Rows.Add(new object[] { 1, "iPhone 5", 400, 1 });
            phones_DataTable.Rows.Add(new object[] { 2, "iPhone 6S", 600, 1 });
            phones_DataTable.Rows.Add(new object[] { 3, "Samsung Galaxy S6", 500, 2 });
            phones_DataTable.Rows.Add(new object[] { 4, "Samsung Galaxy Ace 2", 200, 2 });

            var query = from phone in dataSet.Tables["Phones"].AsEnumerable()
                        from company in dataSet.Tables["Companies"].AsEnumerable()
                        where (int)phone["CompanyId"] == (int)company["Id"]
                        where (decimal)phone["Price"] > 200
                        select new { Model = phone["Name"], Price = phone["Price"], Company = company["Name"] };

            foreach (var phone in query)
                Console.WriteLine("{0} ({1}) - {2}", phone.Model, phone.Company, phone.Price);
            Console.Read();
        }
    }
}
