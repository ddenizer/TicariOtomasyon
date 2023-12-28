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
    public partial class FrmDetayGuncelle : Form
    {
        public FrmDetayGuncelle()
        {
            InitializeComponent();
        }
        public string id = "";
        DataTable dt;
        islemler bg = new islemler();
        

        private void FrmDetayGuncelle_Load(object sender, EventArgs e)
        {
            txtürünıd.Text = id;

            SqlCommand komut = new SqlCommand("select * from TBL_FATURADETAY where FATURAURUNID=@P1", sqlbaglantisi.baglan);
            komut.Parameters.AddWithValue("@P1", id);
            sqlbaglantisi.baglanti_ac();
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                txtfiyat.Text = dr[3].ToString();
                txtmiktar.Text = dr[2].ToString();
                txttutar.Text = dr[4].ToString();
                txtürünad.Text = dr[1].ToString();
            }
            dr.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            double miktar, tutar, fiyat;
            fiyat = Convert.ToDouble(txtfiyat.Text);
            miktar = Convert.ToDouble(txtmiktar.Text);
            tutar = fiyat * miktar;
            txttutar.Text = tutar.ToString();


            SqlCommand guncelle = new SqlCommand("update TBL_FATURADETAY set URUNAD=@URUN, MIKTAR=@MIK, FIYAT=@FIYAT, TUTAR=@TUTAR WHERE FATURAURUNID= @ID", sqlbaglantisi.baglan);
            guncelle.Parameters.AddWithValue("@URUN", txtürünad.Text);
            guncelle.Parameters.AddWithValue("@MIK", txtmiktar.Text);
            guncelle.Parameters.AddWithValue("@FIYAT", decimal.Parse(txtfiyat.Text));
            guncelle.Parameters.AddWithValue("@TUTAR", decimal.Parse(txttutar.Text));
            guncelle.Parameters.AddWithValue("@ID", txtürünıd.Text);
            guncelle.ExecuteNonQuery();
            sqlbaglantisi.baglanti_kapat();



            MessageBox.Show("Değişiklikler Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Silmek İstediğinize Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from TBL_FATURABİLGİ where FATURAURUNID= @P1", sqlbaglantisi.baglan);
                sil.Parameters.AddWithValue("@P1", txtürünıd.Text);
                sqlbaglantisi.baglanti_ac();
                sil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();

                MessageBox.Show("Fatura Bilgisi Silndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {

            }
        }
    }
    }

