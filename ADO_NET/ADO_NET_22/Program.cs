using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO_NET_22
{
    class Program
    {
        static void Main(string[] args)
        {
            //==================================DATABASE===============================
            DataSet dataSet = new DataSet("Store");
            //===================================TABLE-1==============================
            DataTable dataTable_Companies = new DataTable("Companies");
            DataColumn dataColumn_Company_id= new DataColumn("Id", Type.GetType("System.String"));
            dataColumn_Company_id.Unique = true;
            dataColumn_Company_id.AllowDBNull = false;
            dataColumn_Company_id.AutoIncrement = true;
            dataColumn_Company_id.AutoIncrementSeed = 1;
            dataColumn_Company_id.AutoIncrementStep = 1;
            DataColumn dataColumn_Company_Name = new DataColumn("Name", Type.GetType("System.String"));
            dataTable_Companies.Columns.AddRange(new DataColumn[] { dataColumn_Company_id, dataColumn_Company_Name });
            dataSet.Tables.Add(dataTable_Companies);
            //====================================TABLE-2===============================
            DataTable dataTable_Phones = new DataTable("Phones");
            DataColumn dataColumn_Phones_id = new DataColumn("Id", Type.GetType("System.Int32"));
            dataColumn_Phones_id.Unique = true;
            dataColumn_Phones_id.AllowDBNull = false;
            dataColumn_Phones_id.AutoIncrement = true;
            dataColumn_Phones_id.AutoIncrementSeed = 1;
            dataColumn_Phones_id.AutoIncrementStep = 1;
            DataColumn dataColumn_Phones_Name = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn dataColumn_Phones_Price = new DataColumn("Price", Type.GetType("System.Decimal"));
            DataColumn dataColumn_Phones_Company = new DataColumn("CompanyId", Type.GetType("System.Int32"));
            dataTable_Phones.Columns.AddRange(new DataColumn[] { dataColumn_Phones_id, dataColumn_Phones_Name, dataColumn_Phones_Price, dataColumn_Phones_Company });
            dataSet.Tables.Add(dataTable_Phones);
            //================================FORINKEY=================================
            dataSet.Relations.Add("PhonesCompanies", dataTable_Companies.Columns["Id"], dataTable_Phones.Columns["CompanyId"]);
            //========================ADDING DATA INTO COMPANIES========================
            DataRow dataRow_Apple = dataTable_Companies.NewRow();
            dataRow_Apple.ItemArray = new object[] { null, "Apple" };
            dataTable_Companies.Rows.Add(dataRow_Apple);
            DataRow dataRow_Sumsung = dataTable_Companies.NewRow();
            dataRow_Sumsung.ItemArray = new object[] { null, "Sumsung" };
            dataTable_Companies.Rows.Add(dataRow_Sumsung);
            //===========================ADD DATA INTO PHONES===========================
            DataRow dataRow_iphone5 = dataTable_Phones.NewRow();
            dataRow_iphone5.ItemArray = new object[] { null, "iPhone 5", 400, dataRow_Apple["Id"] };
            dataTable_Phones.Rows.Add(dataRow_iphone5);
            DataRow dataRow_iphone6s = dataTable_Phones.NewRow();
            dataRow_iphone6s.ItemArray = new object[] { null, "iPhone 6S", 600, dataRow_Apple["Id"] };
            dataTable_Phones.Rows.Add(dataRow_iphone6s);
            DataRow dataRow_galaxy6 = dataTable_Phones.NewRow();
            dataRow_galaxy6.ItemArray = new object[] { null, "Samsung Galaxy S6", 500, dataRow_Sumsung["Id"] };
            dataTable_Phones.Rows.Add(dataRow_galaxy6);
            DataRow dataRow_galaxyace2 = dataTable_Phones.NewRow();
            dataRow_galaxyace2.ItemArray = new object[] { null,"Samsung Galaxy Ace 2", 200, dataRow_Sumsung["Id"] };
            dataTable_Phones.Rows.Add(dataRow_galaxyace2);
            DataRow[] rows = dataRow_Apple.GetChildRows(dataSet.Relations["PhonesCompanies"]);
            Console.WriteLine("The Products of Apple Company");
            foreach (DataRow r in rows)
            {
                Console.WriteLine("{0} \t{1} \t{2}", r["Id"], r["Name"], r["Price"]);
            }
            Console.Read();
        }
    }
}
