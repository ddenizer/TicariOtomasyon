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
    public partial class frmguncellerehber : Form
    {
        public frmguncellerehber()
        {
            InitializeComponent();
        }

        public string id = "";
        DataTable dt;
        islemler bg = new islemler();
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update TBL_ MUSTERILER set AD= @P1, SOYAD=@P2, TELEFON=@P3, TELEFON=@P4, MAIL=@P5 WHERE ID=@P6 ", sqlbaglantisi.baglan);
            guncelle.Parameters.AddWithValue("@P1", textBox1.Text);
            guncelle.Parameters.AddWithValue("@P2", textBox2.Text);
            guncelle.Parameters.AddWithValue("@P3", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@P4", maskedTextBox2.Text);
            guncelle.Parameters.AddWithValue("@P5", textBox3.Text);
            guncelle.Parameters.AddWithValue("@P6", textBox4.Text);

            sqlbaglantisi.baglanti_ac();
            guncelle.ExecuteNonQuery();
            sqlbaglantisi.baglanti_kapat();

            MessageBox.Show("Bilgiler Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void frmguncellerehber_Load(object sender, EventArgs e)
        {

            dt = bg.listele("select * from TBL_MUSTERILER WHERE ID="+id);
            

            textBox4.DataBindings.Add("Text", dt, "ID");
            textBox1.DataBindings.Add("Text", dt, "MUSTERIAD");
            textBox2.DataBindings.Add("Text", dt, "SOYAD");
            textBox3.DataBindings.Add("Text", dt, "MAIL");
            maskedTextBox1.DataBindings.Add("Text", dt, "TELEFON");
            maskedTextBox2.DataBindings.Add("Text", dt, "TELEFON2");
        }
    }
}
