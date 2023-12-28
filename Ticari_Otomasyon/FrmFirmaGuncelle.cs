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
    public partial class FrmFirmaGuncelle : Form
    {
        public FrmFirmaGuncelle()
        {
            InitializeComponent();
        }
        public string id = "";
        DataTable dt;
        islemler bg = new islemler();

        private void FrmFirmaGuncelle_Load(object sender, EventArgs e)
        {
            dt = bg.listele("select * from TBL_FIRMALAR WHERE ID=" + id);

            txtid.DataBindings.Add("Text", dt, "ID");
            txtsirketad.DataBindings.Add("Text", dt, "FIRMAAD");
            txtyetkili.DataBindings.Add("Text", dt, "YETKILISTATU");
            txtadsoyad.DataBindings.Add("Text", dt, "YETKILIADSOYAD");
            maskedtel.DataBindings.Add("Text", dt, "TELEFON1");
            maskedtel2.DataBindings.Add("Text", dt, "TELEFON2");
            maskedtel3.DataBindings.Add("Text", dt, "TELEFON3");
            txtmail.DataBindings.Add("Text", dt, "MAIL");
            maskedfax.DataBindings.Add("Text", dt, "FAX");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_FIRMALAR set FIRMAAD= @P1, YETKILISTATU=@P2, YETKILIADSOYAD=@P3, TELEFON1=@P4, TELEFON2=@P5, TELEFON3=@P6, MAIL=@P7, FAX=@P8 WHERE ID =@P9 ", sqlbaglantisi.baglan);
            guncelle.Parameters.AddWithValue("@P1", txtsirketad.Text);
            guncelle.Parameters.AddWithValue("@P2", txtyetkili.Text);
            guncelle.Parameters.AddWithValue("@P3", txtadsoyad.Text);
            guncelle.Parameters.AddWithValue("@P4", maskedtel.Text);
            guncelle.Parameters.AddWithValue("@P5", maskedtel2.Text);
            guncelle.Parameters.AddWithValue("@P6", maskedtel3.Text);
            guncelle.Parameters.AddWithValue("@P7", txtmail.Text);
            guncelle.Parameters.AddWithValue("@P8", maskedfax.Text);
            guncelle.Parameters.AddWithValue("@P9", txtid.Text);

            sqlbaglantisi.baglanti_ac();
            guncelle.ExecuteNonQuery();
            sqlbaglantisi.baglanti_kapat();

            MessageBox.Show("Bilgiler Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
