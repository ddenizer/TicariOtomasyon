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
    public partial class FrmBankalar : Form
    {
        DataTable dt;
        islemler bg = new islemler();
        string sorgu = "";
        DataTable dtil;
        DataTable dtilce;
        DataTable db;
        DataTable dtf;
        DataTable dts;
        DataTable dtyet;

        void listeler()
        {

            sorgu = @"select * from VW_BANKAFIRMA";
            
            dt = bg.listele(sorgu);


            gridControl1.DataSource = dt;
        }
        void sehirler()
        {
            dtil = bg.listele("select * from TBL_İLLER");
            comboBoxil.Properties.Items.Clear();
            foreach (DataRow dr in dtil.Rows)
            {
                comboBoxil.Properties.Items.Add(dr["SEHİR"]);

            }
            sqlbaglantisi.baglanti_kapat();
        }
        void bankalar()
        {
            db = bg.listele("select * from TBL_BANKAİSİM");
            comboBoxbanka.Properties.Items.Clear();
            foreach (DataRow dr in db.Rows)
            {
                comboBoxbanka.Properties.Items.Add(dr["banka"]);
            }
            sqlbaglantisi.baglanti_kapat();
        }
        void firmalar()
        {
            db = bg.listele("select ID,FIRMAAD from TBL_FIRMALAR");
            lookUpfirma.Properties.ValueMember = "ID";
            lookUpfirma.Properties.DisplayMember = "FIRMAAD";
            lookUpfirma.Properties.DataSource = db;
          

        }
        public FrmBankalar()
        {
            InitializeComponent();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            sehirler();
            listeler();
            bankalar();
            firmalar();


            txtID.DataBindings.Add("Text", dt, "ID");
            comboBoxbanka.DataBindings.Add("Text", dt, "BANKAADI");
            comboBoxil.DataBindings.Add("Text", dt, "IL");
            comboBoxilçe.DataBindings.Add("Text", dt, "ILCE");
            comboBoxsube.DataBindings.Add("Text", dt, "SUBE");
            txtiban.DataBindings.Add("Text", dt, "IBAN");
            txthesap.DataBindings.Add("Text", dt, "HESAPNO");
            comboBoxyetkili.DataBindings.Add("Text", dt, "YETKILI");
            maskedtel.DataBindings.Add("Text", dt, "TELEFON");
            maskedtarih.DataBindings.Add("Text", dt, "TARIH");
            txttür.DataBindings.Add("Text", dt, "HESAPTURU");
            lookUpfirma.DataBindings.Add("Text", dt, "FIRMAID");



        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into TBL_BANKALAR(BANKAADI, IL, ILCE,  SUBE, IBAN, HESAPNO, YETKILI, TELEFON, TARIH, HESAPTURU, FIRMAID)" +
                "values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11) ", sqlbaglantisi.baglan);
            kaydet.Parameters.AddWithValue("@p1", comboBoxbanka.Text);
            kaydet.Parameters.AddWithValue("@p2", comboBoxil.Text);
            kaydet.Parameters.AddWithValue("@p3", comboBoxilçe.Text);
            kaydet.Parameters.AddWithValue("@p4", comboBoxsube.Text);
            kaydet.Parameters.AddWithValue("@p5", txtiban.Text);
            kaydet.Parameters.AddWithValue("@p6", txthesap.Text);
            kaydet.Parameters.AddWithValue("@p7", comboBoxyetkili.Text);
            kaydet.Parameters.AddWithValue("@p8", maskedtel.Text);
            kaydet.Parameters.AddWithValue("@p9", maskedtarih.Text);
            kaydet.Parameters.AddWithValue("@p10", txttür.Text);
            kaydet.Parameters.AddWithValue("@p11", lookUpfirma.EditValue);

            sqlbaglantisi.baglanti_ac();
            kaydet.ExecuteNonQuery();
            listeler();
            sqlbaglantisi.baglanti_kapat();

            MessageBox.Show("Banka Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
            
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_BANKALAR set BANKAADI=@P1, IL=@P2, ILCE=@P3, SUBE=@P4, IBAN=@P5, HESAPNO=@P6, YETKILI=@P7, TELEFON=@P8, TARIH=@P9, HESAPTURU=@P10, FIRMAID=@P11 WHERE ID = @P12", sqlbaglantisi.baglan);
            guncelle.Parameters.AddWithValue("@P1", comboBoxbanka.Text);
            guncelle.Parameters.AddWithValue("@P2", comboBoxil.Text);
            guncelle.Parameters.AddWithValue("@P3", comboBoxilçe.Text);
            guncelle.Parameters.AddWithValue("@P4", comboBoxsube.Text);
            guncelle.Parameters.AddWithValue("@P5", txtiban.Text);
            guncelle.Parameters.AddWithValue("@P6", txthesap.Text);
            guncelle.Parameters.AddWithValue("@P7", comboBoxyetkili.Text);
            guncelle.Parameters.AddWithValue("@P8", maskedtel.Text);
            guncelle.Parameters.AddWithValue("@P9", maskedtarih.Text);
            guncelle.Parameters.AddWithValue("@P10", txttür.Text);
            guncelle.Parameters.AddWithValue("@P11", lookUpfirma.EditValue);
            guncelle.Parameters.AddWithValue("@P12", txtID.Text);

            sqlbaglantisi.baglanti_ac();
            if (comboBoxilçe.Text == "")
            {

                MessageBox.Show("İlçeyi Giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                guncelle.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();
                MessageBox.Show("Banka Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
            }
            }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            comboBoxbanka.Text = "";
            comboBoxil.Text = "";
            comboBoxilçe.Text = "";
            comboBoxsube.Text = "";
            txtiban.Text = "";
            txthesap.Text = "";
            comboBoxyetkili.Text = "";
            maskedtel.Text = "";
            maskedtarih.Text = "";
            txttür.Text = "";
            lookUpfirma.Text = "";

        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Silmek İstediğinize Emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete from TBL_BANKALAR where ID= @P1", sqlbaglantisi.baglan);
                sil.Parameters.AddWithValue("@P1", txtID.Text);
                sqlbaglantisi.baglanti_ac();
                sil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();

                MessageBox.Show("Banka Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listeler();
            }
            else
            {

            }
        }

        private void comboBoxil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxsube_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtyet = bg.listele("select * from VW_SUBE_YETKİLİ where sube= '" + comboBoxsube.Text + "'");
            comboBoxyetkili.Properties.Items.Clear();
            foreach(DataRow dr in dtyet.Rows)
            {
                comboBoxyetkili.Properties.Items.Add(dr["yetkili"]);
            }
        }

        private void comboBoxbanka_SelectedIndexChanged(object sender, EventArgs e)
        {
            dts = bg.listele("select * from VW_BANKA_SUBE where banka = '" + comboBoxbanka.Text + "'");
            comboBoxsube.Properties.Items.Clear();
            foreach(DataRow dr in dts.Rows)
            {
                comboBoxsube.Properties.Items.Add(dr["sube"]);
            }
        }

        private void txtiban_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void yENİLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler();
        }

        private void lookUpfirma_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void il(object sender, EventArgs e)
        {
            comboBoxilçe.Text = "";
            dtilce = bg.listele("select * from VW_IL_ILCELER where IL='" + comboBoxil.Text + "'");
            comboBoxilçe.Properties.Items.Clear();
            foreach (DataRow dr in dtilce.Rows)
            {

                comboBoxilçe.Properties.Items.Add(dr["ILCE"]);

            }
        }

        private void maskedtarih_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txttür_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
