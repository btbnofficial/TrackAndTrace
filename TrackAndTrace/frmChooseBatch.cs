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
        public frmChooseBatch(string matnr, string lgort, int loai, int plnum, string lg)
        {
            if (loai == 0) //0 tương ứng với item đã có trong plannedOrder
            {
                //Detail obj = DetailBusiness.GetDetail(matnr, plnum);
                string maktx = DetailBusiness.GetName(matnr, plnum);
                InitializeComponent();
                ShowBatchListToCombobox(plnum.ToString(), matnr);
                ShowPlannedOrderDetailFromMatnr(matnr, maktx);
            }
            else//loai = 1 item chưa có trong plan, thêm mới
            {
                List<Itemcode> lstItem = ItemCodeBusiness.GetITemList(matnr);
                InitializeComponent();
                ShowBatchListToCombobox(plnum.ToString(), matnr);
                ShowPlannedOrderDetailFromMatnr(matnr, lstItem[0].maktx);
            }

            this.AcceptButton = btnChooseBatch;
            this.CancelButton = btnCancel;

            //Hiển thị các thông tin cần thiết
            lblPlnum.Text = plnum.ToString();
            lblLoai.Text = loai.ToString();
            txtlg.Text = lg;
            nmItemCount.DecimalPlaces = 3;
            nmItemCount.Increment = 0.001M;
            nmItemCount.Value = decimal.Parse((DetailBusiness.GetDetail(matnr,plnum)).erfmg.ToString());
            //List<String> lstErfme = new List<String>();
            //lstErfme.Add("KG");
            //lstErfme.Add("Meter");
            //lstErfme.Add("");
            //cboErfme.DataSource = lstErfme;
            //cboErfme.DropDownStyle = ComboBoxStyle.DropDownList;
            txtErfme.Text = (DetailBusiness.GetDetail(matnr, plnum)).erfme.ToString();

            List<String> lstLgpro = new List<String>();
            lstLgpro.Add("BULK");
            lstLgpro.Add("FGWH");
            lstLgpro.Add("RMSA");
            cboLgpro.DataSource = lstLgpro;
            //cboLgpro.DropDownStyle = ComboBoxStyle.DropDownList;
            Detail objDetail = DetailBusiness.GetDetail(matnr, plnum);
            foreach (string item in lstLgpro)
            {
                if (item == objDetail.lgpro)
                {
                    cboLgpro.SelectedItem = item;
                }
            }
        }

        public void ShowBatchListToCombobox(string plnum, string matnr)
        {
            cboChooseBatch.DataSource = BatchBusiness.GetBatchList2(plnum, matnr);
            //cboChooseBatch.DisplayMember = "charg";
            //cboChooseBatch.DropDownStyle = ComboBoxStyle.DropDownList; //Cấm người dùng nhập tay vào :v
        }

        public void ShowPlannedOrderDetailFromMatnr(string matnr, string maktx)
        {
            txtMatnr.Text = matnr;
            txtMaktx.Text = maktx;
        }

        private void BtnChooseBatch_Click(object sender, EventArgs e)
        {
            //Neu da ton tai plannedOrderDetail + Batch do thi + them
            //Neu chua co batch do cho plannedOrderDetail do thi add 1 dong moi
            string matnr = txtMatnr.Text;
            List<Itemcode> lstItem = ItemCodeBusiness.GetITemList(matnr);
            string maktx = lstItem[0].maktx;
            int loai = int.Parse(lblLoai.Text);
            int plnum = int.Parse(lblPlnum.Text);
            double count = (double)nmItemCount.Value;
            string charg = "";
            string erfme = txtErfme.Text;

            List<string> lstBatch = BatchBusiness.GetBatchList2(plnum.ToString(), matnr);
            if (lstBatch.Count == 0)
            {
                if (!String.IsNullOrEmpty(cboChooseBatch.Text))
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
                if (String.IsNullOrEmpty(cboChooseBatch.Text))
                {
                    charg = "";
                }
                else
                {
                    int i = 0;
                    foreach (string item in lstBatch)
                    {
                        if (item == cboChooseBatch.Text)
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
                        charg = cboChooseBatch.Text;
                    }
                }
            }
            //Xử lý trường hợp nếu item không có batch ( ví dụ 1 số sản phẩm như chai lọ)
            //string lgort = (PlanndeBusiness.GetPlannedOrderFromPlnum(plnum)).lgort;
            string lgort = txtlg.Text;
            string lgpro = cboLgpro.SelectedItem.ToString();
            int posnr = DetailBusiness.GetMaxPosnrFromMatnr(plnum);
            //Truong hop da ton tai matnr do trong list Detail
            //Them moi neu k trung batch, update neu trung batch
            //Kiểm tra xem batch đó có trong danh sách batch tương ứng với 

            if (count == 0)
            {
                MessageBox.Show("So luong khong duoc bang 0!", "Thong bao!");
            }

            else
            {
                if (loai == 0)
                {
                    Detail objDetail = DetailBusiness.GetDetail(matnr, plnum, lgpro, charg);
                    List<Detail> lstDetail = DetailBusiness.GetListDetailFromPlnum(plnum);
                    #region code thừa
                    //int i = 0;
                    //foreach (Detail item in lstDetail)
                    //{
                    //    if (item.charg == charg && item.matnr == matnr)
                    //    {
                    //        i++;
                    //    }
                    //}
                    #endregion
                    if (objDetail.charg == charg && objDetail.lgpro == lgpro)
                    {
                        //Neu da co thi update them erfmg
                        DetailBusiness.UpdateCountForDetail(plnum, objDetail.count + count, matnr, charg, lgpro);
                    }
                    else
                    {
                        //if (cboErfme.SelectedItem == null)
                        //{
                        //    erfme = "";
                        //}
                        //Neu chua co thi add them
                        objDetail.plnum = plnum.ToString();
                        objDetail.matnr = matnr;
                        objDetail.maktx = maktx;
                        objDetail.charg = charg;
                        objDetail.erfmg = objDetail.erfmg;
                        objDetail.plwrk = PlanndeBusiness.GetPlannde(plnum).plwrk;
                        objDetail.posnr = (posnr + 10);
                        objDetail.erfme = erfme;
                        objDetail.lgpro = lgpro;
                        objDetail.count = count;
                        DetailBusiness.AddDetail(objDetail);
                    }
                }
                //Them moi 1 Detail
                else
                {
                    //if (cboErfme.SelectedItem == null)
                    //{
                    //    erfme = "";
                    //}
                    //else
                    //{
                        Detail objDetail = new Detail();
                        objDetail.plnum = plnum.ToString();
                        objDetail.matnr = matnr;
                        objDetail.maktx = maktx;
                        objDetail.erfmg = 0;
                        objDetail.plwrk = PlanndeBusiness.GetPlannde(plnum).plwrk;
                        objDetail.lgpro = lgort;
                        objDetail.charg = charg;
                        objDetail.posnr = (posnr + 10);
                        objDetail.erfme = erfme;
                        objDetail.count = count;
                        DetailBusiness.AddDetail(objDetail);
                    //}
                }
            }
            this.Close();
            #region code cũ
            /*
            string matnr = txtMatnr.Text;
            Detail objDetail = DetailBusiness.GetPlannedOrderDetailFromMatnr(matnr);
            List<Detail> lstPlannedOrderDetail = DetailBusiness.GetListPlannedOrderDetail(int.Parse(objDetail.plnum));
            string charg = (cboChooseBatch.SelectedItem as Batch).charg;
            Detail obj = DetailBusiness.GetPlannedOrderDetailFromMatnr(matnr);
            float plannedOrderDetailCount = float.Parse(nmItemCount.Value.ToString());
            int count = 0;
            foreach (Detail item in lstPlannedOrderDetail)
            {
                if (item.matnr == matnr && item.charg == charg)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                DetailBusiness.UpdateErfmgForPlannedOrderDetail(plannedOrderDetailCount + obj.erfmg, matnr, charg);
            }
            else
            {
                obj.erfmg = plannedOrderDetailCount;
                obj.charg = charg;
                obj.posnr = (DetailBusiness.GetMaxPosnrFromMatnr(matnr) + 10).ToString();
                DetailBusiness.AddPlannedOrderDetail(obj);
            }
             */

            #endregion
        }

        private void FrmChooseBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Chay ngon lanh
        private void BtnChooseBatch_Click(object sender, EventArgs e)
        {
            //Neu da ton tai plannedOrderDetail + Batch do thi + them
            //Neu chua co batch do cho plannedOrderDetail do thi add 1 dong moi
            string matnr = txtMatnr.Text;
            List<Itemcode> lstItem = ItemCodeBusiness.GetITemList(matnr);
            string maktx = lstItem[0].maktx;
            int loai = int.Parse(lblLoai.Text);
            int plnum = int.Parse(lblPlnum.Text);
            float count = (float)nmItemCount.Value;
            string charg = "";
            string erfme = cboErfme.SelectedItem.ToString();

            List<Batch> lstBatch = BatchBusiness.GetBatchList2(plnum.ToString(), matnr);
            if (lstBatch.Count == 0)
            {
                if (!String.IsNullOrEmpty(cboChooseBatch.Text))
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
                if (String.IsNullOrEmpty(cboChooseBatch.Text))
                {
                    MessageBox.Show("Không tồn tại batch tương ứng với Planned Order Detail này!", "Thông báo!");
                    return;
                }
                else
                {
                    int i = 0;
                    foreach (Batch obj in lstBatch)
                    {
                        if (obj.charg == cboChooseBatch.Text)
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
                        charg = cboChooseBatch.Text;
                    }
               
                }
            }
            //Xử lý trường hợp nếu item không có batch ( ví dụ 1 số sản phẩm như chai lọ)
            //string lgort = (PlanndeBusiness.GetPlannedOrderFromPlnum(plnum)).lgort;
            string lgort = txtlg.Text;
            string lgpro = cboLgpro.SelectedItem.ToString();
            int posnr = DetailBusiness.GetMaxPosnrFromMatnr(plnum);
            //Truong hop da ton tai matnr do trong list Detail
            //Them moi neu k trung batch, update neu trung batch
            //Kiểm tra xem batch đó có trong danh sách batch tương ứng với 

            if (count == 0)
            {
                MessageBox.Show("So luong khong duoc bang 0!", "Thong bao!");
            }

            else
            {
                if (loai == 0)
                {
                    Detail objDetail = DetailBusiness.GetDetail(matnr, plnum, lgpro, charg);
                    List<Detail> lstDetail = DetailBusiness.GetListDetailFromPlnum(plnum);
                    #region code thừa
                    //int i = 0;
                    //foreach (Detail item in lstDetail)
                    //{
                    //    if (item.charg == charg && item.matnr == matnr)
                    //    {
                    //        i++;
                    //    }
                    //}
                    #endregion
                    if (objDetail.charg == charg && objDetail.lgpro == lgpro)
                    {
                        //Neu da co thi update them erfmg
                        DetailBusiness.UpdateCountForDetail(plnum, objDetail.count + count, matnr, charg, lgpro);
                    }
                    else
                    {
                        if (cboErfme.SelectedItem == null)
                        {
                            erfme = "";
                        }
                        //Neu chua co thi add them
                        objDetail.plnum = plnum.ToString();
                        objDetail.matnr = matnr;
                        objDetail.maktx = maktx;
                        objDetail.charg = charg;
                        objDetail.erfmg = objDetail.erfmg;
                        objDetail.plwrk = PlanndeBusiness.GetPlannde(plnum).plwrk;
                        objDetail.posnr = (posnr + 10);
                        objDetail.erfme = erfme;
                        objDetail.lgpro = lgpro;
                        objDetail.count = count;
                        DetailBusiness.AddDetail(objDetail);
                    }
                }
                //Them moi 1 Detail
                else
                {
                    if (cboErfme.SelectedItem == null)
                    {
                        erfme = "";
                    }
                    else
                    {
                        Detail objDetail = new Detail();
                        objDetail.plnum = plnum.ToString();
                        objDetail.matnr = matnr;
                        objDetail.maktx = maktx;
                        objDetail.erfmg = 0;
                        objDetail.plwrk = PlanndeBusiness.GetPlannde(plnum).plwrk;
                        objDetail.lgpro = lgort;
                        objDetail.charg = charg;
                        objDetail.posnr = (posnr + 10);
                        objDetail.erfme = erfme;
                        objDetail.count = count;
                        DetailBusiness.AddDetail(objDetail);
                    }
                }
            }
            this.Close();
            #region code cũ
            /*
            string matnr = txtMatnr.Text;
            Detail objDetail = DetailBusiness.GetPlannedOrderDetailFromMatnr(matnr);
            List<Detail> lstPlannedOrderDetail = DetailBusiness.GetListPlannedOrderDetail(int.Parse(objDetail.plnum));
            string charg = (cboChooseBatch.SelectedItem as Batch).charg;
            Detail obj = DetailBusiness.GetPlannedOrderDetailFromMatnr(matnr);
            float plannedOrderDetailCount = float.Parse(nmItemCount.Value.ToString());
            int count = 0;
            foreach (Detail item in lstPlannedOrderDetail)
            {
                if (item.matnr == matnr && item.charg == charg)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                DetailBusiness.UpdateErfmgForPlannedOrderDetail(plannedOrderDetailCount + obj.erfmg, matnr, charg);
            }
            else
            {
                obj.erfmg = plannedOrderDetailCount;
                obj.charg = charg;
                obj.posnr = (DetailBusiness.GetMaxPosnrFromMatnr(matnr) + 10).ToString();
                DetailBusiness.AddPlannedOrderDetail(obj);
            }
             */
    }
}
