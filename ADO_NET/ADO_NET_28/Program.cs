using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;


namespace ADO_NET_28
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext(connectionString);
            Console.WriteLine("Before Adding");
            foreach (var user in dataContext.GetTable<User>().OrderByDescending(u=>u.Id).Take(5))
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.Age}");
            }
            Console.WriteLine();
            User user1 = new User() { FirstName = "xxx", Age = 000 };
            dataContext.GetTable<User>().InsertOnSubmit(user1);
            dataContext.SubmitChanges();
            Console.WriteLine();
            Console.WriteLine("After Adding");
            foreach (var user in dataContext.GetTable<User>().OrderByDescending(u=>u.Id).Take(5))
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.Age}");
            }
            Console.ReadLine();
        }
    }
}
