using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class DetailBusiness
    {

        //Lay chi tiet list plannedorder Detail
        public static List<Detail> GetListDetailFromPlnum(int plnum)
        {
            String query = "select * from PlannedOrderDetail where plnum = " + plnum + " and status = 1 order by posnr";
            List<Detail> lst = new List<Detail>();
            DataTable dt = DataProvider.GetList(query, null, false);
            foreach (DataRow row in dt.Rows)
            {
                Detail objPlannedOrderDetail = new Detail(row);
                lst.Add(objPlannedOrderDetail);
            }
            return lst;
        }

        public static List<Detail> GetListDetailFromPlnum(int plnum, string matnr)
        {
            String query = "select * from PlannedOrderDetail where plnum = " + plnum + " and matnr = '" + matnr + "' order by posnr";
            List<Detail> lst = new List<Detail>();
            DataTable dt = DataProvider.GetList(query, null, false);
            foreach (DataRow row in dt.Rows)
            {
                Detail objPlannedOrderDetail = new Detail(row);
                lst.Add(objPlannedOrderDetail);
            }
            return lst;
        }

        public static List<Detail> GetListAllDetailFromPlnum(int plnum)
        {
            String query = "select * from PlannedOrderDetail where plnum = " + plnum + " order by posnr";
            List<Detail> lst = new List<Detail>();
            DataTable dt = DataProvider.GetList(query, null, false);
            foreach (DataRow row in dt.Rows)
            {
                Detail objPlannedOrderDetail = new Detail(row);
                lst.Add(objPlannedOrderDetail);
            }
            return lst;
        }

        public static Detail GetDetail(string matnr, int plnum, string lgpro, string charg)
        {
            String query = "select * from PlannedOrderDetail where plnum = " + plnum + " and matnr = '" + matnr + "' and lgpro = '" + lgpro + "' and charg = '" + charg + "';";
            Detail objPlannedOrderDetail = new Detail();
            DataTable dt = DataProvider.GetList(query, null, false);
            foreach (DataRow row in dt.Rows)
            {
                objPlannedOrderDetail = new Detail(row);
            }
            return objPlannedOrderDetail;
        }

        public static Detail GetDetail(int plnum, string matnr, int posnr)
        {
            string query = "select * from dbo.PlannedOrderDetail where plnum = " + plnum + " and matnr = '" + matnr + "' and posnr = " + posnr;
            DataTable dt = DataProvider.GetList(query, null, false);
            List<Detail> lstDetail = new List<Detail>();
            foreach (DataRow row in dt.Rows)
            {
                Detail objDetail = new Detail(row);
                lstDetail.Add(objDetail);
            }
            return lstDetail[0];
        }

        public static Detail GetDetail(string matnr, int plnum)
        {
            String query = "select * from PlannedOrderDetail where plnum = " + plnum + " and matnr = '" + matnr + "';";
            Detail objPlannedOrderDetail = new Detail();
            DataTable dt = DataProvider.GetList(query, null, false);
            foreach (DataRow row in dt.Rows)
            {
                objPlannedOrderDetail = new Detail(row);
            }
            return objPlannedOrderDetail;
        }
        public static string GetName(string matnr, int plnum)
        {
            String query = "select top 1 maktx from PlannedOrderDetail where plnum = " + plnum + " and matnr = '" + matnr + "';";
            //Detail objPlannedOrderDetail = new Detail();
            DataTable dt = DataProvider.GetList(query, null, false);
            //foreach (DataRow row in dt.Rows)
            //{
            //    objPlannedOrderDetail = new Detail(row);
            //}
            return dt.Rows[0]["maktx"].ToString();
        }

        public static void UpdateCountForDetail(int plnnum, double count, string matnr, string charg, string lgpro)
        {
            string query = "update dbo.PlannedOrderDetail set count =" + count + ", status = 1 where matnr = '" + matnr + "' and charg = '" + charg + "' and lgpro = '" + lgpro + "'";
            DataProvider.Execute(query, null, false);
        }

        //status = true tức là Detail này được tạo mới!
        public static void AddDetail(Detail obj, Boolean status = true)
        {
            SqlParameter[] pars = new SqlParameter[11];

            pars[0] = new SqlParameter("@plnum", SqlDbType.Int);
            pars[0].Value = obj.plnum;
            pars[1] = new SqlParameter("@matnr", SqlDbType.NVarChar, 10);
            pars[1].Value = obj.matnr;
            pars[2] = new SqlParameter("@maktx", SqlDbType.NVarChar, 100);
            pars[2].Value = obj.maktx;
            pars[3] = new SqlParameter("@erfmg", SqlDbType.Float);
            pars[3].Value = obj.erfmg;
            pars[4] = new SqlParameter("@count", SqlDbType.Float);
            pars[4].Value = obj.count;
            pars[5] = new SqlParameter("@erfme", SqlDbType.Char, 10);
            pars[5].Value = obj.erfme;
            pars[6] = new SqlParameter("@plwmk", SqlDbType.VarChar, 4);
            pars[6].Value = obj.plwrk;
            pars[7] = new SqlParameter("@lgpro", SqlDbType.VarChar, 4);
            pars[7].Value = obj.lgpro;
            pars[8] = new SqlParameter("@charg", SqlDbType.VarChar, 50);
            pars[8].Value = obj.charg;
            pars[9] = new SqlParameter("@posnr", SqlDbType.Int);
            pars[9].Value = obj.posnr;
            pars[10] = new SqlParameter("@status", SqlDbType.Bit);
            pars[10].Value = status;

            DataProvider.Execute("usp_AddPlannedOrderDetail", pars, true);
        }


        public static bool DeleteDetail(int plnum, string matnr, int posnr)
        {
            string query = "delete from PlannedOrderDetail where plnum = " + plnum + " and matnr = '" + matnr + "' and posnr = " + posnr;

            return DataProvider.Execute(query, null, false);
        }

        //public static List<Detail> GetListPlannedOrderDetailFromPlnum(int plnum)
        //{
        //    string query = "select * from PlannedOrderDetail where plnum = " + plnum;

        //    List<Detail> lstDetail = new List<Detail>();

        //    DataTable dt = DataProvider.GetList(query, null, false);

        //    foreach(DataRow row in dt.Rows)
        //    {
        //        Detail objDetail = new Detail(row);

        //        lstDetail.Add(objDetail);
        //    }
        //    return lstDetail;
        //}

        public static int GetMaxPosnrFromMatnr(int plnum)
        {
            List<Detail> lstDetail = DetailBusiness.GetListAllDetailFromPlnum(plnum);
            int maxPosnr = 0;
            if (lstDetail.Count == 0)
            {
                return 0;
            }
            else
            {
                maxPosnr = int.Parse(lstDetail.Select(s => s.posnr).Max().ToString());
            }

            //foreach(Detail item in lstDetail)
            //{
            //    if (int.Parse(item.posnr) > maxPosnr)
            //    {
            //        maxPosnr = int.Parse(item.posnr);
            //    }
            //}
            return maxPosnr;
        }

        /*public static List<String> GetListMatnr(int plnum)
          {
              List<String> lstMatnr = new List<string>();

              DataTable dt = DataProvider.GetList("select distinct matnr from dbo.PlannedOrderDetail where plnum = " + plnum, null, false);

              StringBuilder sb = new StringBuilder();

              foreach(DataRow row in dt.Rows)
              {
                  object[] arr = row.ItemArray;

                  for(int i=0;i<=arr.Length;i++)
                  {
                      sb.Append(Convert.ToString(arr[i]));
                      lstMatnr.Add(sb.ToString());
                  }
              }

              return lstMatnr;
          }*/

        public static bool UpdateDetail(int plnum, string matnr, double count, string lgpro, string charg, int posnr)
        {
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@plnum", SqlDbType.Int);
            pars[0].Value = plnum;
            pars[1] = new SqlParameter("@matnr", SqlDbType.NVarChar, 100);
            pars[1].Value = matnr;
            pars[2] = new SqlParameter("@count", SqlDbType.Float);
            pars[2].Value = count;
            pars[3] = new SqlParameter("@lgpro", SqlDbType.VarChar, 4);
            pars[3].Value = lgpro;
            pars[4] = new SqlParameter("@charg", SqlDbType.VarChar, 50);
            pars[4].Value = charg;
            pars[5] = new SqlParameter("@posnr", SqlDbType.Int);
            pars[5].Value = posnr;

            return DataProvider.Execute("usp_UpdatePlannedOrderDetail", pars, true);
        }

        public static void PUTDetail(int plnum)
        {
            string query = "update PlannedOrderDetail set status = 0 where plnum = " + plnum;

            DataProvider.Execute(query, null, false);
        }
    }
}
