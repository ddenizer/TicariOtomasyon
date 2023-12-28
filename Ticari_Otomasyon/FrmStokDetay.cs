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
    public partial class FrmStokDetay : Form
    {
        public FrmStokDetay()
        {
            InitializeComponent();
        }

        DataTable dt;
        islemler bg = new islemler();
        public string ad;


        //void listele()
        //{
        //    dt = bg.listele("select * from TBL_URUNLER WHERE URUNAD=" + ad);
        //    gridControl1.DataSource = dt;
        //}
        private void FrmStokDetay_Load(object sender, EventArgs e)
        {

            //listele();

            dt = bg.listele("select * from TBL_URUNLER WHERE URUNAD='" + ad+"'");
            gridControl1.DataSource = dt;
        }
    }
}
