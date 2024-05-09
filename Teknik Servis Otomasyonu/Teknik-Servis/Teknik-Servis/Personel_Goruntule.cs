using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknik_Servis
{
    public partial class Personel_Goruntule : Form
    {
        public Personel_Goruntule()
        {
            InitializeComponent();
        }

        private void Personel_Goruntule_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = PersonelIslemleri.goster();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = PersonelIslemleri.sıralaA();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = PersonelIslemleri.sıralaZ();
        }
    }
}
