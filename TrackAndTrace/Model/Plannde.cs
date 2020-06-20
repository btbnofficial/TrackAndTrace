using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class Plannde
    {
        public string plnum { get; set; }
        public string matnr { get; set; }
        public float gsmng { get; set; }
        public string plwrk { get; set; }
        public string lgort { get; set; }
        public string maktx { get; set; }
        public Detail[] detail { get; set; }

        public DateTime dateEdited { get; set; }
        public string username { get; set; }
        public Boolean status { get; set; }

        public Plannde(DataRow row)
        {
            this.plnum = row["plnum"].ToString();
            this.matnr = row["matnr"].ToString();
            this.gsmng = float.Parse(row["gsmng"].ToString());
            this.plwrk = row["plwrk"].ToString();
            this.lgort = row["lgort"].ToString();
            this.maktx = row["maktx"].ToString();
            this.dateEdited = DateTime.Parse(row["dateEdited"].ToString());
            this.username = row["username"].ToString();
            this.status = Boolean.Parse(row["status"].ToString());
        }
        public Plannde() { }
    }
}
