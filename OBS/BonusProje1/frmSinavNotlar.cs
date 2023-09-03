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
    public partial class frmSinavNotlar : Form
    {
        public frmSinavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_notlarTableAdapter ds = new DataSet1TableAdapters.tbl_notlarTableAdapter();
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-CQKIIC2\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True");

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtid.Text));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
       

        private void frmSinavNotlar_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_dersler", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "DERSAD";
            cmbders.ValueMember = "DERSID";
            cmbders.DataSource = dt;
            bgl.Close();
        }
        int notid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;

        private void btnhesapla_Click(object sender, EventArgs e)
        {
           
           // string durum;
            sinav1 = Convert.ToInt32(txtsinav1.Text);
            sinav2 = Convert.ToInt32(txtsinav2.Text);
            sinav3 = Convert.ToInt32(txtsinav3.Text);
            proje = Convert.ToInt32(txtproje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtortalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtdurum.Text = "true";
            }
            else
            {
                txtdurum.Text = "false";
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbders.SelectedValue.ToString()), int.Parse(txtid.Text),byte.Parse(txtsinav1.Text), byte.Parse(txtsinav2.Text), byte.Parse(txtsinav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtortalama.Text), bool.Parse(txtdurum.Text), notid);
            MessageBox.Show("GÜNCELLENDİ");
        }
    }
}
