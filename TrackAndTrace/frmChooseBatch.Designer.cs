namespace TrackAndTrace
{
    partial class frmChooseBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseBatch));
            this.txtMatnr = new System.Windows.Forms.TextBox();
            this.txtMaktx = new System.Windows.Forms.TextBox();
            this.cboChooseBatch = new System.Windows.Forms.ComboBox();
            this.nmItemCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChooseBatch = new System.Windows.Forms.Button();
            this.lblPlnum = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.txtlg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLgpro = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtErfme = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmItemCount)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMatnr
            // 
            this.txtMatnr.BackColor = System.Drawing.Color.White;
            this.txtMatnr.Enabled = false;
            this.txtMatnr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatnr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMatnr.Location = new System.Drawing.Point(12, 26);
            this.txtMatnr.Name = "txtMatnr";
            this.txtMatnr.ReadOnly = true;
            this.txtMatnr.Size = new System.Drawing.Size(255, 31);
            this.txtMatnr.TabIndex = 0;
            // 
            // txtMaktx
            // 
            this.txtMaktx.BackColor = System.Drawing.Color.White;
            this.txtMaktx.Enabled = false;
            this.txtMaktx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaktx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMaktx.Location = new System.Drawing.Point(290, 26);
            this.txtMaktx.Name = "txtMaktx";
            this.txtMaktx.ReadOnly = true;
            this.txtMaktx.Size = new System.Drawing.Size(255, 31);
            this.txtMaktx.TabIndex = 1;
            // 
            // cboChooseBatch
            // 
            this.cboChooseBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.cboChooseBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboChooseBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChooseBatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboChooseBatch.FormattingEnabled = true;
            this.cboChooseBatch.Location = new System.Drawing.Point(12, 97);
            this.cboChooseBatch.Name = "cboChooseBatch";
            this.cboChooseBatch.Size = new System.Drawing.Size(255, 33);
            this.cboChooseBatch.TabIndex = 2;
            // 
            // nmItemCount
            // 
            this.nmItemCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.nmItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmItemCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nmItemCount.Location = new System.Drawing.Point(290, 98);
            this.nmItemCount.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.nmItemCount.Name = "nmItemCount";
            this.nmItemCount.Size = new System.Drawing.Size(255, 31);
            this.nmItemCount.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Batch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(292, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số lượng:";
            // 
            // btnChooseBatch
            // 
            this.btnChooseBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnChooseBatch.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnChooseBatch.FlatAppearance.BorderSize = 2;
            this.btnChooseBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseBatch.ForeColor = System.Drawing.Color.White;
            this.btnChooseBatch.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseBatch.Image")));
            this.btnChooseBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChooseBatch.Location = new System.Drawing.Point(142, 218);
            this.btnChooseBatch.Name = "btnChooseBatch";
            this.btnChooseBatch.Size = new System.Drawing.Size(125, 40);
            this.btnChooseBatch.TabIndex = 6;
            this.btnChooseBatch.Text = "Ok";
            this.btnChooseBatch.UseVisualStyleBackColor = false;
            this.btnChooseBatch.Click += new System.EventHandler(this.BtnChooseBatch_Click);
            // 
            // lblPlnum
            // 
            this.lblPlnum.AutoSize = true;
            this.lblPlnum.Location = new System.Drawing.Point(-1, 308);
            this.lblPlnum.Name = "lblPlnum";
            this.lblPlnum.Size = new System.Drawing.Size(35, 13);
            this.lblPlnum.TabIndex = 7;
            this.lblPlnum.Text = "label3";
            this.lblPlnum.Visible = false;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(-1, 321);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(35, 13);
            this.lblLoai.TabIndex = 8;
            this.lblLoai.Text = "label3";
            this.lblLoai.Visible = false;
            // 
            // txtlg
            // 
            this.txtlg.BackColor = System.Drawing.Color.White;
            this.txtlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlg.Location = new System.Drawing.Point(2, 337);
            this.txtlg.Name = "txtlg";
            this.txtlg.ReadOnly = true;
            this.txtlg.Size = new System.Drawing.Size(10, 31);
            this.txtlg.TabIndex = 9;
            this.txtlg.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Đơn vị:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(292, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Kho:";
            // 
            // cboLgpro
            // 
            this.cboLgpro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.cboLgpro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLgpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLgpro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboLgpro.FormattingEnabled = true;
            this.cboLgpro.Location = new System.Drawing.Point(290, 170);
            this.cboLgpro.Name = "cboLgpro";
            this.cboLgpro.Size = new System.Drawing.Size(255, 33);
            this.cboLgpro.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(290, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // txtErfme
            // 
            this.txtErfme.BackColor = System.Drawing.Color.White;
            this.txtErfme.Enabled = false;
            this.txtErfme.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErfme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtErfme.Location = new System.Drawing.Point(12, 170);
            this.txtErfme.Name = "txtErfme";
            this.txtErfme.ReadOnly = true;
            this.txtErfme.Size = new System.Drawing.Size(255, 31);
            this.txtErfme.TabIndex = 15;
            // 
            // frmChooseBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(557, 273);
            this.Controls.Add(this.txtErfme);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboLgpro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtlg);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.lblPlnum);
            this.Controls.Add(this.btnChooseBatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmItemCount);
            this.Controls.Add(this.cboChooseBatch);
            this.Controls.Add(this.txtMaktx);
            this.Controls.Add(this.txtMatnr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(573, 312);
            this.MinimumSize = new System.Drawing.Size(573, 312);
            this.Name = "frmChooseBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Item";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmChooseBatch_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.nmItemCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatnr;
        private System.Windows.Forms.TextBox txtMaktx;
        private System.Windows.Forms.ComboBox cboChooseBatch;
        private System.Windows.Forms.NumericUpDown nmItemCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseBatch;
        private System.Windows.Forms.Label lblPlnum;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.TextBox txtlg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLgpro;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtErfme;
    }
}