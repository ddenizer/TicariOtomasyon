using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    class sqlbaglantisi
    {

       public static SqlConnection baglan = new SqlConnection(@"Data Source=AKSAN_FATIH_M\SQLEXPRESS;Initial Catalog=DboTicariOtomasyon;Integrated Security=True");
        public static SqlConnection baglanti()
        {
            //SqlConnection baglan = new SqlConnection(@"Data Source=AKSAN_FATIH_M\SQLEXPRESS;Initial Catalog=DboTicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }


        public static void baglanti_ac()
        {

            if (baglan.State == System.Data.ConnectionState.Closed)
                baglan.Open();


        }

        public static void baglanti_kapat()
        {

            if (baglan.State == System.Data.ConnectionState.Open)
                baglan.Close();


        }
    }
}
