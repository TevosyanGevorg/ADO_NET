using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Linq;


namespace ADO_NET_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            DataContext dataContext = new DataContext(connectionString);
            var _Users = from u in dataContext.GetTable<User>()
                        where u.Age < 25
                        orderby u.FirstName
                        select u;
            foreach(var user in _Users)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.Age}");
            }
        } 
    }
}
