using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class Detail
    {
        public string plnum { get; set; }
        public string matnr { get; set; }
        public string maktx { get; set; }
        public double erfmg { get; set; }
        public double count { get; set; }
        public string erfme { get; set; }
        public string plwrk { get; set; }
        public string lgpro { get; set; }
        public string charg { get; set; }
        public int posnr { get; set; }

        public DateTime dateCreated { get; set; }
        public DateTime dateEdited { get; set; }
        public Boolean status { get; set; }


        //public Boolean status { get; set; }

        public Detail(DataRow row)
        {
            plnum = row["plnum"].ToString();
            matnr = row["matnr"].ToString();
            maktx = row["maktx"].ToString();
            erfmg = double.Parse(row["erfmg"].ToString());
            count = double.Parse(row["count"].ToString());
            erfme = row["erfme"].ToString();
            plwrk = row["plwrk"].ToString();
            lgpro = row["lgpro"].ToString();
            charg = row["charg"].ToString();
            posnr = int.Parse(row["posnr"].ToString());
            dateCreated = DateTime.Parse(row["dateCreated"].ToString());
            dateEdited = DateTime.Parse(row["dateEdited"].ToString());
            status = Boolean.Parse(row["status"].ToString());
            //this.status = Boolean.Parse(row["status"].ToString());
        }

        public Detail() { }
    }
}
