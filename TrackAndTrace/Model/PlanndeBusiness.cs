using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class PlanndeBusiness
    {
        public static List<Plannde> GetListPlannedOrder()
        {
            List<Plannde> lst = new List<Plannde>();

            DataTable dt = DataProvider.GetList("select * from PlannedOrder where status = 0", null, false);

            foreach(DataRow row in dt.Rows)
            {
                Plannde objPlannedOrder = new Plannde(row);

                lst.Add(objPlannedOrder);
            }

            return lst;
        }

        public static List<Plannde> GetListAvailblePlannedOrder()
        {
            List<Plannde> lst = new List<Plannde>();

            DataTable dt = DataProvider.GetList("select * from PlannedOrder where status = 0", null, false);

            foreach (DataRow row in dt.Rows)
            {
                Plannde objPlannedOrder = new Plannde(row);

                lst.Add(objPlannedOrder);
            }

            return lst;
        }


        public static Plannde GetPlannde(int plnum)
        {
            Plannde objPlannedOrder = null;

            DataTable dt = DataProvider.GetList("select * from PlannedOrder where  plnum = "+plnum, null, false);

            foreach (DataRow row in dt.Rows)
            {
                objPlannedOrder = new Plannde(row);
            }
            return objPlannedOrder;
        }


        public static List<Plannde> GetPlannedOrderListFromApi()
        {
            List<Plannde> lstPlannedOrder = new List<Plannde>();



            return lstPlannedOrder;
        }

        public static void AddPlannedOrder(Plannde objPlannedOrder)
        {
            SqlParameter[] pars = new SqlParameter[6];

            pars[0] = new SqlParameter("@plnum", SqlDbType.Int);
            pars[0].Value = objPlannedOrder.plnum;

            pars[1] = new SqlParameter("@matnr", SqlDbType.VarChar, 10);
            pars[1].Value = objPlannedOrder.matnr;

            pars[2] = new SqlParameter("@gsmng", SqlDbType.Float);
            pars[2].Value = objPlannedOrder.gsmng   ;

            pars[3] = new SqlParameter("@plwrk", SqlDbType.NVarChar, 50);
            pars[3].Value = objPlannedOrder.plwrk;

            pars[4] = new SqlParameter("@lgort", SqlDbType.NVarChar, 4);
            pars[4].Value = objPlannedOrder.lgort;

            pars[5] = new SqlParameter("@maktx", SqlDbType.NVarChar, 100);
            pars[5].Value = objPlannedOrder.maktx;

            DataProvider.Execute("usp_AddPlannedOrder", pars, true);
        }

        public static void UpdatePlannedOrder(Plannde obj)
        {
            SqlParameter[] pars = new SqlParameter[6];

            pars[0] = new SqlParameter("@plnum", SqlDbType.Int);
            pars[0].Value = obj.plnum;

            pars[1] = new SqlParameter("@matnr", SqlDbType.VarChar,10);
            pars[1].Value = obj.matnr   ;

            pars[2] = new SqlParameter("@gsmng", SqlDbType.Float);
            pars[2].Value = obj.gsmng;

            pars[3] = new SqlParameter("@plwrk", SqlDbType.NVarChar,50);
            pars[3].Value = obj.plwrk;

            pars[4] = new SqlParameter("@lgort", SqlDbType.NVarChar,4);
            pars[4].Value = obj.lgort;

            pars[5] = new SqlParameter("@maktx", SqlDbType.NVarChar,100);
            pars[5].Value = obj.maktx;

            DataProvider.Execute("usp_UpdatePlannedOrder", pars, true);
        }

        public static void PUTPlannde(int plnum)
        {
            string query = "update PlannedOrder set status = 1 where plnum = " + plnum;

            DataProvider.Execute(query, null, false);
        }
    }
}
