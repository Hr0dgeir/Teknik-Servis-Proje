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
    public partial class Urun_Islem : Form
    {
        public Urun_Islem()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_Kisi.Text) && sayiKontrol(textbox_Kisi.Text))
            {
                if (!String.IsNullOrEmpty(textbox_tel.Text) && harfKontrol(textbox_tel.Text))
                {
                    if (!String.IsNullOrEmpty(textbox_marka.Text))
                    {
                        if (!String.IsNullOrEmpty(textbox_model.Text))
                        {
                            if (!String.IsNullOrEmpty(combobox_garanti.SelectedItem.ToString()))
                            {
                                DateTime selectedDate = datetime_tarih.Value;
                                string sqlFormattedDate = selectedDate.ToString("yyyy-MM-dd");
                                cihazİslemleri.ekle(textbox_Kisi.Text, textbox_tel.Text, textbox_marka.Text, textbox_model.Text, sqlFormattedDate, richtextbox_detay.Text, combobox_garanti.SelectedItem.ToString());
                                yenile();
                            }
                            else
                            {
                                MessageBox.Show("Ürün garantisini kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ürün modelini kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ürün markasını kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri telefonu kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Müşteri ismini kontrol ediniz", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void datetime_tarih_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Urun_Islem_Load(object sender, EventArgs e)
        {
            yenile();
        }

        public void yenile()
        {
            guna2DataGridView1.DataSource = cihazİslemleri.listele();
        }
        string globalID;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(richTextBox2.Text))
            {
                if (richTextBox1.Text != null)
                {
                    if (textbox_degisen.Text == null)
                    {
                        MessageBox.Show("Lütfen değişen parça adedini Yazınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (globalID != null)
                        {
                            DateTime selectedDate = datatime_teslim.Value;
                            string sqlFormattedDate = selectedDate.ToString("yyyy-MM-dd");
                            cihazİslemleri.cihazTeslim(ad, soyad, tel, marka, richTextBox2.Text, richTextBox1.Text, textbox_degisen.Text, sqlFormattedDate);
                            cihazİslemleri.cihazSil(Convert.ToInt32(globalID));
                            yenile();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Teslim edilecek cihazı seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    if (globalID != null)
                    {
                        cihazİslemleri.cihazTeslim(ad, soyad, tel, marka, richTextBox2.Text, richTextBox1.Text, textbox_degisen.Text, datatime_teslim.Value.ToString());
                        cihazİslemleri.cihazSil(Convert.ToInt32(globalID));
                        yenile();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Teslim edilecek cihazı seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Yapılan işlemi Yazınız","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        string ad;
        string soyad;
        string tel;
        string marka;
        string model;
        string tarih;
        string detay;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];

            string id = selectedRow.Cells[0].Value.ToString();
            ad = selectedRow.Cells[1].Value.ToString();
            soyad = selectedRow.Cells[2].Value.ToString();
            tel = selectedRow.Cells[3].Value.ToString();
            marka = selectedRow.Cells[4].Value.ToString();
            model = selectedRow.Cells[5].Value.ToString();
            tarih = selectedRow.Cells[6].Value.ToString();
            detay = selectedRow.Cells[7].Value.ToString();

            globalID = id;


            textboxguncelle_ad.Text  = ad;
            textboxguncelle_tel.Text = soyad;
            textboxguncelle_marka.Text = tel;
            textboxguncelle_model.Text = marka;
            textboxguncelle_detay.Text = tarih;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (globalID != null)
            {
                if (!String.IsNullOrEmpty(textboxguncelle_ad.Text) && sayiKontrol(textboxguncelle_ad.Text))
                {
                    if (!String.IsNullOrEmpty(textboxguncelle_tel.Text) && harfKontrol(textboxguncelle_tel.Text))
                    {
                        if (!String.IsNullOrEmpty(textboxguncelle_detay.Text))
                        {
                            if (!String.IsNullOrEmpty(textboxguncelle_marka.Text))
                            {
                                if (!String.IsNullOrEmpty(textboxguncelle_model.Text))
                                {
                                    DateTime selectedDate = datetimeguncelle_tarih.Value;
                                    string sqlFormattedDate = selectedDate.ToString("yyyy-MM-dd");
                                    cihazİslemleri.guncelle(Convert.ToInt32(globalID),textboxguncelle_ad.Text,textboxguncelle_tel.Text,textboxguncelle_marka.Text,textboxguncelle_model.Text,sqlFormattedDate,textboxguncelle_detay.Text);
                                    yenile();
                                }
                                else
                                {
                                    MessageBox.Show("Ürün Modelini kontrol ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ürün Markasını kontrol ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ürün Detayını kontrol ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Müşteri telefonunu kontrol ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri adını kontrol ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }             
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource =  cihazİslemleri.sıralaA();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = cihazİslemleri.sıralaZ();
        }

        char[] sayilar = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
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

        private void textboxguncelle_tel_TextChanged(object sender, EventArgs e)
        {
            if (textboxguncelle_tel.Text.Length == 3)
            {
                textboxguncelle_tel.Text += "-";
                textboxguncelle_tel.SelectionStart = textboxguncelle_tel.Text.Length;
            }
            if (textboxguncelle_tel.Text.Length == 7)
            {
                textboxguncelle_tel.Text += "-";
                textboxguncelle_tel.SelectionStart = textboxguncelle_tel.Text.Length;
            }
            if (textboxguncelle_tel.Text.Length == 10)
            {
                textboxguncelle_tel.Text += "-";
                textboxguncelle_tel.SelectionStart = textboxguncelle_tel.Text.Length;

            }
        }

        private void textbox_tel_TextChanged(object sender, EventArgs e)
        {
            if (textbox_tel.Text.Length == 3)
            {
                textbox_tel.Text += "-";
                textbox_tel.SelectionStart = textbox_tel.Text.Length;
            }
            if (textbox_tel.Text.Length == 7)
            {
                textbox_tel.Text += "-";
                textbox_tel.SelectionStart = textbox_tel.Text.Length;
            }
            if (textbox_tel.Text.Length == 10)
            {
                textbox_tel.Text += "-";
                textbox_tel.SelectionStart = textbox_tel.Text.Length;

            }
        }
    }
}
