using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class PlannedOrderDetailBusiness
    {
        public static List<PlannedOrderDetail> GetListPlannedOrderDetail()
        {
            List<PlannedOrderDetail> lst = new List<PlannedOrderDetail>();

            DataTable dt = DataProvider.GetList("usp_GetListPlannedOrderDetail", null, true);

            foreach (DataRow row in dt.Rows)
            {
                PlannedOrderDetail obj = new PlannedOrderDetail(row);

                lst.Add(obj);
            }

            return lst;
        }

        //Lay chi tiet 1 plannedorder Detail
        public static List<PlannedOrderDetail> GetPlannedOrderDetailFromPlnum(int plnum)
        {
            String query = "select * from PlannedOrderDetail where plnum = " + plnum;

            List<PlannedOrderDetail> lst = new List<PlannedOrderDetail>();

            DataTable dt = DataProvider.GetList(query, null, false);

            foreach(DataRow row in dt.Rows)
            {
                PlannedOrderDetail objPlannedOrderDetail = new PlannedOrderDetail(row);
                lst.Add( objPlannedOrderDetail);
            }

            return lst;
        }

        public static PlannedOrderDetail GetPlannedOrderDetailFromMatnr(string matnr)
        {
            String query = "select * from PlannedOrderDetail where matnr = '" + matnr + "'";

            PlannedOrderDetail objPlannedOrderDetail = new PlannedOrderDetail();

            DataTable dt = DataProvider.GetList(query, null, false);

            foreach (DataRow row in dt.Rows)
            {
                objPlannedOrderDetail = new PlannedOrderDetail(row);
            }

            return objPlannedOrderDetail;
        }

        public static void UpdateErfmgForPlannedOrderDetail(double count, string matnr, string charg)
        {
            string query = "update dbo.PlannedOrderDetail set erfmg = " + count + " where matnr = '" + matnr + "' and charg = '" + charg + "'";

            bool ketQua = DataProvider.Execute(query, null, false);
            
            if(ketQua)
            {
                return;
            }
        }

        public static void AddPlannedOrderDetail(PlannedOrderDetail obj)
        {
            SqlParameter[] pars = new SqlParameter[9];

            pars[0] = new SqlParameter("@plnum", SqlDbType.Int);
            pars[0].Value = obj.Plnum;
            pars[1] = new SqlParameter("@matnr", SqlDbType.NVarChar,10);
            pars[1].Value = obj.Matnr;
            pars[2] = new SqlParameter("@maktx", SqlDbType.NVarChar,100);
            pars[2].Value = obj.Maktx;
            pars[3] = new SqlParameter("@erfmg", SqlDbType.Float);
            pars[3].Value = obj.Erfmg;
            pars[4] = new SqlParameter("@erfme", SqlDbType.Char,10);
            pars[4].Value = obj.Erfme;
            pars[5] = new SqlParameter("@plwmk", SqlDbType.VarChar,4);
            pars[5].Value = obj.Plwrk;
            pars[6] = new SqlParameter("@lgpro", SqlDbType.VarChar,4);
            pars[6].Value = obj.Lgpro;
            pars[7] = new SqlParameter("@charg", SqlDbType.VarChar,50);
            pars[7].Value = obj.Charg;
            pars[8] = new SqlParameter("@posnr", SqlDbType.Int);
            pars[8].Value = obj.Posnr;

            DataProvider.Execute("usp_AddPlannedOrderDetail", pars, true);
        }
    }
}
