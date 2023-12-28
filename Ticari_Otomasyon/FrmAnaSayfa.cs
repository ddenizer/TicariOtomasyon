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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        DataTable dt,dt2,dt3,dt4;
        islemler bg = new islemler();
        string sorgu = "";
        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridstoklar_Click(object sender, EventArgs e)
        {

        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            //AZALAN STOKLAR
            sorgu = "select URUNAD,SUM(ADET) as 'Adet' from TBL_URUNLER group by URUNAD having SUM(ADET)<= 20 order by SUM(ADET)";
            dt = bg.listele(sorgu);
            gridstoklar.DataSource = dt;


            //AJANDA
            sorgu = "select TOP 5 TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP from TBL_NOTLAR ORDER BY ID DESC";
            dt2 = bg.listele(sorgu);
            gridajanda.DataSource = dt2;

            //FİRMA HAREKETLER
            sorgu = @"select URUNAD,AD,FIRMAAD,ADET,FIYAT,TOPLAM,FATURAID,TARIH,NOTLAR from VW_FIRMAHAREKET";
            dt3 = bg.listele(sorgu);

            gridhareket.DataSource = dt3;


            //FİRMA İLETİŞİM
            sorgu = @"select FIRMAAD, TELEFON1, TELEFON2, TELEFON3, MAIL FROM TBL_FIRMALAR";
            dt4 = bg.listele(sorgu);
            gridfirmailetisim.DataSource = dt4;


            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
