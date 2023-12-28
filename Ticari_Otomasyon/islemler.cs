using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticari_Otomasyon
{
    class islemler
    {



        //public string bugun_tarih()
        //{

        //    string trh = System.DateTime.Now.ToString("dd.MM.yyyy");
        //    return trh;


        //}

        public static string kul_ad = "";
        public DataTable listele(string sorgu)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, sqlbaglantisi.baglan);

            da.Fill(dt);


            return dt;

        }
    }
}
 




