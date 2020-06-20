using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackAndTrace.Model;

namespace TrackAndTrace
{
    public partial class frmChooseDocument : Form
    {
        public frmChooseDocument(string username)
        {
            //this.AcceptButton = btnChooseDocument;
            InitializeComponent();
            LoadListPlannedOrder();
            WindowState = FormWindowState.Maximized;
            lblAccount.Text = username;
            dtgPlannedOrder.ReadOnly = true;

        }

        #region methods

        public void LoadListPlannedOrder()
        {
            dtgPlannedOrder.DataSource = PlanndeBusiness.GetListAvailblePlannedOrder();
            dtgPlannedOrder.Columns[0].HeaderText = "Planned Order Number";
            dtgPlannedOrder.Columns[1].HeaderText = "Mã sản phẩm";
            dtgPlannedOrder.Columns[2].HeaderText = "Số lượng";
            dtgPlannedOrder.Columns[3].HeaderText = "Plant";
            dtgPlannedOrder.Columns[4].HeaderText = "Kho";
            dtgPlannedOrder.Columns[5].HeaderText = "Tên sản phẩm";
            dtgPlannedOrder.Columns[6].HeaderText = "Ngày sửa đổi";
            dtgPlannedOrder.Columns[7].HeaderText = "Tài khoản";
            dtgPlannedOrder.Columns[8].HeaderText = "Trạng thái";
            //dtgPlannedOrder.Columns[8] = new DataGridViewCheckBoxColumn();
        }

        private void CheckPlan()
        {
            try
            {
                int plnum = int.Parse(txtDocument.Text);

                Plannde objPlan = PlanndeBusiness.GetPlannde(plnum);
                //Trường hợp nếu đã tồn tại plan này và đã post
                if (objPlan!=null && objPlan.status == true)
                {
                    string query = "update dbo.PlannedOrder set status = 0 where plnum =" + plnum;
                    DataProvider.Execute(query, null, false);
                    frmDocumentDetail f = new frmDocumentDetail(plnum, lblAccount.Text);
                    txtDocument.Clear();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    List<Plannde> lstPlan = PlanndeBusiness.GetListPlannedOrder();
                    int planCount = 0;

                    foreach (Plannde item in lstPlan)
                    {
                        if (item.plnum == plnum.ToString())
                        {
                            planCount++;
                        }
                    }

                    if (planCount == 1)
                    {
                        LoadListPlannedOrder();
                        frmDocumentDetail f = new frmDocumentDetail(plnum,lblAccount.Text);
                        txtDocument.Clear();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        AccessToken objToken = DataProvider.GetTokenDictionary("dms_admin@unza.com", "Wuvl@1234", ConfigurationManager.AppSettings["tokenUrl"].ToString());
                        string url = ConfigurationManager.AppSettings["get_planned_order"].ToString() + plnum;
                        string jsonString = DataProvider.GetRESTDats(url, objToken.accessToken.ToString());
                        List<Plannde> lstPlannedOrder = new List<Plannde>();
                        lstPlannedOrder = JsonConvert.DeserializeObject<List<Plannde>>(jsonString);
                        if (lstPlannedOrder.Count == 0)
                        {
                            txtDocument.BackColor = Color.OrangeRed;
                            MessageBox.Show("K tồn tại Planned Order bạn muốn tìm!", "Thong bao!");
                            txtDocument.Clear();
                            txtDocument.BackColor = Color.White;
                        }
                        else
                        {
                            PlanndeBusiness.AddPlannedOrder(lstPlannedOrder[0]);
                            var lstPlannedOrderDetail = lstPlannedOrder[0].detail.ToList();
                            foreach (Detail item in lstPlannedOrderDetail)
                            {
                                DetailBusiness.AddDetail(item, false);
                            }

                            LoadListPlannedOrder();
                            frmDocumentDetail f = new frmDocumentDetail(plnum,lblAccount.Text);
                            txtDocument.Clear();
                            this.Hide();
                            f.ShowDialog();
                            this.Show();
                        }
                    }
                }
            }
            catch (FormatException)
            {
                txtDocument.BackColor = Color.OrangeRed;
                MessageBox.Show("Bạn nhập sai mã plan number!", "Thông báo!");
                txtDocument.Clear();
                txtDocument.BackColor = Color.White;
            }

            LoadListPlannedOrder();
        }

        #endregion

        #region Events
        //xử lý nút OK
        private void BtnChooseDocument_Click(object sender, EventArgs e)
        {
            CheckPlan();
        }

        private void DtgPlannedOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string matnr = "";

            matnr = dtgPlannedOrder.CurrentRow.Cells[0].Value.ToString();

            txtDocument.Text = matnr;
        }

        private void FrmChooseDocument_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Ban co thuc su muon thoat chuong trinh?", "Thong bao!", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.No)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                frmChooseDocument f = new frmChooseDocument(lblAccount.Text);
                f.ShowDialog();
            }
        }

        private void DtgPlannedOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckPlan();
        }

        private void TxtDocument_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                CheckPlan();
            }
        }

        private void DtgPlannedOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                CheckPlan();
            }
        }
        private void TxtDocument_TextChanged(object sender, EventArgs e)
        {
        }

    }
}

#endregion
/*
     try
            {
                string strPlnum = (txtDocument.Text);

                PlannedOrder objPlannedOrder = PlannedOrderBusiness.GetPlannedOrderFromPlnum(int.Parse(strPlnum));

                if (String.IsNullOrEmpty(strPlnum))
                {
                    MessageBox.Show("Bạn chưa nhập Planned Order nào!", "Thông báo!");
                }
                else
                {
                    TestAccessToken tk = DataProvider.GetTokenDictionary("dms_admin@unza.com", "Wuvl@1234", @"http://ssm.unza.com.vn:88/token");
                    //Get 1 doi tuong tu api
                    string url = @"http://ssm.unza.com.vn:88/api/GET_PLANNED_ORDER?ZPLNUM="+strPlnum;

                    string jsonString = DataProvider.GetRESTDats(url, tk.AccessToken.ToString());

                    var lstPlannedOrder = JsonConvert.DeserializeObject<List<Plannde>>(jsonString);

                    if(lstPlannedOrder[0] == null)
                    {
                        MessageBox.Show("PlannedOrder do khong ton tai", "Thong bao");
                    }
                    else
                    {
                        PlannedOrderBusiness.AddPlannedOrder(lstPlannedOrder[0]);

                        var lstPlannedOrderDetail = lstPlannedOrder[0].detail.ToList();

                        foreach (Detail item in lstPlannedOrderDetail)
                        {
                            PlannedOrderDetailBusiness.AddPlannedOrderDetail(item);
                        }

                        LoadPlannedOrder();

                        frmDocumentDetail f = new frmDocumentDetail(int.Parse(strPlnum));

                        this.Hide();

                        f.ShowDialog();

                        this.Show();
                    }
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Planned Order mà bạn nhập không tồn tại!", "Thông báo!");
            }
     */
