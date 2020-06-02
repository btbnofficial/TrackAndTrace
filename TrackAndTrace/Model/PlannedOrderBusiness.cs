using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class PlannedOrderBusiness
    {
        public static List<PlannedOrder> GetListPlannedOrder()
        {
            List<PlannedOrder> lst = new List<PlannedOrder>();

            DataTable dt = DataProvider.GetList("usp_GetListPlannedOrder", null, true);

            foreach(DataRow row in dt.Rows)
            {
                PlannedOrder objPlannedOrder = new PlannedOrder(row);

                lst.Add(objPlannedOrder);
            }

            return lst;
        }

        public static PlannedOrder GetPlannedOrderFromPlnum(int plnum)
        {
            PlannedOrder objPlannedOrder = new PlannedOrder();

            DataTable dt = DataProvider.GetList("select * from PlannedOrder where plnum = "+plnum, null, false);

            foreach (DataRow row in dt.Rows)
            {
                objPlannedOrder = new PlannedOrder(row);
            }

            return objPlannedOrder;
        }
    }
}
