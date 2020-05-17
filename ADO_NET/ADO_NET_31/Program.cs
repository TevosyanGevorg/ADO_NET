using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ADO_NET_31
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        static void Main(string[] args)
        {
            UserDataContext userDataContext = new UserDataContext(connectionString);
            int minAge = 0, maxAge = 0;
            string name = "Tom";
            userDataContext.GetAgeRange(name, ref minAge, ref maxAge);
            Console.WriteLine($"for Users with name: {name}, min age: {minAge}, max age: {maxAge}");
            Console.ReadLine();
        }
    }
}
