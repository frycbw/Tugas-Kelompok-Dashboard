using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Dashboard_App
{
    public partial class laporan_pelanggan : UserControl
    {
        private string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1; Database=expresss";
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private string sql;
        private DataTable dt;
        public laporan_pelanggan()
        {
            InitializeComponent();
        }

        private void laporan_pelanggan_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                sql = "SELECT * FROM tb_pelanggan";
                cmd = new NpgsqlCommand(sql, conn);

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;

                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
