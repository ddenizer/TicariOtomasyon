
namespace Ticari_Otomasyon
{
    partial class FrmMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMail));
            this.TXTM = new System.Windows.Forms.TextBox();
            this.TXTK = new System.Windows.Forms.TextBox();
            this.txtmail = new System.Windows.Forms.Label();
            this.txtkonu = new System.Windows.Forms.Label();
            this.txtmesaj = new System.Windows.Forms.Label();
            this.TXTMSJ = new System.Windows.Forms.RichTextBox();
            this.BtnGönder = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TXTM
            // 
            this.TXTM.Location = new System.Drawing.Point(143, 141);
            this.TXTM.Name = "TXTM";
            this.TXTM.Size = new System.Drawing.Size(304, 27);
            this.TXTM.TabIndex = 0;
            this.TXTM.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // TXTK
            // 
            this.TXTK.Location = new System.Drawing.Point(143, 196);
            this.TXTK.Name = "TXTK";
            this.TXTK.Size = new System.Drawing.Size(304, 27);
            this.TXTK.TabIndex = 1;
            // 
            // txtmail
            // 
            this.txtmail.AutoSize = true;
            this.txtmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtmail.Location = new System.Drawing.Point(12, 149);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(106, 19);
            this.txtmail.TabIndex = 2;
            this.txtmail.Text = "Mail Adresi:";
            // 
            // txtkonu
            // 
            this.txtkonu.AutoSize = true;
            this.txtkonu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkonu.Location = new System.Drawing.Point(34, 204);
            this.txtkonu.Name = "txtkonu";
            this.txtkonu.Size = new System.Drawing.Size(56, 19);
            this.txtkonu.TabIndex = 3;
            this.txtkonu.Text = "Konu:";
            this.txtkonu.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtmesaj
            // 
            this.txtmesaj.AutoSize = true;
            this.txtmesaj.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtmesaj.Location = new System.Drawing.Point(27, 299);
            this.txtmesaj.Name = "txtmesaj";
            this.txtmesaj.Size = new System.Drawing.Size(63, 19);
            this.txtmesaj.TabIndex = 4;
            this.txtmesaj.Text = "Mesaj:";
            // 
            // TXTMSJ
            // 
            this.TXTMSJ.Location = new System.Drawing.Point(143, 250);
            this.TXTMSJ.Name = "TXTMSJ";
            this.TXTMSJ.Size = new System.Drawing.Size(304, 218);
            this.TXTMSJ.TabIndex = 5;
            this.TXTMSJ.Text = "";
            // 
            // BtnGönder
            // 
            this.BtnGönder.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGönder.Appearance.Options.UseFont = true;
            this.BtnGönder.ImageOptions.Image = global::Ticari_Otomasyon.Properties.Resources.send_32x321;
            this.BtnGönder.Location = new System.Drawing.Point(179, 485);
            this.BtnGönder.Name = "BtnGönder";
            this.BtnGönder.Size = new System.Drawing.Size(216, 40);
            this.BtnGönder.TabIndex = 7;
            this.BtnGönder.Text = "GÖNDER";
            this.BtnGönder.Click += new System.EventHandler(this.BtnGönder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mail Gönderme Paneli:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 103);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // FrmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 538);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.BtnGönder);
            this.Controls.Add(this.TXTMSJ);
            this.Controls.Add(this.txtmesaj);
            this.Controls.Add(this.txtkonu);
            this.Controls.Add(this.txtmail);
            this.Controls.Add(this.TXTK);
            this.Controls.Add(this.TXTM);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAİL GÖNDER";
            this.Load += new System.EventHandler(this.FrmMail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTM;
        private System.Windows.Forms.TextBox TXTK;
        private System.Windows.Forms.Label txtmail;
        private System.Windows.Forms.Label txtkonu;
        private System.Windows.Forms.Label txtmesaj;
        private System.Windows.Forms.RichTextBox TXTMSJ;
        private DevExpress.XtraEditors.SimpleButton BtnGönder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}