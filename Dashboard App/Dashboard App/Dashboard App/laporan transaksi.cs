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
    public partial class laporan_transaksi : UserControl
    {
        private string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1; Database=expresss";
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private string sql;
        private DataTable dt;
        public laporan_transaksi()
        {
            InitializeComponent();
        }

        private void laporan_transaksi_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                sql = "SELECT tb_pelanggan.nama_pelanggan, tb_pelanggan.no_pelanggan, tb_pelanggan.kota_pelanggan , tb_penerima.nama_penerima,tb_penerima.no_penerima, tb_penerima.alamat_penerima, tb_penerima.provinsi_penerima, tb_penerima.kota_penerima,tb_penerima.kecamatan_penerima,tb_paket.jenis_paket,tb_paket.deskripsi_paket,tb_paket.berat,tb_paket.jumlah,tb_paket.jenis_pengiriman,tb_transaksi.harga,tb_transaksi.tanggal,tb_transaksi.status,tb_transaksi.rating FROM tb_transaksi JOIN tb_penerima ON tb_transaksi.id_penerima = tb_penerima.id_penerima JOIN tb_paket ON tb_transaksi.id_paket = tb_paket.id_paket JOIN tb_pelanggan ON tb_transaksi.id_pelanggan = tb_pelanggan.id_pelanggan";
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
