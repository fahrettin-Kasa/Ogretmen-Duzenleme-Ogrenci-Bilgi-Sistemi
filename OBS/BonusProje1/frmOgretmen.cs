using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class frmOgretmen : Form
    {
        public frmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKulup fr = new frmKulup();
            fr.Show();
        }

        private void brnders_Click(object sender, EventArgs e)
        {
            frmDersler fr = new frmDersler();
            fr.Show();
        }

        private void btnogrenci_Click(object sender, EventArgs e)
        {
            frmOgrenci fr = new frmOgrenci();
            fr.Show();
        }

        private void btnsınav_Click(object sender, EventArgs e)
        {
            frmSinavNotlar fr = new frmSinavNotlar();
            fr.Show();
        }
    }
}
