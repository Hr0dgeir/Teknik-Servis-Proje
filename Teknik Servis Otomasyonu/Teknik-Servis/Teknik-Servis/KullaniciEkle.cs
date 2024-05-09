using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknik_Servis
{
    public static class KullaniciEkle
    {
        public static string kullaniciMail { get; set; }
        public static string kullaniciAd { get; set; }
        public static string kullaniciSoyad { get; set; }
        public static bool ekle(string isim , string soyad , string yetki , string email , string tel, byte[] foto  , string sifre)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into PersonelKayit (İsim , Soyad , Yetki , E_mail , Tel , Fotograf ,Sifre) values (@isim , @soyad , @yetki , @email , @tel , @foto ,@sifre)",con);
            ekle.Parameters.AddWithValue("@isim", isim);
            ekle.Parameters.AddWithValue("@soyad", soyad);
            ekle.Parameters.AddWithValue("@yetki", yetki);
            ekle.Parameters.AddWithValue("@email", email);
            ekle.Parameters.AddWithValue("@tel", tel);
            ekle.Parameters.AddWithValue("@foto", foto);
            ekle.Parameters.AddWithValue("@sifre", sifre);
            ekle.ExecuteNonQuery(); 
            con.Close();
            return true;
        }

        public static bool ekle(string isim, string soyad, string yetki, string email, string tel, string sifre)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into PersonelKayit (İsim , Soyad , Yetki , E_mail , Tel ,Sifre) values (@isim , @soyad , @yetki , @email , @tel,@sifre)", con);
            ekle.Parameters.AddWithValue("@isim", isim);
            ekle.Parameters.AddWithValue("@soyad", soyad);
            ekle.Parameters.AddWithValue("@yetki", yetki);
            ekle.Parameters.AddWithValue("@email", email);
            ekle.Parameters.AddWithValue("@tel", tel);
            ekle.Parameters.AddWithValue("@sifre", sifre);
            ekle.ExecuteNonQuery();
            con.Close();
            return true;
        }
    }
}
