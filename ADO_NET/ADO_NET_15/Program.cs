using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;

namespace ADO_NET_15
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            DataContext dataContext = new DataContext(connectionString);
            //var query = from u in dataContext.GetTable<User>()
            //            group u by u.Age
            //            into grouped
            //            select grouped;
            var query = dataContext.GetTable<User>().GroupBy(u => u.FirsName);
            foreach (var group in query)
            {
                Console.WriteLine($"age={group.Key}");
                foreach(var user in group)
                { 
                    Console.WriteLine($"{user.Id}\t{user.Age}\t{user.FirsName}"); 
                }
            }
            Console.ReadLine();
        }
    }
}
