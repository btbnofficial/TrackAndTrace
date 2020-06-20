using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class BatchBusiness
    {
        public static List<Batch> GetBatchList(string matnr, string lgort, string charg)
        {
            List<Batch> lstBatch = new List<Batch>();
            AccessToken objToken = DataProvider.GetTokenDictionary("dms_admin@unza.com", "Wuvl@1234", ConfigurationManager.AppSettings["tokenUrl"].ToString());
            string url = ConfigurationManager.AppSettings["check_batch"].ToString() + matnr + "&LGORT=" + lgort + "&CHARG=" + charg;
            string jsonString = DataProvider.GetRESTDats2(url, objToken.accessToken.ToString());
            lstBatch = JsonConvert.DeserializeObject<List<Batch>>(jsonString);
            return lstBatch;
        }

        public static List<string> GetBatchList2(string plnum, string matnr)
        {
            List<string> lstBatch = new List<string>();

            string query = "select distinct charg from PlannedOrderDetail where plnum = "+plnum+" and matnr = '"+matnr+"'";

            DataTable dt = DataProvider.GetList(query, null, false);
            foreach(DataRow row in dt.Rows)
            {
                string charg = "";
                if(row.IsNull(0))
                {
                    charg = "";
                }
                charg += row["charg"].ToString();
                lstBatch.Add(charg);
            }
            return lstBatch;
        }
    }
}
