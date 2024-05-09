using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknik_Servis
{
    public static class kullaniciBilgileri
    {  
        public static void kullaniciSelamla()
        {          
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand kullanici = new SqlCommand("SELECT İsim, Soyad FROM PersonelKayit WHERE E_mail=@kullaniciMail", con);
            kullanici.Parameters.AddWithValue("@kullaniciMail", KullaniciEkle.kullaniciMail);
            SqlDataReader read = kullanici.ExecuteReader();         
            while (read.Read())
            {
                KullaniciEkle.kullaniciAd = read[0].ToString();
                string soyad = read[1].ToString();
            }
            con.Close();           
        }

        public static Image kullanici_foto()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            try
            {

                SqlCommand picture_retrieve = new SqlCommand("select Fotograf from PersonelKayit where E_mail='" + KullaniciEkle.kullaniciMail + "'", con);
                byte[] pictureData = (byte[])picture_retrieve.ExecuteScalar();
                if (pictureData != null)
                {
                    using (MemoryStream ms = new MemoryStream(pictureData))
                    {
                        Image retrievedImage = Image.FromStream(ms);
                        con.Close();
                        return retrievedImage;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }

        }
    }
}
