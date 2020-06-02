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
    public partial class frmChooseBatch : Form
    {
        public frmChooseBatch(string matnr)
        {
            InitializeComponent();
            ShowBatchListToCombobox();
            ShowPlannedOrderDetailFromMatnr(matnr);
        }

        public void ShowBatchListToCombobox()
        {
            cboChooseBatch.DataSource = BatchBusiness.GetBatchList();
            cboChooseBatch.DisplayMember = "Charg";
        }

        public void ShowPlannedOrderDetailFromMatnr(string matnr)
        {
            PlannedOrderDetail obj = PlannedOrderDetailBusiness.GetPlannedOrderDetailFromMatnr(matnr);

            txtItemCount.Text = obj.Erfmg.ToString();
            txtItemId.Text = obj.Matnr.ToString();
        }

        private void BtnChooseBatch_Click(object sender, EventArgs e)
        {
            //Neu da ton tai plannedOrderDetail + Batch do thi + them
            //Neu chua co batch do cho plannedOrderDetail do thi add 1 dong moi
            List<PlannedOrderDetail> lstPlannedOrderDetail = PlannedOrderDetailBusiness.GetListPlannedOrderDetail();

            string matnr = txtItemId.Text;
            string charg = (cboChooseBatch.SelectedItem as Batch).Charg;

            PlannedOrderDetail obj = PlannedOrderDetailBusiness.GetPlannedOrderDetailFromMatnr(matnr);

            double plannedOrderDetailCount = Double.Parse(nmItemCount.Value.ToString());

            int count = 0;
            foreach(PlannedOrderDetail item in lstPlannedOrderDetail)
            {
                if (item.Matnr == matnr && item.Charg == charg)
                {
                    count++;
                }
            }

            if(count>0)
            {
                PlannedOrderDetailBusiness.UpdateErfmgForPlannedOrderDetail(plannedOrderDetailCount+obj.Erfmg,matnr, charg);
            }
            else
            {
                obj.Erfmg = plannedOrderDetailCount;
                obj.Charg = charg;
                PlannedOrderDetailBusiness.AddPlannedOrderDetail(obj);
            }


        }
    }
}
