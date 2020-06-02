using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackAndTrace.Model;

namespace TrackAndTrace
{
    public partial class frmChooseDocument : Form
    {
        public frmChooseDocument()
        {
            InitializeComponent();
            LoadPlannedOrder();
            dtgPlannedOrder.Columns[0].HeaderText = "Planned Order Number";
            dtgPlannedOrder.Columns[1].HeaderText = "Mã sản phẩm";
            dtgPlannedOrder.Columns[2].HeaderText = "Số lượng";
            dtgPlannedOrder.Columns[3].HeaderText = "Plan";
            dtgPlannedOrder.Columns[4].HeaderText = "Kho";
            dtgPlannedOrder.Columns[5].HeaderText = "Tên sản phẩm";
        }

        public void LoadPlannedOrder()
        {
            dtgPlannedOrder.DataSource = PlannedOrderBusiness.GetListPlannedOrder();
        }

        private void BtnChooseDocument_Click(object sender, EventArgs e)
        {
            int plnum = (int)(dtgPlannedOrder.CurrentRow.Cells[0].Value);

            frmDocumentDetail f = new frmDocumentDetail(plnum);

            this.Hide();

            f.ShowDialog();

            this.Show();
        }

        private void DtgPlannedOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string matnr = "";

            matnr = dtgPlannedOrder.CurrentRow.Cells[0].Value.ToString();

            txtDocument.Text = matnr;
        }
    }
}
