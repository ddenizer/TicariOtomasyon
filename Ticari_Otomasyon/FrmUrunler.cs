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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        DataTable dt;
        islemler bg = new islemler();
        //SQL Bağlama
        void listele()
        {
            dt = bg.listele("Select * From TBL_URUNLER");


            gridControl1.DataSource = dt;


        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericChartRangeControlClient1_CustomizeSeries(object sender, DevExpress.XtraEditors.ClientDataSourceProviderCustomizeSeriesEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit8_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit7_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
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

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            txtid.DataBindings.Add("Text", dt, "ID");
            txtad.DataBindings.Add("Text", dt, "URUNAD");
            txtmarka.DataBindings.Add("Text", dt, "MARKA");
            txtmodel.DataBindings.Add("Text", dt, "MODEL");
            maskedyıl.DataBindings.Add("Text", dt, "YIL");
            numericadet.DataBindings.Add("Text", dt, "YIL");
            txtalış.DataBindings.Add("Text", dt, "ALISFIYAT");
            txtsatış.DataBindings.Add("Text", dt, "SATISFIYAT");
            richtxtdetay.DataBindings.Add("Text", dt, "DETAY");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //Verileri Kaydetme
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD, MARKA, MODEL, YIL, ADET, ALISFIYAT, SATISFIYAT, DETAY) " +
                "values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", sqlbaglantisi.baglan);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtmarka.Text);
            komut.Parameters.AddWithValue("@p3", txtmodel.Text);
            komut.Parameters.AddWithValue("@p4", maskedyıl.Text);
            komut.Parameters.AddWithValue("@p5", numericadet.Value.ToString());
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtalış.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtsatış.Text));
            komut.Parameters.AddWithValue("@p8", richtxtdetay.Text);
            sqlbaglantisi.baglanti_ac();
            komut.ExecuteNonQuery();

            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
            listele();

        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Veri satırı sınıfından bir tane nesne türetip bu nesneye görev atama 
            //görev= gridview satırının verisini al
            //hangi satırın ındex olduğunu yaz

            //1.YOL
            //DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //txtid.Text = dr["ID"].ToString();
            //txtad.Text = dr["URUNAD"].ToString();
            //txtmarka.Text = dr["MARKA"].ToString();
            //txtmodel.Text = dr["MODEL"].ToString();
            //maskedyıl.Text = dr["YIL"].ToString();
            //numericadet.Value = decimal.Parse(dr["ADET"].ToString());
            //txtalış.Text = dr["ALISFIYAT"].ToString();
            //txtsatış.Text = dr["SATISFIYAT"].ToString();
            //richtxtdetay.Text = dr["DETAY"].ToString();

            //2.YOL
            //txtad.Text = gridView1.GetFocusedRowCellDisplayText("URUNAD");




        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set URUNAD=@P1, MARKA=@P2, MODEL=@P3, YIL=@P4, ADET=@P5, ALISFIYAT=@P6, SATISFIYAT=@P7, DETAY=@P8 where ID=@P9 ", sqlbaglantisi.baglan);
            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtmarka.Text);
            komut.Parameters.AddWithValue("@P3", txtmodel.Text);
            komut.Parameters.AddWithValue("@P4", maskedyıl.Text);
            komut.Parameters.AddWithValue("@P5", int.Parse((numericadet.Value).ToString()));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(txtalış.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(txtsatış.Text));
            komut.Parameters.AddWithValue("@P8", richtxtdetay.Text);
            komut.Parameters.AddWithValue("@P9", txtid.Text);



            sqlbaglantisi.baglanti_ac();
            komut.ExecuteNonQuery();
            sqlbaglantisi.baglanti_kapat();


            MessageBox.Show("Ürün Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
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
                SqlCommand komutsil = new SqlCommand("Delete from TBL_URUNLER where ID = @p1", sqlbaglantisi.baglan);
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);


                sqlbaglantisi.baglanti_ac();
                komutsil.ExecuteNonQuery();
                sqlbaglantisi.baglanti_kapat();


                MessageBox.Show("Ürün Silndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
            else
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtad.Text = " ";
            txtmarka.Text = " ";
            txtmodel.Text = " ";
            maskedyıl.Text = " ";
            richtxtdetay.Text = " ";
            txtalış.Text = " ";
            txtsatış.Text = " ";
            numericadet.Text = " ";

        }
    }
}
