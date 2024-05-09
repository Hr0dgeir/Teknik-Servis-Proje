using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknik_Servis
{
    public partial class Kullanıcı_Ayarları : Form
    {
        public Kullanıcı_Ayarları()
        {
            InitializeComponent();
        }
        byte[] picture;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_Email.Text))
            {
                if (!String.IsNullOrEmpty(textbox_Tel.Text))
                {
                    if (!String.IsNullOrEmpty(textbox_sifre.Text) && textbox_sifre.Text.Length >= 5)
                    {
                        if (!String.IsNullOrEmpty(textbox_sifre2.Text) && sha256.sha256hash_(textbox_sifre.Text) == sha256.sha256hash_(textbox_sifre2.Text))
                        {
                            KullaniciAyarlari.guncelle(textbox_Email.Text,textbox_Tel.Text,sha256.sha256hash_(textbox_sifre2.Text));
                            KullaniciEkle.kullaniciMail = textbox_Email.Text;
                        }
                        else
                        {
                            MessageBox.Show("Şifrenizi kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifrenizi kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Telefon Numaranızı kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mailinizi kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textbox_Tel_TextChanged(object sender, EventArgs e)
        {
            if (textbox_Tel.Text.Length == 3)
            {
                textbox_Tel.Text += "-";
                textbox_Tel.SelectionStart = textbox_Tel.Text.Length;
            }
            if (textbox_Tel.Text.Length == 7)
            {
                textbox_Tel.Text += "-";
                textbox_Tel.SelectionStart = textbox_Tel.Text.Length;
            }
            if (textbox_Tel.Text.Length == 10)
            {
                textbox_Tel.Text += "-";
                textbox_Tel.SelectionStart = textbox_Tel.Text.Length;

            }
        }

        private void Kullanıcı_Ayarları_Load(object sender, EventArgs e)
        {
            KullaniciAyarlari.bilgiler();

            pictureBox.Image =  kullaniciBilgileri.kullanici_foto();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            textbox_Tel.Text = KullaniciAyarlari.tel;
            textbox_Email.Text = KullaniciAyarlari.mail;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Sellect your picture";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = null;
                string dosya_yolu = ofd.FileName;
                pictureBox.Image = Image.FromFile(dosya_yolu);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                picture = br.ReadBytes((int)fs.Length);
                br.Close();

                KullaniciAyarlari.fotoguncelle(picture);

            }
        }
    }
}
