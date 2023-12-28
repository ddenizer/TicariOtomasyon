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
    public partial class FrmFaturaDetaY : Form
    {
        public FrmFaturaDetaY()
        {
            InitializeComponent();
        }
        public string id = "";
        DataTable dt;
        islemler bg = new islemler();

        void listele()
        {
            dt = bg.listele("select * from TBL_FATURADETAY WHERE FATURAURUNID=" + id);
            gridControl1.DataSource = dt;
        }

        private void FrmFaturaDetayGuncelle_Load(object sender, EventArgs e)
        {

            listele();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            FrmDetayGuncelle fr = new FrmDetayGuncelle();
            fr.id = gridView1.GetFocusedRowCellDisplayText("FATURAURUNID").ToString();
            fr.Show();
        }

     
    }
}
