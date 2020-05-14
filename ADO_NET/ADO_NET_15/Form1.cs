using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace ADO_NET_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlExpression, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }

        }
    }
}
