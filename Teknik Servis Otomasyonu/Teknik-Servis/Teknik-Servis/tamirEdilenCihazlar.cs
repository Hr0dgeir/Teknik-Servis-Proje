using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknik_Servis
{
    public static class tamirEdilenCihazlar
    {
        public static DataTable goster()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand goster = new SqlCommand("select * from TeslimEdilenCihazlar",con);
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
            SqlCommand sıralaA = new SqlCommand("select * from TeslimEdilenCihazlar order by TeslimTarihi asc",con);
            SqlDataReader read = sıralaA.ExecuteReader();
            DataTable dt  = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }

        public static DataTable sıralaZ()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sıralaA = new SqlCommand("select * from TeslimEdilenCihazlar order by TeslimTarihi desc", con);
            SqlDataReader read = sıralaA.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }

        public static string ad { get; set; }
        public static string tel { get; set; }
        public static string marka { get; set; }
        public static string model { get; set; }
        public static string islem { get; set; }
        public static string degisenparca { get; set; }
        public static string toplamparca { get; set; }


        public static void detayGoster()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NCQ0VQR;Initial Catalog=Teknik-Servis-DB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sec = new SqlCommand("select * from TeslimEdilenCihazlar where ID=@id",con);
            sec.Parameters.AddWithValue("@id",cihazİslemleri.secilenUrunID);
            SqlDataReader read = sec.ExecuteReader();
            while (read.Read())
            {
                tamirEdilenCihazlar.ad = read[1].ToString();
                tamirEdilenCihazlar.tel = read[2].ToString();
                tamirEdilenCihazlar.marka = read[3].ToString();
                tamirEdilenCihazlar.model = read[4].ToString();
                tamirEdilenCihazlar.islem = read[5].ToString();
                tamirEdilenCihazlar.degisenparca = read[6].ToString();
                tamirEdilenCihazlar.toplamparca = read[7].ToString();

            }
            con.Close();
        }
    }
}
