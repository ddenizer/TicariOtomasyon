using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmHareketler : Form
    {
        DataTable dt, dt2;
        islemler bg = new islemler();
        string sorgu = "";
        string sorgu2 = "";

        void listele()
        {
            sorgu = @"select * from VW_MUSTERIHAREKET";
            dt = bg.listele(sorgu);


            gridControl1.DataSource = dt;

            sorgu2 = @"select * from VW_FIRMAHAREKET";
            dt2 = bg.listele(sorgu2);

            gridControl2.DataSource = dt2;


        }

        public FrmHareketler()
        {
            InitializeComponent();
        }

        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
