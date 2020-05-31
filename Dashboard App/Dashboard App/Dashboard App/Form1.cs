using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Dashboard_App
{
    public partial class Form1 : Form
    {
        private string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1; Database=expresss";
        private NpgsqlConnection conn;

        public Form1()
        {
            InitializeComponent();
            dashboard1.BringToFront();
        }

        private void home_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void home_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void home_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void b1_Click(object sender, EventArgs e)
        {
            dashboard1.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
         
        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void b2_Click(object sender, EventArgs e)
        {
            laporan_pelanggan1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            laporan_penerimaan1.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            laporan_paket1.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            laporan_transaksi1.BringToFront();
        }
    }
}
