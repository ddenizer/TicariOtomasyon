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

namespace Ticari_Otomasyon
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        islemler bg = new islemler();
        DataTable dt;
        void listeler()
        {
            dt = bg.listele("Select * from TBL_NOTLAR");
            gridControl1.DataSource = dt;
        }


        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listeler();
            txtid.DataBindings.Add("Text", dt, "ID");
            txtbaslık.DataBindings.Add("Text", dt, "BASLIK");
            maskedsaat.DataBindings.Add("Text", dt, "SAAT");
            maskedtarıh.DataBindings.Add("Text", dt, "TARIH");
            txthitap.DataBindings.Add("Text", dt, "HITAP");
            txtolusturan.DataBindings.Add("Text", dt, "OLUSTURAN");
            txtdetay.DataBindings.Add("Text", dt, "DETAY");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into TBL_NOTLAR (BASLIK, SAAT, TARIH, HITAP, OLUSTURAN, DETAY)"
                + "values ( @BAS, @SAAT, @TARIH, @HİTAP, @OLUSTURAN, @DETAY)", sqlbaglantisi.baglan);
            kaydet.Parameters.AddWithValue("@BAS", txtbaslık.Text);
            kaydet.Parameters.AddWithValue("@SAAT", maskedsaat.Text);
            kaydet.Parameters.AddWithValue("@TARIH", maskedtarıh.Text);
            kaydet.Parameters.AddWithValue("@HİTAP", txthitap.Text);
            kaydet.Parameters.AddWithValue("@OLUSTURAN", txtolusturan.Text);
            kaydet.Parameters.AddWithValue("@DETAY", txtdetay.Text);
            sqlbaglantisi.baglanti_ac();
            kaydet.ExecuteNonQuery();
            

            MessageBox.Show("Not Bilgileri Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listeler();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtbaslık.Text = "";
            maskedsaat.Text = "";
            maskedtarıh.Text = "";
            txthitap.Text = "";
            txtolusturan.Text = "";
            txtdetay.Text = "";
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_NOTLAR set BASLIK=@BASLIK, SAAT=@SAAT, TARIH=@TARIH, HITAP=@HITAP, OLUSTURAN=@OLUSTURAN, DETAY=@DETAY where ID=@id", sqlbaglantisi.baglan);
            guncelle.Parameters.AddWithValue("@BASLIK", txtbaslık.Text);
            guncelle.Parameters.AddWithValue("@SAAT", maskedsaat.Text);
            guncelle.Parameters.AddWithValue("@TARIH", maskedtarıh.Text);
            guncelle.Parameters.AddWithValue("@HITAP", txthitap.Text);
            guncelle.Parameters.AddWithValue("@OLUSTURAN", txtolusturan.Text);
            guncelle.Parameters.AddWithValue("@DETAY", txtdetay.Text);
            guncelle.Parameters.AddWithValue("@id", txtid.Text);
            sqlbaglantisi.baglanti_ac();
            guncelle.ExecuteNonQuery();

            MessageBox.Show("Not Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listeler();

        }

        private void yENİLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Silmek İstediğinize Emin Misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("Delete from TBL_NOTLAR where ID = @p1", sqlbaglantisi.baglan);
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);


                sqlbaglantisi.baglanti_ac();
                komutsil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();


                MessageBox.Show("Ürün Silndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listeler();
            }
            else
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay frm = new FrmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(dr != null)
            {
                frm.metin = dr["DETAY"].ToString();
            }
            frm.Show();
        }
    }
}
