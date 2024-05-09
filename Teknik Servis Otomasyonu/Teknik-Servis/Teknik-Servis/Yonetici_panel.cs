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
    public partial class Yonetici_panel : Form
    {
        public Yonetici_panel()
        {
            InitializeComponent();
        }

        private void Yonetici_panel_Load(object sender, EventArgs e)
        {
            kullaniciBilgileri.kullaniciSelamla();
            guna2CirclePictureBox1.Image = kullaniciBilgileri.kullanici_foto();
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            label1.Text = KullaniciEkle.kullaniciAd + " " + KullaniciEkle.kullaniciSoyad;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Personel_Goruntule frm = new Personel_Goruntule();
            frm.ShowDialog();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KullaniciEkle.kullaniciMail = null;
            KullaniciEkle.kullaniciAd = null;
            KullaniciEkle.kullaniciSoyad = null;
        }
    }
}
