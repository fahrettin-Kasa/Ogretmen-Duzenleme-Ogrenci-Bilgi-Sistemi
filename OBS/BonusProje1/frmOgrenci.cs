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
    public partial class frmOgrenci : Form
    {
        public frmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-CQKIIC2\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True");

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void frmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            bgl.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kulupler", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulub.DisplayMember = "kULUPAD";
            cmbkulub.ValueMember = "KULUPID";
            cmbkulub.DataSource = dt;
            bgl.Close();
            
        }
        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {
             
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
            ds.OgrenciEkle(txtogrenciad.Text, txtogrencisoyad.Text, byte.Parse(cmbkulub.SelectedValue.ToString()), c);
            MessageBox.Show("ÖĞRENCİ EKLENDİ");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void cmbkulub_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtid.Text = cmbkulub.SelectedValue.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtid.Text));
            MessageBox.Show("ÖĞRENCİ SİLİNDİ");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtogrenciad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtogrencisoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbkulub.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "KIZ";
            }
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "ERKEK";
            }
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
            
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "Kız")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "Erkek")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtogrenciad.Text, txtogrencisoyad.Text, byte.Parse (cmbkulub.SelectedValue.ToString()), c,int.Parse (txtid.Text));
            MessageBox.Show("ÖĞRENCİ GÜNCELLENDİ", "Öğrenci", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =  ds.OgrenciGetir(txtarama.Text);
        }
    }
}
