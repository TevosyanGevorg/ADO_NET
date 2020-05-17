using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;

namespace ADO_NET_25
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext(connectionString);
            Table<User> users = dataContext.GetTable<User>();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.Age}");
            }
        }
    }
}
