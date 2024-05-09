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
    public partial class Ana_Panel : Form
    {
        public Ana_Panel()
        {
            InitializeComponent();
        }

        private void Ana_Panel_Load(object sender, EventArgs e)
        {
            kullaniciBilgileri.kullaniciSelamla();
            guna2CirclePictureBox1.Image = kullaniciBilgileri.kullanici_foto();
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 

            label1.Text = KullaniciEkle.kullaniciAd + " " + KullaniciEkle.kullaniciSoyad;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Urun_Islem frm = new Urun_Islem();
            frm.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KullaniciEkle.kullaniciMail = null;
            KullaniciEkle.kullaniciAd = null;
            KullaniciEkle.kullaniciSoyad = null;

            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void Ana_Panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Tamir_edilen_cihazlar frm = new Tamir_edilen_cihazlar();
            frm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Kullanıcı_Ayarları frm = new Kullanıcı_Ayarları();
            frm.ShowDialog();
        }
    }
}
