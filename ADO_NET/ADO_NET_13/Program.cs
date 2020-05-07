using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_13
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }
    }
}
