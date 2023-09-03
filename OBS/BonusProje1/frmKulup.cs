using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class frmKulup : Form
    {
        public frmKulup()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-CQKIIC2\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True");

         void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulupler", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_kulupler (KULUPAD) values (@k1)", bgl);
            komut.Parameters.AddWithValue("@k1", txtkulupad.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulup Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("delete from tbl_kulupler where KULUPID=@p1", bgl);
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulup Silindi");
            liste();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("update tbl_kulupler set KULUPAD=@k1 where KULUPID=@k2", bgl);
            komut.Parameters.AddWithValue("@k1", txtkulupad.Text);
            komut.Parameters.AddWithValue("@k2", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Bilgi Güncellendi");
            liste();
        }
    }
}
