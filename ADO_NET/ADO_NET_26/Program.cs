using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;


namespace ADO_NET_26
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext(connectionString);

            //=========================Фильтрация и сортировка=========================
            var users = from u in dataContext.GetTable<User>()
                        where u.Age > 25
                        orderby u.FirstName
                        select u;
            foreach (var user in users)
            {
                Console.WriteLine($"{ user.Id}\t{ user.FirstName}\t{ user.Age}");
            }

            //============================Группировка===============================
            //var query = from u in dataContext.GetTable<User>()
            //            group u by u.Age
            //            into grouped
            //            select grouped;
            //foreach (var group in query)
            //{
            //    Console.WriteLine($"Age:{group.Key}");
            //    foreach (var user in group)
            //    {
            //        Console.WriteLine(user.FirstName);
            //        Console.WriteLine();
            //    }
            //}

            //=============================Пагинация===============================
            //int pageNumber = 1; // текущая страница
            //int pageSize = 5; // кол-во элементов на странице
            //int count = 0; // сколько всего элементов
            //count = dataContext.GetTable<User>().Count();
            //if (count > pageNumber * pageSize)
            //{
            //    var query = dataContext.GetTable<User>().Skip(pageNumber * pageSize).Take(pageSize);
            //    foreach (var user in query)
            //    {
            //        Console.WriteLine($"{ user.Id} \t{user.FirstName} \t{user.Age}");
            //    }
            //}
            Console.Read();

        }
    }
}
