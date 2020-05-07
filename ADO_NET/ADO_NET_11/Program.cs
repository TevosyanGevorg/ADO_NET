using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO_NET_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            int age = 38;
            string name = "Kenny";
            string sqlExpression = "INSERT INTO Users (Name,Age)VALUES(@name,@age);SET @id=SCOPE_IDENTITY()";
            using (SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                SqlParameter nameParameter = new SqlParameter("@name", name);
                SqlParameter ageParameter = new SqlParameter("@age", age);
                SqlParameter idParameter = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction=ParameterDirection.Output
                };
                SqlParameter[] sqlParameters = { idParameter,nameParameter, ageParameter };
                sqlCommand.Parameters.AddRange(sqlParameters);
                sqlCommand.ExecuteNonQuery();

            }
        }
    }
}
