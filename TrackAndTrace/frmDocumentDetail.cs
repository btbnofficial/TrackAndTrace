using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        public frmDocumentDetail(int plnum, string account)
        {
            InitializeComponent();
            ShowInfo(plnum);
            WindowState = FormWindowState.Maximized;
            lblAccount.Text = account;
            dtgPlannedOrderDetail.ReadOnly = true;
            this.CancelButton = btnCancel;
        }

        #region Methods

        public void ShowInfo(int plnum)
        {
            dtgPlannedOrderDetail.DataSource = DetailBusiness.GetListDetailFromPlnum(plnum);
            Plannde objPlannedOrder = PlanndeBusiness.GetPlannde(plnum);
            txtMaterial.Text = objPlannedOrder.matnr;
            txtOrderQuantitty.Text = objPlannedOrder.gsmng.ToString();
            txtDocumentName.Text = objPlannedOrder.maktx.ToString();
            txtPlanNumber.Text = objPlannedOrder.plnum.ToString();//
            txtStog.Text = objPlannedOrder.lgort;
            //dtgPlannedOrderDetail.Columns["plnum"].DisplayIndex = 0;
            //dtgPlannedOrderDetail.Columns["matnr"].DisplayIndex = 1;
            //dtgPlannedOrderDetail.Columns["maktx"].DisplayIndex = 2;
            //dtgPlannedOrderDetail.Columns["erfmg"].DisplayIndex = 3;
            //dtgPlannedOrderDetail.Columns["count"].DisplayIndex = 4;
            //dtgPlannedOrderDetail.Columns["erfme"].DisplayIndex = 5;
            //dtgPlannedOrderDetail.Columns["plwrk"].DisplayIndex = 6;
            //dtgPlannedOrderDetail.Columns["lgpro"].DisplayIndex = 7;
            //dtgPlannedOrderDetail.Columns["charg"].DisplayIndex = 8;
            //dtgPlannedOrderDetail.Columns["posnr"].DisplayIndex = 9;

            dtgPlannedOrderDetail.Columns["plnum"].HeaderText = "Planned order";
            dtgPlannedOrderDetail.Columns["plnum"].Visible = false;
            dtgPlannedOrderDetail.Columns[1].HeaderText = "Mã sản phẩm con";
            dtgPlannedOrderDetail.Columns[2].HeaderText = "Tên sản phẩm con";
            dtgPlannedOrderDetail.Columns[3].HeaderText = "Số lượng ban đầu";
            dtgPlannedOrderDetail.Columns[4].HeaderText = "SỐ LƯỢNG THỰC TẾ";
            dtgPlannedOrderDetail.Columns[5].HeaderText = "Đơn vị tính";
            dtgPlannedOrderDetail.Columns[6].HeaderText = "Plant";
            dtgPlannedOrderDetail.Columns[7].HeaderText = "Kho";
            dtgPlannedOrderDetail.Columns[8].HeaderText = "Số batch";
            dtgPlannedOrderDetail.Columns[9].HeaderText = "Số thứ tự";
            dtgPlannedOrderDetail.Columns["dateCreated"].Visible = false;
            dtgPlannedOrderDetail.Columns["dateEdited"].Visible = false;
            dtgPlannedOrderDetail.Columns["status"].Visible = false;

        }

        private void EditRow()
        {
            int plnum = int.Parse(dtgPlannedOrderDetail.CurrentRow.Cells[0].Value.ToString());
            string matnr = "" + dtgPlannedOrderDetail.CurrentRow.Cells[1].Value;
            int posnr = (int)dtgPlannedOrderDetail.CurrentRow.Cells["posnr"].Value;
            string lgort = txtStog.Text;
            string bacht = "" + dtgPlannedOrderDetail.CurrentRow.Cells["charg"].Value;

            frmEditDetail f = new frmEditDetail(plnum, matnr, posnr, lgort, bacht);
            f.ShowDialog();
            ShowInfo(plnum);
        }

        private void DeleteRow()
        {
            DialogResult dr = MessageBox.Show("Bạn có chắn chắn muốn xóa dòng này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int plnum = int.Parse(dtgPlannedOrderDetail.CurrentRow.Cells[0].Value.ToString());
                string matnr = "" + dtgPlannedOrderDetail.CurrentRow.Cells[1].Value;
                int posnr = int.Parse(dtgPlannedOrderDetail.CurrentRow.Cells[9].Value.ToString());

                bool ketQua = DetailBusiness.DeleteDetail(plnum, matnr, posnr);

                if (ketQua)
                {
                    ShowInfo(plnum);
                }
            }
        }
        #endregion

        #region Events

        //Nhấn Enter để thêm batch mới
        private void TxtScanItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                string matnr = txtScanItem.Text;
                int plnum = int.Parse(txtPlanNumber.Text);
                txtScanItem.Clear();

                try
                {
                    string query = "select * from PlannedOrderDetail where plnum = " + txtPlanNumber.Text + " and matnr = '" + matnr + "'";
                    DataTable dt = DataProvider.GetList(query, null, false);
                    List<Itemcode> lstItem = ItemCodeBusiness.GetITemList(matnr);
                    //list kiểm tra các Detail có sẵn trong listDetail của plan 
                    List<Detail> lstDetailCheck = new List<Detail>();

                    foreach (DataRow row in dt.Rows)
                    {
                        Detail objDetail = new Detail();
                        objDetail.plnum = row["plnum"].ToString();
                        objDetail.matnr = row["matnr"].ToString();
                        objDetail.maktx = row["maktx"].ToString();
                        objDetail.erfmg = double.Parse(row["erfmg"].ToString());
                        objDetail.count = double.Parse(row["count"].ToString());
                        objDetail.erfme = row["erfme"].ToString();
                        objDetail.plwrk = row["plwrk"].ToString();
                        objDetail.lgpro = row["lgpro"].ToString();
                        objDetail.charg = row["charg"].ToString();
                        objDetail.posnr = int.Parse(row["posnr"].ToString());
                        objDetail.dateCreated = DateTime.Parse(row["dateCreated"].ToString());
                        objDetail.dateEdited = DateTime.Parse(row["dateEdited"].ToString());
                        objDetail.status = Boolean.Parse(row["status"].ToString());

                        lstDetailCheck.Add(objDetail);
                    }

                    //k tồn tại item cần tìm trên api
                    if (lstItem.Count == 0)
                    {
                        txtScanItem.BackColor = Color.OrangeRed;
                        MessageBox.Show("Không tồn tại Item mà bạn vừa nhập!", "Thông báo!");
                        txtScanItem.BackColor = Color.White;

                    }
                    //đã tồn tại item này trên api
                    else
                    {
                        #region code Cũ
                        //kiểm tra nó đã tồn tại trong lstPlanDetail của Plan hay chưa
                        //List<Detail> lstDetail = DetailBusiness.GetListDetailFromPlnum(plnum);
                        //int count = 0;
                        //foreach(Detail item in lstDetail)
                        //{
                        //    if(item.matnr==matnr)
                        //    {
                        //        count++;
                        //    }
                        //}
                        //Nếu chưa tồn tại item này trong lstDetail
                        #endregion
                        if (lstDetailCheck.Count == 0)
                        {
                            txtScanItem.BackColor = Color.OrangeRed;
                            MessageBox.Show("Item này không tồn tại trong planned order này!", "Thông báo!");
                            txtScanItem.BackColor = Color.White;
                        }
                        //Nếu đã tồn tại: lstDetailCheck > 0
                        else
                        {
                            txtScanItem.BackColor = Color.Cyan;
                            frmChooseBatch f1 = new frmChooseBatch(matnr, txtStog.Text, 0, plnum, txtStog.Text);
                            f1.ShowDialog();
                            txtScanItem.BackColor = Color.White;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                    MessageBox.Show(ex.Message, "Thông báo");
                    return;
                }
                ShowInfo(plnum);
                #region code cũ
                /*
                Detail objDetail = DetailBusiness.GetPlannedOrderDetailFromMatnr(matnr);
                    if (objDetail.plnum == null)
                    {
                        if (MessageBox.Show("Không tìm thấy SP ở Planned Order này, bạn có muốn tiếp tục không", "Thông báo!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)  
                        {
                            frmChooseBatch f = new frmChooseBatch(matnr, txtStog.Text, 1);
                            f.ShowDialog();
                        };
                    }
                    else
                    {
                        List<Detail> lstPlannedOrderDetail = DetailBusiness.GetListPlannedOrderDetail(plnum);
                        int count = 0;
                        foreach (Detail item in lstPlannedOrderDetail)
                        {
                            if(item.matnr == matnr)
                            {
                                count++;
                            }
                        }
                        if(count==0)
                        {
                            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thong bao!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                            {
                                //Thêm mới một Detail
                            }
                        }
                        else
                        {
                            frmChooseBatch f = new frmChooseBatch(matnr, txtStog.Text,0);
                            f.ShowDialog();
                        }
                    } 
             */

                //
                //int plnum = int.Parse(PlannedOrderDetailBusiness.GetPlannedOrderDetailFromMatnr(matnr).plnum.ToString());
                //List<Detail> lstDistincPlannedOrderDetail = new List<Detail>();
                //int count = 0;
                //foreach (Detail item in lstPlannedOrderDetail)
                //{
                //    foreach (Detail item1 in lstPlannedOrderDetail)
                //    {
                //        if (item1.matnr == item.matnr)
                //        {
                //            count++;
                //            if (count == 1)
                //            {
                //                lstDistincPlannedOrderDetail.Add(item1);
                //            }
                //        }
                //    }
                //}
                //count = 0;
                //foreach (Detail item in lstDistincPlannedOrderDetail)
                //{
                //    if (item.matnr == matnr)
                //    {

                //    }
                //    else
                //    {
                //        //MessageBoxButtons.YesNo
                //    }
                //}
                //ShowInfo(plnum);
                #endregion
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void DtgPlannedOrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditRow();
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            #region oldCode
            //AccessToken objToken = DataProvider.GetTokenDictionary("dms_admin@unza.com", "Wuvl@1234", @"http://ssm.unza.com.vn:88/token");
            //string url = @"http://ssm.unza.com.vn:88/api/GET_PLANNED_ORDER?ZPLNUM=" + plnum;
            //string jsonString = DataProvider.GetRESTDats(url, objToken.accessToken.ToString());
            //List<Plannde> lstPlannedOrder = new List<Plannde>();
            //lstPlannedOrder = JsonConvert.DeserializeObject<List<Plannde>>(jsonString);
            //if (lstPlannedOrder.Count == 0)
            //{
            //    MessageBox.Show("K tồn tại Planned Order bạn muốn tìm!", "Thong bao!");
            //}
            //else
            //{
            //    PlanndeBusiness.AddPlannedOrder(lstPlannedOrder[0]);
            //    var lstPlannedOrderDetail = lstPlannedOrder[0].detail.ToList();
            //    foreach (Detail item in lstPlannedOrderDetail)
            //    {
            //        DetailBusiness.AddDetail(item);
            //    }

            //    LoadListPlannedOrder();
            //    frmDocumentDetail f = new frmDocumentDetail(plnum);
            //    this.Hide();
            //    f.ShowDialog();
            //    this.Show();
            //}
            #endregion

            string query = "select count(*) as soLuong from PlannedOrderDetail where plnum = " + txtPlanNumber.Text+" and status = 1";
            DataTable dt = DataProvider.GetList(query, null, false);
            string soLuong = dt.Rows[0]["soLuong"].ToString();

            string query1 = "select distinct count(matnr) as soLuong from PlannedOrderDetail where plnum =  "+txtPlanNumber.Text;
            DataTable dt1 = DataProvider.GetList(query1, null, false);
            string soLuongGoc = dt1.Rows[0]["soLuong"].ToString();

            if (MessageBox.Show("Số lượng hiện tại là "+soLuong+"/"+soLuongGoc+" \nBạn có chắc muốn gửi biểu mẫu này?","Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<Pnl> lstDetail = new List<Pnl>();
                foreach (DataGridViewRow row in dtgPlannedOrderDetail.Rows)
                {
                    Pnl pn = new Pnl();

                    pn.plnum = row.Cells["plnum"].Value.ToString();
                    pn.posnr = row.Cells["posnr"].Value.ToString();
                    pn.charg = row.Cells["charg"].Value.ToString();
                    pn.idnrk = row.Cells["matnr"].Value.ToString();
                    pn.menge = float.Parse(row.Cells["count"].Value.ToString());
                    pn.matnr = txtMaterial.Text;
                    lstDetail.Add(pn);
                }
                /*
                get data cua dtgPlannedOrderDetail ra ojb plannerorder*/
                string url = ConfigurationManager.AppSettings["put_planned_order"].ToString() + lblAccount.Text;
                AccessToken objToken = DataProvider.GetTokenDictionary("dms_admin@unza.com", "Wuvl@1234", ConfigurationManager.AppSettings["tokenUrl"].ToString());
                string jsonString = DataProvider.GetRESTDats3(url, objToken.accessToken.ToString(), lstDetail);
                if (jsonString == "\"ok\"")
                {
                    DetailBusiness.PUTDetail(int.Parse(txtPlanNumber.Text));
                    PlanndeBusiness.PUTPlannde(int.Parse(txtPlanNumber.Text));
                }
                //ShowInfo(int.Parse(txtPlanNumber.Text));
                this.Close();
                //load lại bảng planned Order
            }
            else
            {
                return;
            }
        }

        private void DtgPlannedOrderDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                EditRow();
            }

            if (e.KeyCode == Keys.Delete)
            {
                DeleteRow();
            }
        }
        #endregion

        private void BtnEditRow_Click(object sender, EventArgs e)
        {
            EditRow();
        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {

        }
        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Label7_Click(object sender, EventArgs e)
        {

        }
        private void Label8_Click(object sender, EventArgs e)
        {

        }
        private void TxtScanItem_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
