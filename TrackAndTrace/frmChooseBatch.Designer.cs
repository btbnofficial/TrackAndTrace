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
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.cboChooseBatch = new System.Windows.Forms.ComboBox();
            this.nmItemCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChooseBatch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmItemCount)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemId
            // 
            this.txtItemId.BackColor = System.Drawing.Color.White;
            this.txtItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemId.Location = new System.Drawing.Point(12, 26);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.ReadOnly = true;
            this.txtItemId.Size = new System.Drawing.Size(206, 31);
            this.txtItemId.TabIndex = 0;
            // 
            // txtItemCount
            // 
            this.txtItemCount.BackColor = System.Drawing.Color.White;
            this.txtItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCount.Location = new System.Drawing.Point(224, 26);
            this.txtItemCount.Name = "txtItemCount";
            this.txtItemCount.ReadOnly = true;
            this.txtItemCount.Size = new System.Drawing.Size(296, 31);
            this.txtItemCount.TabIndex = 1;
            // 
            // cboChooseBatch
            // 
            this.cboChooseBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChooseBatch.ForeColor = System.Drawing.Color.Teal;
            this.cboChooseBatch.FormattingEnabled = true;
            this.cboChooseBatch.Location = new System.Drawing.Point(14, 131);
            this.cboChooseBatch.Name = "cboChooseBatch";
            this.cboChooseBatch.Size = new System.Drawing.Size(204, 33);
            this.cboChooseBatch.TabIndex = 2;
            // 
            // nmItemCount
            // 
            this.nmItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmItemCount.ForeColor = System.Drawing.Color.Teal;
            this.nmItemCount.Location = new System.Drawing.Point(224, 131);
            this.nmItemCount.Name = "nmItemCount";
            this.nmItemCount.Size = new System.Drawing.Size(296, 35);
            this.nmItemCount.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Batch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(219, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số lượng:";
            // 
            // btnChooseBatch
            // 
            this.btnChooseBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChooseBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseBatch.ForeColor = System.Drawing.Color.Teal;
            this.btnChooseBatch.Location = new System.Drawing.Point(237, 211);
            this.btnChooseBatch.Name = "btnChooseBatch";
            this.btnChooseBatch.Size = new System.Drawing.Size(57, 37);
            this.btnChooseBatch.TabIndex = 6;
            this.btnChooseBatch.Text = "Ok";
            this.btnChooseBatch.UseVisualStyleBackColor = false;
            this.btnChooseBatch.Click += new System.EventHandler(this.BtnChooseBatch_Click);
            // 
            // frmChooseBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 277);
            this.Controls.Add(this.btnChooseBatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmItemCount);
            this.Controls.Add(this.cboChooseBatch);
            this.Controls.Add(this.txtItemCount);
            this.Controls.Add(this.txtItemId);
            this.Name = "frmChooseBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChooseProduct";
            ((System.ComponentModel.ISupportInitialize)(this.nmItemCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.TextBox txtItemCount;
        private System.Windows.Forms.ComboBox cboChooseBatch;
        private System.Windows.Forms.NumericUpDown nmItemCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseBatch;
    }
}