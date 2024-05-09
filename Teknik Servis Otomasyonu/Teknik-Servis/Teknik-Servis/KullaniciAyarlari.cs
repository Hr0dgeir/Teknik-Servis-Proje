using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknik_Servis
{
    public static class KullaniciAyarlari
    {
        public static string tel { get; set; }
        public static string mail { get; set; }
        public static string sifre { get; set; }
        public static void bilgiler()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand bilgi = new SqlCommand("select * from PersonelKayit where E_mail=@mail",con);
            bilgi.Parameters.AddWithValue("@mail", KullaniciEkle.kullaniciMail);
            SqlDataReader read = bilgi.ExecuteReader();
            while(read.Read())
            {
                KullaniciAyarlari.tel = read[5].ToString();
                KullaniciAyarlari.mail = read[4].ToString();
                KullaniciAyarlari.sifre = read[7].ToString();
            }
            con.Close();
        }

        public static void guncelle(string mail , string tel , string sifre)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update PersonelKayit set E_mail=@mail , Tel=@tel , Sifre=@sifre where E_mail=@mailg",con);
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            cmd.Parameters.AddWithValue("@mailg", mail);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void fotoguncelle(byte[] pic)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("update PersonelKayit Set Fotograf=@foto where E_mail=@mail",con);
            sqlCommand.Parameters.AddWithValue("@foto",pic);
            sqlCommand.Parameters.AddWithValue("@mail", KullaniciEkle.kullaniciMail);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}
