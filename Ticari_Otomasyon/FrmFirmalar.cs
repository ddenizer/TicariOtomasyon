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
    public partial class FrmFirmalar : Form
    {
        
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        DataTable dt;
        islemler bg = new islemler();
        DataTable dt_il;
        DataTable dt_ilce;
        void listele()
        {
            dt = bg.listele("Select * From TBL_FIRMALAR");


            gridControl1.DataSource = dt;


        }
        void sehirler()
        {
            dt_il = bg.listele("select * from TBL_İLLER");
            comboBoxil.Properties.Items.Clear();
            foreach (DataRow dr in dt_il.Rows)
            {
                comboBoxil.Properties.Items.Add(dr["SEHİR"]);

            }
            sqlbaglantisi.baglanti_kapat();
        }
        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", sqlbaglantisi.baglan);
            sqlbaglantisi.baglanti_ac();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                richTextBox2.Text = dr[0].ToString();
            }
            sqlbaglantisi.baglanti_kapat();
        }
   
        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            listele();
            sehirler();
            carikodaciklamalar();


            txtID.DataBindings.Add("Text", dt, "ID");
            txtAD.DataBindings.Add("Text", dt, "FIRMAAD");
            txtSEKTÖR.DataBindings.Add("Text", dt, "SEKTOR");
            txtyetkili.DataBindings.Add("Text", dt, "YETKILIADSOYAD");
            txtgörev.DataBindings.Add("Text", dt, "YETKILISTATU");
            maskedtc.DataBindings.Add("Text", dt, "YETKILITC");
            maskedtel.DataBindings.Add("Text", dt, "TELEFON1");
            maskedtel2.DataBindings.Add("Text", dt, "TELEFON2");
            maskedtel3.DataBindings.Add("Text", dt, "TELEFON3");
            maskedfax.DataBindings.Add("Text", dt, "FAX");
            comboBoxil.DataBindings.Add("Text", dt, "IL");
            comboBoxilçe.DataBindings.Add("Text", dt, "ILCE");
            txtvergi.DataBindings.Add("Text", dt, "VERGIDAIRE");
            txtadres.DataBindings.Add("Text", dt, "ADRES");
            txtmail.DataBindings.Add("Text", dt, "MAIL");
            txtkod1.DataBindings.Add("Text", dt, "OZELKOD1");
            txtkod2.DataBindings.Add("Text", dt, "OZELKOD2");
            txtkod3.DataBindings.Add("Text", dt, "OZELKOD3");





        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into TBL_FIRMALAR (FIRMAAD, YETKILISTATU, YETKILIADSOYAD, YETKILITC, SEKTOR, TELEFON1, TELEFON2, TELEFON3, MAIL, FAX, IL, ILCE, VERGIDAIRE, ADRES, OZELKOD1, OZELKOD2, OZELKOD3)"
                + "values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17)", sqlbaglantisi.baglan);

            kaydet.Parameters.AddWithValue("@p1", txtAD.Text);
            kaydet.Parameters.AddWithValue("@p2", txtgörev.Text);
            kaydet.Parameters.AddWithValue("@p3", txtyetkili.Text);
            kaydet.Parameters.AddWithValue("@p4", maskedtc.Text);
            kaydet.Parameters.AddWithValue("@p5", txtSEKTÖR.Text);
            kaydet.Parameters.AddWithValue("@p6", maskedtel.Text);
            kaydet.Parameters.AddWithValue("@p7", maskedtel2.Text);
            kaydet.Parameters.AddWithValue("@p8", maskedtel3.Text);
            kaydet.Parameters.AddWithValue("@p9", txtmail.Text);
            kaydet.Parameters.AddWithValue("@p10", maskedfax.Text);
            kaydet.Parameters.AddWithValue("@p11", comboBoxil.Text);
            kaydet.Parameters.AddWithValue("@p12", comboBoxilçe.Text);
            kaydet.Parameters.AddWithValue("@p13", txtvergi.Text);
            kaydet.Parameters.AddWithValue("@p14", txtadres.Text);
            kaydet.Parameters.AddWithValue("@p15", txtkod1.Text);
            kaydet.Parameters.AddWithValue("@p16", txtkod2.Text);
            kaydet.Parameters.AddWithValue("@p17", txtkod3.Text);
            sqlbaglantisi.baglanti_ac();
            kaydet.ExecuteNonQuery();
            sqlbaglantisi.baglanti_kapat();

            MessageBox.Show("Firma Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            listele();
            
        }

        private void comboBoxilçe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxil_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void labelControl15_Click(object sender, EventArgs e)
        {
           
            

            }
    

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_FIRMALAR set FIRMAAD=@p1, YETKILISTATU=@p2, YETKILIADSOYAD=@p3, YETKILITC=@p4, SEKTOR=@p5,TELEFON1=@p6, TELEFON2=@p7, TELEFON3=@p8, MAIL=@p9, FAX=@p10, IL=@p11, ILCE=@p12, VERGIDAIRE=@p13, ADRES=@p14, OZELKOD1=@p15, OZELKOD2=@p16, OZELKOD3=@p17 where ID=@p18 "
                , sqlbaglantisi.baglan);



            guncelle.Parameters.AddWithValue("@p1", txtAD.Text);
            guncelle.Parameters.AddWithValue("@p2", txtgörev.Text);
            guncelle.Parameters.AddWithValue("@p3", txtyetkili.Text);
            guncelle.Parameters.AddWithValue("@p4", maskedtc.Text);
            guncelle.Parameters.AddWithValue("@p5", txtSEKTÖR.Text);
            guncelle.Parameters.AddWithValue("@p6", maskedtel.Text);
            guncelle.Parameters.AddWithValue("@p7", maskedtel2.Text);
            guncelle.Parameters.AddWithValue("@p8", maskedtel3.Text);
            guncelle.Parameters.AddWithValue("@p9", txtmail.Text);
            guncelle.Parameters.AddWithValue("@p10", maskedfax.Text);
            guncelle.Parameters.AddWithValue("@p11", comboBoxil.Text);
            guncelle.Parameters.AddWithValue("@p12", comboBoxilçe.Text);
            guncelle.Parameters.AddWithValue("@p13", txtvergi.Text);
            guncelle.Parameters.AddWithValue("@p14", txtadres.Text);
            guncelle.Parameters.AddWithValue("@p15", txtkod1.Text);
            guncelle.Parameters.AddWithValue("@p16", txtkod2.Text);
            guncelle.Parameters.AddWithValue("@p17", txtkod3.Text);
            guncelle.Parameters.AddWithValue("@p18", txtID.Text);
            sqlbaglantisi.baglanti_ac();

            if (comboBoxilçe.Text == "")
            {

                MessageBox.Show("İlçeyi Giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                guncelle.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();
                MessageBox.Show("Firma Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void yENİLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Silmek İstediğinize Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from TBL_FIRMALAR where ID= @P1", sqlbaglantisi.baglan);
                sil.Parameters.AddWithValue("@P1", txtID.Text);
                sqlbaglantisi.baglanti_ac();
                sil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();

                MessageBox.Show("Firma Silndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
            else
            {

            }
            }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtAD.Text = " ";
            txtSEKTÖR.Text = " ";
            txtyetkili.Text = " ";
            txtgörev.Text = " ";
            maskedtc.Text = " ";
            maskedtel.Text = " ";
            maskedtel2.Text = " ";
            maskedtel3.Text = " ";
            maskedfax.Text = " ";
            txtmail.Text = " ";
            comboBoxil.Text = " ";
            comboBoxilçe.Text = " ";
            txtvergi.Text = " ";
            txtadres.Text = " ";
            txtkod1.Text = " ";
            txtkod2.Text = " ";
            txtkod3.Text = " ";
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

