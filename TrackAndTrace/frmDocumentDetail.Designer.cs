namespace TrackAndTrace
{
    partial class frmDocumentDetail
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtScanItem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDocumentName = new System.Windows.Forms.TextBox();
            this.txtOrderQuantitty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlannedOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgPlannedOrderDetail = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlannedOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnPost);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 546);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 58);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Location = new System.Drawing.Point(820, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 200, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save Draft";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Teal;
            this.btnCancel.Location = new System.Drawing.Point(997, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnPost
            // 
            this.btnPost.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPost.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.ForeColor = System.Drawing.Color.Teal;
            this.btnPost.Location = new System.Drawing.Point(637, 11);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(95, 35);
            this.btnPost.TabIndex = 4;
            this.btnPost.Text = "POST GL";
            this.btnPost.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtScanItem);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtDocumentName);
            this.panel3.Controls.Add(this.txtOrderQuantitty);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtMaterial);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtPlant);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtPlannedOrder);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1108, 178);
            this.panel3.TabIndex = 2;
            // 
            // txtScanItem
            // 
            this.txtScanItem.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtScanItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScanItem.ForeColor = System.Drawing.Color.Teal;
            this.txtScanItem.Location = new System.Drawing.Point(942, 116);
            this.txtScanItem.Name = "txtScanItem";
            this.txtScanItem.Size = new System.Drawing.Size(155, 40);
            this.txtScanItem.TabIndex = 19;
            this.txtScanItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtScanItem_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(782, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 33);
            this.label5.TabIndex = 18;
            this.label5.Text = "Scan Item:";
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtDocumentName.BackColor = System.Drawing.Color.White;
            this.txtDocumentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentName.ForeColor = System.Drawing.Color.Teal;
            this.txtDocumentName.Location = new System.Drawing.Point(942, 23);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.ReadOnly = true;
            this.txtDocumentName.Size = new System.Drawing.Size(155, 26);
            this.txtDocumentName.TabIndex = 17;
            // 
            // txtOrderQuantitty
            // 
            this.txtOrderQuantitty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtOrderQuantitty.BackColor = System.Drawing.Color.White;
            this.txtOrderQuantitty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderQuantitty.ForeColor = System.Drawing.Color.Teal;
            this.txtOrderQuantitty.Location = new System.Drawing.Point(708, 63);
            this.txtOrderQuantitty.Name = "txtOrderQuantitty";
            this.txtOrderQuantitty.ReadOnly = true;
            this.txtOrderQuantitty.Size = new System.Drawing.Size(155, 26);
            this.txtOrderQuantitty.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(586, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Order Quantity:";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtMaterial.BackColor = System.Drawing.Color.White;
            this.txtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterial.ForeColor = System.Drawing.Color.Teal;
            this.txtMaterial.Location = new System.Drawing.Point(708, 23);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(155, 26);
            this.txtMaterial.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(633, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Material:";
            // 
            // txtPlant
            // 
            this.txtPlant.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPlant.BackColor = System.Drawing.Color.White;
            this.txtPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlant.ForeColor = System.Drawing.Color.Teal;
            this.txtPlant.Location = new System.Drawing.Point(449, 66);
            this.txtPlant.Name = "txtPlant";
            this.txtPlant.ReadOnly = true;
            this.txtPlant.Size = new System.Drawing.Size(135, 26);
            this.txtPlant.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(375, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Plan:";
            // 
            // txtPlannedOrder
            // 
            this.txtPlannedOrder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPlannedOrder.BackColor = System.Drawing.Color.White;
            this.txtPlannedOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlannedOrder.ForeColor = System.Drawing.Color.Teal;
            this.txtPlannedOrder.Location = new System.Drawing.Point(449, 23);
            this.txtPlannedOrder.Name = "txtPlannedOrder";
            this.txtPlannedOrder.ReadOnly = true;
            this.txtPlannedOrder.Size = new System.Drawing.Size(135, 26);
            this.txtPlannedOrder.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(328, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Planned Order:";
            // 
            // dtgPlannedOrderDetail
            // 
            this.dtgPlannedOrderDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlannedOrderDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgPlannedOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlannedOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPlannedOrderDetail.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dtgPlannedOrderDetail.Location = new System.Drawing.Point(0, 178);
            this.dtgPlannedOrderDetail.Name = "dtgPlannedOrderDetail";
            this.dtgPlannedOrderDetail.Size = new System.Drawing.Size(1108, 368);
            this.dtgPlannedOrderDetail.TabIndex = 10;
            // 
            // frmDocumentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 604);
            this.Controls.Add(this.dtgPlannedOrderDetail);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "frmDocumentDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDocumentDetail";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlannedOrderDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtDocumentName;
        private System.Windows.Forms.TextBox txtOrderQuantitty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlannedOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgPlannedOrderDetail;
        private System.Windows.Forms.TextBox txtScanItem;
        private System.Windows.Forms.Label label5;
    }
}