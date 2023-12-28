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
    public partial class FrmRehber : Form
    {
        DataTable dt, dt2;
        islemler bg = new islemler();
        
        public FrmRehber()
        {
            InitializeComponent();
        }
        void listele()
        {
            dt = bg.listele("Select ID, MUSTERIAD, SOYAD, TELEFON, TELEFON2, MAIL from TBL_MUSTERILER");

            gridControl1.DataSource = dt;

            dt2 = bg.listele("Select ID, FIRMAAD, YETKILISTATU, YETKILIADSOYAD, TELEFON1, TELEFON2, TELEFON3, MAIL, FAX from TBL_FIRMALAR ");
            
            gridControl2.DataSource = dt2;

        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmguncellerehber frm = new frmguncellerehber();
            frm.id = gridView1.GetFocusedRowCellDisplayText("ID").ToString();
            frm.Show();




        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmMail frm = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();

            FrmMail frm2  = new FrmMail();
            DataRow dr2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr2 != null)
            {
                frm2.mail = dr2["MAIL"].ToString();
            }
            frm2.Show();
        }

        private void yENİLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick_1(object sender, EventArgs e)
        {
            FrmFirmaGuncelle frm = new FrmFirmaGuncelle();
            frm.id = gridView2.GetFocusedRowCellDisplayText("ID").ToString();
            frm.Show();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
