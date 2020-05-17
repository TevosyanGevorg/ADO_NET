using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;

namespace ADO_NET_27
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext(connectionString);
            Console.WriteLine("Before Update");
            foreach (var user in dataContext.GetTable<User>().Take(5))
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.Age}");
            }
            Console.WriteLine();
            User user1 = dataContext.GetTable<User>().FirstOrDefault();
            user1.Age = 32;
            dataContext.SubmitChanges();
            Console.WriteLine();
            Console.WriteLine("After Update");
            foreach (var user in dataContext.GetTable<User>().Take(5))
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.Age}");
            }
        }
    }
}
