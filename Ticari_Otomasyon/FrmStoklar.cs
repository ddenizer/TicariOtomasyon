using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ticari_Otomasyon
{
    public partial class FrmStoklar : Form
    {

        public FrmStoklar()
        {
            InitializeComponent();
        }

        DataTable dt,dt_ ,dt2;
        islemler bg = new islemler();


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay frm = new FrmStokDetay();
            frm.ad = gridView1.GetFocusedRowCellDisplayText("URUNAD").ToString();
            frm.Show();
        }

        string sorgu = "";
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
          
            //GridControle Listeleme
          
            sorgu= "Select URUNAD ,SUM(ADET) As 'Miktar' FROM TBL_URUNLER GROUP BY URUNAD";
            dt = bg.listele(sorgu);
            gridControl1.DataSource = dt;


            sorgu = "Select IL, COUNT (*) As 'Sayı' from TBL_FIRMALAR Group By IL";
            dt2 = bg.listele(sorgu);
            gridControl2.DataSource = dt2;





            //Charta Listeleme
            sorgu = "Select URUNAD ,SUM(ADET) As 'Miktar' FROM TBL_URUNLER GROUP BY URUNAD";
            dt_ = bg.listele(sorgu);


            foreach (DataRow dr in dt_.Rows)
            {


                chartControl1.Series["Series 1"].Points.AddPoint(dr["URUNAD"].ToString(),Convert.ToDouble(dr["Miktar"].ToString()));
            }


            sorgu = "Select IL, COUNT (*) from TBL_FIRMALAR Group By IL";
            dt2 = bg.listele(sorgu);


            foreach (DataRow dr2 in dt2.Rows)
            {


                chartControl2.Series["Series 1"].Points.AddPoint(dr2[0].ToString(), Convert.ToDouble(dr2[1].ToString()));

               
            }


        }

        

     


    

    }
}
