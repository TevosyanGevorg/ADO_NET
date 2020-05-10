using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;



namespace ADO_NET_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            List<Image> images = new List<Image>();
            using (SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string sqlExpression = "SELECT*FROM Images";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while(sqlDataReader.Read())
                {
                    int id = sqlDataReader.GetInt32(0);
                    string filename = sqlDataReader.GetString(1);
                    string title = sqlDataReader.GetString(2);
                    byte[] data = (byte[])sqlDataReader.GetValue(3);
                    Image image = new Image(id, filename, title, data);
                    images.Add(image);
                }
            }
            if(images.Count>0)
            {
                using (FileStream fileStream = new FileStream(images[0].FileName, FileMode.OpenOrCreate))
                {
                    fileStream.Write(images[0].Data, 0, images[0].Data.Length);
                    Console.WriteLine($"The Image {images[0].Title} is saved");
                }
            }
            Console.ReadLine();
        } 
    }
}
