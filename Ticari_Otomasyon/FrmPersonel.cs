using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DataTable dt;
        DataTable dt_il;
        DataTable dt_ilce;
        islemler bg = new islemler();
        void listele()
        {

            dt = bg.listele("Select * From TBL_PERSONELLER");


            gridControl1.DataSource = dt;


        }
        void sehirlistesi()
        {

            dt_il = bg.listele("select * from TBL_İLLER");
            comboBoxil.Properties.Items.Clear();
            foreach (DataRow dr in dt_il.Rows)
            {
                comboBoxil.Properties.Items.Add(dr["SEHİR"]);

            }
            sqlbaglantisi.baglanti_kapat();

        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            sehirlistesi();
            listele();


            txtID.DataBindings.Add("Text", dt, "ID");
            txtAD.DataBindings.Add("Text", dt, "AD");
            txtSOYAD.DataBindings.Add("Text", dt, "PERSONSOYAD");
            maskedtel.DataBindings.Add("Text", dt, "TELEFON");
            maskedtc.DataBindings.Add("Text", dt, "TC");
            txtmail.DataBindings.Add("Text", dt, "MAIL");
            comboBoxil.DataBindings.Add("Text", dt, "IL");
            comboBoxilçe.DataBindings.Add("Text", dt, "ILCE");
            txtadres.DataBindings.Add("Text", dt, "ADRES");
            txtgörev.DataBindings.Add("Text", dt, "GOREV");
        }

        private void comboBoxil_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into TBL_PERSONELLER(AD, PERSONSOYAD, TELEFON, TC, MAIL, IL, ILCE, ADRES, GOREV)" +
                "values(@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", sqlbaglantisi.baglan);
           
            kaydet.Parameters.AddWithValue( "@p1", txtAD.Text);
            kaydet.Parameters.AddWithValue( "@p2", txtSOYAD.Text);
            kaydet.Parameters.AddWithValue( "@p3", maskedtel.Text);
            kaydet.Parameters.AddWithValue( "@p4", maskedtc.Text);
            kaydet.Parameters.AddWithValue( "@p5", txtmail.Text);
            kaydet.Parameters.AddWithValue( "@p6", comboBoxil.Text);
            kaydet.Parameters.AddWithValue( "@p7", comboBoxilçe.Text);
            kaydet.Parameters.AddWithValue( "@p8", txtadres.Text);
            kaydet.Parameters.AddWithValue( "@p9", txtgörev.Text);
            sqlbaglantisi.baglanti_ac();
            kaydet.ExecuteNonQuery();
            MessageBox.Show("Personel Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK,
             MessageBoxIcon.Information);

            listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_PERSONELLER set AD=@P1, PERSONSOYAD=@P2, TELEFON=@P3, TC=@P4, MAIL=@P5, IL=@P6, ILCE=@P7, ADRES=@P8, GOREV=@P9 where ID=@P10", sqlbaglantisi.baglan);
            guncelle.Parameters.AddWithValue("@P1", txtAD.Text);
            guncelle.Parameters.AddWithValue("@P2", txtSOYAD.Text);
            guncelle.Parameters.AddWithValue("@P3", maskedtel.Text);
            guncelle.Parameters.AddWithValue("@P4", maskedtc.Text);
            guncelle.Parameters.AddWithValue("@P5", txtmail.Text);
            guncelle.Parameters.AddWithValue("@P6", comboBoxil.Text);
            guncelle.Parameters.AddWithValue("@P7", comboBoxilçe.Text);
            guncelle.Parameters.AddWithValue("@P8", txtadres.Text);
            guncelle.Parameters.AddWithValue("@P9", txtgörev.Text);
            guncelle.Parameters.AddWithValue("@P10", txtID.Text);
            sqlbaglantisi.baglanti_ac();

            if (comboBoxilçe.Text == "")
            {

                MessageBox.Show("İlçeyi Giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                guncelle.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();
                MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            
            txtAD.Text = " ";
            txtSOYAD.Text = " ";
            maskedtc.Text = " ";
            maskedtel.Text = " ";
            txtmail.Text = " ";
            comboBoxil.Text = " ";
            comboBoxilçe.Text = " ";
            txtadres.Text = " ";
            txtgörev.Text = "";
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Silmek İstediğinize Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("Delete from TBL_PERSONELLER where ID = @p1", sqlbaglantisi.baglan);
                komutsil.Parameters.AddWithValue("@p1", txtID.Text);

                sqlbaglantisi.baglanti_ac();
                komutsil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();


                MessageBox.Show("Personel Silndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
            else
            {

            }
            }

            private void yENİLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBoxil_TextChanged(object sender, EventArgs e)
        {
            comboBoxilçe.Text = "";
            dt_ilce = bg.listele("select * from VW_IL_ILCELER where IL='" + comboBoxil.Text + "'");
            comboBoxilçe.Properties.Items.Clear();
            foreach (DataRow dr in dt_ilce.Rows)
            {

                comboBoxilçe.Properties.Items.Add(dr["ILCE"]);

            }
        }
    }
}
