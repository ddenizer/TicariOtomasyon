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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        DataTable dt;

        islemler bg = new islemler();
        private void label2_Click(object sender, EventArgs e)
        {

        }
        void listele()
        {
            dt = bg.listele("Select * from TBL_ADMIN");
            gridControl1.DataSource = dt;
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();

            txtkullanıcıad.DataBindings.Add("Text", dt, "KullaniciAd");
            txtsifre.DataBindings.Add("Text", dt, "Sifre");
            txtid.DataBindings.Add("Text", dt, "ID");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (BtnKaydet.Text == "Kaydet")
            {
                SqlCommand kaydet = new SqlCommand("insert into TBL_ADMIN values (@kullanici, @sifre)", sqlbaglantisi.baglan);
                kaydet.Parameters.AddWithValue("@kullanici", txtkullanıcıad.Text);
                kaydet.Parameters.AddWithValue("@sifre", txtsifre.Text);
                sqlbaglantisi.baglanti_ac();
                kaydet.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();

                MessageBox.Show("Yeni Admin Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(BtnKaydet.Text=="Güncelle")
            {
                SqlCommand guncelle = new SqlCommand("update TBL_ADMIN set KullaniciAd=@kullanici , Sifre=@sifre where ID=@id", sqlbaglantisi.baglan);
                guncelle.Parameters.AddWithValue("@kullanici", txtkullanıcıad.Text);
                guncelle.Parameters.AddWithValue("@sifre", txtsifre.Text);
                guncelle.Parameters.AddWithValue("@id", txtid.Text);
                sqlbaglantisi.baglanti_ac();
                guncelle.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();

                MessageBox.Show(" Admin Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtkullanıcıad_EditValueChanged(object sender, EventArgs e)
        {
            if(txtkullanıcıad.Text != "")
            {
                BtnKaydet.Text = "Güncelle";
                BtnKaydet.BackColor = Color.GreenYellow;
            }
            else
            {
                BtnKaydet.Text = "Kaydet";
            }
        }
    }
}
