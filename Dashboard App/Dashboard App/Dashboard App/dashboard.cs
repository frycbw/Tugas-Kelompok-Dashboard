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
using LiveCharts;
using LiveCharts.Wpf;

namespace Dashboard_App
{
    public partial class dashboard : UserControl
    {
        private string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1; Database=expresss";
        private NpgsqlConnection conn;
        private NpgsqlCommand cmdChart;
        private NpgsqlCommand cmd;
        private string sqlChart;
        private string sql;
        private DataTable dt;
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
           
            totalPengiriman();
            totalPenerimaan();

            getTotalPemasukanTable();
            getTotalPemasukanDiagram();
        }
        private void getTotalPemasukanTable()
        {
            try
            {
                conn.Open();
                sqlChart = "SELECT date_part('year', tb_transaksi.tanggal) AS tahun, date_part('month', tb_transaksi.tanggal) AS bulan, sum(harga*100) AS frekuensi FROM tb_transaksi GROUP BY date_part('year', tb_transaksi.tanggal), date_part('month', tb_transaksi.tanggal) ORDER BY date_part('month', tanggal) ASC";
                cmdChart = new NpgsqlCommand(sqlChart,conn);
                dt = new DataTable();
                dt.Load(cmdChart.ExecuteReader());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getTotalPemasukanDiagram()
        {
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = dataGridView1.Columns[1].Name,
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "mei", "Jun", "Jul", "Agu", "Sep", "Okt", "Nov", "DES" }
            });

            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Frekuensi",
                LabelFormatter = value => value.ToString("C")
            }) ;
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;

            cartesianChart1.Series.Clear();
            SeriesCollection series = new SeriesCollection();

            try
            {
                conn.Open();
                NpgsqlDataReader myReader = cmdChart.ExecuteReader();

                List<string> yearsList = new List<string>();
                while(myReader.Read())
                {
                    yearsList.Add(myReader["tahun"].ToString());
                }

                var years = yearsList.Distinct();

                foreach (var year in years)
                {
                    List<double> frekuensiList = new List<double>();
                    for (int month = 1; month <= 12; month++)
                    {
                        double frekuensi = 0;
                        DataRow[] result = dt.Select("tahun = " + year + "AND bulan = " + month);
                        foreach (DataRow row in result)
                        {
                            frekuensi = Double.Parse(row[2].ToString());
                        }
                        frekuensiList.Add(frekuensi);
                    }
                    series.Add(new LineSeries()
                    {
                        Title = year.ToString(),
                        Values = new ChartValues<double>(frekuensiList)
                    });
                }
                cartesianChart1.Series = series;
                conn.Close();
            }
            catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void totalPengiriman()
        {
            try
            {
                conn.Open();
                sql = "SELECT COUNT(id_transaksi) as total_pengiriman FROM tb_transaksi where status = 'Telah dikirim'";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader Myreader = cmd.ExecuteReader();
                Myreader.Read();
                label6.Text = Myreader["total_pengiriman"].ToString();



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void totalPenerimaan()
        {
            try
            {
                conn.Open();
                sql = "SELECT COUNT(id_transaksi) as total_penerimaan FROM tb_transaksi";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader Myreader = cmd.ExecuteReader();
                Myreader.Read();
                label7.Text = Myreader["total_penerimaan"].ToString();



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
