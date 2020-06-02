namespace TrackAndTrace
{
    partial class frmChooseDocument
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocument = new System.Windows.Forms.TextBox();
            this.btnChooseDocument = new System.Windows.Forms.Button();
            this.dtgPlannedOrder = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlannedOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDocument);
            this.panel1.Controls.Add(this.btnChooseDocument);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 141);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(38, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Document:";
            // 
            // txtDocument
            // 
            this.txtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocument.Location = new System.Drawing.Point(140, 61);
            this.txtDocument.Name = "txtDocument";
            this.txtDocument.Size = new System.Drawing.Size(244, 26);
            this.txtDocument.TabIndex = 6;
            // 
            // btnChooseDocument
            // 
            this.btnChooseDocument.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnChooseDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChooseDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseDocument.ForeColor = System.Drawing.Color.Teal;
            this.btnChooseDocument.Location = new System.Drawing.Point(390, 61);
            this.btnChooseDocument.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btnChooseDocument.Name = "btnChooseDocument";
            this.btnChooseDocument.Size = new System.Drawing.Size(75, 26);
            this.btnChooseDocument.TabIndex = 5;
            this.btnChooseDocument.Text = "Ok";
            this.btnChooseDocument.UseVisualStyleBackColor = false;
            this.btnChooseDocument.Click += new System.EventHandler(this.BtnChooseDocument_Click);
            // 
            // dtgPlannedOrder
            // 
            this.dtgPlannedOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlannedOrder.BackgroundColor = System.Drawing.Color.White;
            this.dtgPlannedOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlannedOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPlannedOrder.Location = new System.Drawing.Point(0, 141);
            this.dtgPlannedOrder.Name = "dtgPlannedOrder";
            this.dtgPlannedOrder.Size = new System.Drawing.Size(517, 283);
            this.dtgPlannedOrder.TabIndex = 6;
            this.dtgPlannedOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgPlannedOrder_CellClick);
            // 
            // frmChooseDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 424);
            this.Controls.Add(this.dtgPlannedOrder);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmChooseDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChooseDocument";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlannedOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocument;
        private System.Windows.Forms.Button btnChooseDocument;
        private System.Windows.Forms.DataGridView dtgPlannedOrder;
    }
}