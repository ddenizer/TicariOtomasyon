using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        DataTable dt, dt2, dtp, dtm, dtf, dtfs, dtms, dtps, dts, dtc, dtc2, dtc3,
            dtc4,dtc5;

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            //Elektrik
            if (sayac > 0 && sayac <= 5)
            {
                groupControl10.Text = "Elektrik";
                chartControl1.Series["Aylar"].Points.Clear();
                sorgu = "select top 4 AY, ELEKTRIK from TBL_GİDERLER order by ID desc";
                dtc = bg.listele(sorgu);
                foreach (DataRow drc in dtc.Rows)
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(drc["AY"], drc["ELEKTRIK"]));
                }
            }

            //Su
            if (sayac > 5 && sayac <= 10)
            {
                groupControl10.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();
                sorgu = "select top 4 AY, SU from TBL_GİDERLER order by ID desc";
                dtc2 = bg.listele(sorgu);
                foreach (DataRow drc2 in dtc2.Rows)
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(drc2["AY"], drc2["SU"]));
                }
            }


            //Doğalgaz
            if (sayac > 10 && sayac <= 15)
            {
                groupControl10.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();
                sorgu = "select top 4 AY, DOGALGAZ from TBL_GİDERLER order by ID desc";
                dtc3 = bg.listele(sorgu);
                foreach (DataRow drc3 in dtc3.Rows)
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(drc3["AY"], drc3["DOGALGAZ"]));
                }
            }

            //İnternet
            if (sayac > 15 && sayac <= 20)
            {
                groupControl10.Text = "İnternet";
                chartControl1.Series["Aylar"].Points.Clear();
                sorgu = "select top 4 AY, INTERNET from TBL_GİDERLER order by ID desc";
                dtc4 = bg.listele(sorgu);
                foreach (DataRow drc4 in dtc4.Rows)
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(drc4["AY"], drc4["INTERNET"]));
                }
            }
            
            //Ekstra
            if (sayac > 20 && sayac <= 25)
            {
                groupControl10.Text = "Ekstra";
                chartControl1.Series["Aylar"].Points.Clear();
                sorgu = "select top 4 AY, EKSTRA from TBL_GİDERLER order by ID desc";
                dtc5 = bg.listele(sorgu);
                foreach (DataRow drc5 in dtc5.Rows)
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(drc5["AY"], drc5["EKSTRA"]));
                }
            }
            if(sayac == 26)
            {
                sayac = 0;
            }
        }


        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        islemler bg = new islemler();
        string sorgu = "";

        void listele1()
        {
            dt = bg.listele("Select * from VW_FIRMAHAREKET");
            gridControl1.DataSource = dt;

            
        }
        void listele2()
        {
            dt2 = bg.listele("Select * from VW_MUSTERIHAREKET");
            gridControl3.DataSource = dt2;
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblaktifkullanici.Text = islemler.kul_ad;

            listele1();
            listele2();

            //Toplam Tutar
            sorgu = "Select SUM(TUTAR) FROM TBL_FATURADETAY";

            dt = bg.listele(sorgu);

            foreach (DataRow dr in dt.Rows)
            {
                lbltoplam.Text = dr[0].ToString() + "TL";
            }

            //SqlCommand komut1 = new SqlCommand("Select Sum(TUTAR) from TBL_FATURADETAY", sqlbaglantisi.baglan);
            //sqlbaglantisi.baglanti_ac();
            //SqlDataReader dr1 = komut1.ExecuteReader();
            //while(dr1.Read())
            //{
            //    lbltoplam.Text = dr1[0].ToString();
            //}
            //sqlbaglantisi.baglanti_kapat();

            //Son Ayın Faturaları
            sorgu = "select (ELEKTRIK+SU+DOGALGAZ) FROM TBL_GİDERLER order by ID ASC";

            dt2 = bg.listele(sorgu);

            foreach (DataRow dr2 in dt2.Rows)
            {
                lblödeme.Text = dr2[0].ToString() + "TL";
            }

            //Son Ayın Personel Maaşları

            sorgu = "select SUM(MAASLAR) from TBL_GİDERLER ";
            dtp = bg.listele(sorgu);
            foreach (DataRow drp in dtp.Rows)
            {
                lblpersonelmaas.Text = drp[0].ToString() + "TL";
            }

            //Toplam Müşteri Sayısı

            sorgu = "select Count(*) from TBL_MUSTERILER ";
            dtm = bg.listele(sorgu);
            foreach (DataRow drm in dtm.Rows)
            {
                lblmüsterisayisi.Text = drm[0].ToString();
            }

            //Toplam Firma Sayısı

            sorgu = "select Count(*) from TBL_FIRMALAR ";
            dtf = bg.listele(sorgu);
            foreach (DataRow drf in dtf.Rows)
            {
                lblfirma.Text = drf[0].ToString();
            }

            //Firma Şehir Sayısı

            sorgu = "select Count(Distinct(IL)) from TBL_FIRMALAR ";
            dtfs = bg.listele(sorgu);
            foreach (DataRow drfs in dtfs.Rows)
            {
                lblfsehir.Text = drfs[0].ToString();
            }

            //Müşteri Şehir Sayısı

            sorgu = "select Count(Distinct(IL)) from TBL_MUSTERILER ";
            dtms = bg.listele(sorgu);
            foreach (DataRow drms in dtms.Rows)
            {
                lblmsehir.Text = drms[0].ToString();
            }
            //Toplam Personel Sayısı

            sorgu = "select Count(*) from TBL_PERSONELLER ";
            dtps = bg.listele(sorgu);
            foreach (DataRow drps in dtps.Rows)
            {
                lblpersonelsayisi.Text = drps[0].ToString();
            }
            //Toplam Stok Sayısı

            sorgu = "select sum(ADET) from TBL_URUNLER";
            dts = bg.listele(sorgu);
            foreach (DataRow drs in dts.Rows)
            {
                lblstoksayısı.Text = drs[0].ToString();
            }


        }
    }
}
