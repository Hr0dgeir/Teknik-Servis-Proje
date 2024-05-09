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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KullaniciEkle.kullaniciMail = guna2TextBox1.Text;

            if (!String.IsNullOrEmpty(guna2TextBox1.Text))
            {
                if (!String.IsNullOrEmpty(guna2TextBox2.Text))
                {
                    if (giris.giris_kontrol(guna2TextBox2.Text, guna2TextBox1.Text))
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("Şifrenizi kontrol ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mailinizi kontrol ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kullanici_Ekle frm = new Kullanici_Ekle();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
