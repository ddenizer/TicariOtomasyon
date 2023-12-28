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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        DataTable dt;
        islemler bg = new islemler();

        void listele()
        {
            dt = bg.listele("Select * From TBL_FATURABİLGİ");


            gridControl1.DataSource = dt;


        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            FrmFaturaDetaY FRM = new FrmFaturaDetaY();
            FRM.id = gridView1.GetFocusedRowCellDisplayText("ID").ToString();
            FRM.Show();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtfaturaıd.Text=="")
            {
                SqlCommand kaydet = new SqlCommand("insert into TBL_FATURABİLGİ (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN)"
                    + "values (@SERI,@SIRANO,@TARIH,@SAAT,@VERGI,@ALICI,@EDEN,@ALAN)", sqlbaglantisi.baglan);
                kaydet.Parameters.AddWithValue("@SERI", txtserino.Text);
                kaydet.Parameters.AddWithValue("@SIRANO", txtsırano.Text);
                kaydet.Parameters.AddWithValue("@TARIH", maskedtarih.Text);
                kaydet.Parameters.AddWithValue("@SAAT", maskedsaat.Text);
                kaydet.Parameters.AddWithValue("@VERGI", txtvergi.Text);
                kaydet.Parameters.AddWithValue("@ALICI", txtalıcı.Text);
                kaydet.Parameters.AddWithValue("@EDEN", txteden.Text);
                kaydet.Parameters.AddWithValue("@ALAN", txtalan.Text);
                sqlbaglantisi.baglanti_ac();
                kaydet.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();

                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                listele();
            }
            if(txtfaturaıd.Text!= "")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtfiyat.Text);
                miktar = Convert.ToDouble(txtmiktar.Text);
                tutar = fiyat * miktar;
                txttutar.Text = tutar.ToString();

                SqlCommand kaydet2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD, MIKTAR, FIYAT, TUTAR, FATURAID)"
                    + "values (@urunad, @mıktar, @fıyat, @tutar, @faturaıd)", sqlbaglantisi.baglan);
                kaydet2.Parameters.AddWithValue("@urunad", txtürünad.Text);
                kaydet2.Parameters.AddWithValue("@mıktar", txtmiktar.Text);
                kaydet2.Parameters.AddWithValue("@fıyat", decimal.Parse(txtfiyat.Text));
                kaydet2.Parameters.AddWithValue("@tutar", decimal.Parse(txttutar.Text));
                kaydet2.Parameters.AddWithValue("@faturaıd", txtfaturaıd.Text);
                sqlbaglantisi.baglanti_ac();
                kaydet2.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();
                MessageBox.Show("Faturaya Ait Ürün Kaydedildi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                listele();
            }
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();

            txtID.DataBindings.Add("Text", dt, "ID");
            txtserino.DataBindings.Add("Text", dt, "SERI");
            txtsırano.DataBindings.Add("Text", dt, "SIRANO");
            maskedtarih.DataBindings.Add("Text", dt, "TARIH");
            maskedsaat.DataBindings.Add("Text", dt, "SAAT");
            txtvergi.DataBindings.Add("Text", dt, "VERGIDAIRE");
            txtalıcı.DataBindings.Add("Text", dt, "ALICI");
            txteden.DataBindings.Add("Text", dt, "TESLIMEDEN");
            txtalan.DataBindings.Add("Text", dt, "TESLIMALAN");
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtID.Text = " ";
            txtserino.Text = " ";
            txtsırano.Text = " ";
            maskedtarih.Text = " ";
            maskedsaat.Text = " ";
            txtvergi.Text = " ";
            txtalıcı.Text = " ";
            txteden.Text = " ";
            txtalan.Text = " ";
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Silmek İstediğinize Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from TBL_FATURABİLGİ where ID= @P1", sqlbaglantisi.baglan);
                sil.Parameters.AddWithValue("@P1", txtID.Text);
                sqlbaglantisi.baglanti_ac();
                sil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();

                MessageBox.Show("Fatura Bilgisi Silndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
            else
            {

            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_FATURABİLGİ set SERI=@SERI, SIRANO=@SIRANO, TARIH=@TARIH, SAAT=@SAAT, VERGIDAIRE=@VERGI, ALICI=@ALICI, TESLIMEDEN=@EDEN, TESLIMALAN=@ALAN where ID=@id", sqlbaglantisi.baglan);
            guncelle.Parameters.AddWithValue("@SERI", txtserino.Text);
            guncelle.Parameters.AddWithValue("@SIRANO", txtsırano.Text);
            guncelle.Parameters.AddWithValue("@TARIH", maskedtarih.Text);
            guncelle.Parameters.AddWithValue("@SAAT", maskedsaat.Text);
            guncelle.Parameters.AddWithValue("@VERGI", txtvergi.Text);
            guncelle.Parameters.AddWithValue("@ALICI", txtalıcı.Text);
            guncelle.Parameters.AddWithValue("@EDEN", txteden.Text);
            guncelle.Parameters.AddWithValue("@ALAN", txtalan.Text);
            guncelle.Parameters.AddWithValue("@id", txtID.Text);
            sqlbaglantisi.baglanti_ac();
            guncelle.ExecuteNonQuery();
            sqlbaglantisi.baglanti_kapat();

            MessageBox.Show("Firma Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }
    }
}
