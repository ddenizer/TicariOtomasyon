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
    public partial class FrmAdmin : Form
    {
        islemler bg = new islemler();
        DataTable dt;
        
        public FrmAdmin()
        {
            InitializeComponent();
        }
        
        


        private void FrmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.Blue;
        }

        
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand giris = new SqlCommand("select * from TBL_ADMIN where KullaniciAd= @kullanici and Sifre=@sifre", sqlbaglantisi.baglan);
            giris.Parameters.AddWithValue("@kullanici", txtkullaniciad.Text);
            giris.Parameters.AddWithValue("@sifre", txtsifre.Text);
            sqlbaglantisi.baglanti_ac();
            SqlDataReader dr = giris.ExecuteReader();
            if(dr.Read())
            {
                islemler.kul_ad = dr["KullaniciAd"].ToString();
                FrmMenü fr = new FrmMenü();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlbaglantisi.baglanti_kapat();
        }
    }
}
