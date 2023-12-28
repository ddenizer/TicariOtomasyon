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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        DataTable dt;
        islemler bg = new islemler();

        void listele()
        {

            dt = bg.listele("Select * From TBL_GİDERLER");


            gridControl1.DataSource = dt;


        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            listele();
            txtID.DataBindings.Add("Text", dt, "ID");
            comboBoxAY.DataBindings.Add("Text", dt, "AY");
            comboBoxYIL.DataBindings.Add("Text", dt, "YIL");
            txtelektrik.DataBindings.Add("Text", dt, "ELEKTRIK");
            txtsu.DataBindings.Add("Text", dt, "SU");
            txtgaz.DataBindings.Add("Text", dt, "DOGALGAZ");
            txtint.DataBindings.Add("Text", dt, "INTERNET");
            txtmaas.DataBindings.Add("Text", dt, "MAASLAR");
            txtekstra.DataBindings.Add("Text", dt, "EKSTRA");
            txtnotlar.DataBindings.Add("Text", dt, "NOTLAR");
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into TBL_GİDERLER (AY, YIL, ELEKTRIK, SU, DOGALGAZ, INTERNET, MAASLAR, EKSTRA, NOTLAR )" +
                "values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9 )", sqlbaglantisi.baglan);
            kaydet.Parameters.AddWithValue("@p1", comboBoxAY.Text);
            kaydet.Parameters.AddWithValue("@p2", comboBoxYIL.Text);
            kaydet.Parameters.AddWithValue("@p3", decimal.Parse(txtelektrik.Text));
            kaydet.Parameters.AddWithValue("@p4", decimal.Parse(txtsu.Text));
            kaydet.Parameters.AddWithValue("@p5", decimal.Parse(txtgaz.Text));
            kaydet.Parameters.AddWithValue("@p6", decimal.Parse(txtint.Text));
            kaydet.Parameters.AddWithValue("@p7", decimal.Parse(txtmaas.Text));
            kaydet.Parameters.AddWithValue("@p8", decimal.Parse(txtekstra.Text));
            kaydet.Parameters.AddWithValue("@p9", txtnotlar.Text);

            sqlbaglantisi.baglanti_ac();
            kaydet.ExecuteNonQuery();
            sqlbaglantisi.baglanti_kapat();

            MessageBox.Show("Giderler Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_GİDERLER set AY=@P1, YIL=@P2, ELEKTRIK=@P3, SU=@P4, DOGALGAZ=@P5, INTERNET=@P6, MAASLAR=@P7, EKSTRA=@P8, NOTLAR=@P9 where ID=@P10", sqlbaglantisi.baglan);
            
            guncelle.Parameters.AddWithValue("@P1", comboBoxAY.Text);
            guncelle.Parameters.AddWithValue("@P2", comboBoxYIL.Text);
            guncelle.Parameters.AddWithValue("@P3", decimal.Parse(txtelektrik.Text));
            guncelle.Parameters.AddWithValue("@P4", decimal.Parse(txtsu.Text));
            guncelle.Parameters.AddWithValue("@P5", decimal.Parse(txtgaz.Text));
            guncelle.Parameters.AddWithValue("@P6", decimal.Parse(txtint.Text));
            guncelle.Parameters.AddWithValue("@P7", decimal.Parse(txtmaas.Text));
            guncelle.Parameters.AddWithValue("@P8", decimal.Parse(txtekstra.Text));
            guncelle.Parameters.AddWithValue("@P9", txtnotlar.Text);
            guncelle.Parameters.AddWithValue("@P10", txtID.Text);

            sqlbaglantisi.baglanti_ac();
            guncelle.ExecuteNonQuery();
            sqlbaglantisi.baglanti_kapat();

            MessageBox.Show("Giderler Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            comboBoxAY.Text = "";
            comboBoxYIL.Text = "";
            txtelektrik.Text = "";
            txtsu.Text = "";
            txtgaz.Text = "";
            txtint.Text = "";
            txtmaas.Text = "";
            txtekstra.Text = "";
            txtnotlar.Text = "";
            
        }

        private void yENİLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Silmek İstediğinize Emin Misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from TBL_GİDERLER where ID=@p1", sqlbaglantisi.baglan);
                sil.Parameters.AddWithValue("@p1", txtID.Text);
                sqlbaglantisi.baglanti_ac();
                sil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();

                MessageBox.Show("Giderler Silndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
            else
            {
                
                
            }
            
        }
    }
}
