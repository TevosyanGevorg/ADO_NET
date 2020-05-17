using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;

namespace ADO_NET_29
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext(connectionString);
            var user = dataContext.GetTable<User>().OrderByDescending(u => u.Id).FirstOrDefault();
            if(user!=null)
            {
                Console.WriteLine("The Object Which Will Be Deleted:");
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"FirstName: {user.FirstName}");
                Console.WriteLine($"Age: {user.Age}");
                dataContext.GetTable<User>().DeleteOnSubmit(user);
                dataContext.SubmitChanges();
                Console.WriteLine("The Object Deleted");
            }
            Console.ReadLine();
        }
    }
}
