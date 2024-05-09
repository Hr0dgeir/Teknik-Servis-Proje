using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknik_Servis
{
    public static class cihazİslemleri
    {
        public static int secilenUrunID { get; set; }
        public static void ekle(string kisi , string tel , string marka , string model , string tarih , string detay ,string garanti)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cihazEkle = new SqlCommand("insert into ArizaliCihazlar (GonderenKisi , GonderenTel , Marka , Model , GonderimTarihi , ArizaDetayi , Garanti) values (@kisi , @tel , @marka ,@model , @tarih , @detay , @garanti)",con);
            cihazEkle.Parameters.AddWithValue("@kisi",kisi);
            cihazEkle.Parameters.AddWithValue("@tel",tel);
            cihazEkle.Parameters.AddWithValue("@marka",marka);
            cihazEkle.Parameters.AddWithValue("@model",model);
            cihazEkle.Parameters.AddWithValue("@tarih",tarih);
            cihazEkle.Parameters.AddWithValue("@detay",detay);
            cihazEkle.Parameters.AddWithValue("@garanti",garanti);
            cihazEkle.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable listele()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand listele = new SqlCommand("select * from ArizaliCihazlar",con);
            SqlDataReader read = listele.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }

        public static void cihazTeslim(string urunsahibi , string tel , string marka , string model , string islemler , string degisen ,string degisentoplam , string tarih)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cihazTeslim = new SqlCommand("insert into TeslimEdilenCihazlar (CihazSahibi , Tel , CihazMarka , CihazModel , YapılanIslemler , DegisenParcalar , DegisenToplamParca , TeslimTarihi) values (@sahip , @tel , @marka ,@model , @islem , @degisenparca ,@degisentoplam , @tarih)",con);
            cihazTeslim.Parameters.AddWithValue("@sahip", urunsahibi);
            cihazTeslim.Parameters.AddWithValue("@tel",tel);
            cihazTeslim.Parameters.AddWithValue("@marka",marka);
            cihazTeslim.Parameters.AddWithValue("@model",model);
            cihazTeslim.Parameters.AddWithValue("@islem", islemler);
            cihazTeslim.Parameters.AddWithValue("@degisenparca", degisen);
            cihazTeslim.Parameters.AddWithValue("@degisentoplam", degisentoplam);
            cihazTeslim.Parameters.AddWithValue("@tarih", tarih);
            cihazTeslim.ExecuteNonQuery();
            con.Close();
        }

        public static void cihazSil(int id )
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sil = new SqlCommand("delete from ArizaliCihazlar where ID = @id",con);
            sil.Parameters.AddWithValue("@id",id);
            sil.ExecuteNonQuery();
            con.Close();
        }

        public static void guncelle(int id,string gonderenkisi, string gonderentel , string marka , string model , string tarih , string detay)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand guncelle = new SqlCommand("update ArizaliCihazlar set GonderenKisi=@kisi , GonderenTel=@tel , Marka=@marka , Model=@model , GonderimTarihi=@tarih , ArizaDetayi=@detay where ID=@id",con);
            guncelle.Parameters.AddWithValue("@kisi", gonderenkisi);
            guncelle.Parameters.AddWithValue("@tel", gonderentel);
            guncelle.Parameters.AddWithValue("@marka", marka);
            guncelle.Parameters.AddWithValue("@model", model);
            guncelle.Parameters.AddWithValue("@tarih", tarih);
            guncelle.Parameters.AddWithValue("@detay", detay);
            guncelle.Parameters.AddWithValue("@id",id);
            guncelle.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable sıralaA()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sıralaA = new SqlCommand("select * from ArizaliCihazlar order by GonderenKisi asc",con);
            SqlDataReader read = sıralaA.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }

        public static DataTable sıralaZ()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sıralaZ = new SqlCommand("select * from ArizaliCihazlar order by GonderenKisi desc", con);
            SqlDataReader read = sıralaZ.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }
    }
}
