using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknik_Servis
{
    public static class giris
    {
        public static bool giris_kontrol(string sifre, string mail)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string sifrelenmis_sifre;
            SqlCommand login = new SqlCommand("select * from PersonelKayit where E_mail=@kullanici and Sifre=@sifre", con);
            sifrelenmis_sifre = sha256.sha256hash_(sifre);
            login.Parameters.AddWithValue("@kullanici", mail);
            login.Parameters.AddWithValue("@sifre", sifrelenmis_sifre);

            SqlDataAdapter da = new SqlDataAdapter(login);

            DataTable dt = new DataTable();
            da.Fill(dt);

           
            if (dt.Rows.Count > 0)
            {
                string yetkiString;

                SqlCommand yetki = new SqlCommand("select Yetki from PersonelKayit where E_mail=@mail",con);
                yetki.Parameters.AddWithValue("@mail",mail);
                yetki.ExecuteNonQuery();
                SqlDataReader read = yetki.ExecuteReader();
                while (read.Read())
                {
                    yetkiString = read[0].ToString();
                    MessageBox.Show(yetkiString);
                    if (yetkiString == "Personel")
                    {
                        System.Windows.Forms.MessageBox.Show("Başarılı", "Giriş Yapıldı", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.None);
                        Ana_Panel frm = new Ana_Panel();
                        frm.Show();
                        con.Close();
                        return true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Başarılı", "Giriş Yapıldı", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.None);
                        Yonetici_panel frm = new Yonetici_panel();
                        frm.Show();
                        con.Close();
                        return true;
                    }
                }



                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
