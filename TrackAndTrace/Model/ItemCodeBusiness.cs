using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class ItemCodeBusiness
    {
        public static List<Itemcode> GetITemList(string matnr)
        {
            List<Itemcode> lstBatch = new List<Itemcode>();
            AccessToken objToken = DataProvider.GetTokenDictionary("dms_admin@unza.com", "Wuvl@1234", ConfigurationManager.AppSettings["tokenUrl"].ToString());
            string url = ConfigurationManager.AppSettings["check_item"].ToString() + matnr;
            string jsonString = DataProvider.GetRESTDats2(url, objToken.accessToken.ToString());
            lstBatch = JsonConvert.DeserializeObject<List<Itemcode>>(jsonString);
            return lstBatch;
        }
    }
}
