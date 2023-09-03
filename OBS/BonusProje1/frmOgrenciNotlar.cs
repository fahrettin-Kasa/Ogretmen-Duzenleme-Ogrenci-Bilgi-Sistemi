using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class frmOgrenciNotlar : Form
    {
        public frmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-CQKIIC2\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        //public string numara;
        private void frmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM tbl_notlar\r\nINNER JOIN TBL_dersler ON tbl_notlar.DERSID=tbl_dersler.DERSID WHERE OGRID=@p1\t", bgl);
            komut.Parameters.AddWithValue("@p1",numara );
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);  
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
