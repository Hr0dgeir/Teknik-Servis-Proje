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
    public partial class Tamir_edilen_cihazlar_detay : Form
    {
        public Tamir_edilen_cihazlar_detay()
        {
            InitializeComponent();
        }

        private void Tamir_edilen_cihazlar_detay_Load(object sender, EventArgs e)
        {
            tamirEdilenCihazlar.detayGoster();
            textbox_ad.Text = tamirEdilenCihazlar.ad;
            textbox_marka.Text = tamirEdilenCihazlar.marka;
            textbox_model.Text = tamirEdilenCihazlar.model;
            textbox_tel.Text = tamirEdilenCihazlar.tel;
            textbox_toplamparca.Text = tamirEdilenCihazlar.toplamparca;
            richTextBox1_yapılanislem.Text = tamirEdilenCihazlar.islem;
            richTextBox2_degisenparcalar.Text = tamirEdilenCihazlar.degisenparca;
        }
    }
}
