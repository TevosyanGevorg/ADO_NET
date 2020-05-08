using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;

namespace ADO_NET_16
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            int pageNumber = 2;
            int pageSize = 5;
            int count = 0;
            DataContext dataContext = new DataContext(connectionString);
            count = dataContext.GetTable<User>().Count();
            Console.WriteLine($"Count= {count}");
            if(count>pageNumber*pageSize)
            {
                var _Users = dataContext.GetTable<User>().Skip(pageNumber).Take(pageSize);
                foreach (var user in _Users)
                {
                    Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.Age}");
                }
            }
            Console.ReadLine();
        }
    }
}
