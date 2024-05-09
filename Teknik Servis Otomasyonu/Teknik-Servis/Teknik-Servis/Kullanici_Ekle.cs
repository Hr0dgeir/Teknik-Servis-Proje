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
    public partial class Kullanici_Ekle : Form
    {
        public Kullanici_Ekle()
        {
            InitializeComponent();
        }
        byte[] picture;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_Ad.Text) && sayiKontrol(textbox_Ad.Text))
            {
                if (!String.IsNullOrEmpty(textbox_Soyad.Text) && !textbox_Soyad.Text.Contains(" ") && sayiKontrol(textbox_Ad.Text))
                {
                    if (!String.IsNullOrEmpty(Combobox_Yetki.SelectedItem.ToString()))
                    {
                        if (!String.IsNullOrEmpty(textbox_Email.Text) && !textbox_Soyad.Text.Contains(" "))
                        {
                            if (!String.IsNullOrEmpty(textbox_Tel.Text) && textbox_Tel.Text.Length == 13 && !textbox_Soyad.Text.Contains(" ") && harfKontrol(textbox_Tel.Text))
                            {
                                if (!String.IsNullOrEmpty(textbox_sifre.Text) && textbox_sifre.Text.Length >= 5)
                                {
                                    if (pictureBox.Image == null)
                                    {
                                        DialogResult cevap = MessageBox.Show("Resim eklemeden devam ediceksiniz eklemek ister misiniz Daha sonra ekleyebilirsiniz","Uyarı",MessageBoxButtons.YesNo);
                                        if (cevap == DialogResult.Yes)
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
                                            }
                                        }
                                        else
                                        {
                                            if (KullaniciEkle.ekle(textbox_Ad.Text, textbox_Soyad.Text, Combobox_Yetki.SelectedItem.ToString(), textbox_Email.Text, textbox_Tel.Text, sha256.sha256hash_(textbox_sifre.Text)))
                                            {
                                                MessageBox.Show("Başarılı bir şekilde yeni kullanıcı eklendi", "Başarılı", MessageBoxButtons.OK);
                                                this.Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Bir hata oluştu", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (KullaniciEkle.ekle(textbox_Ad.Text, textbox_Soyad.Text, Combobox_Yetki.SelectedItem.ToString(), textbox_Email.Text, textbox_Tel.Text, picture, sha256.sha256hash_(textbox_sifre.Text)))
                                        {
                                            MessageBox.Show("Başarılı bir şekilde yeni kullanıcı eklendi", "Başarılı", MessageBoxButtons.OK);
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Bir hata oluştu", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                    
                                }
                                else
                                {
                                    MessageBox.Show("Lütfen şifreinizi kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Telefon numaranızı kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("E-Mailinizi kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Yetki kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Soyadınız kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Adınızı kontrol ediniz","Uyarı !",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Kullanici_Ekle_Load(object sender, EventArgs e)
        {
            Combobox_Yetki.SelectedItem = "Personel";
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

        char[] sayilar = {'1','2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public bool sayiKontrol(string veri)
        {
            foreach (char s in veri)
            {
                if (sayilar.Contains(s))
                {
                    return false;
                }
            }
            return true;
        }
        char[] harf_liste = {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public bool harfKontrol(string veri)
        {
            foreach (char s in veri)
            {
                if (harf_liste.Contains(s))
                {
                    return false;
                }
            }
            return true;
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
            }
        }

        private void Kullanici_Ekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
