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

namespace ADO_NET_19
{
    public partial class FormCRUD : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        string sqlExpression = "SELECT * FROM Users";
        DataSet dataSet;
        SqlDataAdapter sqlDataAdapter;
        SqlCommandBuilder SqlCommandBuilder;
        public FormCRUD()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(sqlExpression, sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView1.Columns["Id"].ReadOnly = true;
            }
        }
        private void button_ADD(object sender, EventArgs e)
        {
            DataRow dataRow = dataSet.Tables[0].NewRow();
            dataSet.Tables[0].Rows.Add(dataRow);
        }
        private void button_SAVE(object sender, EventArgs e)
        {
            using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(sqlExpression, sqlConnection);
                //SqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.InsertCommand = new SqlCommand("sp_CreateUser", sqlConnection);
                sqlDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
                sqlDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@age", SqlDbType.Int, 0, "Age"));
                SqlParameter sqlParameter = sqlDataAdapter.InsertCommand.Parameters.Add("Id", SqlDbType.Int, 0, "Id");
                sqlParameter.Direction = ParameterDirection.Output;
                sqlDataAdapter.Update(dataSet);
            }
        }
        private void button_DELETE(object sender, EventArgs e)
        {
            // удаляем выделенные строки из dataGridView1
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
