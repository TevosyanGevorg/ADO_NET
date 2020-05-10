using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ADO_NET_13
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = @"INSERT INTO Images VALUES (@FileName,@Title,@ImageData)";
                sqlCommand.Parameters.Add("@FileName", SqlDbType.NVarChar,50);
                sqlCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 50);
                sqlCommand.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);

                string fileName = @"C:\Users\arm7g\Desktop\paymentSystem\paymantLOGO\AmeriaBank.png";
                string title = "LogoOfAmeriaBank";
                string shortFileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                byte[] imageData;
                using(FileStream fileStream=new FileStream(fileName,FileMode.Open))
                {
                    imageData = new byte[fileStream.Length];
                    fileStream.Read(imageData, 0, imageData.Length);
                }
                sqlCommand.Parameters["@FileName"].Value = shortFileName;
                sqlCommand.Parameters["@Title"].Value = title;
                sqlCommand.Parameters["@ImageData"].Value = imageData;
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
