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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        DataTable dt;

        islemler bg = new islemler();
        DataTable dt_il;
        DataTable dt_ilce;


        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void txtvergi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxilçe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dt_ilce = bg.listele("select * from VW_IL_ILCELER where IL='" + comboBoxil.Text + "'");
            //comboBoxilçe.Properties.Items.Clear();
            //foreach (DataRow dr in dt_ilce.Rows)
            //{

            //    comboBoxilçe.Properties.Items.Add(dr["ILCE"]);

            //}


        }

        private void maskedtc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedtel2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void txtadres_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void txtmail_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSOYAD_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void txtAD_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void maskedtel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        void listele()
        {

            dt = bg.listele("Select * From TBL_MUSTERILER");


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

        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            sehirlistesi();
           listele();

            txtID.DataBindings.Add("Text", dt, "ID");
            txtAD.DataBindings.Add("Text", dt, "MUSTERIAD");
            txtSOYAD.DataBindings.Add("Text", dt, "SOYAD");
            maskedtel.DataBindings.Add("Text", dt, "TELEFON");
            maskedtel2.DataBindings.Add("Text", dt, "TELEFON2");
            maskedtc.DataBindings.Add("Text", dt, "TC");
            txtmail.DataBindings.Add("Text", dt, "MAIL");
            comboBoxil.DataBindings.Add("Text", dt, "IL");
            comboBoxilçe.DataBindings.Add("Text", dt, "ILCE");
            txtadres.DataBindings.Add("Text", dt, "ADRES");
            txtvergi.DataBindings.Add("Text", dt, "VERGIDAIRE");

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER(MUSTERIAD, SOYAD, TELEFON, TELEFON2, TC, MAIL, IL, ILCE, ADRES, VERGIDAIRE)"
                + "values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9,@p10)", sqlbaglantisi.baglan);
            komut.Parameters.AddWithValue("@p1", txtAD.Text);
            komut.Parameters.AddWithValue("@p2", txtSOYAD.Text);
            komut.Parameters.AddWithValue("@p3", maskedtel.Text);
            komut.Parameters.AddWithValue("@p4", maskedtel2.Text);
            komut.Parameters.AddWithValue("@p5", maskedtc.Text);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p8", comboBoxilçe.Text);
            komut.Parameters.AddWithValue("@p9", txtadres.Text);
            komut.Parameters.AddWithValue("@p10", txtvergi.Text);
            sqlbaglantisi.baglanti_ac();
            komut.ExecuteNonQuery();


            MessageBox.Show("Müşteri Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
            listele();

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_MUSTERILER set  MUSTERIAD = @P1, SOYAD= @P2, TELEFON= @P3, TELEFON2=@P4, TC=@P5, MAIL=@P6, IL=@P7, ILCE=@P8, ADRES=@P9, VERGIDAIRE=@P10 where ID=@P11", sqlbaglantisi.baglan);
            
            guncelle.Parameters.AddWithValue("@P1", txtAD.Text);
            guncelle.Parameters.AddWithValue("@P2", txtSOYAD.Text);
            guncelle.Parameters.AddWithValue("@P3", maskedtel.Text);
            guncelle.Parameters.AddWithValue("@P4", maskedtel2.Text);
            guncelle.Parameters.AddWithValue("@P5", maskedtc.Text);
            guncelle.Parameters.AddWithValue("@P6", txtmail.Text);
            guncelle.Parameters.AddWithValue("@P7", comboBoxil.Text);
            guncelle.Parameters.AddWithValue("@P8", comboBoxilçe.Text);
            guncelle.Parameters.AddWithValue("@P9", txtadres.Text);
            guncelle.Parameters.AddWithValue("@P10", txtvergi.Text);
            guncelle.Parameters.AddWithValue("@P11", txtID.Text);
            sqlbaglantisi.baglanti_ac();

            if (comboBoxilçe.Text=="")
            {

                MessageBox.Show("İlçeyi Giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                guncelle.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();
                MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
           

        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Silmek İstediğinize Emin Misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {


                SqlCommand komutsil = new SqlCommand("Delete from TBL_MUSTERILER where ID = @p1", sqlbaglantisi.baglan);
                komutsil.Parameters.AddWithValue("@p1", txtID.Text);

                sqlbaglantisi.baglanti_ac();
                komutsil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();


                MessageBox.Show("Müşteri Silndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
            else
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtAD.Text = " ";
            txtSOYAD.Text = " ";
            maskedtc.Text = " ";
            maskedtel.Text = " ";
            maskedtel2.Text = " ";
            txtmail.Text = " ";
            comboBoxil.Text = " ";
            comboBoxilçe.Text = " ";
            txtvergi.Text = " ";
            txtadres.Text = " ";
            
        }

        private void ıl(object sender, EventArgs e)
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












































































































