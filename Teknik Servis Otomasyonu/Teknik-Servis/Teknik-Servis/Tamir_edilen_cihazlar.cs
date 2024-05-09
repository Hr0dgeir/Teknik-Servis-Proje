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
    public partial class Tamir_edilen_cihazlar : Form
    {
        public Tamir_edilen_cihazlar()
        {
            InitializeComponent();
        }

        private void Tamir_edilen_cihazlar_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = tamirEdilenCihazlar.goster();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = tamirEdilenCihazlar.sıralaA();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = tamirEdilenCihazlar.sıralaZ();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];
            string id = selectedRow.Cells[0].Value.ToString();
            cihazİslemleri.secilenUrunID = Convert.ToInt32(id);

            Tamir_edilen_cihazlar_detay frm = new Tamir_edilen_cihazlar_detay();
            frm.ShowDialog();
        }
    }
}
