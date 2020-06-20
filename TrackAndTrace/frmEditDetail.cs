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
    public partial class frmEditDetail : Form
    {
        public frmEditDetail(int plnum, string matnr, int posnr, string lgort, string bacht)
        {
            InitializeComponent();
            ShowDetail(plnum, matnr, posnr, lgort, bacht);
            this.AcceptButton = btnUpdateDetail;
            this.CancelButton = btnCancel;
        }

        #region Methods
        private void ShowDetail(int plnum, string matnr, int posnr, string lgort, string batch)
        {
            Detail objDetail = DetailBusiness.GetDetail(plnum, matnr, posnr);

            List<String> lstLgpro = new List<String>();
            lstLgpro.Add("BULK");
            lstLgpro.Add("FGWH");
            lstLgpro.Add("RMSA");
            cboLgpro.DataSource = lstLgpro;
            //cboLgpro.DropDownStyle = ComboBoxStyle.DropDownList;

            txtPlnum.Text = plnum.ToString();
            txtMatnr.Text = matnr;
            txtMaktx.Text = objDetail.maktx;
            nmCount.Value = decimal.Parse(objDetail.count.ToString());
            lblPosnr.Text = objDetail.posnr.ToString();

            nmCount.DecimalPlaces = 3;
            nmCount.Increment = 0.001M;

            cboCharg.DataSource = BatchBusiness.GetBatchList2(plnum.ToString(), matnr);
            //cboCharg.DisplayMember = "Charg";
            //cboCharg.ValueMember = "Charg";
            //cboCharg.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach(string item in lstLgpro)
            {
                if(item == objDetail.lgpro)
                {
                    cboLgpro.SelectedItem = item;
                }
            }

            try
            {
                if (batch != null || batch != "")
                {
                    cboCharg.SelectedValue = batch;
                }
            }
            catch(Exception ex)
            {
                batch = "";
            }
        }

        private void EditDetail()
        {
            //2 trường hợp:
            //Nếu thay đổi mà trùng charg và trùng erfmg thì báo là đã tồn tại 1 detail như thế
            //Còn không thì thay đổi hàng này
            #region lấy thông tin của Detail cần sửa
            double count = (double)nmCount.Value;
            int plnum = int.Parse(txtPlnum.Text);
            string matnr = txtMatnr.Text;
            string charg = "";
            int posnr = int.Parse(lblPosnr.Text);
            List<string> lstBatch = BatchBusiness.GetBatchList2(plnum.ToString(),matnr);
            if (lstBatch.Count == 0)
            {
                if (!String.IsNullOrEmpty(cboCharg.Text))
                {
                    MessageBox.Show("Không tồn tại batch tương ứng với Planned Order Detail này!", "Thông báo!");
                    return;
                }
                else
                {
                    charg = "";
                }
            }
            else
            {
                if (String.IsNullOrEmpty(cboCharg.Text))
                {
                    charg = "";
                }
                else
                {
                    int i = 0;
                    foreach (string item in lstBatch)
                    {
                        if (item == cboCharg.Text)
                        {
                            i++;
                        }
                    }

                    if (i == 0)
                    {
                        MessageBox.Show("Không tồn tại batch tương ứng với Planned Order Detail này!", "Thông báo!");
                        return;
                    }
                    else
                    {
                        charg = cboCharg.Text;
                    }

                }
            }
            string lgpro = cboLgpro.SelectedItem.ToString();
            Detail oldDetail = DetailBusiness.GetDetail(plnum, matnr, posnr);
            Detail newDetail = DetailBusiness.GetDetail(matnr, plnum, lgpro, charg);
            #endregion
            if (count == 0)
            {
                MessageBox.Show("So luong khong duoc bang 0!", "Thong bao!");
                return;
            }
            else
            {
                /*Lấy ra 1 list các Detail trong danh sách có plnum, matnr, lgpro, charg có trong
                 * gridview trùng với objDetail sắp được sửa ra
                 */
                #region layListDetailTrongGridViewGiongVoiNewDetail
                string query = "select * from dbo.PlannedOrderDetail where status = 1 and plnum = " + plnum + "" +
                    " and matnr = '" + matnr + "' and lgpro = '" + lgpro + "' and charg = '" + charg + "'";

                DataTable dt = DataProvider.GetList(query, null, false);
                List<Detail> lstDetailNew = new List<Detail>();
                foreach (DataRow row in dt.Rows)
                {
                    Detail obj = new Detail(row);
                    lstDetailNew.Add(obj);
                }
                #endregion

                #region layListDetailKhongCoTrongGridViewGiongVoiNewDetail
                //lấy 1 list các Detail không có trong gridview
                string query1 = "select * from dbo.PlannedOrderDetail where status = 0 and plnum = " + plnum + "" +
                    " and matnr = '" + matnr + "' and lgpro = '" + lgpro + "' and charg = '" + charg + "'";

                DataTable dt1 = DataProvider.GetList(query1, null, false);
                List<Detail> lstDetailOld = new List<Detail>();
                foreach (DataRow row in dt1.Rows)
                {
                    Detail obj = new Detail(row);
                    lstDetailOld.Add(obj);
                }
                #endregion

                if (newDetail.lgpro == oldDetail.lgpro && newDetail.charg == oldDetail.charg)
                {
                    DetailBusiness.UpdateDetail(plnum, matnr, count, lgpro, charg, posnr);
                    this.Close();
                }
                else
                {
                    if ((lstDetailNew.Count > 0 && newDetail.lgpro != oldDetail.lgpro && newDetail.charg == oldDetail.charg) || (lstDetailNew.Count > 0 && newDetail.lgpro == oldDetail.lgpro && newDetail.charg != oldDetail.charg) || (lstDetailNew.Count > 0 && newDetail.lgpro != oldDetail.lgpro && newDetail.charg != oldDetail.charg))
                    {
                        MessageBox.Show("Đã tồn tại một item có cùng kho và số batch!", "Thông báo!");
                    }
                    else if (lstDetailOld.Count > 0)
                    {
                        //Xoa OldDetail cần sửa
                        string query2 = "delete from PlannedOrderDetail where plnum = " + plnum + " and matnr = '" + matnr + "' and posnr = " + posnr;
                        //Cap nhat Detail bi trung trong list DetailOld
                        DataProvider.Execute(query2, null, false);
                        string query3 = "update dbo.PlannedOrderDetail set count = " + count + ", status = 1, posnr = " + posnr + " where plnum = " + plnum + " and matnr = '" + matnr + "' and lgpro = '" + lgpro + "' and charg = '" + charg + "'";
                        DataProvider.Execute(query3, null, false);
                        this.Close();
                    }
                    else
                    {
                        DetailBusiness.UpdateDetail(plnum, matnr, count, lgpro, charg, posnr);
                        this.Close();
                    }
                }

                //Nếu lstDetailNew có nhiều hơn 0 phần tử chứng tỏ đã bị trùng với một Detail khác trong gridview
                //if ((lstDetailNew.Count > 0 && newDetail.lgpro != oldDetail.lgpro && newDetail.charg == oldDetail.charg) ||(lstDetailNew.Count > 0 && newDetail.lgpro == oldDetail.lgpro && newDetail.charg != oldDetail.charg) ||(lstDetailNew.Count > 0 && newDetail.lgpro != oldDetail.lgpro && newDetail.charg != oldDetail.charg))
                //{
                //    MessageBox.Show("Đã tồn tại một item có cùng kho và số batch!", "Thông báo!");
                //}
                //else
                //{
                //    if (lstDetailOld.Count > 0)
                //    {
                //        //Xoa OldDetail cần sửa
                //        string query2 = "delete from PlannedOrderDetail where plnum = "+plnum+" and matnr = '"+matnr+"' and posnr = "+posnr;
                //        //Cap nhat Detail bi trung trong list DetailOld
                //        DataProvider.Execute(query2, null, false);
                //        string query3 = "update dbo.PlannedOrderDetail set count = " + count + ", status = 1, posnr = "+posnr+" where plnum = " + plnum + " and matnr = '" + matnr + "' and lgpro = '" + lgpro + "' and charg = '" + charg + "' and status = 0";
                //        DataProvider.Execute(query3, null, false);
                //    }
                //    else
                //    {
                //        DetailBusiness.UpdateDetail(plnum, matnr, count, lgpro, charg, posnr);
                //    }
                //    this.Close();
                //}
            }
        }
        #endregion

        #region events
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdateDetail_Click(object sender, EventArgs e)
        {
            EditDetail();
        }
        #endregion
        private void Label5_Click(object sender, EventArgs e)
        {

        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        
    }
}
