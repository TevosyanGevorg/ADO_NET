using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;

namespace ADO_NET_30
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext(connectionString);
            int n = 18;
            int modifedRowsNumber = dataContext.ExecuteCommand($"DELETE FROM Users WHERE Id={n}");
            Console.WriteLine(modifedRowsNumber);
            int age = 40;
            IEnumerable<User> users = dataContext.ExecuteQuery<User>($"SELECT * FROM Users WHERE Age>{age}");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.Age}");
            }
            Console.ReadKey();
        }
    }
}
