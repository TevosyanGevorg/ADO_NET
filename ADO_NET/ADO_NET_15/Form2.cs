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
    public partial class Form2 : Form
    {
        int pageSize = 5;
        int pageNumber = 0;
        DataSet dataSet;
        SqlDataAdapter sqlDataAdapter;
        string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        string sqlExpression="SELECT * FROM Users";
        public Form2()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(sqlExpression, sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridView2.DataSource = dataSet.Tables[0];
                dataGridView2.Columns["Id"].ReadOnly = true; 
            }
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0].Rows.Count < pageSize) return;

            pageNumber++;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlDataAdapter = new SqlDataAdapter(GetSql(), sqlConnection);

                dataSet.Tables[0].Rows.Clear();

                sqlDataAdapter.Fill(dataSet);
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0) return;
            pageNumber--;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlDataAdapter = new SqlDataAdapter(GetSql(), sqlConnection);

                dataSet.Tables[0].Rows.Clear();

                sqlDataAdapter.Fill(dataSet);
            }
        }
        private string GetSql()
        {
            return "SELECT * FROM Users ORDER BY Id OFFSET ((" + pageNumber + ") * " + pageSize + ") " +
                "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
        }
    }
}
