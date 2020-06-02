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
    public partial class frmDocumentDetail : Form
    {

        #region Methods
        public frmDocumentDetail(int plnum)
        {
            InitializeComponent();
            ShowInfo(plnum);

            dtgPlannedOrderDetail.Columns[0].HeaderText = "Planned order";
            dtgPlannedOrderDetail.Columns[1].HeaderText = "Mã sản phẩm con";
            dtgPlannedOrderDetail.Columns[2].HeaderText = "Tên sản phẩm con";
            dtgPlannedOrderDetail.Columns[3].HeaderText = "Số lượng";
            dtgPlannedOrderDetail.Columns[4].HeaderText = "Đơn vị tính";
            dtgPlannedOrderDetail.Columns[5].HeaderText = "Plan";
            dtgPlannedOrderDetail.Columns[6].HeaderText = "Kho";
            dtgPlannedOrderDetail.Columns[7].HeaderText = "Số batch";
            dtgPlannedOrderDetail.Columns[8].HeaderText = "Số thứ tự";
        }

        public void ShowInfo(int plnum)
        {
            dtgPlannedOrderDetail.DataSource = PlannedOrderDetailBusiness.GetPlannedOrderDetailFromPlnum(plnum);
            PlannedOrder objPlannedOrder = PlannedOrderBusiness.GetPlannedOrderFromPlnum(plnum);
            txtMaterial.Text = objPlannedOrder.Matnr;
            txtOrderQuantitty.Text = objPlannedOrder.Gsmng.ToString();
            txtDocumentName.Text = objPlannedOrder.Plnum.ToString();
            txtPlannedOrder.Text = objPlannedOrder.Plwrk;
            txtPlant.Text = objPlannedOrder.Lgort;
        }
        #endregion

        #region Events
        private void Label2_Click(object sender, EventArgs e)
        {

        }
        

        #endregion

        private void TxtScanItem_KeyPress(object sender, KeyPressEventArgs e)
        {

            List<String> lstMatnr = new List<string>();

            List<PlannedOrderDetail> lst = PlannedOrderDetailBusiness.GetListPlannedOrderDetail();

            foreach(PlannedOrderDetail item in lst)
            {
                lstMatnr.Add(item.Matnr);
            }

            string matnr = txtScanItem.Text;

            if (e.KeyChar.ToString() == "\r" )
            {
                foreach(String item in lstMatnr)
                {
                    if(matnr == item)
                    {
                        frmChooseBatch f = new frmChooseBatch(matnr);
                        f.ShowDialog();
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
