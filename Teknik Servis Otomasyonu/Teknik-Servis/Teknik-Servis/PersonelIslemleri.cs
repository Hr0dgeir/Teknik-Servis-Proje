using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknik_Servis
{
    public static class PersonelIslemleri
    {
        public static DataTable goster()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand goster = new SqlCommand("select ID , İsim , Soyad , Yetki , E_mail , Tel from PersonelKayit",con);
            SqlDataReader read = goster.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }

        public static DataTable sıralaA()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sıralaA = new SqlCommand("select ID , İsim , Soyad , Yetki , E_mail , Tel from PersonelKayit order by İsim asc", con);
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
            SqlCommand sıralaA = new SqlCommand("select ID , İsim , Soyad , Yetki , E_mail , Tel from PersonelKayit order by İsim desc", con);
            SqlDataReader read = sıralaA.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }
    }
}
